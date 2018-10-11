/* 
 * Creator: Rory Hiscock
 * Student Number: 2776863
 * Date: 05/09/12
 * Description: Navigate a maze using the A* algorithm
 * Compile instructions: Does not work. Was not sure how to implement my code into the code provided.
 * The code below should navigate the maze effectively.
 */


public class A {
	//Set start and goal locations. Start being the top left and goal being bottom right.
	final startLocation = [1][1]; //[x][y] co-ords
	final goalLocation = [10][10];
	//Keep track of current location.
	currentLocation = [1][1];
	//Keep track of the different node location values
	possibleLoc = ArrayList of possible node locations
	possibleLoc[1] = currentLocation; //Give the loop somewhere to start in main method
	//Tracked maze path
	trackedPath = ArrayList of locations;
	//Array of multiple tracked paths
	allPaths = ArrayList of trackedPaths;
	//Create the maze. Given assignment maze.
	Maze maze = new Maze;
	//Indicate if path is not blocked
	pathOpen = 0; // blocked will return any value other then 0.
	blockedPaths = ;//List of blocked paths / ArrayList.
	blockedPaths[1] = currentLocation; //Remove start location from possible moves
	//Set the score as a high number to begin with
	int score = infinite;
	tempLoc; //Temporary location with lowest value
	lastLoc; //Last move
	distanceFromStart = 0; //Keep track of how far the object has moved.
	
	public static void main(){
		while(currentLocation != goalLocation){
			//Loop through the possible locations and check where it can move next
			for(int i = 0; i < possibleLoc.length; i++){
				getPossibleMoves(possibleLoc[i]);
			}
			findShortestRoute();
			//Reset score for next search
			scoreLow = infinite;
		}
		//Print out the shortest route on the maze
		display(trackedPath);
	}
	
	//Check which blocks are available to be moved to. Works out the score and saves the 
	//shortest answer. Adding the location with shortest score to possibleLoc.
	//getValue used to determine if the square is open or blocked or the goal location.
	//distanceToGoal and distanceFromStart would use a straight line heuristic to get the straight line
	//distance between start and goal.
	public getPossibleMoves(location){
		if(location == lastLoc){
			trackedPath[] += lastLoc;
			distanceFromStart++;
		}else{
			allPaths[] += trackedPath;
		}
	
		if(location.getValue[+1][+1] == pathOpen || location.getValue[+1][+1] == goalLocation){
			newLocation = location[+1][+1];
			tempScore = distanceToGoal(newLocation) + distanceFromStart(newLocation);
			if(score > tempScore){
				score = tempScore;
				tempLoc = newLocation;
			}
		}
		if(location.getValue[+1][+0] == pathOpen || location.getValue[+1][+0] == goalLocation){
			newLocation = location[+1][+0];
			tempScore = distanceToGoal(newLocation) + distanceFromStart(newLocation);
			if(score > tempScore){
				score = tempScore;
				tempLoc = newLocation;
			}
		}
		if(location.getValue[+0][+1] == pathOpen || location.getValue[+0][+1] == goalLocation){
			newLocation = location[+0][+1];
			tempScore = distanceToGoal(newLocation) + distanceFromStart(newLocation);
			if(score > tempScore){
				score = tempScore;
				tempLoc = newLocation;
			}
		}
		if(location.getValue[-1][-1] == pathOpen || location.getValue[-1][-1] == goalLocation){
			newLocation = location[-1][-1];
			tempScore = distanceToGoal(newLocation) + distanceFromStart(newLocation);
			if(score > tempScore){
				score = tempScore;
				tempLoc = newLocation;
			}
		}
		if(location.getValue[-1][-0] == pathOpen || location.getValue[-1][-0] == goalLocation){
			newLocation = location[-1][-0];
			tempScore = distanceToGoal(newLocation) + distanceFromStart(newLocation);
			if(score > tempScore){
				score = tempScore;
				tempLoc = newLocation;
			}
		}
		if(location.getValue[-0][-1] == pathOpen || location.getValue[-0][-1] == goalLocation){
			newLocation = location[-0][-1];
			tempScore = distanceToGoal(newLocation) + distanceFromStart(newLocation);
			if(score > tempScore){
				score = tempScore;
				tempLoc = newLocation;
			}
		}
		if(location.getValue[-1][+1] == pathOpen || location.getValue[-1][+1] == goalLocation){
			newLocation = location[-1][+1];
			tempScore = distanceToGoal(newLocation) + distanceFromStart(newLocation);
			if(score > tempScore){
				score = tempScore;
				tempLoc = newLocation;
			}
		}
		if(location.getValue[+1][-1] == pathOpen || location.getValue[+1][-1] == goalLocation){
			newLocation = location[+1][-1];
			tempScore = distanceToGoal(newLocation) + distanceFromStart(newLocation);
			if(score > tempScore){
				score = tempScore;
				tempLoc = newLocation;
			}
		}
		if(all locations == pathBlocked){
			blockedPaths[] += location;
		}
		
		//Remove the last location from possible locations to prevent it from searching the same areas
		for(int i = 0; i < possibleLoc.length; i++){
			if(possibleLoc[i] == location){
				possibleLoc.remove(i);
			}
		}
	}
	
	public findShortestRoute(){
		possibleLoc[] += tempLoc; //Adding the lowest score to the possibleLoc array
		blockedPaths[] += tempLoc; //Make sure other paths don't join on
	}

	//Cycle through the tracked path and add numbers to the maze squares
	public display(path){
		for(int i = 0; i < path.length; i++){
			path[i] = print(i);
		}
	}
}