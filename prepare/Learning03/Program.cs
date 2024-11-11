using System;

class Program
{
    static void Main(string[] args){
        
        //First Test - nothing
        Console.Write("No Inputs: ");
        Fraction f1 = new Fraction();
        string fracString = f1.GetFractionString();
        string fracValue = f1.GetDecimalValue().ToString();
        Console.WriteLine($"String: {fracString}, decimal: {fracValue}");

        //Second Test - one input
        Console.Write("One input, What is the Numerator? ");
        int num1 = int.Parse(Console.ReadLine());
        Fraction f2 =  new Fraction(num1);
        fracString = f2.GetFractionString();
        fracValue = f2.GetDecimalValue().ToString();
        Console.WriteLine($"String: {fracString}, decimal: {fracValue}");
        
        //Third Test - tw0 inputs
        Console.Write("First input, What is the Numerator? ");
        num1 = int.Parse(Console.ReadLine());
        Console.Write("Second input, What is the Denominator? ");
        int num2 = int.Parse(Console.ReadLine());
        Fraction f3 =  new Fraction(num1, num2);
        fracString = f3.GetFractionString();
        fracValue = f3.GetDecimalValue().ToString();
        Console.WriteLine($"String: {fracString}, decimal: {fracValue}");
    }
}