using System.Data;
using System.Dynamic;

public class Stats: Datum {
    private List<Datum> stats = new List<Datum>();
    private string name;
    private string type;
    
    public Stats(List<Datum> data, string n, string t ){
        stats = data;
        name = n;
        type = t;
    }

    public List<Datum> GetStats(){
        return stats;
    }
    public Stats getData(){
        List<Stat> compiledStats = new List<Stat>(); //change to datum later
        foreach (Datum s in stats){
            if (s is Stats) {  // this looks to see if it is a bigger stat, Like team, or league
                Stats Contains_stat = (Stats)s;
                
                if (Contains_stat.ContainsStat()== false){ // This makes sure that the Stats only contains "stat"
                    Contains_stat = Contains_stat.getData();
                }
                
                if (compiledStats.Count() == 0) {
                    foreach (Stat stat in Contains_stat.GetStats()){
                        compiledStats.Add(stat);
                    }
                } else {
                    int compStat_INDEX = 0;
                    foreach (Stat stat in Contains_stat.GetStats()){
                        compiledStats[compStat_INDEX] = stat.Combine(compiledStats[compStat_INDEX]);
                        compStat_INDEX++;
                    }
                }
            }
            else if(s is Stat){ // this is if its the lowest level, if it only contains singular Stat
                Stat endstat = (Stat)s;
                compiledStats.Add(endstat);
            }

        }
        foreach (Stat s in compiledStats){
            s.UpdateType(stats.Count());
        }

        List<Datum> Datumlist = new List<Datum>(compiledStats);
        return new Stats(Datumlist, name, type);
    }

    public string getName(){ return name;}
    public string getType(){ return type;}

    public bool ContainsStat(){
        if (stats[1] is Stat){
            return true;
        } 
        return false;
    }
}

