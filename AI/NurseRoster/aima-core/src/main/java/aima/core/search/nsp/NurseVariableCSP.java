package aima.core.search.nsp;

import java.util.ArrayList;
import java.util.List;

/**
 * Artificial Intelligence A Modern Approach (3rd Ed.): Figure 6.1, Page 204.<br>
 * <br>
 * The principal states and territories of Australia. Coloring this map can be
 * viewed as a constraint satisfaction problem (CSP). The goal is to assign
 * colors to each region so that no neighboring regions have the same color.
 * 
 * @author Ruediger Lunde
 * @author Mike Stampone
 */
public class NurseVariableCSP extends CSP {
//	public static final Variable VAR;
//	public static final Variable NT = new Variable("NT");
//	public static final Variable Q = new Variable("Q");
//	public static final Variable SA = new Variable("SA");
//	public static final Variable T = new Variable("T");
//	public static final Variable V = new Variable("V");
//	public static final Variable WA = new Variable("WA");
	public static final String DAY = "DAY";
	public static final String NIGHT = "NIGHT";
	public static final String OFF = "OFF";
	public static List<Variable> variables;

	/**
	 * Returns the principle states and territories of Australia as a list of
	 * variables.
	 * 
	 * @return the principle states and territories of Australia as a list of
	 *         variables.
	 */
	private static List<Variable> collectVariables() {
		variables = new ArrayList<Variable>();
		for (int i = 0; i < 12; i++){
			for (int j = 0; j < 7; j++){
				Variable var = new Variable (i+"",j);
				variables.add(var);
			}
		}
		return variables;
	}

	/**
	 * Constructs a map CSP for the principal states and territories of
	 * Australia, with the colors Red, Green, and Blue.
	 */
	public NurseVariableCSP() {
		super(collectVariables());

		Domain shifts = new Domain(new Object[] { DAY, NIGHT, OFF });
		//System.out.println(variables);

		for (Variable var : getVariables()){
			setDomain(var, shifts);
		}
		
		for (int i = 0; i < variables.size(); i++){
			
			if(Integer.parseInt(variables.get(i).getName()) >= 0){
				
				Variable[] vars = new Variable[Integer.parseInt(variables.get(i).getName())];
				for (int j = 0; j < vars.length; j++){	
					vars[j] = variables.get(i - (j*7));
					//System.out.println(Integer.parseInt(variables.get(i - (j*7)).getName()));
				}
				//System.out.println();
				addConstraint(new MinShifts(vars));
			}
//			if(Integer.parseInt(variables.get(i).getName()) >= 0){
//				
//				Variable[] vars = new Variable[12];
//				int index = 0;
//				for (int j = 0; j < variables.size(); j++){
//					if(variables.get(j).getName().equals(variables.get(i).getName())){
//						vars[index] = variables.get(j);
//						index++;
//						//System.out.println(variables.get(j).getName());
//					}
//				}
//				//System.out.println();
//				addConstraint(new MinShifts(vars));
//			}
			
//			if(variables.get(i).getDay() >= 5){
//				addConstraint(new LastOff(variables.get(i), variables.get(i-1), variables.get(i-2)
//						, variables.get(i-3), variables.get(i-4)));
//			}
			if(i < variables.size()-1){
				addConstraint(new NightThenOff(variables.get(i), variables.get(i+1)));
			}
			if(variables.get(i).getDay() == 6){
				Variable[] vars = new Variable[variables.get(i).getDay()];
				for (int j = 0; j < variables.get(i).getDay(); j++){	
					vars[j] = variables.get(i - (j));
					//System.out.println(variables.get(i).getDay());
				}
				addConstraint(new OnlyFive(vars));
			}
			
			
			
		}
		
//		addConstraint(new NotEqualConstraint(WA, SA));
//		addConstraint(new NotEqualConstraint(NT, SA));
//		addConstraint(new NotEqualConstraint(NT, Q));
//		addConstraint(new NotEqualConstraint(SA, Q));
//		addConstraint(new NotEqualConstraint(SA, NSW));
//		addConstraint(new NotEqualConstraint(SA, V));
//		addConstraint(new NotEqualConstraint(Q, NSW));
//		addConstraint(new NotEqualConstraint(NSW, V));
	}
}