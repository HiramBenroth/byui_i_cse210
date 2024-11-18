using System.Dynamic;

class SacredWrit  {
    // Is also a colection of Holy writings, but in a smaller block. 
    Dictionary<string, string> bookNames = new Dictionary<string, string>();

    public SacredWrit(string path){
        bookNames = GetFoldersDictionary(path);
    }


    private Dictionary<string, string> GetFoldersDictionary(string directory){
        Dictionary<string, string> foldersDict = new Dictionary<string, string>();

        if (!Directory.Exists(directory)){
            Console.WriteLine("The directory does not exist.");
            return foldersDict;
        }

        string[] items = Directory.GetDirectories(directory);
        foreach (var item in items){
            string folderName = Path.GetFileName(item);
            foldersDict[folderName] = item;
        }

        return foldersDict;
    }

    public bool ContainsBook(string book){
        foreach (string key in bookNames.Keys){
            if (key.ToLower().Equals(book.ToLower())) { 
                return true;
            }
        }
        return false;
    }

    public string GetVerseText(string book, int chapter, int verse){
        string path = bookNames[book] + $"/{chapter}.txt";
        Console.WriteLine(path);
        if (!File.Exists(path)) { 
            Console.WriteLine("The file does not exist."); 
            return ""; 
            } 
        try { 
            using (StreamReader reader = new StreamReader(path)) { 
                string line; 
                int currentLineNumber = 1; 
                while ((line = reader.ReadLine()) != null) { 
                    if (currentLineNumber == verse) { 
                        return line; 
                    } 
                    currentLineNumber++; 
                } 
                if (currentLineNumber < verse) {
                Console.WriteLine($"The file has fewer than {verse} lines."); }
            }
            }
        catch (Exception e) { 
            Console.WriteLine($"An error occurred: {e.Message}");
        }
        return "";
    }
}