using FactoryMethod.ConcreteCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class ResponseXmlParser : XmlParse
    {
        public string parse()
        {
            return "<Response>The element 15 was createdr</Response>";
        }
    }
}
