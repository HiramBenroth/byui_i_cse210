using System.Text.RegularExpressions;

public class Display{
    //the purpose of this class is to navagate a branch and leaf

    public static void EntireStats(Datum datum,int tab = 0){
        string indent = new string('\t', tab);
        if (datum is Stats) {
            Stats stats = (Stats)datum;
            string t = datum.getType();
            string n = datum.getName();
            
            Console.WriteLine($"{indent}{t}: {n}");

            foreach (Datum d in stats.GetStats()){
                EntireStats(d,tab + 1);
            }
        } else {
            Stat stat = (Stat)datum;
            Console.WriteLine($"{indent}{stat.getName()}: {stat.getStat()}");
        }

    }

    public static List<Stats> NavigationMenu(Stats stats, bool Select = false, List<Stats> exit = null,  List<Stats> selections = null) {
        void Exit(){ // handles the leaving of the thing one at a time
            if (Select) {
                Selections();
            }
            if (exit.Count() != 0 && selections.Count != 2){
                Stats exitStat = exit.Last();
                exit.RemoveAt(exit.Count() - 1);
                NavigationMenu(exitStat, Select, exit, selections);
            }
        } 
        void Selections(){
            if (SelectPrompt(stats.getName())){
                selections.Add(stats);
            }
        }

        if (exit == null) {
            exit = new List<Stats>();
        }
        if (selections == null){
            selections = new List<Stats>();
        }

        Console.Clear();

        if (stats.ContainsStat() == false) {
            PrintStats(stats);
            List<Datum> objstats = stats.GetStats();
            string selecting_type = objstats[0].getType();
            int options = objstats.Count();
            int count = 1;

            Console.WriteLine($"Select {selecting_type} (or -1 to return a level): ");

            foreach (Datum obj in objstats){
                PrintStats(obj, count);
                count++;
            }

            int choice = GetChoice(options);
            if (choice != -1) {
                Stats recursiveMenu = (Stats)objstats[choice -1];
                exit.Add(stats);
                NavigationMenu(recursiveMenu, Select, exit, selections);
            } else {
                Exit();
            }
            
        } else {
            EntireStats(stats);
            GetChoice(0);
            Exit();
        }

        return selections;
    }

    private static void PrintStats(Datum s, int option = 0){
        string name = s.getName();
        string type = s.getType();
        
        string preface = (option == 0) ? "" : option.ToString() + ") ";

        Console.WriteLine($"{preface}{type}: {name}");

    }

    private static int GetChoice(int options){
        string range = "";
        if (options == 0){
            range = "-1 to return";
        } else {
            range = $"a number from 1-{options} or -1 to return";
        }

        Console.WriteLine($"Please input {range}");
        int Choice = int.Parse(Console.ReadLine());
        if (Choice > options ){
            Console.WriteLine("Invalid Range, please go lower");
            Choice = GetChoice(options);
        } else if (Choice == 0 || Choice < -1) {
            Console.WriteLine("Invalid Range, please go higher");
        }
        return Choice;
    }

    private static bool SelectPrompt(string name){
        Console.WriteLine($"Wouold you like to select {name} to compare? Please input 'y' or 'no' ");
        string answer = Console.ReadLine().ToLower();
        if (answer == "y"){
            return true;
        } else{return false;}
    }

    public static void Wait(string Msg = "Enter to continue"){
        Console.Write(Msg);
        Console.ReadLine();
    }
}