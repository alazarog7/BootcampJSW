using FactoryMethod.ConcreteCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public abstract class DisplayService
    {
        protected abstract XmlParse Parser();

        public void Display()
        {
            XmlParse parser = Parser();
            string render = parser.parse();
            Console.WriteLine(render);
        }
    }
}
