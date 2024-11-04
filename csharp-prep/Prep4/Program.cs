using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        int newNum;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do {
            Console.Write("Enter number: ");
            newNum = int.Parse(Console.ReadLine());
            numbers.Add(newNum);
        } while (newNum != 0);

        int sum = 0;
        int max = numbers[0];
        foreach (int num in numbers) {
            sum += num;
            if (num > max) { 
                max = num;
            }
        }
        int avg = sum / numbers.Count;
        
        Console.WriteLine($"The total sum is {sum}");
        Console.WriteLine($"The average is {avg}");
        Console.WriteLine($"The largest number is {max}");

    }
}