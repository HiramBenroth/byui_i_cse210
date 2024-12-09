using System.Diagnostics.Tracing;
using Newtonsoft.Json;

public class JasonPaser {
    public static Stats LoadJson(string fileName){
        // Path to your JSON file
        string json = File.ReadAllText(fileName);
        
        Stats league = genericParseJson(json);

        return league;
    }   
    private static Stats genericParseJson(string json){
        // Deserialize JSON into a dynamic object
        Dictionary<string, object> root = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        
        List<Newtonsoft.Json.Linq.JObject> root_node =
        ((Newtonsoft.Json.Linq.JArray)root["root"]).ToObject<List<Newtonsoft.Json.Linq.JObject>>();
        
        List<Datum> Stats = new List<Datum>();

        ListModifier(Stats, root_node);

        return (Stats)Stats[0];

    }
    static void ListModifier(List<Datum> CompileList, List<Newtonsoft.Json.Linq.JObject> Node){
        foreach(Newtonsoft.Json.Linq.JObject nodeObj in Node){

            string Obj_name = nodeObj["name"].ToString(); 
            string Obj_type = nodeObj["type"].ToString();
        
            //checks specific obj to see if it has a value
            if (nodeObj["contains"] is Newtonsoft.Json.Linq.JValue){
                float Obj_data = float.Parse(nodeObj["contains"].ToString());
                CompileList.Add(new Stat(Obj_name, Obj_data, Obj_type)); // two objects are created with this name see line 46
            
            } else if (nodeObj["contains"] is Newtonsoft.Json.Linq.JArray) {
                List<Newtonsoft.Json.Linq.JObject> ChildrenNodes =
                    ((Newtonsoft.Json.Linq.JArray)nodeObj["contains"]).ToObject<List<Newtonsoft.Json.Linq.JObject>>();

                List<Datum> complist = new List<Datum>();
                ListModifier(complist, ChildrenNodes);
                
                CompileList.Add(new Stats(complist, Obj_name, Obj_type));
                
            } 
            // on the last object weather its a stat or not it will still create a [Stats] on the end of this.
        }

    }
}
