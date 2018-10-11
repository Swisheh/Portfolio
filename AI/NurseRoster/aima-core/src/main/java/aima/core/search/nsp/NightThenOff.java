package aima.core.search.nsp;

import java.util.ArrayList;
import java.util.List;

/**
 * Represents a binary constraint which forbids equal values.
 * 
 * @author Ruediger Lunde
 */
public class NightThenOff implements Constraint {

	private Variable var1;
	private Variable var2;
	private List<Variable> scope;

	public NightThenOff(Variable var1, Variable var2) {
		this.var1 = var1;
		this.var2 = var2;
		scope = new ArrayList<Variable>(2);
		scope.add(var1);
		scope.add(var2);
	}

	@Override
	public List<Variable> getScope() {
		return scope;
	}

	@Override
	public boolean isSatisfiedWith(Assignment assignment) {
		Object value1 = assignment.getAssignment(var1);
		Object value2 = assignment.getAssignment(var2);
//		System.out.print(value1 +" ");
//		System.out.println(value2);
		if(value1 == null || value2 == null){
			return true;
		}
		if(value1.equals("NIGHT") && value2.equals("DAY")){
			return false;
		}
		return true;
	}
}
