package aima.core.environment.knightspath;

import aima.core.agent.impl.DynamicAction;
import aima.core.util.datastructure.XYLocation;

/**
 * Knights can be placed, removed, and moved. For movements, a vertical direction
 * is assumed. Therefore, only the end point needs to be specified.
 * 
 * @author Ravi Mohan
 * @author R. Lunde
 */
public class KnightAction extends DynamicAction {
	public static final String PLACE_KNIGHT = "placeKnightAt";
	public static final String REMOVE_KNIGHT = "removeKnightAt";
	public static final String MOVE_KNIGHT = "moveKnightTo";

	public static final String ATTRIBUTE_KNIGHT_LOC = "location";

	/**
	 * Creates a knight action. Supported values of type are {@link #PLACE_KNIGHT}
	 * , {@link #REMOVE_KNIGHT}, or {@link #MOVE_KNIGHT}.
	 */
	public KnightAction(String type, XYLocation loc) {
		super(type);
		setAttribute(ATTRIBUTE_KNIGHT_LOC, loc);
	}

	public XYLocation getLocation() {
		return (XYLocation) getAttribute(ATTRIBUTE_KNIGHT_LOC);
	}

	public int getX() {
		return getLocation().getXCoOrdinate();
	}

	public int getY() {
		return getLocation().getYCoOrdinate();
	}
}
