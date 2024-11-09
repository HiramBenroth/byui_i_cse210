public class UserInterface {
    
    public static string GetSingleLine(string question) {
        Console.Write(question);
        string ret = Console.ReadLine();
        Console.WriteLine("");
        return ret;
        
    }

    public static string GetMultiline(string question) {
        Console.WriteLine(question);
        string line;
        string ret = "";
        do {
            line = Console.ReadLine();
            ret += line + "/";

        } while (line != string.Empty);

        return ret;
    }

    public static void DisplayMainMenu() {
        Console.WriteLine("These are your Opitons\n\t" +
            "1) Write a new entry\n\t" + 
            "2) Display Journal\n\t" +
            "3) Save to file\n\t"+
            "4) Load a Journal from File\n\t"+
            "5) Exit Journal "
            );
    }

    public static void Welcome(){
        Console.WriteLine("Welcome to your Journal Asistant");
    }

    public static void Goodbye(){
        Console.WriteLine("Goodbye, Hope to see you soon. ");
    }

    public static void DisplayEntry(Entry entry){
        
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine($"Entry #{entry.entryNum} \nEntry date: {entry.date} || Prompt: {entry.prompt}");
        
        string[] lines = entry.userText.Split("/");
        foreach (string l in lines) {
            Console.WriteLine(l);
        }
            
    }
}