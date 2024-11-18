public class Word{
    private string _word;
    public bool hid = false;


    public Word(string w){
        _word = w;
    }
    public void Hide(){
        string n = "";
        foreach( char c in _word){
            n += '_';
        }
        _word = n;
        hid = true;
    }

    public void Display(){
        Console.Write(_word + " ");
    }
}
