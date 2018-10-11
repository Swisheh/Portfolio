import java.io.*;

public class Lab9Tester{
 
  public static void main(String[] args) throws FileNotFoundException{
   
   System.out.println("Labtest1 -------------------------------------");
    
   Lab9 labtest = new Lab9(10, 40);
   System.out.println("toString = " + labtest.tostring());
   labtest.setVal(5, 60);
   System.out.println("setVal(5,60) = " + labtest.tostring());
   System.out.println("between(20,30) = " + labtest.betweenCount(20,30));
   labtest.last(5);
   System.out.println("Last(5) = " + labtest.tostring());
   
   System.out.println("Labtest2 -------------------------------------");
   
   int[] inArray = {5,10,15,20,25,30,35,40,45,50};
   Lab9 labtest2 = new Lab9(inArray);
   System.out.println("toString = " + labtest2.tostring());
   labtest2.setVal(5, 60);
   System.out.println("setVal(5,60) = " + labtest2.tostring());
   System.out.println("between(20,30) = " + labtest2.betweenCount(20,30));
   labtest2.last(5);
   System.out.println("Last(5) = " + labtest2.tostring());
  }
  
}