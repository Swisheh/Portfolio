//////////////////////////////////////// PROBLEM STATEMENT ////////////////////////////////////////
// The following main method asks the user for details for a bank account and creates an         //
// instance of a BankAccount class. The main method calls the constructor of BankAccount to      //
// initialise values and also uses get accessor methods to print out the BankAccount details.    //
// Create and complete the BankAccount class as a separate Java file so that this file compiles  //
// and runs.                                                                                     //
// NOTE: All input uses a Scanner object and all output uses System.out.                         //
///////////////////////////////////////////////////////////////////////////////////////////////////

// >>>>>> Your import statements start here <<<<<<
import java.util.*;
// >>>>>> Your import statements end here   <<<<<<
public class L263
{// >>>>>> Your Class variables start here <<<<<<

 // >>>>>> Your Class variables end here   <<<<<<
 public static void main (String[] args)
   {while (JPL.test())
      {
       // >>>>>> Your Java Code Fragment starts here <<<<<<
       Scanner keyboard = new Scanner(System.in);
       System.out.print("Enter account no: ");
       int accountNumber = keyboard.nextInt();
       System.out.print("Enter firstname: ");
       String firstname = keyboard.next();
       System.out.print("Enter surname: ");
       String surname = keyboard.next();
       System.out.print("Enter balance: ");
       double balance = keyboard.nextDouble();

       BankAccount b = new BankAccount(accountNumber, firstname, surname, balance);

       System.out.println(b.getAccountNumber() + ", " + b.getFirstname() + ", " + b.getLastname() + ", " + b.getBalance());
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