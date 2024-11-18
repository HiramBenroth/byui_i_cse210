using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Verse{
    private Random rand = new Random();
    private int _vNum; 
    private List<Word> _text = new List<Word>();

    public Verse(string txt){
        
        List<string> txtSplit = new List<string>(txt.Split('#'));
        _vNum = int.Parse(txtSplit[0]);
        
        List<string> words = new List<string>(txtSplit[1].Split());

        foreach (string s in words) {
            Word w = new Word(s);
            _text.Add(w);
        }
    }

    public void hideWords(){
        for (int x=0; x < 3; x++){
            if (IsHidden() == true){
                break;
            }

            Word w = getRandWord();
            w.Hide();
            

        }
    }

    private Word getRandWord(){
        int r;
        do{ 
           r = rand.Next(0, _text.Count);
        } while (_text[r].hid == true);
        return _text[r];
    } 

    public void Display(){
        Console.Write($"{_vNum}) ");
        int lineCount = 0;
        foreach (Word w in _text){
            w.Display();
            lineCount++;

            if (lineCount > 10) {
                Console.Write("\n");
                lineCount = 0;
            }
        }
    }

    public bool IsHidden(){
        foreach (Word w in _text){
            if (w.hid == false) {
                return false;
            }
        }
        return true;
    }


}