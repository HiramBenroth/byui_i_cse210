using System;
using System.Runtime.Versioning;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string fName = Console.ReadLine();
        Console.Write("What is your last name? ");
        string lName = Console.ReadLine();

        Console.Write($"\n\nYour name is {lName}, {fName} {lName}");

    }
}