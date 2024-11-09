public class Entry {

    public int entryNum;
    public string prompt;
    public string date = DateTime.Now.ToShortDateString(); 
    public string userText; 

    public Entry(){
    }


    public void InitializeEntry(string p, int num) {
        
        prompt =  p;
        userText = UserInterface.GetMultiline( "\n" + date + " || Prompt: " + prompt);
        entryNum = num;
        
    }
}