using System.Dynamic;

public class Stats: Datum {
    private List<Datum> stats = new List<Datum>();
    private string name;
    private string type;
    
    public Stats(List<Datum> data, string n, string t ){
        stats = data;
        name = n;
        type = t;

        Console.WriteLine($"[STATS GROUP]created with name: {n} and type {t}");
    }

    public List<Datum> GetStats(){
        return stats;
    }
    public Datum getData(){
        foreach (Datum s in stats){
            
            // it will always return a Stats that is a list of stat, so instead of being 2 deep its just 1 deep, 
            if (s is Stats) {
                Stats c = (Stats)s;
                if (c.ContainsStat()){
                    return this;
                }
            }
            
            else {
                return this;
            }
        }
        return this;
    }

    public void Display(){
        Console.WriteLine($"{type}: {name}");
        foreach (Datum s in stats){
            s.Display();
        }
        Console.WriteLine("\n");
    }
    public string getName(){ return name;}
    public string getType(){ return type;}
    public bool Compare(Datum d1, Datum d2){
        return true;
    }
    
    public bool ContainsStat(){
        if (stats[1] is Stat){
            return true;
        } 
        return false;
    }
}

