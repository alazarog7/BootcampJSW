using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsability
{
    public class AudioFileHandler : Handler
    {
        public Handler Handler { get; set; }
        private string HandlerName;

        public AudioFileHandler(string handlerName)
        {
            this.HandlerName = handlerName;
        }
        public void Process(File file)
        {
            if (file.FileType.Equals("mp3"))
            {
                Console.WriteLine("Procesando el archivo mp3 ... OK");
            }
            else if (Handler != null)
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
