using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsability
{
    public class TextFileHandler : Handler
    {
        public Handler Handler { get; set; }
        private string HandlerName;

        public TextFileHandler(string handlerName)
        {
            this.HandlerName = handlerName;
        }

        public void Process(File file)
        {
            if (file.FileType.Equals("txt"))
            {
                Console.WriteLine("Procesando el archivo texto ... OK"); 
            } 
            else if(Handler != null)
            {
                Console.WriteLine("Delegando el proceso");
                Handler.Process(file);
            }
            else
            {
                Console.WriteLine($"{HandlerName} no pudo procesar el archivo");
            }
        }
    }
}
