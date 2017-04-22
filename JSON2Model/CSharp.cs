using System;
using System.Text;

namespace JSON2Model
{
    public class CSharp : ILanguage
    {
        private readonly bool _formatClassName;
        private readonly bool _useField;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="useField">true，字段，false，属性</param>
        /// <param name="formatClassName">首字母大写，遇下划线则删除并将下划线下一个字符转为大写</param>
        public CSharp(bool useField,bool formatClassName)
        {
            _useField = useField;
            _formatClassName = formatClassName;
        }

        public CSharp()
            :this(true,false)
        {
            
        }

        public string GenerateCode(ClassDefinition classDefinition)
        {
            return GenerateCode(classDefinition, 0);
        }

        private string GenerateCode(ClassDefinition classDefinition, int space)
        {
            StringBuilder sb = new StringBuilder();
            var space1 = GetSpaces(space);
            var space2 = GetSpaces(space + 4);
            sb.AppendLine($"{space1}public class {FormatClassName(classDefinition.Name)}");
            sb.AppendLine($"{space1}{{");

            foreach (var property in classDefinition.Properties)
            {
                string typename;
                if (property.PropertyType == JsonType.Class)
                {
                    typename = FormatClassName(property.ClassName);
                    if (property.IsArray)
                    {
                        typename += "[]";
                    }
                }
                else
                {
                    typename = GetTypeString(property.PropertyType, property.IsArray);
                }
                var forp = _useField ? ";" : " { get; set; }";

                sb.AppendLine($"{space2}public {typename} {property.Name}{forp}");
            }

            foreach (var innserClassDefine in classDefinition.NestClassDefinitions)
            {
                sb.Append(GenerateCode(innserClassDefine, space + 4));
            }

            sb.AppendLine($"{space1}}}");
            return sb.ToString();
        }

        private string GetTypeString(JsonType jsonType, bool isarray)
        {
            string typename;
            switch (jsonType)
            {
                case JsonType.Boolean:
                    typename = "bool";
                    break;
                case JsonType.Float:
                    typename = "float";
                    break;
                case JsonType.Int:
                    typename = "int";
                    break;
                case JsonType.Long:
                    typename = "long";
                    break;
                case JsonType.String:
                    typename = "string";
                    break;
                case JsonType.UnKnow:
                default:
                    typename = "dynamic";
                    break;
            }
            if (isarray)
            {
                typename = typename + "[]";
            }
            return typename;
        }

        private string GetSpaces(int width)
        {
            return string.Empty.PadLeft(width);
        }

        private string FormatClassName(string className)
        {
            if (_formatClassName)
            {
                var first = className[0];
                className = first.ToString().ToUpper() + className.Remove(0, 1);
                int index;
                while ((index = className.IndexOf("_", StringComparison.Ordinal)) >= 0)
                {
                    className = className.Remove(index, 1);
                    if (className.Length != index)
                    {
                        var upper = className[index];
                        className = className.Remove(index, 1);
                        className = className.Insert(index, upper.ToString().ToUpper());
                    }
                }
            }
            
            return className;
        }
    }
}
