using EmailApp.Decorators;
using EmailApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Controller
{
    class AccountController : BaseController
    {
        
        private readonly IProfileService _profileService;
        private readonly ISecurityService _securityService;

        public AccountController(IStarterApp main, IProfileService profileService, ISecurityService securityService) : base(main)
        {
            _profileService = profileService;
            _securityService = securityService;
        }

        [View]
        public override void Start()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($" WELCOME: {_profileService.GetCurrent().FullName}");
            Console.WriteLine("---------------------------------------\n\n\n");

            Console.WriteLine("1. Email");
            Console.WriteLine("2. Folders");
            Console.WriteLine("3. Rules");
            Console.WriteLine("4. Log out(press any number)");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    main.Route("MailController");
                    break;
                case 2:
                    main.Route("FolderController");
                    break;
                case 3:
                    main.Route("RuleController");
                    break;
                default:
                    _securityService.RemoveAuthetication();
                    main.Route("MainController");
                    break;
            }
        }
    }
}
