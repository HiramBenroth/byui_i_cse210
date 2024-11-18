public class Passage{
    private Reference _reference;
    private List<Verse> _Verses = new List<Verse>();

    public Passage(Reference r, List<string> verses){
        _reference = r;
        
        foreach (string s in verses){
            Verse v = new Verse(s);
            _Verses.Add(v);
        }
        Console.WriteLine(_Verses.Count);
    }

    public void Display(){
        Console.Clear();
        _reference.Display();
        foreach (Verse v in _Verses){
            v.Display();
            Console.WriteLine("\n");
        }
    }

    public void Memorize(){
        Display();
        Console.WriteLine("Press enter to continue or 'quit' to exit");
        string inp = Console.ReadLine();

        while (VersesHidden() == false && inp != "quit"){
            foreach (Verse v in _Verses){
                v.hideWords();
            }
            Display();

            Console.WriteLine("Press enter to continue or 'quit' to exit");
            inp = Console.ReadLine();
        }

    }


    private bool VersesHidden(){
        foreach (Verse v in _Verses){
            if (v.IsHidden() == false) {
                return false;
            }
            
        }
        return true;
    }
}