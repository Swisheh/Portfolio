package aima.gui.applications.search.nsp;

import java.awt.Color;

import javax.swing.JFrame;
import javax.swing.JScrollPane;
import javax.swing.JTable;

import aima.core.search.nsp.Assignment;
import aima.core.search.nsp.BacktrackingStrategy;
import aima.core.search.nsp.CSP;
import aima.core.search.nsp.CSPStateListener;
//import aima.core.search.nsp.Domain;
import aima.core.search.nsp.ImprovedBacktrackingStrategy;
import aima.core.search.nsp.MinConflictsStrategy;
import aima.core.search.nsp.NurseVariableCSP;
import aima.core.search.nsp.SolutionStrategy;
import aima.core.search.nsp.Variable;
import aima.core.util.datastructure.FIFOQueue;
import aima.gui.applications.search.nsp.CSPEnvironment;
import aima.gui.applications.search.nsp.CSPView;
import aima.gui.applications.search.nsp.NurseRosterApp;
//import aima.gui.applications.search.nsp.NurseRosterApp.MapColoringController;
//import aima.gui.applications.search.nsp.NurseRosterApp.MapColoringFrame;
import aima.gui.framework.AgentAppController;
import aima.gui.framework.AgentAppEnvironmentView;
import aima.gui.framework.AgentAppFrame;
import aima.gui.framework.MessageLogger;
import aima.gui.framework.SimpleAgentApp;
import aima.gui.framework.SimulationThread;

/**
 * Application which demonstrates basic constraint algorithms based on map
 * coloring problems. It shows the constraint graph, lets the user select a
 * solution strategy, and allows then to follow the progress step by step. For
 * pragmatic reasons, the implementation uses the agent framework, even though
 * there is no agent and only a dummy environment.
 * 
 * @author Ruediger Lunde
 */
public class NurseRosterApp extends SimpleAgentApp {

	public static Assignment finalAssignment;
	/** Returns an <code>CSPView</code> instance. */
	@Override
	public AgentAppEnvironmentView createEnvironmentView() {
		return new CSPView();
	}

	/** Returns a <code>MapColoringFrame</code> instance. */
	@Override
	public AgentAppFrame createFrame() {
		return new MapColoringFrame();
	}

	/** Returns a <code>MapColoringController</code> instance. */
	@Override
	public AgentAppController createController() {
		return new MapColoringController();
	}

	
	// ///////////////////////////////////////////////////////////////
	// main method

	/**
	 * Starts the application.
	 */
	public static void main(String args[]) {
		new NurseRosterApp().startApplication();
	}

	
	// ///////////////////////////////////////////////////////////////
	// some inner classes

	/**
	 * Adds some selectors to the base class and adjusts its size.
	 */
	protected static class MapColoringFrame extends AgentAppFrame {
		private static final long serialVersionUID = 1L;
		public static String ENV_SEL = "EnvSelection";
		public static String STRATEGY_SEL = "SearchSelection";
		public static String NURSE_SEL = "NurseSelection";
		
		

		public MapColoringFrame() {
			setTitle("Nurse Roster");
			setSelectors(new String[] { ENV_SEL, STRATEGY_SEL, NURSE_SEL }, new String[] {
					"Select Days", "Select Solution Strategy", "Number of Nurses" });
			setSelectorItems(ENV_SEL, new String[] { "7 Days","14 Days",}, 0);
			setSelectorItems(STRATEGY_SEL, new String[] { "Backtracking",
					"Backtracking + MRV & DEG",
					"Backtracking + Forward Checking",
					"Backtracking + Forward Checking + MRV",
					"Backtracking + Forward Checking + LCV",
					"Backtracking + AC3",
					"Backtracking + AC3 + MRV & DEG + LCV",
					"Min-Conflicts (50)" }, 0);
			setSelectorItems(NURSE_SEL, new String[] { "Nurse Option 1", "Nurse Option 2" }, 0);
			setEnvView(new CSPView());
			
			// Moved table to its own method at the bottom.
		        
			setSize(800, 600);
		}
	}
	
	

	/**
	 * Defines how to react on standard simulation button events.
	 */
	protected static class MapColoringController extends AgentAppController {

		protected CSPEnvironment env;
		protected SolutionStrategy strategy;
		protected FIFOQueue<CSPEnvironment.StateChangeAction> actions;
		protected int actionCount;

		protected MapColoringController() {
			env = new CSPEnvironment();
			actions = new FIFOQueue<CSPEnvironment.StateChangeAction>();
		}

		protected CSPView getCSPView() {
			return (CSPView) frame.getEnvView();
		}

		/** Prepares next simulation. */
		@Override
		public void clear() {
			prepare(null);
		}

		/**
		 * Creates a CSP and updates the environment as well as its view.
		 */
		@Override
		public void prepare(String changedSelector) {
			AgentAppFrame.SelectionState selState = frame.getSelection();
			CSP csp = null;
			CSPView view = getCSPView();
			switch (selState.getValue(MapColoringFrame.ENV_SEL)) {
			case 0:
				csp = new NurseVariableCSP();
				break;
			case 1: // three moves
				csp = new NurseVariableCSP();
				//csp.setDomain(NurseVariableCSP.NSW, new Domain(new Object[]{NurseVariableCSP.OFF}));
				break;
			case 2: // three moves
				csp = new NurseVariableCSP();
				//csp.setDomain(NurseVariableCSP.WA, new Domain(new Object[]{NurseVariableCSP.NIGHT}));
				break;
			}
			view.clearMappings();
			
			actions.clear();
			actionCount = 0;
			env.init(csp);
			view.setEnvironment(env);
		}

		/** Checks whether simulation can be started. */
		@Override
		public boolean isPrepared() {
			return env.getCSP() != null
					&& (!actions.isEmpty() || env.getAssignment() == null);
		}

		/** Starts simulation. */
		@Override
		public void run(MessageLogger logger) {
			logger.log("<simulation-log>");
			prepareActions();
			try {
				while (!actions.isEmpty() && !frame.simulationPaused()) {
					env.executeAction(null, actions.pop());
					actionCount++;
					Thread.sleep(0);
				}
				setUpTable(finalAssignment);
				logger.log("Number of Steps: " + actionCount);
				// logger.log(getStatistics());
			} catch (InterruptedException e) {
				// nothing to do here.
			}
			logger.log("</simulation-log>\n");
		}

		/** Performs a simulation step. */
		@Override
		public void step(MessageLogger logger) {
			prepareActions();
			if (!actions.isEmpty()) {
				env.executeAction(null, actions.pop());
				actionCount++;
				if (actions.isEmpty())
					logger.log("Number of Steps: " + actionCount);
			}
		}

		/**
		 * Starts the selected constraint solver and fills the action list if
		 * necessary.
		 */
		protected void prepareActions() {
			ImprovedBacktrackingStrategy iStrategy = null;
			if (actions.isEmpty()) {
				SolutionStrategy strategy = null;
				switch (frame.getSelection().getValue(
						MapColoringFrame.STRATEGY_SEL)) {
				case 0:
					strategy = new BacktrackingStrategy();
					break;
				case 1: // MRV + DEG
					strategy = new ImprovedBacktrackingStrategy
					(true, true, false, false);
					break;
				case 2: // FC
					iStrategy = new ImprovedBacktrackingStrategy();
					iStrategy.setInference(ImprovedBacktrackingStrategy
									.Inference.FORWARD_CHECKING);
					break;
				case 3: // MRV + FC 
					iStrategy = new ImprovedBacktrackingStrategy
					(true, false, false, false);
					iStrategy.setInference(ImprovedBacktrackingStrategy
									.Inference.FORWARD_CHECKING);
					break;
				case 4: // FC + LCV
					iStrategy = new ImprovedBacktrackingStrategy
					(false, false, false, true);
					iStrategy.setInference(ImprovedBacktrackingStrategy
									.Inference.FORWARD_CHECKING);
					break;
				case 5: // AC3
					strategy = new ImprovedBacktrackingStrategy
					(false, false, true, false);
					break;
				case 6: // MRV + DEG + AC3 + LCV
					strategy = new ImprovedBacktrackingStrategy
					(true, true, true, true);
					break;
				case 7:
					strategy = new MinConflictsStrategy(50);
					break;
				}
				if (iStrategy != null)
					strategy = iStrategy;
				
				try {
					strategy.addCSPStateListener(new CSPStateListener() {
						@Override
						public void stateChanged(Assignment assignment, CSP csp) {
							actions.add(new CSPEnvironment.StateChangeAction(
									assignment, csp));	
							updateAssignment(assignment);
						}
						@Override
						public void stateChanged(CSP csp) {
							actions.add(new CSPEnvironment.StateChangeAction(
									csp));
						}
					});
					strategy.solve(env.getCSP().copyDomains());
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		}

		/** Updates the status of the frame after simulation has finished. */
		public void update(SimulationThread simulationThread) {
			if (simulationThread.isCanceled()) {
				frame.setStatus("Task canceled.");
			} else if (frame.simulationPaused()) {
				frame.setStatus("Task paused.");
			} else {
				frame.setStatus("Task completed.");
			}
		}
		
		public void updateAssignment(Assignment assignment){
			finalAssignment = assignment;
		}
		
		public void setUpTable(Assignment assignment){
	///////////////////
			 JFrame guiFrame = new JFrame();
		        
		        //make sure the program exits when the frame closes
		        //guiFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		        guiFrame.setTitle("Table");
		        guiFrame.setSize(900,400);
		      
		        //This will center the JFrame in the middle of the screen
		        guiFrame.setLocationRelativeTo(null);
		        
		        //Create the JTable using the ExampleTableModel implementing 
		        //the AbstractTableModel abstract class
		        JTable table = new JTable(12,12);
		        
		        //Set the column sorting functionality on
		        table.setAutoCreateRowSorter(true);
		        
		        //Change the colour of the table
		        table.setGridColor(Color.BLACK);
		        table.setBackground(Color.WHITE);
		        
		        	int i = 0;
		        	int j = 0;
		        	//System.out.println(assignment);
		        	for (Variable var : assignment.getVariables()){
		        		if(i < 12){
		        			if(j < 7){
		        				if(assignment.getAssignment(var) != null){
		        					table.setValueAt(assignment.getAssignment(var), i, j+5);	
		        				}else{
		        					table.setValueAt("null", i, j+5);
		        				}
		        				j++;
		        			}
		        		if(j == 7){
		        			j = 0;
		        			i++;	
		        		}
		        	}
		        		
							//System.out.println(assignment.getAssignment(var));
		        		
		        	
				}
		       if (MapColoringFrame.ENV_SEL == "7 Days"){
			        table.getColumnModel().getColumn(0).setHeaderValue("Shift Pattern");
			        table.getColumnModel().getColumn(1).setHeaderValue("Grade");
			        table.getColumnModel().getColumn(2).setHeaderValue("Num Shifts");
			        table.getColumnModel().getColumn(3).setHeaderValue("Last Off");
			        table.getColumnModel().getColumn(4).setHeaderValue("Last Shift");
			        table.getColumnModel().getColumn(5).setHeaderValue("Mon");
			        table.getColumnModel().getColumn(6).setHeaderValue("Tue");
			        table.getColumnModel().getColumn(7).setHeaderValue("Wed");
			        table.getColumnModel().getColumn(8).setHeaderValue("Thu");
			        table.getColumnModel().getColumn(9).setHeaderValue("Fri");
			        table.getColumnModel().getColumn(10).setHeaderValue("Sat");
			        table.getColumnModel().getColumn(11).setHeaderValue("Sun");
		       } else {
		    	   	table.getColumnModel().getColumn(0).setHeaderValue("Shift Pattern");
			        table.getColumnModel().getColumn(1).setHeaderValue("Grade");
			        table.getColumnModel().getColumn(2).setHeaderValue("Num Shifts");
			        table.getColumnModel().getColumn(3).setHeaderValue("Last Off");
			        table.getColumnModel().getColumn(4).setHeaderValue("Last Shift");
			        table.getColumnModel().getColumn(5).setHeaderValue("Mon");
			        table.getColumnModel().getColumn(6).setHeaderValue("Tue");
			        table.getColumnModel().getColumn(7).setHeaderValue("Wed");
			        table.getColumnModel().getColumn(8).setHeaderValue("Thu");
			        table.getColumnModel().getColumn(9).setHeaderValue("Fri");
			        table.getColumnModel().getColumn(10).setHeaderValue("Sat");
			        table.getColumnModel().getColumn(11).setHeaderValue("Sun");
			        table.getColumnModel().getColumn(5).setHeaderValue("Mon");
			        table.getColumnModel().getColumn(6).setHeaderValue("Tue");
			        table.getColumnModel().getColumn(7).setHeaderValue("Wed");
			        table.getColumnModel().getColumn(8).setHeaderValue("Thu");
			        table.getColumnModel().getColumn(9).setHeaderValue("Fri");
			        table.getColumnModel().getColumn(10).setHeaderValue("Sat");
			        table.getColumnModel().getColumn(11).setHeaderValue("Sun");
		       }
		        //Place the JTable object in a JScrollPane for a scrolling table
		        JScrollPane tableScrollPane = new JScrollPane(table);
		        
		        guiFrame.add(tableScrollPane);
		        guiFrame.setVisible(true);
			///////////////////
		}
	}
}
