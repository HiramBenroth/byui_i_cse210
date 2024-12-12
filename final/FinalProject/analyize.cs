public class Analyze {
    static public List<Stats> Combine(List<Stats> toCombine){
        List<Stats> combined = new List<Stats>();
        foreach (Stats s in toCombine){
            combined.Add(s.getData());
        }
        return combined;
    }


    static public void Compare(List<Stats> ToCompare){
        Dictionary<string, int> EvaluatedStats = RateStats(ToCompare);

        string higherscore = EvaluatedStats.OrderByDescending(pair => pair.Value).First().Key;
        
        Display.Wait($"The anylizer predicts that {higherscore} will win");


    }
    static private Dictionary<string, int> RateStats(List<Stats> data){
        //initialize retrun variable
        Dictionary<string, int> scores = new Dictionary<string, int>();
        
        // List for easier hold of Stats to compare
        List<List<Stat>>  compare =  new List<List<Stat>>();
        
        // Set the values in the compare and Scores dict    
        foreach (Stats d in data ){
            List<Stat> statlist = new List<Stat>();
            foreach (Stat s in d.GetStats()){
                statlist.Add(s);
            }
            compare.Add(statlist);

            scores[d.getName()] = 0;
        };

        int size = compare[0].Count();
        
        for (int i = 0; i < size; i++){
            float a = compare[0][i].getStat();
            float b = compare[1][i].getStat();
            if ( a > b){
                string nameA = data[0].getName();
                scores[nameA]++;
            }
            else if (a < b){
                string nameB = data[1].getName();
                scores[nameB]++;
            }
        }

        return scores;
    }


    
}