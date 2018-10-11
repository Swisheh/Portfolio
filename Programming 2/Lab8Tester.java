
import java.io.*;

public class Lab8Tester{
  
  public static void main (String[] args) throws FileNotFoundException{

   Lab8 labTest = new Lab8(10, 40.5);
   System.out.println("toString = " + labTest.tostring());
   Lab8 labTest2 = new Lab8(40.5, 10);
   System.out.println("toString2 = " + labTest2.tostring());
   Lab8 labTest3 = new Lab8(10, 40.5);
   System.out.println("toString3 = " + labTest3.tostring());
   
   System.out.println("getLength = " + labTest.getLength());
   labTest.setVal(1, 5000);
   System.out.println("getVal = " + labTest.getVal(1));
   System.out.println("toString = " + labTest.tostring());
   System.out.println("toString2 = " + labTest2.tostring());
   System.out.println("toString3 = " + labTest3.tostring());
   System.out.println("find = " + labTest.find(5000));
   //System.out.println("Concat lab1, lab2 = " + labTest.tostring(labTest.concat(labTest2.data)));
  
  }
  
}

