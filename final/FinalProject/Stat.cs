using System.Dynamic;

class Stat : Datum {
    private string statype; // type of analysis performed
    private string name;
    private float data;
    public Stat(string n, float d, string t){
        name = n;
        statype = t;
        data = d;
    }

    public float getStat(){
        return data;
    }

    public void Display(){
        Console.WriteLine($"{name}: {data}");
    }
    public Datum getData(){ return this;}
    public string getName(){ return name;}
    public string getType(){return statype;}
    public bool Compare(Datum a, Datum b){
        return true;
    }


}