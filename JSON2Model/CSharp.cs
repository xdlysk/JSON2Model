using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSON2Model
{
    public class CSharp
    {
        public string Generate(string json)
        {
            var cd = new ClassDefine { Name = "YOUR_NAME" };
            if (json.StartsWith("["))
            {
                JArray jarray = JArray.Parse(json);
                MakeArray(cd,"key",jarray);
            }
            else
            {
                JObject jobject = JObject.Parse(json);
                foreach (var kv in jobject)
                {
                    Visit(cd, kv.Key, kv.Value);
                }
            }
            
            return cd.ToString(0);
        }




        private ClassDefine MakeClassDefine(string className, JToken token)
        {
            var cd = new ClassDefine { Name = className };

            foreach (JProperty kv in token)
            {
                Visit(cd, kv.Name, kv.Value);
            }

            return cd;
        }

        private void MakeArray(ClassDefine cd, string key, JArray jarray)
        {
            var first = jarray.First;
            if (jarray.Count == 0 || first == null)
            {
                cd.Properties.Add(key, "dynamic");
                return;
            }


            switch (first.Type)
            {
                case JTokenType.Boolean:
                    cd.Properties.Add(key, "bool[]");
                    break;
                case JTokenType.Guid:
                    cd.Properties.Add(key, "Guid[]");
                    break;
                case JTokenType.Float:
                    cd.Properties.Add(key, "float[]");
                    break;
                case JTokenType.Integer:
                    var vv = (JValue)first;
                    cd.Properties.Add(key, Convert.ToInt64(vv.Value) > int.MaxValue ? "long[]" : "int[]");
                    break;
                case JTokenType.String:

                    cd.Properties.Add(key, "string[]");
                    break;
                case JTokenType.Object:
                    var cdi = MakeClassDefine(key, first);
                    cd.InnserClassDefines.Add(cdi);
                    cd.Properties.Add(key, $"{key}[]");
                    break;
            }
        }

        private void Visit(ClassDefine cd, string key, JToken token)
        {
            if (token == null)
            {
                cd.Properties.Add(key, "dynamic");
                return;
            }
            switch (token.Type)
            {
                case JTokenType.Object:
                    cd.InnserClassDefines.Add(MakeClassDefine(key, token));
                    break;
                case JTokenType.Boolean:
                    cd.Properties.Add(key, "bool");
                    break;
                case JTokenType.Integer:
                    var v = (JValue)token;

                    cd.Properties.Add(key, Convert.ToInt64(v.Value) > int.MaxValue ? "long" : "int");
                    break;
                case JTokenType.String:

                    cd.Properties.Add(key, "string");
                    break;
                case JTokenType.Guid:
                    cd.Properties.Add(key, "Guid");
                    break;
                case JTokenType.Float:
                    cd.Properties.Add(key, "float");
                    break;
                case JTokenType.Array:
                    MakeArray(cd, key, (JArray)token);

                    break;
            }
        }
    }
}
