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
            var cd = new ClassDefine();

            JObject jobject = JObject.Parse(json);
            foreach (var kv in jobject)
            {
                Visit(cd,kv.Key,kv.Value);
            }
            return cd.ToString();
        }

        


        private ClassDefine MakeClassDefine(string className,JToken token)
        {
            var cd = new ClassDefine {Name = className};

            foreach (JProperty kv in token)
            {
                Visit(cd, kv.Name,kv.Value);
            }

            return cd;
        }

        private void MakeArray(string classname, JArray jarray)
        {
            
        }

        private void Visit(ClassDefine cd,string key, JToken token)
        {
            if (token == null)
            {
                cd.Properties.Add(key,"dynamic");
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
                    cd.Properties.Add(key,"int");
                    break;
                case JTokenType.String:
                    cd.Properties.Add(key, "string");
                    break;
                case JTokenType.Array:
                    if (((JArray) token).Count == 0)
                    {
                        cd.Properties.Add(key, "dynamic");
                    }
                    else
                    {
                        var cdi = MakeClassDefine(key, token.First);
                        cd.InnserClassDefines.Add(cdi);
                        cd.Properties.Add(key, $"{key}[]");
                    }
                    
                    break;
            }
        }
    }
}
