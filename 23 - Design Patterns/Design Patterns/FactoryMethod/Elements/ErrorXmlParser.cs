using FactoryMethod.ConcreteCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class ErrorXmlParser : XmlParse
    {
        public string parse()
        {
            return "<Error>Error de Sistema</Error>";
        }
    }
}
