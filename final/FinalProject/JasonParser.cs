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
        
        return parse(root_node);
    }

    private static Stats parse(List<Newtonsoft.Json.Linq.JObject> node){
        List<Datum> node_list = new List<Datum>();
        string Obj_name = "";
        string Obj_type = "";
        foreach(Newtonsoft.Json.Linq.JObject nodeObj in node){
            Obj_name = nodeObj["name"].ToString(); 
            Obj_type = nodeObj["type"].ToString();
        
            if (nodeObj["contains"] is Newtonsoft.Json.Linq.JValue){
                Console.WriteLine($"***** {Obj_name}: {Obj_type}, contains: {nodeObj["contains"]} ");
                float Obj_data = float.Parse(nodeObj["contains"].ToString());
                node_list.Add(new Stat(Obj_name, Obj_data, Obj_type));
            
            } else if (nodeObj["contains"] is Newtonsoft.Json.Linq.JArray) {
                Console.WriteLine($"$$$$ {Obj_name}: {Obj_type}, contains: {nodeObj["contains"]} ");
                List<Newtonsoft.Json.Linq.JObject> Obj_node =
                    ((Newtonsoft.Json.Linq.JArray)nodeObj["contains"]).ToObject<List<Newtonsoft.Json.Linq.JObject>>();
                node_list.Add(parse(Obj_node));
            }
        }

        return new Stats(node_list, Obj_name, Obj_type);
    } 
}
