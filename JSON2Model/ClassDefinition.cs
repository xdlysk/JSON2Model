using System.Collections.Generic;
using System.Text;

namespace JSON2Model
{
    public class ClassDefinition
    {
        public ClassDefinition()
        {
            Properties = new List<PropertyDefinition>();
            NestClassDefinitions = new List<ClassDefinition>();
        }
        public string Name { get; set; }

        public List<PropertyDefinition> Properties { get; set; }

        public List<ClassDefinition> NestClassDefinitions { get; set; }

    }
}
