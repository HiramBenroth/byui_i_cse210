using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Program
{
    public static void Main(string[] args)
    {
        // Load JSON from file
        string filePath = "data.json"; // Ensure the file is in the same directory as the executable
        string json = File.ReadAllText(filePath);

        // Parse JSON into the object model
        Stats league = ParseJsonToStats(json);

        // Display the object hierarchy
        Console. WriteLine($"League: {league.getName()}");
        foreach (Stats teamStats in league.GetStats()){
            Console.WriteLine($"\tTeam Name: {teamStats.getName()}");
            foreach (Stats playerStats in teamStats.GetStats()){
                Console.WriteLine($"\t\tPlayer: {playerStats.getName()}");
                foreach (Stat stat in playerStats.GetStats()){
                    Console.WriteLine($"\t\t\t{stat.GetStatype()}: {stat.GetData()}");
                }
            }
        }
    }

    public static Stats ParseJsonToStats(string json){

    // Deserialize JSON into a dynamic object
    Dictionary<string, object> root = 
        JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

    // Parse the team data
    // uses Newtonsoft to make a list of JObjects, 
    List<Datum> teams = new List<Datum>();
    List<Newtonsoft.Json.Linq.JObject> teamsArray = ((Newtonsoft.Json.Linq.JArray)root["teams"]).ToObject<List<Newtonsoft.Json.Linq.JObject>>();
    string league = root["name"].ToString();

    foreach (Newtonsoft.Json.Linq.JObject teamObj in teamsArray)
    {
        string teamName = teamObj["name"].ToString();
        List<Newtonsoft.Json.Linq.JObject> playersArray = ((Newtonsoft.Json.Linq.JArray)teamObj["players"]).ToObject<List<Newtonsoft.Json.Linq.JObject>>();
        List<Datum> players = new List<Datum>();

        foreach (Newtonsoft.Json.Linq.JObject playerObj in playersArray)
        {
            string playerName = playerObj["name"].ToString();
            float pointsPerGame = float.Parse(playerObj["points_per_game"].ToString());
            float reboundsPerGame = float.Parse(playerObj["rebounds_per_game"].ToString());
            float assistsPerGame = float.Parse(playerObj["assists_per_game"].ToString());

            List<Datum> playerStats = new List<Datum>
            {
                new Stat(playerName, pointsPerGame, "points_per_game"),
                new Stat(playerName, reboundsPerGame, "rebounds_per_game"),
                new Stat(playerName, assistsPerGame, "assists_per_game")
            };

            
            players.Add(new Stats(playerStats, playerName));
        }

        teams.Add( new Stats(players, teamName)); // Assuming one team for simplicity
    }

    return new Stats(teams, league);
    }
}

public class Datum { }

public class Stats : Datum
{
    private List<Datum> stats;
    private string name;

    public Stats(List<Datum> data, string n)
    {
        stats = data;
        name = n;
    }

    public List<Datum> GetStats()
    {
        return stats;
    }

    public Datum getData()
    {
        foreach (Datum s in stats)
        {
            if (s is Stats && ((Stats)s).ContainsStat())
            {
                return this;
            }
            else
            {
                return this;
            }
        }
        return this;
    }

    public string getName()
    {
        return name;
    }

    public bool ContainsStat()
    {
        if (stats.Count > 1 && stats[1] is Stat)
        {
            return true;
        }
        return false;
    }
}

public class Stat : Datum
{
    private string statype;
    private string name;
    private float data;

    public Stat(string n, float d, string t)
    {
        name = n;
        statype = t;
        data = d;
    }

    public string GetName()
    {
        return name;
    }

    public string GetStatype()
    {
        return statype;
    }

    public float GetData()
    {
        return data;
    }
}
