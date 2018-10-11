//////////////////////////////////////// PROBLEM STATEMENT ////////////////////////////////////////
// Write a program that reads bank accounts from the accounts.txt file and stores the bank       //
// accounts in an array of BankAccount objects. Print out the account with the highest balance   //
// using the BankAccount getter methods. You may use your BankAccount class from the previous    //
// problem.                                                                                      //
// Part 2: Display the details of the bank account with the highest balance in a JFrame using    //
// JLabels and JTextFields.                                                                      //
// NOTE: All input uses a Scanner object and all output uses System.out.                         //
// NOTE: To read an array, you must ALWAYS FIRST read the number of                              //
//       elements in the array, THEN declare the array, and THEN read the                        //
//       data to put into the array. See:                                                        //
//       Help -> Java Examples -> Java IO Code Fragments.                                        //
///////////////////////////////////////////////////////////////////////////////////////////////////

// >>>>>> Your import statements start here <<<<<<
import java.util.*;
import java.io.*;
// >>>>>> Your import statements end here   <<<<<<
public class L264
{// >>>>>> Your Class variables start here <<<<<<

 // >>>>>> Your Class variables end here   <<<<<<
 public static void main (String[] args) throws FileNotFoundException
   {while (JPL.test())
      {
       // >>>>>> Your Java Code Fragment starts here <<<<<<
       Scanner scan = new Scanner(new File("accounts.txt"));
       BankAccount[] bankArray = new BankAccount[100];
       int num = 0;
       
       while(scan.hasNext()){
         int accountNumber = scan.nextInt();
         String firstname = scan.next();
         String surname = scan.next();
         double balance = scan.nextDouble();
         BankAccount b = new BankAccount(accountNumber, firstname, surname, balance);
         bankArray[num++] = b;
       }
                                  
       scan.close();
                                  
       BankAccount highest = null;
       for(int i = 0; i < num; i++){
         if(highest == null || bankArray[i].getBalance() > highest.getBalance()){
          highest = bankArray[i]; 
         }
       }

       System.out.println(highest.getAccountNumber() + ", " + highest.getFirstname() + ", " + highest.getLastname() + ", " + highest.getBalance());
       // >>>>>> Your Java Code Fragment ends here   <<<<<<

      }
   }
}

class BankAccount
{
 private int accountNumber;
 private String firstname;
 private String surname;
 private double balance;

 public BankAccount(int accountNumber, String firstname, String surname, double balance)
 {
  this.accountNumber = accountNumber;
  this.firstname = firstname;
  this.surname = surname;
  this.balance = balance;
 }

 public int getAccountNumber(){
   return accountNumber;
 }
 
 public String getFirstname(){
   return firstname;
 }
 
  public String getLastname(){
   return surname;
 }
  
 public double getBalance(){
   return balance;
 }
}