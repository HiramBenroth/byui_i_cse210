using System;
using System.Diagnostics;

class Program {
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        UserInterface.Welcome();
        bool running = true;
        while (running) {
            UserInterface.DisplayMainMenu();
            int select = int.Parse(UserInterface.GetSingleLine("What do you choose? "));

            switch (select) {
                case 1:
                    journal.newEntry();
                    break;
                case 2:
                    journal.DisplayJournal();
                    break;
                case 3:
                    journal.SaveToFile();
                    break;
                case 4:
                    journal.LoadFromFile();
                    break;
                case 5:
                    UserInterface.Goodbye();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Is not a valid option, please try again");
                    break;

            }

        }

        
    


    }
}