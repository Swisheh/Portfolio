package aima.core.search.nsp;

import java.util.ArrayList;
import java.util.List;

/**
 * Represents a binary constraint which forbids equal values.
 * 
 * @author Ruediger Lunde
 */
public class MinShifts implements Constraint {

	private Variable[] vars;
//	private Variable var1;
//	private Variable var2;
//	private Variable var3;
//	private Variable var4;
//	private Variable var5;
//	private Variable var6;
//	private Variable var7;
//	private Variable var8;
//	private Variable var9;
//	private Variable var10;
//	private Variable var11;
//	private Variable var12;
	public int dayShifts;
	public int nightShifts;
	public int offShifts;
	private List<Variable> scope;

	public MinShifts(Variable[] vars) {
		this.vars = vars;
//		this.var2 = var2;
//		this.var3 = var3;
//		this.var4 = var4;
//		this.var5 = var5;
//		this.var6 = var6;
//		this.var7 = var7;
//		this.var8 = var8;
//		this.var9 = var9;
//		this.var10 = var10;
//		this.var11 = var11;
//		this.var12 = var12;
		
		scope = new ArrayList<Variable>(vars.length);
		for(Variable var : vars){
			if(var != null){
				scope.add(var);
			}
		}
	
	}

	@Override
	public List<Variable> getScope() {
		return scope;
	}

	@Override
	public boolean isSatisfiedWith(Assignment assignment) {
		
		Object[] values = new Object[vars.length];
		for (int i = 0; i < vars.length; i++){
			if(vars[i] != null){
				Object value1 = assignment.getAssignment(vars[i]);
				values[i] = value1;
			}
		}
		dayShifts = 0;
		nightShifts = 0;
		offShifts = 0;
		
//		Object value1 = assignment.getAssignment(var1);
//		Object value2 = assignment.getAssignment(var2);
//		Object value3 = assignment.getAssignment(var3);
//		Object value4 = assignment.getAssignment(var4);
//		Object value5 = assignment.getAssignment(var5);
//		Object value6 = assignment.getAssignment(var6);
//		Object value7 = assignment.getAssignment(var7);
//		Object value8 = assignment.getAssignment(var8);
//		Object value9 = assignment.getAssignment(var9);
//		Object value10 = assignment.getAssignment(var10);
//		Object value11 = assignment.getAssignment(var11);
//		Object value12 = assignment.getAssignment(var12);
		//Object[] values = {value1,value2,value3,value4,value5,value6,value7,value8,value9,value10,value11,value12};
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
			if(value.equals("DAY")){
				dayShifts++;
			}
			if(value.equals("NIGHT")){
				nightShifts++;
			}
			if(value.equals("OFF")){
				offShifts++;
			}
		}
		if(dayShifts >= 6 || nightShifts >= 3){
			return false;
		}
		
//		if(offShifts < 3){
//			return false;
//		}
//		if(nightShifts > 2){
//			return false;
//		}
		//System.out.print(dayShifts + " " + nightShifts);
		//System.out.println();
		return true;
	}
}
