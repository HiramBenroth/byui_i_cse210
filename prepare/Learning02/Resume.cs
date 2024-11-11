using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

public class Resume {
    List<Job> Jobs = new List<Job>();
    string Name;
    
    public Resume(){
        Console.Write("What is your name? ");
        Name = Console.ReadLine();

        List<String> Prompts = new List<string>() {"Company","Job Title", "Start Year", "End Year"};
        
        bool HasMoreJobs = true;
        int jobcount = 1;
        while (HasMoreJobs) { 
            Console.WriteLine($"\nJob number {jobcount}.\n");
            Job newjob = new Job();

            //
            foreach (string p in Prompts) {
                Console.Write($"What is the {p}? ");
                string val = Console.ReadLine();

                switch (p) {
                    case "Company":
                        newjob.Company = val;
                        break;
                    case "Job Title":
                        newjob.JobTitle = val;
                        break;
                    case "Start Year":
                        newjob.StartYear = val;
                        break;
                    case "End Year":
                        newjob.EndYear = val;
                        break;
                    default:
                        break;
                }
            }

            Jobs.Add(newjob);
            

            Console.Write("Do you want to add Another Job?(y/n) ");
            if (Console.ReadLine() == "n") { HasMoreJobs = false;}

            jobcount++;
        }
    }

    public void Display() {
        Console.WriteLine($"\nName: {Name}");

        foreach (Job j in Jobs) {
            Console.WriteLine("\n-------------------------");
            j.PrintJob();

        }
    }
}