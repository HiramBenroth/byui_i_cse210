using System;
using System.Collections.Generic; 
using System.IO;

public class Scripture{
    // A Scripture is a compilation of sacred Writ
    private string libraryPath = Directory.GetCurrentDirectory() + "/Library";
    private List<SacredWrit> sacredWrits = new List<SacredWrit>();
    public Scripture(){
        Console.WriteLine(libraryPath);
        List<string> writsAvailable = GetFoldersInDirectory(libraryPath);

        foreach (string f in writsAvailable){
            SacredWrit s = new SacredWrit(f);
            sacredWrits.Add(s);
        }
    }
    public List<string> GetVerse(Reference v){
        List<string> ret = new List<string>();
        
        SacredWrit Writ = GetSacredWrit(v);
        Console.Write(Writ);

        int start_verse = (int)v.GetVerse().X;
        int end_verse = (int)v.GetVerse().Y;
        string book = v.GetBook();
        int chapter = v.GetChapter();
        if (end_verse != 0) {
            for (int current_verse = start_verse; current_verse <= end_verse; current_verse++) {
                string Text = Writ.GetVerseText(book, chapter, current_verse);
                ret.Add(Text);
                Console.WriteLine($"Current Verse: {current_verse}");
            }
        } else {
            
            string text = Writ.GetVerseText(book, chapter, start_verse);
            Console.WriteLine($"Current Text: {text}");
            ret.Add(text);
        }
        return ret;
    } 

    private List<string> GetFoldersInDirectory(string directory){
        List<string> folders = new List<string>();

        if (!Directory.Exists(directory)) { 
            Console.WriteLine("The directory does not exist.");
            return folders; 
        } 
        string[] items = Directory.GetDirectories(directory);
        folders.AddRange(items); 
         
        return folders;
    }

    private SacredWrit GetSacredWrit(Reference v){
        string book = v.GetBook();
        foreach (SacredWrit sw in sacredWrits){
            if (sw.ContainsBook(book)) {
                return sw;
            }
        }
        return null;
    }

}


