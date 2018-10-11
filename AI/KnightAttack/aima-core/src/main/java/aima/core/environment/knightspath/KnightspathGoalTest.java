package aima.core.environment.knightspath;

import aima.core.search.framework.GoalTest;

/**
 * @author R. Lunde
 */
public class KnightspathGoalTest implements GoalTest {

	public boolean isGoalState(Object state) {
		KnightspathBoard board = (KnightspathBoard) state;
		return board.getKnightInRange();
	}
}

