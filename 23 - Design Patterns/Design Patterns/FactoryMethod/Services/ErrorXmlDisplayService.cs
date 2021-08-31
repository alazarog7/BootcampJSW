using FactoryMethod.ConcreteCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Services
{
    public class ErrorXmlDisplayService : DisplayService
    {

        protected override XmlParse Parser()
        {
            return new ErrorXmlParser();
        }
    }
}
