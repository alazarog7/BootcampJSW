using EmailApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Services
{
    public interface IMailService
    {
        public Dictionary<Guid, Mail> GetByFolder(string folderName);
        public Mail GetById(Guid id);
        public void Create(Mail mail);
        public void Send(Tuple<Guid, Mail> mail);
        public void Delete(Guid id, string folderName);
        public void Move(string folderOrg, string folderDest, Guid id);
    }
}
