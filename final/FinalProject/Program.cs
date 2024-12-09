using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Stats league = JasonPaser.LoadJson("Team_Test_copy.json");

        // Display the object hierarchy

        //league.Display();

        Display(league);
    }

    static void Display(Datum datum, int tab = 0){
        string indent = new string('\t', tab);
        if (datum is Stats) {
            Stats stats = (Stats)datum;
            string t = datum.getType();
            string n = datum.getName();
            
            Console.WriteLine($"{indent}{t}: {n}");

            foreach (Datum d in stats.GetStats()){
                Display(d, tab + 1);
            }
        } else {
            Stat stat = (Stat)datum;
            Console.WriteLine($"{indent}{stat.getName()}: {stat.getStat()}");
        }


    }
}
