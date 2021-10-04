using System;
using System;
namespace CovnertingParsingCasing 
{
  public class Program
  {
   public static void Main(string[] args)
    {
      //1. Implicit Conversion
      //store int inside float without issue: implicit conversion
      int myInt =5;
      float myFloat = myInt;
      System.Console.WriteLine(myInt);
      System.Console.WriteLine(myFloat);
      //2 Explicit Conversion only from float to doulbe 
      int myValue = (int)3.4f;

      //3. even explicit conversion is not allow when the 
      //complier does not know how to convert form the existing type to target type
      //non-existant conversion : ie convert from a string to a numeric value

      string data ="1886";
      //int convertNumber = data;


//4. Convert , when convert from string to numberic value
//try catch to catch errors that occurs when converting a non numeric string to number
try{
int convertedNumber = Convert.ToInt32(data);
System.Console.WriteLine(convertedNumber);
}catch(Exception e)
{
System.Console.WriteLine(e.Message);
}

//5. Parse

//Convert VS parse
//Convert tatke objects as an object returns 0, never throw an argument nor exception if you pass null as an argument
//return the default value for the value type you are trying to convert(support custom types : iconvertible),o for ins or false for a boolean
//parse,only string 
//takes strings, throw argumentNullException when pass null, not support for custom Types
//when converting string : both do the same thing, recommend parse/try parse

//own convet types: implement the iconvertible interface  to provide conversiont for your own customer type





try{
int convertedNumber =int.Parse(data);
System.Console.WriteLine(convertedNumber);
}catch(Exception e)
{
System.Console.WriteLine(e.Message);
}

      
    }
  }
}