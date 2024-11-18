using System;
using System.Numerics;

class Program{
    static void Main(string[] args){
        Scripture scripture = new Scripture();
        do {
            Console.Clear();
            Reference newRef = new Reference();
            List<string> text = scripture.GetVerse(newRef);
            Passage newPas = new Passage(newRef, text);
            newPas.Memorize();
        } while(DoesContinue());

    }


    static bool DoesContinue(){
        //Console.Clear();
        Console.WriteLine("\n Press enter to memorize another scripture or 'quit' to exit. ");
        if (Console.ReadLine() == "quit") {
            return false;
        }
        return true;
    }
}