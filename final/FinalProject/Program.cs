using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Stats league = JasonPaser.LoadJson("Team_Test_copy.json");

        while (MainMenu(league)){}
    }

    public static bool MainMenu(Stats stat){
        List<string> Options = [
                                    "1) Navigate the Entire Group",
                                    "2) Head on Head Match Up",
                                    "3) Look At Combined Stats for entire League",
                                    "4) Exit",
                                ];

        Console.Clear();
        Console.WriteLine("Welocme to this Team matchup program\nHere are your options");
        foreach (string opt in Options){Console.WriteLine(opt);}  
        
        int choice = 0;
        do {
            Console.WriteLine("Please Input a number between 1-4");
            choice = int.Parse(Console.ReadLine());
        }while ( 1 < choice && choice > 3 );

        switch (choice){
            case 1:
                Display.NavigationMenu(stat);
                break;
            case 2:
                Display.Wait("To select a team to compare, get to the desired level.\nThen input -1, you will be prompted if you want to select that Entity.");
                List<Stats> s = Display.NavigationMenu(stat, true);
                s = Analyze.Combine(s);
                foreach (Stats stats in s){
                    Display.EntireStats(stats);                    
                }
                Display.Wait("Enter to see Predicted Team");
                Analyze.Compare(s);
                break;
            case 3:
                Display.EntireStats(stat.getData());
                Display.Wait();
                break;
            case 4:
                Console.WriteLine("Have a good Day");
                return false;
            default:
                break;
            }
        
        return true;
    }
}
