using System.Collections.Generic;
using System.Text;

namespace JSON2Model
{
    class ClassDefine
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public ClassDefine()
        {
            Properties = new Dictionary<string, string>();
            InnserClassDefines = new List<ClassDefine>();
        }
        public string Name { get; set; }

        public Dictionary<string, string> Properties { get; set; }

        public List<ClassDefine> InnserClassDefines { get; set; }

        public override string ToString()
        {
            _sb.AppendLine($"public class {Name}");
            _sb.AppendLine("{");

            foreach (var property in Properties)
            {
                _sb.AppendLine($"public {property.Value} {property.Key} {{ get; set ;}}");
            }

            foreach (var innserClassDefine in InnserClassDefines)
            {
                _sb.Append(innserClassDefine);
            }

            _sb.AppendLine("}");
            return _sb.ToString();
        }
    }
}
