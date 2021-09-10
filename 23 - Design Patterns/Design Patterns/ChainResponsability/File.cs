using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResponsability
{
    public class File
    {
        public string FileName { get; }
        public string FileType { get; }
        public string FilePath { get; }

        public File(string fileName, string fileType, string filePath)
        {
            FileName = fileName;
            FileType = fileType;
            FilePath = filePath;
        }
    }
}
