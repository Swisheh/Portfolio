package aima.core.environment.knightspath;

import java.util.LinkedHashSet;
import java.util.Set;

import aima.core.agent.Action;
//import aima.core.environment.nqueens.NQueensBoard;
import aima.core.search.framework.ActionsFunction;
import aima.core.search.framework.ResultFunction;
import aima.core.util.datastructure.XYLocation;

/**
 * Provides useful functions for two versions of the n-knights problem. The
 * incremental formulation and the complete-state formulation share the same
 * RESULT function but use different ACTIONS functions.
 * 
 * @author Ciaran O'Reilly
 * @author R. Lunde
 */
public class KnightspathFunctionFactory {
	private static ActionsFunction _iActionsFunction = null;
	private static ActionsFunction _cActionsFunction = null;
	private static ResultFunction _resultFunction = null;

	/**
	 * Returns an ACTIONS function for the incremental formulation of the
	 * n-knights problem.
	 */
	public static ActionsFunction getIActionsFunction() {
		if (null == _iActionsFunction) {
			_iActionsFunction = new NQIActionsFunction();
		}
		return _iActionsFunction;
	}

	/**
	 * Returns an ACTIONS function for the complete-state formulation of the
	 * n-knights problem.
	 */
	public static ActionsFunction getCActionsFunction() {
		if (null == _cActionsFunction) {
			_cActionsFunction = new NQCActionsFunction();
		}
		return _cActionsFunction;
	}

	/**
	 * Returns a RESULT function for the n-knights problem.
	 */
	public static ResultFunction getResultFunction() {
		if (null == _resultFunction) {
			_resultFunction = new NQResultFunction();
		}
		return _resultFunction;
	}

	/**
	 * Assumes that knights are placed column by column, starting with an empty
	 * board, and provides knight placing actions for all non-attacked positions
	 * of the first free column.
	 * 
	 * @author R. Lunde
	 */
	private static class NQIActionsFunction implements ActionsFunction {
		public Set<Action> actions(Object state) {
			KnightspathBoard board = (KnightspathBoard) state;

			Set<Action> actions = new LinkedHashSet<Action>();

			// Goes through the board and determines which squares are able to be attacked by the knight 
			// which not being under attack from the opposing piece. Then saves that action to send through later
			int boardSize = board.getSize();
			for (int i = 0; i < boardSize; i++) {
				for (int j = 0; j < boardSize; j++) {
					XYLocation newLocation = new XYLocation(j, i);
					if ((board.isSquareKnightAttack(newLocation))) {
						if(!(board.isSquareUnderAttack2(newLocation))){
							actions.add(new KnightAction(KnightAction.MOVE_KNIGHT,
									newLocation));
						}
					}
				}
			}

			return actions;
		}
	}

	/**
	 * Assumes exactly one knight in each column and provides all possible knight
	 * movements in vertical direction as actions.
	 * 
	 * @author R. Lunde
	 */
	private static class NQCActionsFunction implements ActionsFunction {

		// this code was removed
		public Set<Action> actions(Object state) {
			Set<Action> actions = new LinkedHashSet<Action>();
			KnightspathBoard board = (KnightspathBoard) state;
			for (int i = 0; i < board.getSize(); i++)
				for (int j = 0; j < board.getSize(); j++) {
					XYLocation loc = new XYLocation(i, j);
					if (!board.knightExistsAt(loc))
						actions.add(new KnightAction(KnightAction.MOVE_KNIGHT, loc));
				}
			return actions;
		}
	}

	/** Supports knight placing, knight removal, and knight movement actions. */
	private static class NQResultFunction implements ResultFunction {
		public Object result(Object s, Action a) {
			if (a instanceof KnightAction) {
				// This code updates the board with the most appropriate action
				KnightAction qa = (KnightAction) a;
				KnightspathBoard board = (KnightspathBoard) s;
				KnightspathBoard newBoard = new KnightspathBoard(board.getSize());
				// Checks which enemy piece to update on the new board
				if (board.isBishop()){
					newBoard.setBoard(board.getBishopPositions());
				} else if (board.isRook()){
					newBoard.setBoard(board.getRookPositions());
				} else if (board.isQueen()){
					newBoard.setBoard(board.getQueenPositions());
				}
				newBoard.setBoard(board.getKnightPositions());
				if (qa.getName() == KnightAction.MOVE_KNIGHT){
					if (board.isBishop()){
						newBoard.moveBishopTo(board.getEnemyPosition());
					} else if (board.isRook()){
						newBoard.moveBishopTo(board.getEnemyPosition());
					} else if (board.isQueen()){
						newBoard.moveBishopTo(board.getEnemyPosition());
					}
					newBoard.moveKnightTo(qa.getLocation());
				}
					
				s = newBoard;
			}
			// if action is not understood or is a NoOp
			// the result will be the current state.
			return s;
		}
	}
}