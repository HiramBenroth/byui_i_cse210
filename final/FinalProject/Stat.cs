using System.Dynamic;
using System.Text.RegularExpressions;

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
    public string getName(){ return name;}
    public string getType(){return statype;}

    public Stat Combine(Stat s = null){
        float d = 0;
        
        if (s == null) {} else if (name == s.getName()){

            d = data + s.getStat();
        } 
        return new Stat(name,  d, statype);
    }

    public void UpdateType(int Avg){
        switch (statype){
            case "Avg":
                data = data / Avg;
                break;
            case "Sum":
                break;
        }
    }

}