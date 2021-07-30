using EmailApp.Controller;
using EmailApp.Decorators;
using EmailApp.Entities;
using EmailApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp
{
    public class MailController: BaseController
    {
        private IMailService _mailService;
        private IFolderService _folderService;
        private IProfileService _profileService;

        public MailController(IStarterApp main, IMailService mailService, IProfileService profileService, IFolderService folderService): base(main)
        {
            _mailService = mailService;
            _profileService = profileService;
            _folderService = folderService;
        }

        [View]
        public override void Start()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"WELCOME {_profileService.GetCurrent().FullName}");
            Console.WriteLine("---------------------------------------\n\n\n");

            Console.WriteLine("1. Send an Email");
            Console.WriteLine("2. Read Email");
            Console.WriteLine("3. Delete Email");
            Console.WriteLine("4. Move Email");
            Console.WriteLine("5. Return");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    this.SendEmail();
                    break;
                case 2:
                    this.ReadEmail();
                    break;
                case 3:
                    this.DeleteEmail();
                    break;

                case 4:
                    this.MoveEmail();
                    break;

                default:
                    main.Route("AccountController");
                    break;
            }
        }
        
        [View]
        private void SendEmail()
        {
            Console.WriteLine("To:");
            string to = Console.ReadLine();
            Console.WriteLine("Subject:");
            string subject = Console.ReadLine();
            Console.WriteLine("CC (Separate by semicolom): ");
            string cc = Console.ReadLine();
            Console.WriteLine("Body:");
            string body = Console.ReadLine();

            _mailService.Create(new Mail { To = to, Subject = subject , CC = cc, Body = body });

            Console.ReadKey();
            main.Route("AccountController");
        }

        [View]
        private void ReadEmail()
        {
            _folderService.GetAll().ForEach( e => {
                Console.WriteLine($" * {e}");
            });

            Console.WriteLine("Write your folder: ");
            string folder = Console.ReadLine();

            Console.WriteLine();

            Dictionary<Guid, Mail> mails = _mailService.GetByFolder(folder);
            
            if(mails.Count != 0)
            {
                foreach (KeyValuePair<Guid, Mail> entry in mails)
                {
                    Console.WriteLine($"| { entry.Key }| { entry.Value.From } | { entry.Value.Subject }|");
                }

                Console.WriteLine();

                Console.WriteLine("Enter email code: ");

                string code = Console.ReadLine();

                Console.WriteLine(_mailService.GetById(new Guid(code)));

                Console.ReadKey();
                main.Route("MailController");
            }
            else
            {
                Console.WriteLine("0 messages");
                Console.ReadKey();
                main.Route("MailController");
            }
            
        }

        [View]
        private void DeleteEmail()
        {
            Console.WriteLine("Write mail folder: ");
            string folder= Console.ReadLine();

            Console.WriteLine("Write mail code: ");
            string code = Console.ReadLine();

            _mailService.Delete(new Guid(code), folder);

            main.Route("MailController");
        }

        [View]
        private void MoveEmail()
        {
            Console.WriteLine("Write origin folder: ");
            string orgFolder = Console.ReadLine();
            Console.WriteLine("Write destination folder: ");
            string dstFolder = Console.ReadLine();

            Console.WriteLine("Cod Email: ");
            string codEmail = Console.ReadLine();

            _mailService.Move(orgFolder, dstFolder, new Guid(codEmail));

            main.Route("MailController");
        }
    }
}
