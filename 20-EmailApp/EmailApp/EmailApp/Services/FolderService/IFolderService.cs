using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Services
{
    public interface IFolderService
    {
        List<string> GetAll();
        void Create(string folderName);
        void Remove(string folderName);

    }
}
