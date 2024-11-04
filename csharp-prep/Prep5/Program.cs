using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args) {
        DisplayWelcome();
        DisplayResult(PromptUserName(), SqaureNumber(PromptUserNumber()));
    }

    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the program");
    }

    static string PromptUserName() {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber() {
        Console.Write("Please enter your favoirte number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SqaureNumber(int num) {
        return num * num;
    }

    static void DisplayResult(string name, int num) {
        Console.WriteLine($"{name}, the square of your number is {num}");
    }
}