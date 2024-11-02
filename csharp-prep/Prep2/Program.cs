using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the number grade? ");
        int grade = int.Parse(Console.ReadLine());
        string lGrade = "F";
        if (grade >= 90) {
            lGrade = "A";
        }
        else if(grade >= 80) {
            lGrade = "B";
        }
        else if(grade >= 70){
            lGrade = "C";
        }
        else if(grade >= 60){
            lGrade = "D";
        }

        Console.WriteLine($"\nYour letter grade is a {lGrade}");

    }
}