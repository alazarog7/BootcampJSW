using FactoryMethod.ConcreteCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class OrderXmlParser : XmlParse
    {
        public string parse()
        {
            return "<Order>This is an Order</Order>";
        }
    }
}
