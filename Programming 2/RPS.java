/**
 * @(#)RPS.java
 *
 *
 * @author
 * @version 1.00 2011/8/10
 */

import java.util.Scanner;
import java.math.*;

public class RPS {

	public static final int MAX = 3;
	public final int MIN = 1;
	public static String personPlay;
	public static String computerPlay;
	public static int computerInt;

    public static void main(String[] args) {

		userGo();
		compGo();
		results();
    }

	public static void userGo(){
		Scanner scan = new Scanner(System.in);
		System.out.print("Enter R, P, or S: ");
		personPlay = scan.nextLine();
		personPlay = personPlay.toUpperCase();
	}

	public static void compGo(){
		computerInt = 0+(int)(Math.random()*MAX);
		if(computerInt == 0){
			computerPlay = R;
		} else if(computerInt == 1){
			computerPlay = P;
		} else if(computerInt == 2){
			computerPlay = S;
		}
	}

	public static void results(){
		if(personPlay == "R" && computerPlay == "S"){
			System.out.println("Yours = "+personPlay+"  Computers = "+computerPlay);
			System.out.println("You WIN");
		}
	}
}