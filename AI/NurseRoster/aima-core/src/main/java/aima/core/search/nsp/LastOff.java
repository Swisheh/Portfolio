package aima.core.search.nsp;

import java.util.ArrayList;
import java.util.List;

/**
 * Represents a binary constraint which forbids equal values.
 * 
 * @author Ruediger Lunde
 */
public class LastOff implements Constraint {

	private Variable var1;
	private Variable var2;
	private Variable var3;
	private Variable var4;
	private Variable var5;
	private List<Variable> scope;

	public LastOff(Variable var1, Variable var2, Variable var3, Variable var4, Variable var5) {
		this.var1 = var1;
		this.var2 = var2;
		this.var3 = var3;
		this.var4 = var4;
		this.var5 = var5;
		scope = new ArrayList<Variable>(5);
		scope.add(var1);
//		scope.add(var2);
//		scope.add(var3);
//		scope.add(var4);
//		scope.add(var5);
	}

	@Override
	public List<Variable> getScope() {
		return scope;
	}

	@Override
	public boolean isSatisfiedWith(Assignment assignment) {
		Object value1 = assignment.getAssignment(var1);
		Object value2 = assignment.getAssignment(var2);
		Object value3 = assignment.getAssignment(var3);
		Object value4 = assignment.getAssignment(var4);
		Object value5 = assignment.getAssignment(var5);
//		System.out.print(var1 +" ");
//		System.out.print(var2 +" ");
//		System.out.print(var3 +" ");
//		System.out.print(var4 +" ");
//		System.out.println(var5);
		if(value1 == null){
			return true;
		}
		if(value1.equals("DAY") || value1.equals("NIGHT")){
			if(value2.equals(value1) && value3.equals(value1) && value4.equals(value1) && value5.equals(value1)){
				return false;	
			}
		}
		
		return true;
	}
}
