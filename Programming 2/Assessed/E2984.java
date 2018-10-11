//////////////////////////////////////// PROBLEM STATEMENT ////////////////////////////////////////
// Implement a Java application that asks the user for an integer value. The application should  //
// use the integer value as the seed for a Random generator (eg. new Random(seed)).  The Java    //
// application should then randomly generate two strings that are either,  Jack, Queen,  King,   //
// or Ace, and print these strings to screen.  Example formatting:                               //
//  Enter a seed value: 9                                                                        //
//  Computer chose: King Queen                                                                   //
// NOTE: All input uses a Scanner object and all output requires System.out.                     //
///////////////////////////////////////////////////////////////////////////////////////////////////

// >>>>>> Your import statements start here <<<<<<
import java.util.*;
// >>>>>> Your import statements end here   <<<<<<
public class E2984
{// >>>>>> Your Class variables start here <<<<<<

 // >>>>>> Your Class variables end here   <<<<<<
 public static void main (String[] args)
   {while (JPL.test())
      {
       // >>>>>> Your Java Code Fragment starts here <<<<<<
     Scanner scan = new Scanner(System.in);
     
     String[] cards = {"Jack","Queen","King","Ace"};
     
     System.out.print("Enter a seed value: ");
     int readSeed = scan.nextInt();
     Random rSeed = new Random(readSeed);
     int seed = rSeed.nextInt(4);
     int seed2 = rSeed.nextInt(4);
     
     String compChoice = cards[seed];
     String compChoice2 = cards[seed2];
     
     System.out.print("Computer chose: " + compChoice + " " + compChoice2);
       // >>>>>> Your Java Code Fragment ends here   <<<<<<

      }
   }
}
