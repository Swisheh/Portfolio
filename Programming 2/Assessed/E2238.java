//////////////////////////////////////// PROBLEM STATEMENT ////////////////////////////////////////
// Implement a Java application that asks the user to input a string and counts how many         //
// characters in this String are uppercase characters (i.e. characters ‘A’ to ‘Z’). Continue to  //
// prompt user for a string and print result until user enters a String with no uppercase        //
// characters (then the program exits). A sample input and output is below:                      //
//  Enter a string: UpperCase Characters have Character CODES from 65 to 90                      //
//  Your string contains 9 uppercase characters.                                                 //
//  Enter a string: test                                                                         //
//  Program exited.                                                                              //
// NOTE: All input uses a Scanner object and all output requires System.out.                     //
///////////////////////////////////////////////////////////////////////////////////////////////////

// >>>>>> Your import statements start here <<<<<<
import java.util.*;
// >>>>>> Your import statements end here   <<<<<<
public class E2238
{// >>>>>> Your Class variables start here <<<<<<

 // >>>>>> Your Class variables end here   <<<<<<
 public static void main (String[] args)
   {while (JPL.test())
      {
       // >>>>>> Your Java Code Fragment starts here <<<<<<
    Scanner scan = new Scanner(System.in);
    
    while(scan.hasNext()){
      System.out.print("Enter a string: ");
      String read = scan.nextLine();
      int numbers = 0;
      for(int i = 0; i < read.length(); i++){
        char c = read.charAt(i);
        if (c >= 'A' && c <= 'Z'){
          numbers+=1; 
        }
      }
      if(numbers < 1){
        System.out.print("Program exited.");
        break;
      }else if(numbers >= 1){
        System.out.print("Your string contains " + numbers + " uppercase characters. ");
      }
     }
       // >>>>>> Your Java Code Fragment ends here   <<<<<<

      }
   }
}
