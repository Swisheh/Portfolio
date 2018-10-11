package aima.core.environment.knightspath;

import aima.core.agent.impl.DynamicAction;
import aima.core.util.datastructure.XYLocation;

/**
 * Rooks can be placed, removed, and moved. For movements, a vertical direction
 * is assumed. Therefore, only the end point needs to be specified.
 * 
 * @author Ravi Mohan
 * @author R. Lunde
 */
public class RookAction extends DynamicAction {
	public static final String PLACE_ROOK = "placeRookAt";
	public static final String REMOVE_ROOK = "removeRookAt";
	public static final String MOVE_ROOK = "moveRookTo";

	public static final String ATTRIBUTE_ROOK_LOC = "location";

	/**
	 * Creates a rook action. Supported values of type are {@link #PLACE_ROOK}
	 * , {@link #REMOVE_ROOK}, or {@link #MOVE_ROOK}.
	 */
	public RookAction(String type, XYLocation loc) {
		super(type);
		setAttribute(ATTRIBUTE_ROOK_LOC, loc);
	}

	public XYLocation getLocation() {
		return (XYLocation) getAttribute(ATTRIBUTE_ROOK_LOC);
	}

	public int getX() {
		return getLocation().getXCoOrdinate();
	}

	public int getY() {
		return getLocation().getYCoOrdinate();
	}
}
