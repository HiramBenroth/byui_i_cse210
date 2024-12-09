using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Stats league = JasonPaser.LoadJson("Team_Test_copy.json");

        // Display the object hierarchy

        //league.Display();

        //Display(league);
    }

    static void Display(Datum datum){
        if (datum is Stats) {
            Stats stats = (Stats)datum;
            string t = datum.getType();
            string n = datum.getName();
            Console.WriteLine($"{t}: {n}");

            foreach (Datum d in stats.GetStats()){
                Display(d);
            }
        } else {
            Console.WriteLine($"{datum.getName}: {datum.getData}");
        }


    }
}
