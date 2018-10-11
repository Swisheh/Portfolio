/**
 * @(#)Trunc.java
 *
 *
 * @author
 * @version 1.00 2011/8/10
 */

import java.util.Scanner;
import javax.swing.*;

public class TruncGUI {

	public static boolean gui = false;
	public static String Trunced = "";
	public static String word = "";
	public static int numb = 0;

    public static void main(String[] args) {

    	inputW();
    	inputN();
    	process(word,numb);
    	output();
    }

    public static void inputW(){
    	if (gui){
			word = JOptionPane.showInputDialog(null,"Enter a string to truncate: ");
    	} else {
    		Scanner scan = new Scanner(System.in);
    		System.out.print("Enter a string to truncate: ");
			word = scan.nextLine();
    	}
    }

    public static void inputN(){
    	if (gui == true){
    		numb = Integer.parseInt
    			(JOptionPane.showInputDialog(null,"Enter number of characters to truncate to: "));
    	} else {
    		Scanner scan = new Scanner(System.in);
    		System.out.print("Enter number of characters to truncate to: ");
    		numb = scan.nextInt();
    	}
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

	public static void output(){
		if(gui == true){
    		JOptionPane.showMessageDialog(null,Trunced);
    	} else {
    		System.out.println(Trunced);
    	}
	}

}