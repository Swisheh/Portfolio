

////////////////////////////// PROBLEM STATEMENT //////////////////////////////
// Create a class called Lab8. This class has an instance field/variable called data of type array of double.
// This class has two constructors:
// • The first constructor takes in two parameters. The first parameter, n, of type int, defines the length of the array. 
//   The second parameter, d, is a double value used to initialise elements of the array. This constructor will create a new double 
//   array with length n, and assign this array to data. Then all elements in data will be set to the value in the second parameter.
// • The second constructor takes in a double value, d, and an int value, n as parameters. 
//   This constructor will create a new double array with n elements and assign it to data. Then each element in data will be assigned a random value between 0 and d.
///////////////////////////////////////////////////////////////////////////////

import java.util.*;
import java.io.*;

public class Lab8{

  public static double[] data;
  
public Lab8(int n, double d)
{
  data = new double[n];
  for(int i = 0; i < n; i++){
   data[i] = d; 
  }
} 

public Lab8(double d, int n)
{
  data = new double[n];
  Random rand = new Random();
  for(int i = 0; i < n; i++){
   data[i] = rand.nextDouble()*d; 
  }
}

public int getLength(){
 return data.length; 
}

public void setVal(int pos, double val){
  if(pos < data.length && pos >= 0){
    data[pos] = val;
  }
}

public double getVal(int pos){
  if(pos < data.length && pos >= 0){
   return data[pos]; 
  }else{
   return -1; 
  }
}

public String tostring(){
  String dataString = "{";
  for(int i = 0; i < data.length; i++){
   dataString+= data[i];
 
   if(i != data.length-1) dataString+= ", ";
   else dataString+= "}";
  }
  return dataString;
}

public int find(double num){
 int pos = -1;
 for(int i = 0; i < data.length; i++){
   if(num == data[i]){
    pos = i;
    break;
   }
 }
 return pos;
}

public double[] concat(double[] dArray){
  double[] combine = new double[data.length + dArray.length];
  for(int i = 0; i < data.length; i++){
    combine[i] = data[i];
  }
  for(int k = 0; k < dArray.length; i++){
   combine[data.length + k] = dArray[k]; 
  }
  return combine;
}


}

