package aima.core.environment.knightspath;

import java.util.ArrayList;
import java.util.List;

import aima.core.util.datastructure.XYLocation;

/**
 * Represents a quadratic board with a matrix of squares on which knights can be
 * placed (only one per square) and moved.
 * 
 * @author Ravi Mohan
 * @author R. Lunde
 */
public class KnightspathBoard {

	/**
	 * X---> increases left to right with zero based index Y increases top to
	 * bottom with zero based index | | V
	 */
	int[][] squares;

	int size;

	public KnightspathBoard(int n) {
		size = n;
		squares = new int[size][size];
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				squares[i][j] = 0;
			}
		}
	}

	public void clear() {
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				squares[i][j] = 0;
			}
		}
	}

	public void setBoard(List<XYLocation> al) {
		clear();
		for (int i = 0; i < al.size(); i++) {
			addKnightAt(al.get(i));
		}
	}

	public int getSize() {
		return size;
	}
	
	// Adds the bishop
	public void addBishopAt(XYLocation l) {
		if (!(bishopExistsAt(l)))
			squares[l.getXCoOrdinate()][l.getYCoOrdinate()] = 2;
	}
	
	// Checks if a bishop is on a square
	public boolean bishopExistsAt(XYLocation l) {
		return (bishopExistsAt(l.getXCoOrdinate(), l.getYCoOrdinate()));
	}

	private boolean bishopExistsAt(int x, int y) {
		return (squares[x][y] == 2);
	}
	
	// Adds a rook
	public void addRookAt(XYLocation l) {
		if (!(rookExistsAt(l)))
			squares[l.getXCoOrdinate()][l.getYCoOrdinate()] = 3;
	}
	
	// Checks if a rook is on a square
	public boolean rookExistsAt(XYLocation l) {
		return (rookExistsAt(l.getXCoOrdinate(), l.getYCoOrdinate()));
	}

	private boolean rookExistsAt(int x, int y) {
		return (squares[x][y] == 3);
	}
	
	// Adds a queen
	public void addQueenAt(XYLocation l) {
		if (!(queenExistsAt(l)))
			squares[l.getXCoOrdinate()][l.getYCoOrdinate()] = 4;
	}
	
	// Checks if a queen is on a square
	public boolean queenExistsAt(XYLocation l) {
		return (queenExistsAt(l.getXCoOrdinate(), l.getYCoOrdinate()));
	}

	private boolean queenExistsAt(int x, int y) {
		return (squares[x][y] == 4);
	}

	// Adds a knight
	public void addKnightAt(XYLocation l) {
		if (!(knightExistsAt(l)))
			squares[l.getXCoOrdinate()][l.getYCoOrdinate()] = 1;
	}

	public void removeKnightFrom(XYLocation l) {
		if (squares[l.getXCoOrdinate()][l.getYCoOrdinate()] == 1) {
			squares[l.getXCoOrdinate()][l.getYCoOrdinate()] = 0;
		}
	}

	/**
	 * Moves the knight in the specified column (x-value of <code>l</code>) to
	 * the specified row (y-value of <code>l</code>). The action assumes a
	 * complete-state formulation of the knights path problem.
	 * 
	 * @param l
	 */
	// Moves the knight
	public void moveKnightTo(XYLocation l) {
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (squares[i][j] == 1)
					squares[i][j] = 0;
			}
		}	
		squares[l.getXCoOrdinate()][l.getYCoOrdinate()] = 1;
	}
	
	// Moves the bishop
	public void moveBishopTo(XYLocation l) {
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (squares[i][j] == 2){
					squares[i][j] = 0;
				}
			}
		}	
		squares[l.getXCoOrdinate()][l.getYCoOrdinate()] = 2;
	}
	
	// Moves the rook
	public void moveRookTo(XYLocation l) {
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (squares[i][j] == 3)
					squares[i][j] = 0;
			}
		}	
		squares[l.getXCoOrdinate()][l.getYCoOrdinate()] = 3;
	}

	// Moves the queen
	public void moveQueenTo(XYLocation l) {
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (squares[i][j] == 4)
					squares[i][j] = 0;
			}
		}	
		squares[l.getXCoOrdinate()][l.getYCoOrdinate()] = 4;
	}
	
	public void moveKnight(XYLocation from, XYLocation to) {
		if ((knightExistsAt(from)) && (!(knightExistsAt(to)))) {
			removeKnightFrom(from);
			addKnightAt(to);
		}
	}

	// Checks if a knight exists on a square
	public boolean knightExistsAt(XYLocation l) {
		return (knightExistsAt(l.getXCoOrdinate(), l.getYCoOrdinate()));
	}

	private boolean knightExistsAt(int x, int y) {
		return (squares[x][y] == 1);
	}

	// Checks the number of bishops on the board
	public int getNumberOfBishopsOnBoard() {
		int count = 0;
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (squares[i][j] == 2)
					count++;
			}
		}
		return count;
	}
	
	// Checks the number of rooks on the board
	public int getNumberOfRooksOnBoard() {
		int count = 0;
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (squares[i][j] == 3)
					count++;
			}
		}
		System.out.println(count);
		return count;
	}
	
	// Checks the number of queens on the board
	public int getNumberOfQueensOnBoard() {
		int count = 0;
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (squares[i][j] == 4)
					count++;
			}
		}
		return count;
	}
	
	// Checks the number of knights on the board
	public int getNumberOfKnightsOnBoard() {
		int count = 0;
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (squares[i][j] == 1)
					count++;
			}
		}
		return count;
	}
	
	// Returns just the enemy location
		public XYLocation getEnemyPosition() {
			XYLocation result = new XYLocation (1,1);
			for (int i = 0; i < size; i++) {
				for (int j = 0; j < size; j++) {
					if (bishopExistsAt(i, j) || (rookExistsAt(i, j) || (queenExistsAt(i, j))))
						result = new XYLocation(i, j);
				}
			}
			return result;
		}
	
	// Gets all the bishop positions
	public List<XYLocation> getBishopPositions() {
		ArrayList<XYLocation> result = new ArrayList<XYLocation>();
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (bishopExistsAt(i, j))
					result.add(new XYLocation(i, j));
			}
		}
		return result;
	}
	
	// Gets all the rook positions
	public List<XYLocation> getRookPositions() {
		ArrayList<XYLocation> result = new ArrayList<XYLocation>();
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (rookExistsAt(i, j))
					result.add(new XYLocation(i, j));
			}
		}
		return result;
	}
	
	// Gets all the queen positions
	public List<XYLocation> getQueenPositions() {
		ArrayList<XYLocation> result = new ArrayList<XYLocation>();
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (queenExistsAt(i, j))
					result.add(new XYLocation(i, j));
			}
		}
		return result;
	}

	// Gets all the knight positions
	public List<XYLocation> getKnightPositions() {
		ArrayList<XYLocation> result = new ArrayList<XYLocation>();
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (knightExistsAt(i, j))
					result.add(new XYLocation(i, j));
			}
		}
		return result;

	}
	
	// Checks which opposing piece is on the board
	public boolean isBishop(){
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (bishopExistsAt(i, j))
					return true;
			}
		}
		return false;
	}
	
	// Checks which opposing piece is on the board
	public boolean isRook(){
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (rookExistsAt(i, j))
					return true;
			}
		}
		return false;
	}
	
	// Checks which opposing piece is on the board
	public boolean isQueen(){
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (queenExistsAt(i, j))
					return true;
			}
		}
		return false;
	}

	public int getNumberOfAttackingPairs() {
		int result = 0;
		for (XYLocation location : getKnightPositions()) {
			result += getNumberOfAttacksOn(location);
		}
		return result / 2;
	}
	
	// Here is where the manhattan distance heuristic is added
	public int getManhattanDistance(){
		int result = 0;
		XYLocation knightLoc = new XYLocation(1, 1);
		XYLocation enemyLoc = new XYLocation(1, 1);
		// finds where the enemy piece is and marks it
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (bishopExistsAt(i, j) || rookExistsAt(i, j) || queenExistsAt(i, j)){
					enemyLoc = new XYLocation(i, j);
				}
			}
		}
		// finds where the knight is and marks it
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (knightExistsAt(i, j)){
					knightLoc = new XYLocation (i, j);
				}
			}
		}
		result = (knightLoc.getXCoOrdinate() - enemyLoc.getXCoOrdinate()) + 
				(knightLoc.getYCoOrdinate() - enemyLoc.getYCoOrdinate());
		
		// this is added to make sure the heuristic is not negative
		if (result < 0){
			result = result * -1;
		}
		
		// divide by 3 because a knight can move a maximum of 3 spaces at once
		result = result / 3;

		//System.out.println(result);
		return result;
	}

	public int getNumberOfAttacksOn(XYLocation l) {
		int x = l.getXCoOrdinate();
		int y = l.getYCoOrdinate();
		return numberOfHorizontalAttacksOn(x, y)
				+ numberOfVerticalAttacksOn(x, y)
				+ numberOfDiagonalAttacksOn(x, y);
	}

	public boolean isSquareUnderAttack(XYLocation l) {
		int x = l.getXCoOrdinate();
		int y = l.getYCoOrdinate();
		return (isSquareHorizontallyAttacked(x, y)
				|| isSquareVerticallyAttacked(x, y) || isSquareDiagonallyAttacked(
					x, y) || isSquareKnightAttacked(x, y));
	}
	
	public boolean isSquareUnderAttack2(XYLocation l) {
		int x = l.getXCoOrdinate();
		int y = l.getYCoOrdinate();
		return (isSquareHorizontallyAttacked(x, y)
				|| isSquareVerticallyAttacked(x, y) || isSquareDiagonallyAttacked(
					x, y));
	}
	
	// Checks if a square is attacked by a knight
	public boolean isSquareKnightAttack(XYLocation l){
		int x = l.getXCoOrdinate();
		int y = l.getYCoOrdinate();
		return (isSquareKnightAttacked(x, y));
	}

	private boolean isSquareHorizontallyAttacked(int x, int y) {
		return numberOfHorizontalAttacksOn(x, y) > 0;
	}

	private boolean isSquareVerticallyAttacked(int x, int y) {
		return numberOfVerticalAttacksOn(x, y) > 0;
	}

	private boolean isSquareDiagonallyAttacked(int x, int y) {
		return numberOfDiagonalAttacksOn(x, y) > 0;
	}
	
	// Checks if a square is attacked by a knight
	public boolean isSquareKnightAttacked(int x, int y) {
		return numberOfKnightAttacksOn(x, y) > 0;
	}

	// Check if rook or queen exist on horizontal axis
	private int numberOfHorizontalAttacksOn(int x, int y) {
		int retVal = 0;
		for (int i = 0; i < size; i++) {
			if ((rookExistsAt(i, y))){
				if (i != x)
					retVal++;
			} else if ((queenExistsAt(i, y))){
				if (i != x)
					retVal++;
			}
		}
		return retVal;
	}

	// Check if rook or queen exist on vertical axis
	private int numberOfVerticalAttacksOn(int x, int y) {
		int retVal = 0;
		for (int j = 0; j < size; j++) {
			if ((rookExistsAt(x, j))){
				if (j != y)
					retVal++;
			} else if ((queenExistsAt(x, j))){
				if (j != y)
					retVal++;
			}
		}
		return retVal;
	}

	// Check if bishop or queen exist on diagonal
	private int numberOfDiagonalAttacksOn(int x, int y) {
		int retVal = 0;
		int i;
		int j;
		// forward up diagonal
		for (i = (x + 1), j = (y - 1); (i < size && (j > -1)); i++, j--) {
			if (bishopExistsAt(i, j) || (queenExistsAt(i, j)))
				retVal++;
		}
		// forward down diagonal
		for (i = (x + 1), j = (y + 1); ((i < size) && (j < size)); i++, j++) {
			if (bishopExistsAt(i, j) || (queenExistsAt(i, j)))
				retVal++;
		}
		// backward up diagonal
		for (i = (x - 1), j = (y - 1); ((i > -1) && (j > -1)); i--, j--) {
			if (bishopExistsAt(i, j) || (queenExistsAt(i, j)))
				retVal++;
		}

		// backward down diagonal
		for (i = (x - 1), j = (y + 1); ((i > -1) && (j < size)); i--, j++) {
			if (bishopExistsAt(i, j) || (queenExistsAt(i, j)))
				retVal++;
		}

		return retVal;
	}
	
	// Adds the knights attack routes
	private int numberOfKnightAttacksOn(int x, int y){
		int retVal = 0;
		// up2-left1
		if(x - 1 >= 0  && y - 2 >= 0){
			if(knightExistsAt(x-1, y-2)){
				retVal++;
			}
		}
		// up1-left2
		if(x - 2 >= 0 && y - 1 >= 0){
			if(knightExistsAt(x-2, y-1)){
				retVal++;
			}
		}
		// up2-right1
		if(x + 1 < size && y - 2 >= 0){
			if(knightExistsAt(x+1, y-2)){
				retVal++;
			}
		}
		// up1-right2
		if(x + 2 < size && y - 1 >= 0){
			if(knightExistsAt(x+2, y-1)){
				retVal++;
			}
		}
		// down2-left1
		if(x - 1 >= 0 && y + 2 < size){
			if(knightExistsAt(x-1, y+2)){
				retVal++;
			}
		}
		// down1-left2
		if(x - 2 >= 0 && y + 1 < size){
			if(knightExistsAt(x-2, y+1)){
				retVal++;
			}
		}
		// down2-right1
		if(x + 1 < size && y + 2 < size){
			if(knightExistsAt(x+1, y+2)){
				retVal++;
			}
		}
		// down1-right2
		if(x + 2 < size && y + 1 < size){
			if(knightExistsAt(x+2, y+1)){
				retVal++;
			}
		}
		return retVal;
	}
	
	// Checks if knight is in range of enemy piece
	public boolean getKnightInRange(){
		boolean goalDone = false;
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < size; j++) {
				if (bishopExistsAt(i, j) || (rookExistsAt(i, j) || queenExistsAt(i, j)))
					if (isSquareKnightAttacked(i, j))
						goalDone = true;
			}
		}
		return goalDone;
	}

	@Override
	public int hashCode() {
		List<XYLocation> locs = getKnightPositions();
		int result = 17;
		for (XYLocation loc : locs) {
			result = 37 * loc.hashCode();
		}
		return result;
	}

	@Override
	public boolean equals(Object o) {
		if (this == o)
			return true;
		if ((o == null) || (this.getClass() != o.getClass()))
			return false;
		KnightspathBoard aBoard = (KnightspathBoard) o;
		boolean retVal = true;
		List<XYLocation> locs = getKnightPositions();

		for (XYLocation loc : locs) {
			if (!(aBoard.knightExistsAt(loc)))
				retVal = false;
		}
		return retVal;
	}

	public void print() {
		System.out.println(getBoardPic());
	}

	public String getBoardPic() {
		StringBuffer buffer = new StringBuffer();
		for (int row = 0; (row < size); row++) { // row
			for (int col = 0; (col < size); col++) { // col
				if (knightExistsAt(col, row))
					buffer.append(" Q ");
				else
					buffer.append(" - ");
			}
			buffer.append("\n");
		}
		return buffer.toString();
	}

	@Override
	public String toString() {
		StringBuffer buf = new StringBuffer();
		for (int row = 0; row < size; row++) { // rows
			for (int col = 0; col < size; col++) { // columns
				if (knightExistsAt(col, row))
					buf.append('Q');
				else
					buf.append('-');
			}
			buf.append("\n");
		}
		return buf.toString();
	}
}