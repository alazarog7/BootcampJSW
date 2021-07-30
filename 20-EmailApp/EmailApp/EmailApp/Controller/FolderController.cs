using EmailApp.Decorators;
using EmailApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Controller
{
    public class FolderController : BaseController
    {

        private IProfileService _profileService;
        private IFolderService _folderService;

        public FolderController(IStarterApp main, IProfileService profileService, IFolderService folderService) : base(main)
        {
            _profileService = profileService;
            _folderService = folderService;
        }

        [View]
        public override void Start()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"WELCOME {_profileService.GetCurrent().FullName}");
            Console.WriteLine("---------------------------------------\n\n\n");

            Console.WriteLine("1. Create a folder");
            Console.WriteLine("2. Remove folder");
            Console.WriteLine("3. Return");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    this.CreateFolder();
                    break;
                case 2:
                    this.RemoveFolder();
                    break;
                default:
                    main.Route("AccountController");
                    break;
            }
        }

        [View]
        private void CreateFolder()
        {
            Console.WriteLine("Folder's name: ");
            
            string folderName = Console.ReadLine();

            _folderService.Create(folderName);

            main.Route("FolderController");
        }

        [View]
        private void RemoveFolder()
        {
            Console.WriteLine("Folder's name: ");

            string folderName = Console.ReadLine();

            _folderService.Remove(folderName);

            main.Route("FolderController");
        }
    }
}
