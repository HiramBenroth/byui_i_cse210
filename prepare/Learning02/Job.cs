 public class Job {
    public string Company;
    public string JobTitle;
    public string StartYear;
    public string EndYear;

    public Job(){}


    public void PrintJob(){
        Console.WriteLine($"{JobTitle} ({Company}) {StartYear}-{EndYear}");
    }


}