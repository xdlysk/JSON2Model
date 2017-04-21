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

        public string ToString(int space)
        {
            var space1 = GetSpaces(space);
            var space2 = GetSpaces(space + 4);
            _sb.AppendLine($"{space1}public class {Name}");
            _sb.AppendLine($"{space1}{{");

            foreach (var property in Properties)
            {
                _sb.AppendLine($"{space2}public {property.Value} {property.Key} {{ get; set ;}}");
            }

            foreach (var innserClassDefine in InnserClassDefines)
            {
                _sb.Append(innserClassDefine.ToString(space+4));
            }

            _sb.AppendLine($"{space1}}}");
            return _sb.ToString();
        }

        private string GetSpaces(int width)
        {
            return string.Empty.PadLeft(width);
        }
    }
}
