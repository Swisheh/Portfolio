package aima.core.environment.knightspath;

import aima.core.agent.impl.DynamicAction;
import aima.core.util.datastructure.XYLocation;

/**
 * Bishops can be placed, removed, and moved. For movements, a vertical direction
 * is assumed. Therefore, only the end point needs to be specified.
 * 
 * @author Ravi Mohan
 * @author R. Lunde
 */
public class BishopAction extends DynamicAction {
	public static final String PLACE_BISHOP = "placeBishopAt";
	public static final String REMOVE_BISHOP = "removeBishopAt";
	public static final String MOVE_BISHOP = "moveBishopTo";

	public static final String ATTRIBUTE_BISHOP_LOC = "location";

	/**
	 * Creates a bishop action. Supported values of type are {@link #PLACE_BISHOP}
	 * , {@link #REMOVE_BISHOP}, or {@link #MOVE_BISHOP}.
	 */
	public BishopAction(String type, XYLocation loc) {
		super(type);
		setAttribute(ATTRIBUTE_BISHOP_LOC, loc);
	}

	public XYLocation getLocation() {
		return (XYLocation) getAttribute(ATTRIBUTE_BISHOP_LOC);
	}

	public int getX() {
		return getLocation().getXCoOrdinate();
	}

	public int getY() {
		return getLocation().getYCoOrdinate();
	}
}
