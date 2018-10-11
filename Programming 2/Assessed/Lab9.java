import java.util.*;
import java.io.*;

public class Lab9{

private static int[] data;
 
public Lab9(int len, int val){
 int[] temp = new int[len];
 data = temp;
 Random rand = new Random();
 for(int i = 0; i < len; i++){
  data[i] = rand.nextInt(val); 
 }

}

public Lab9(int[] inArray){
  int[] temp = new int[inArray.length];
  for(int i = 0; i < inArray.length; i++){
   temp[i] = inArray[i]; 
   data = temp;
  }
}

public void setVal(int pos, int val){
  if(pos < data.length && pos >= 0){
    data[pos] = val;
  }
}

public String tostring(){
 String dataString = "(";
 for(int i = 0; i < data.length; i++){
  dataString+= data[i];
  if(i != data.length-1){
   dataString+= " - "; 
  }else{
   dataString+= ")"; 
  }
 }
 return dataString;
}

public int betweenCount(int x, int y){
  int count = 0;
  for(int i = 0; i < data.length; i++){
    if(data[i] > x && data[i] < y){
      count+= 1;
    }
  }
  return count;
}

public void last(int n){
 int[] temp = new int[n];
 for(int i = 0; i < n; i++){
   temp[i] = data[data.length- (n-i)];
 }
 data = temp;
}


}