using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace JSON2Model
{
    public class NewtonsoftParser : IJsonParser
    {
        public ClassDefinition Parse(string json)
        {
            if (json.StartsWith("["))
            {
                JArray jarray = JArray.Parse(json);
                var first = jarray.OrderByDescending(x => x.Count()).FirstOrDefault();
                return MakeClassDefine("YourClass",first);
            }
           
            var cd = new ClassDefinition {Name = "YourClass" };
            JObject jobject = JObject.Parse(json);
            foreach (var kv in jobject)
            {
                Visit(cd, kv.Key, kv.Value);
            }
            
            return cd;
        }

        private ClassDefinition MakeClassDefine(string className, JToken token)
        {
            var cd = new ClassDefinition { Name = className };
            if (token != null)
            {
                foreach (var jToken in token)
                {
                    var kv = (JProperty) jToken;
                    Visit(cd, kv.Name, kv.Value);
                }
            }
            
            return cd;
        }

        private void Visit(ClassDefinition cd, string name, JToken token, bool isarray = false)
        {
            PropertyDefinition pd = new PropertyDefinition
            {
                Name = name,
                IsArray = isarray,
                ClassName = name
            };
            if (token == null)
            {
                pd.PropertyType = JsonType.UnKnow;
                cd.Properties.Add(pd);
                return;
            }
            switch (token.Type)
            {
                case JTokenType.Object:
                    cd.NestClassDefinitions.Add(MakeClassDefine(name, token));
                    pd.PropertyType = JsonType.Class;
                    break;
                case JTokenType.Boolean:
                    pd.PropertyType = JsonType.Boolean;
                    break;
                case JTokenType.Integer:
                    var v = (JValue)token;
                    pd.PropertyType = Convert.ToInt64(v.Value) > int.MaxValue ? JsonType.Long : JsonType.Int;
                    break;
                case JTokenType.String:
                    pd.PropertyType = JsonType.String;
                    break;
                case JTokenType.Float:
                    pd.PropertyType = JsonType.Float;
                    break;
                case JTokenType.Array:
                    var first = token.OrderByDescending(x=>x.Count()).FirstOrDefault();
                    Visit(cd, name, first,true);
                    return;
            }
            cd.Properties.Add(pd);
        }
        
    }
}
