using System.Security.Cryptography;
using System.IO;
using System.Runtime.InteropServices;
public class Journal {
    List<Entry> Entries = new List<Entry>(); 
    
    List<string> Promt = new List<string>(){
                            "What made you happy today?",
                            "Who did you help today?",
                            "How did someone brighten your day?",
                            "How did you see God's hand in your day?",
                            "What goal did you set?",
                            "What have you learned today?",
                    };

    public void DisplayJournal(){
        foreach (Entry e in Entries){
            UserInterface.DisplayEntry(e);
        }
    }

    public void newEntry(){
        Random rand = new Random();
        int randIndex = rand.Next(0,Promt.Count - 1);
        
        string PrompEntry = Promt[randIndex];

        Entry newEntry = new Entry();

        newEntry.InitializeEntry(PrompEntry, Entries.Count + 1);

        Entries.Add(newEntry);

    }

    public void SaveToFile() {
        string fileName = UserInterface.GetSingleLine("What is the file name?");
        string dirPath = Directory.GetCurrentDirectory() + "/";
        Console.WriteLine(dirPath+fileName);
        using (StreamWriter outputFile = new StreamWriter(fileName)){
            
            foreach( Entry e in Entries) {
                string fileLine = $"{e.entryNum},{e.date},{e.prompt},{e.userText}";
                outputFile.WriteLine(fileLine);
                Console.WriteLine(fileLine);

            }
        }

    }

    public void LoadFromFile() {
        string fileName = UserInterface.GetSingleLine("What is the file name?");
        string dirPath = Directory.GetCurrentDirectory() + "/";
        string[] journal = System.IO.File.ReadAllLines(dirPath + fileName);
        

        foreach (string line in journal) {
            string[] parts = line.Split(",");
            Entry newEntry = new Entry();

            newEntry.entryNum = int.Parse(parts[0]);
            newEntry.date = parts[1];
            newEntry.prompt = parts[2];
            newEntry.userText = parts[3];

            Entries.Add(newEntry);
        }
    }
}