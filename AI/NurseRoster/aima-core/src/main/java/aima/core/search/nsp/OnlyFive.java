package aima.core.search.nsp;

import java.util.ArrayList;
import java.util.List;

/**
 * Represents a binary constraint which forbids equal values.
 * 
 * @author Ruediger Lunde
 */
public class OnlyFive implements Constraint {
	
	private Variable[] vars;
//	private Variable var1;
//	private Variable var2;
//	private Variable var3;
//	private Variable var4;
//	private Variable var5;
//	private Variable var6;
//	private Variable var7;
	private List<Variable> scope;
	public int daysOff;

	public OnlyFive(Variable[] vars) {
		this.vars = vars;
//		this.var2 = var2;
//		this.var3 = var3;
//		this.var4 = var4;
//		this.var5 = var5;
//		this.var6 = var6;
//		this.var7 = var7;
		scope = new ArrayList<Variable>(vars.length);
		for(Variable var : vars){
			scope.add(var);
		}
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
		Object[] values = new Object[vars.length];
		for (int i = 0; i < vars.length; i++){
			Object value1 = assignment.getAssignment(vars[i]);
			values[i] = value1;
		}
		
		daysOff = 0;
//		System.out.print(var1 +" ");
//		System.out.print(var2 +" ");
//		System.out.print(var3 +" ");
//		System.out.print(var4 +" ");
//		System.out.println(var5);
		for(int o = 0; o < values.length; o++){
			if(values[o] == null){
				return true;
			}
		}
		for (Object value : values){
			if(value.equals("OFF")){
				daysOff++;
			}
		}
		if(daysOff < 2){
			return false;
		}
		
		return true;
	}
}
