using EmailApp.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Services
{
    public class FolderService : IFolderService
    {
        private readonly DataSource _data;
        private readonly IMailService _mailService;

        public FolderService(DataSource data, IMailService mailService)
        {
            _data = data;
            _mailService = mailService;
        }

        public void Create(string folderName)
        {
            if ( !_data.CurrentUser.Folders.ContainsKey(folderName) )
            {
                _data.CurrentUser.Folders.Add(folderName, new List<Guid>());
                _data.Users.Add(_data.CurrentUser);
            }
        }

        public List<string> GetAll()
        {
            return _data.CurrentUser
                        .Folders
                        .Select(e => e.Key)
                        .ToList();
        }

        public void Remove(string folderName)
        {
            _data.CurrentUser
                 .Folders[folderName]
                 .ToList()
                 .ForEach( e => {
                     _mailService.Move(folderName, "inbox", e);
                 }); 

            _data.CurrentUser
                .Folders
                .Remove(folderName);

            _data.Users
                .Add(_data.CurrentUser);
        }
    }
}
