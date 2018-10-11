/**
 * @(#)Number_Plate.java
 *
 * Number_Plate application
 *
 * @author
 * @version 1.00 2011/8/3
 */

import java.util.Scanner;
// importing scanner for use with user input

public class Number_Plate {

    public static void main(String[] args) {

    	String[] inArray = {"SEE","ATE","ACC","EX","ER","E","S","I","B","Z","A"};
		String[] outArray = {"C","8","X","X","R","3","5","1","8","2","4"};
    	String in = readInput();
    	String process = processInput(in,inArray,outArray);
    	output(process);

    }

    public static String readInput(){
    	Scanner scan = new Scanner(System.in);
    	// Scanner (read from input)
    	System.out.println("Enter a number plate you desire");
		String input = scan.nextLine();
		// Command to read input from Scanner
		input = input.toUpperCase();
		return input;

    }

    public static String processInput(String i, String[] a, String[] b){
		for(int l = 0; l < a.length; l++){
		// Counter
			i = i.replaceAll(a[l],b[l]);
			// replace all String
		}
		return i;
    }

    public static void output(String process){
		System.out.println(process);
    }
}
