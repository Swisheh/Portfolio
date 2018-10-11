//////////////////////////////////////// PROBLEM STATEMENT ////////////////////////////////////////
// Secret messages have been encoded using ROT23. To decipher them you will need to apply ROT3.  //
// ie. rotate each character by 3 places. Note: that only lowercase letters have been rotated.   //
// Write a method that deciphers a ROT23 string using ROT3 and returns the deciphered string     //
// Write a main method that asks the user for encrypted messages and displays the unencrypted    //
// messages until the user types QUIT.                                                           //
//                                                                                               //
// See if you can decipher the following messages:                                               //
//  Teb Bixzh Stxk cibt lsbo qeb Sqfii Plka                                                      //
//  I ilsb fq tebk x mixk zljbp qldbqebo!                                                        //
//  Ylro jfppflk fc vlr zellpb ql xzzbmq fq...                                                   //
//  Blka... Jxjbp Blka.                                                                          //
// NOTE: All input uses a Scanner object and all output uses System.out.                         //
///////////////////////////////////////////////////////////////////////////////////////////////////

// >>>>>> Your import statements start here <<<<<<
import java.util.*;
// >>>>>> Your import statements end here   <<<<<<
public class L261
{// >>>>>> Your Class variables start here <<<<<<

 // >>>>>> Your Class variables end here   <<<<<<
 public static void main (String[] args)
   {while (JPL.test())
      {
       // >>>>>> Your Java Code Fragment starts here <<<<<<
     Scanner scan = new Scanner(System.in);
     String read = "";
     
     while(!read.equals("QUIT")){
       read = scan.nextLine(); 
       String rot = rot3(read);
       System.out.println(rot);
     }
     
     
     
     
    
       // >>>>>> Your Java Code Fragment ends here   <<<<<<

      }
   }

 // >>>>>> Your Method(s) starts here <<<<<<
 public static String rot3(String x)
 {
   String t = "";
   for(int i = 0; i < x.length(); i++){
     char c = x.charAt(i);
     if(c >= 'a' && c <= 'z'){
        t += (char)((c - 'a' + 3)%26 + 'a');
     }else{
        t+= c;
     }
   }
   return t;
 }
 
}
 

 // >>>>>> Your Method(s) ends here   <<<<<<


