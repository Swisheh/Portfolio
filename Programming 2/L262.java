//////////////////////////////////////// PROBLEM STATEMENT ////////////////////////////////////////
// Write a program that asks the user for a student's firstname, surname, and mark and then      //
// create a student instance by passing the values into the constructor. Once the student has    //
// been created call the student print() method.                                                 //
// NOTE: All input uses a Scanner object and all output uses System.out.                         //
///////////////////////////////////////////////////////////////////////////////////////////////////

// >>>>>> Your import statements start here <<<<<<
import java.util.*;
// >>>>>> Your import statements end here   <<<<<<
public class L262
{// >>>>>> Your Class variables start here <<<<<<

 // >>>>>> Your Class variables end here   <<<<<<
 public void main (String[] args)
   {while (JPL.test())
      {
       // >>>>>> Your Java Code Fragment starts here <<<<<<
     Scanner scan = new Scanner(System.in);
    
     System.out.println("");
     String x = scan.next();
     String y = scan.next();
     int z = scan.nextInt();
     Student s = new Student(x,y,z);
     s.print();
     
       // >>>>>> Your Java Code Fragment ends here   <<<<<<

      }
   }
}


// >>>>>> Your Class(es) starts here <<<<<<

class Student
{
 private String firstname;
 private String lastname;
 private int mark;

 public Student(String firstname, String lastname, int mark)
 {
  this.firstname = firstname;
  this.lastname = lastname;
  this.mark = mark;
 }

 public void print()
 {
  System.out.println("Firstname: " + firstname);
  System.out.println("Surname: " + lastname);
  System.out.println("Mark: " + mark);
 }
}
// >>>>>> Your Class(es) ends here   <<<<<<
