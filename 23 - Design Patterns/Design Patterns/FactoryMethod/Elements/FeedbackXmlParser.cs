using FactoryMethod.ConcreteCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public class FeedbackXmlParser : XmlParse
    {
        public string parse()
        {
            return "<Feedback>The message should be rendered</Feedback>";
        }
    }
}
