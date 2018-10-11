/**
 * @(#)Trunc.java
 *
 *
 * @author
 * @version 1.00 2011/8/10
 */

import java.util.Scanner;

public class Trunc {

	public static String Trunced = "";

    public static void main(String[] args) {
    	String word = inputW();
    	int numb = inputN();
    	process(word,numb);
		System.out.println(Trunced);
    }

    public static String inputW(){
    	Scanner scan = new Scanner(System.in);
    	System.out.print("Enter a string to truncate: ");
		String word = scan.nextLine();
    	return word;
    }

    public static int inputN(){
    	Scanner scan = new Scanner(System.in);
    	System.out.print("Enter number of characters to truncate to: ");
    	int numb = scan.nextInt();
    	return numb;
    }

	public static void process(String a,int b){
		if (b > 3){
			a = a.substring(0,b-3);
			a = a+"...";
			Trunced = a;
		} else {
			Trunced = a;
		}
	}

}