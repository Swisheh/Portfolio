// file: Lowest.java
// generated by: mashc
// from: Lowest.mash

public class Lowest {

protected static final int MAX_INT = java.lang.Integer.MAX_VALUE;

protected static final int MIN_INT = java.lang.Integer.MIN_VALUE;

protected static final long MAX_LONG = java.lang.Long.MAX_VALUE;

protected static final long MIN_LONG = java.lang.Long.MIN_VALUE;

protected static final double PI = java.lang.Math.PI;

private static java.util.Scanner mash_console_scanner 
               = new java.util.Scanner(System.in);

public static void main(java.lang.String[] mash_args_param) 
         throws java.lang.Exception {
            
java.lang.System.out.print("Enter a mark: ");
double mark = mash_console_scanner.nextDouble();
while (mark < 0)
{
java.lang.System.out.print("Enter a number higher then 0: ");
mark = mash_console_scanner.nextDouble();
}
double lowest = mark;
while (mark >= 0.0)
{
if (mark < lowest)
{
lowest = mark;
}
java.lang.System.out.print("Enter another mark: ");
mark = mash_console_scanner.nextDouble();
}
java.lang.System.out.println("The lowest mark was: " + lowest);

         }

}
