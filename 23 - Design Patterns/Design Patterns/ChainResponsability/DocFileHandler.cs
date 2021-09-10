using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsability
{
    public class DocFileHandler : Handler
    {
        public Handler Handler { get; set; }
        private string HandlerName;

        public DocFileHandler(string handlerName)
        {
            this.HandlerName = handlerName;
        }
        public void Process(File file)
        {
            if (file.FileType.Equals("doc"))
            {
                Console.WriteLine("Procesando el archivo txt ... OK");
            }
            else if (Handler != null)
            {
                Console.WriteLine("Delegando el proceso");
                Handler.Process(file);
            }
            else
            {
                Console.WriteLine("No se pudo procesar el archivo");
            }
        }
    }
}
