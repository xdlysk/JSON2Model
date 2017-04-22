using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON2Model
{
    public interface IJsonParser
    {
        ClassDefinition Parse(string json);
    }
}
