using System.Dynamic;
using System.Numerics;
using System.Runtime.Intrinsics;

public class Reference{
    private string _book;
    private int _chapter;
    private Vector2 _vnum;

    public Reference(){
        Console.Write("\nWhat is the book? ");
        _book = Console.ReadLine();
        Console.Write("What is the Chapter? ");
        _chapter = int.Parse(Console.ReadLine());
        Console.Write("What is the first Verse? ");
        _vnum.X = int.Parse(Console.ReadLine());
        Console.Write("If there are multiply verse, put the last one, otherwise do 0: ");
        _vnum.Y = int.Parse(Console.ReadLine());
    }
    public Reference(string b = "", int c = 0, int v1 = 0 , int v2 = 0){
        _book = b;
        _chapter = c;
        _vnum = new Vector2(v1,v2);
        
        Console.Write($"\nWhat is the book? {_book}");
        Console.Write($"\nWhat is the Chapter? {_chapter}");
        Console.Write($"\nWhat is the first Verse? {v1}");
        Console.Write($"\nIf there are multiply verse, put the last one, otherwise do 0: {v2}");
        Console.ReadLine();


    }   

    public void Display(){
        Console.Write($"{_book} {_chapter}: {_vnum.X}");
        if (_vnum.Y != 0 ) {Console.Write($"-{_vnum.Y}\n");
        } else {Console.Write("\n");}
    }

    public string GetBook(){
        return _book;
    }
    public int GetChapter(){
        return _chapter;
    }
    public Vector2 GetVerse(){
        return _vnum;
    }
}
