package aima.gui.applications.search.games;

import java.awt.Color;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Properties;

import javax.swing.JButton;

import aima.core.agent.Action;
import aima.core.agent.Agent;
import aima.core.agent.Environment;
import aima.core.agent.EnvironmentState;
import aima.core.agent.Percept;
import aima.core.agent.impl.AbstractEnvironment;
import aima.core.environment.knightspath.ManhattanDistanceHeuristic;
import aima.core.environment.knightspath.BishopAction;
import aima.core.environment.knightspath.KnightspathBoard;
import aima.core.environment.knightspath.KnightspathFunctionFactory;
import aima.core.environment.knightspath.KnightspathGoalTest;
import aima.core.environment.knightspath.KnightAction;
import aima.core.environment.knightspath.QueenAction;
import aima.core.environment.knightspath.RookAction;
import aima.core.search.framework.ActionsFunction;
import aima.core.search.framework.GraphSearch;
import aima.core.search.framework.Problem;
import aima.core.search.framework.Search;
import aima.core.search.framework.SearchAgent;
import aima.core.search.framework.TreeSearch;
import aima.core.search.informed.AStarSearch;
import aima.core.search.local.HillClimbingSearch;
import aima.core.search.local.Scheduler;
import aima.core.search.local.SimulatedAnnealingSearch;
import aima.core.search.uninformed.BreadthFirstSearch;
import aima.core.search.uninformed.DepthFirstSearch;
import aima.core.search.uninformed.DepthLimitedSearch;
import aima.core.search.uninformed.IterativeDeepeningSearch;
import aima.core.util.datastructure.XYLocation;
import aima.gui.framework.AgentAppController;
import aima.gui.framework.AgentAppEnvironmentView;
import aima.gui.framework.AgentAppFrame;
import aima.gui.framework.MessageLogger;
import aima.gui.framework.SimpleAgentApp;
import aima.gui.framework.SimulationThread;

/**
 * Knights Path App
 * 
 * @author Rory Hiscock
 */
public class KnightsPathApp extends SimpleAgentApp {

	/** List of supported search algorithm names. */
	protected static List<String> SEARCH_NAMES = new ArrayList<String>();
	/** List of supported search algorithms. */
	protected static List<Search> SEARCH_ALGOS = new ArrayList<Search>();

	/** Adds a new item to the list of supported search algorithms. */
	public static void addSearchAlgorithm(String name, Search algo) {
		SEARCH_NAMES.add(name);
		SEARCH_ALGOS.add(algo);
	}

	// Removed all unnecessary search algorithms and added the Manhattan Distance heuristic
	static {
		addSearchAlgorithm("A* search (Manhattan Distance Heuristic)",
				new AStarSearch(new GraphSearch(),
						new ManhattanDistanceHeuristic()));
	}

	/** Returns a <code>knightspathView</code> instance. */
	public AgentAppEnvironmentView createEnvironmentView() {
		return new knightspathView();
	}

	/** Returns a <code>knightspathFrame</code> instance. */
	@Override
	public AgentAppFrame createFrame() {
		return new knightspathFrame();
	}

	/** Returns a <code>knightspathController</code> instance. */
	@Override
	public AgentAppController createController() {
		return new knightspathController();
	}

	// ///////////////////////////////////////////////////////////////
	// main method

	/**
	 * Starts the application.
	 */
	public static void main(String args[]) {
		new KnightsPathApp().startApplication();
	}

	// ///////////////////////////////////////////////////////////////
	// some inner classes

	/**
	 * Adds some selectors to the base class and adjusts its size.
	 */
	protected static class knightspathFrame extends AgentAppFrame {
		private static final long serialVersionUID = 1L;
		public static String ENV_SEL = "EnvSelection";
		public static String PROBLEM_SEL = "ProblemSelection";
		public static String SEARCH_SEL = "SearchSelection";
		
		// Changed the EnvSelection drop down box to include the necessary board dimensions
		// Changed the ProblemSelection drop down box to include the different opposing pieces
		public knightspathFrame() {
			setTitle("Knights Path Application");
			setSelectors(new String[] { ENV_SEL, PROBLEM_SEL, SEARCH_SEL },
					new String[] { "Select Environment",
							"Select Problem Formulation", "Select Search" });
			setSelectorItems(ENV_SEL, new String[] { "4", "6", "8",
					"10", "12" }, 1);
			setSelectorItems(PROBLEM_SEL, new String[] { "Bishop", "Rook",
					"Queen" }, 0);
			setSelectorItems(SEARCH_SEL, (String[]) SEARCH_NAMES
					.toArray(new String[] {}), 0);
			setEnvView(new knightspathView());
			setSize(800, 600);
		}
	}

	/**
	 * Displays the informations provided by a <code>knightspathEnvironment</code>
	 * on a panel.
	 */
	protected static class knightspathView extends AgentAppEnvironmentView
			implements ActionListener {
		private static final long serialVersionUID = 1L;
		protected JButton[] squareButtons;
		protected int currSize = -1;

		protected knightspathView() {
		}

		@Override
		public void setEnvironment(Environment env) {
			super.setEnvironment(env);
			showState();
		}

		/** Agent value null indicates a user initiated action. */
		@Override
		public void agentActed(Agent agent, Action action,
				EnvironmentState resultingState) {
			showState();
			notify((agent == null ? "User: " : "") + action.toString());
		}

		@Override
		public void agentAdded(Agent agent, EnvironmentState resultingState) {
			showState();
		}

		/**
		 * Displays the board state by labeling and coloring the square buttons.
		 */
		protected void showState() {
			KnightspathBoard board = ((knightspathEnvironment) env).getBoard();
			if (currSize != board.getSize()) {
				currSize = board.getSize();
				removeAll();
				setLayout(new GridLayout(currSize, currSize));
				squareButtons = new JButton[currSize * currSize];
				for (int i = 0; i < currSize * currSize; i++) {
					JButton square = new JButton("");
					square.setMargin(new Insets(0, 0, 0, 0));
					square
							.setBackground((i % currSize) % 2 == (i / currSize) % 2 ? Color.WHITE
									: Color.LIGHT_GRAY);
					square.addActionListener(this);
					squareButtons[i] = square;
					add(square);
				}
			}
			for (int i = 0; i < currSize * currSize; i++)
				squareButtons[i].setText("");
			Font f = new java.awt.Font(Font.SANS_SERIF, Font.PLAIN, Math.min(
					getWidth(), getHeight())
					* 3 / 4 / currSize);
			
			// Puts in only the positions for the knights with the letter 'K'
			for (XYLocation loc : board.getKnightPositions()) {
				JButton square = squareButtons[loc.getXCoOrdinate()
						+ loc.getYCoOrdinate() * currSize];
				square.setForeground(board.isSquareUnderAttack2(loc) ? Color.RED
						: Color.BLACK);
				square.setFont(f);
				square.setText("K");
			}
			// Puts in only the positions for the Bishops with the letter 'B'
			if (board.isBishop()){
				for (XYLocation loc : board.getBishopPositions()) {
					JButton square = squareButtons[loc.getXCoOrdinate()
							+ loc.getYCoOrdinate() * currSize];
					square.setForeground(board.isSquareUnderAttack(loc) ? Color.RED
							: Color.BLACK);
					square.setFont(f);
					square.setText("B");
				}
				// Puts in only the positions for the Rooks with the letter 'R'
			} else if (board.isRook()){
				for (XYLocation loc : board.getRookPositions()) {
					JButton square = squareButtons[loc.getXCoOrdinate()
							+ loc.getYCoOrdinate() * currSize];
					square.setForeground(board.isSquareUnderAttack(loc) ? Color.RED
							: Color.BLACK);
					square.setFont(f);
					square.setText("R");
				}
				// Puts in only the positions for the Queens with the letter 'Q'
			} else if (board.isQueen()){
				for (XYLocation loc : board.getQueenPositions()) {
					JButton square = squareButtons[loc.getXCoOrdinate()
							+ loc.getYCoOrdinate() * currSize];
					square.setForeground(board.isSquareUnderAttack(loc) ? Color.RED
							: Color.BLACK);
					square.setFont(f);
					square.setText("Q");
				}
			}
			validate();
		}

		/**
		 * When the user presses square buttons the board state is modified
		 * accordingly.
		 */
		@Override
		public void actionPerformed(ActionEvent ae) {
			for (int i = 0; i < currSize * currSize; i++) {
				if (ae.getSource() == squareButtons[i]) {
					knightspathController contr = (knightspathController) getController();
					XYLocation loc = new XYLocation(i % currSize, i / currSize);
					contr.modifySquare(loc);
				}
			}
		}
	}

	/**
	 * Defines how to react on standard simulation button events.
	 */
	protected static class knightspathController extends AgentAppController {

		protected knightspathEnvironment env = null;
		protected SearchAgent agent = null;
		protected boolean boardDirty;
		// added an int to tell which piece was being moved (used in the left click to move)
		int piece = 0;

		/** Prepares next simulation. */
		@Override
		public void clear() {
			prepare(null);
		}

		/**
		 * Creates a knights path environment and clears the current search agent.
		 */
		@Override
		public void prepare(String changedSelector) {
			AgentAppFrame.SelectionState selState = frame.getSelection();
			KnightspathBoard board = null;
			switch (selState.getValue(knightspathFrame.ENV_SEL)) {
			// Changed all of the board dimensions here
			case 0: // 4 x 4 board
				board = new KnightspathBoard(4);
				break;
			case 1: // 6 x 6 board
				board = new KnightspathBoard(6);
				break;
			case 2: // 8 x 8 board
				board = new KnightspathBoard(8);
				break;
			case 3: // 10 x 10 board
				board = new KnightspathBoard(10);
				break;
			case 4: // 12 x 12 board
				board = new KnightspathBoard(12);
				break;
			}
			env = new knightspathEnvironment(board);
			//Adds the different pieces depending on the problem selection
			board.addKnightAt(new XYLocation(0, 0));
			if (selState.getValue(knightspathFrame.PROBLEM_SEL) == 0)
				board.addBishopAt(new XYLocation((board.getSize() -1), (board.getSize() -1)));
			if (selState.getValue(knightspathFrame.PROBLEM_SEL) == 1)
				board.addRookAt(new XYLocation((board.getSize() -1), (board.getSize() -1)));
			if (selState.getValue(knightspathFrame.PROBLEM_SEL) == 2)
				board.addQueenAt(new XYLocation((board.getSize() -1), (board.getSize() -1)));
			boardDirty = false;
			agent = null;
			frame.getEnvView().setEnvironment(env);
		}

		/**
		 * Creates a new search agent and adds it to the current environment if
		 * necessary.
		 */
		protected void addAgent() throws Exception {
			if (agent != null && agent.isDone()) {
				env.removeAgent(agent);
				agent = null;
			}
			if (agent == null) {
				int sSel = frame.getSelection().getValue(
						knightspathFrame.SEARCH_SEL);
				// removed the old CActionsFunction part because we only need one
				ActionsFunction	af = KnightspathFunctionFactory.getIActionsFunction();
				Problem problem = new Problem(env.getBoard(), af,
						KnightspathFunctionFactory.getResultFunction(),
						new KnightspathGoalTest());
				Search search = SEARCH_ALGOS.get(sSel);
				agent = new SearchAgent(problem, search);
				env.addAgent(agent);
			}
		}

		/** Checks whether simulation can be started. */
		@Override
		public boolean isPrepared() {
			int problemSel = frame.getSelection().getValue(
					knightspathFrame.PROBLEM_SEL);
			return problemSel == 1
					|| (agent == null || !agent.isDone());
			// removed the extra parts here 
		}

		/** Starts simulation. */
		@Override
		public void run(MessageLogger logger) {
			logger.log("<simulation-log>");
			try {
				addAgent();
				while (!agent.isDone() && !frame.simulationPaused()) {
					Thread.sleep(500);
					env.step();
				}
			} catch (InterruptedException e) {
				// nothing to do...
			} catch (Exception e) {
				e.printStackTrace(); // probably search has failed...
			}
			logger.log(getStatistics());
			logger.log("</simulation-log>\n");
		}

		/** Executes one simulation step. */
		@Override
		public void step(MessageLogger logger) {
			try {
				addAgent();
				env.step();
			} catch (Exception e) {
				e.printStackTrace(); // probably search has failed...
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

		/** Provides a text with statistical information about the last run. */
		private String getStatistics() {
			StringBuffer result = new StringBuffer();
			Properties properties = agent.getInstrumentation();
			Iterator<Object> keys = properties.keySet().iterator();
			while (keys.hasNext()) {
				String key = (String) keys.next();
				String property = properties.getProperty(key);
				result.append("\n" + key + " : " + property);
			}
			return result.toString();
		}

		public void modifySquare(XYLocation loc) {
			boardDirty = true;
			AgentAppFrame.SelectionState selState = frame.getSelection();
			// this code uses the global 'piece' int from early to determine which action to send through
			if (piece == 0){
				piece = 1; 
				String atype = KnightAction.MOVE_KNIGHT;
				env.executeAction(null, new KnightAction(atype, loc));
			} else if ((selState.getValue(knightspathFrame.PROBLEM_SEL) == 0) && (piece == 1)){
				piece = 0;
				String atype = BishopAction.MOVE_BISHOP;
				env.executeAction(null, new BishopAction(atype, loc));
			} else if ((selState.getValue(knightspathFrame.PROBLEM_SEL) == 1) && (piece == 1)){
				piece = 0;
				String atype = RookAction.MOVE_ROOK;
				env.executeAction(null, new RookAction(atype, loc));
			} else if ((selState.getValue(knightspathFrame.PROBLEM_SEL) == 2) && (piece == 1)){
				piece = 0;
				String atype = QueenAction.MOVE_QUEEN;
				env.executeAction(null, new QueenAction(atype, loc));
			}
				
			
			agent = null;
			frame.updateEnabledState();
		}
	}

	/** Simple environment maintaining just the current board state. */
	public static class knightspathEnvironment extends AbstractEnvironment {
		KnightspathBoard board;

		public knightspathEnvironment(KnightspathBoard board) {
			this.board = board;
		}

		public KnightspathBoard getBoard() {
			return board;
		}

		/**
		 * Executes the provided action and returns null.
		 */
		@Override
		public EnvironmentState executeAction(Agent agent, Action action) {
			if (action instanceof KnightAction) {
				KnightAction act = (KnightAction) action;
				XYLocation loc = new XYLocation(act.getX(), act.getY());
				// Depending on which action is sent through this code will move different pieces.
				if (act.getName() == KnightAction.PLACE_KNIGHT)
					board.addKnightAt(loc);
				else if (act.getName() == KnightAction.REMOVE_KNIGHT)
					board.removeKnightFrom(loc);
				else if (act.getName() == KnightAction.MOVE_KNIGHT)
					board.moveKnightTo(loc);
				if (agent == null)
					updateEnvironmentViewsAgentActed(agent, action, null);
			}
			if (action instanceof BishopAction) {
				BishopAction act = (BishopAction) action;
				XYLocation loc = new XYLocation(act.getX(), act.getY());
				if (act.getName() == BishopAction.MOVE_BISHOP)
					board.moveBishopTo(loc);
				if (agent == null)
					updateEnvironmentViewsAgentActed(agent, action, null);
			}
			if (action instanceof RookAction) {
				RookAction act = (RookAction) action;
				XYLocation loc = new XYLocation(act.getX(), act.getY());
				if (act.getName() == RookAction.MOVE_ROOK)
					board.moveRookTo(loc);
				if (agent == null)
					updateEnvironmentViewsAgentActed(agent, action, null);
			}
			if (action instanceof QueenAction) {
				QueenAction act = (QueenAction) action;
				XYLocation loc = new XYLocation(act.getX(), act.getY());
				if (act.getName() == QueenAction.MOVE_QUEEN)
					board.moveQueenTo(loc);
				if (agent == null)
					updateEnvironmentViewsAgentActed(agent, action, null);
			}
			return null;
		}

		/** Returns null. */
		@Override
		public EnvironmentState getCurrentState() {
			return null;
		}

		/** Returns null. */
		@Override
		public Percept getPerceptSeenBy(Agent anAgent) {
			return null;
		}
	}
}
