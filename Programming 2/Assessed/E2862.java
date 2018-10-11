//////////////////////////////////////// PROBLEM STATEMENT ////////////////////////////////////////
// Implement a Java application that asks user to input a string. If this string is  START,      //
// BEGIN or GO in upper, lower case or a mix of both, then print Starting program. Otherwise,    //
// print Invalid command.  Your print out must follow the format below:                          //
//  Enter command: Start                                                                         //
//  Starting program.                                                                            //
// Running the program again with a different input:                                             //
//  Enter selection: quit                                                                        //
//  Invalid command.                                                                             //
// Running the program again with a different input:                                             //
//  Enter command: begin                                                                         //
//  Starting program.                                                                            //
// NOTE: All input uses a Scanner object and all output requires System.out.                     //
///////////////////////////////////////////////////////////////////////////////////////////////////

// >>>>>> Your import statements start here <<<<<<
import java.util.Scanner;
// >>>>>> Your import statements end here   <<<<<<
public class E2862
{// >>>>>> Your Class variables start here <<<<<<

 // >>>>>> Your Class variables end here   <<<<<<
 public static void main (String[] args)
   {while (JPL.test())
      {
       // >>>>>> Your Java Code Fragment starts here <<<<<<
     Scanner scan = new Scanner(System.in);
     
     System.out.print("Enter command: ");
     String read = scan.next();
     read = read.toUpperCase();
     if(read.equals("START") || read.equals("BEGIN") || read.equals("GO")){
      System.out.println("Starting program.");
     }else{
      System.out.println("Invalid command."); 
     }
       // >>>>>> Your Java Code Fragment ends here   <<<<<<

      }
   }
}
