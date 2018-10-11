package aima.core.search.nsp;

/**
 * A variable is a distinguishable object with a name.
 * 
 * @author Ruediger Lunde
 */
public class Variable {
	private String nurse;
	private int day;
	private String string;

	public Variable(String nurse, int day) {
		this.nurse = nurse;
		this.day = day;
		this.string = nurse + day;
	}

	public String getName() {
		return nurse;
	}
	
	public int getDay(){
		return day;
	}

	public String toString() {
		return nurse;
	}

	@Override
	public boolean equals(Object obj) {
		if (obj instanceof Variable) {
			return this.nurse.equals(((Variable) obj).nurse);
		}
		return super.equals(obj);
	}

	@Override
	public int hashCode() {
		return string.hashCode();
	}
}
