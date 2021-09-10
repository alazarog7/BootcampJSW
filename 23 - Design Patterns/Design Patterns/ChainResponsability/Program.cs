using System;

namespace ChainResponsability
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler textHandler = new TextFileHandler("Text Handler");
            Handler docHandler = new DocFileHandler("Doc Handler");
            Handler excelHandler = new ExcelFileHandler("Excel Handler");
            Handler audioHandler = new AudioFileHandler("Audio Handler");
            Handler videoHandler = new VideoFileHandler("Video Handler");
            Handler imageHandler = new ImageFileHandler("Image Handler");

            textHandler.Handler = docHandler;
            docHandler.Handler = excelHandler;
            excelHandler.Handler = audioHandler;
            audioHandler.Handler = videoHandler;
            videoHandler.Handler = imageHandler;

            File file = new File("Archivo.txt", "txt", "./");
            textHandler.Process(file);

            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");

            file = new File("Archivo.doc", "doc", "./");
            textHandler.Process(file);

            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");

            file = new File("Iamgen.jpg", "jpg", "./");
            textHandler.Process(file);


            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");

            file = new File("Archivo.mp4", "mp4", "./");
            textHandler.Process(file);

            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");


            file = new File("Archivo.sh", "sh", "./");
            textHandler.Process(file);
        }
    }
}
