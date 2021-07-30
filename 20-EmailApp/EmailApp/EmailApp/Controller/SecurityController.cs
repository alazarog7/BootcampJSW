using EmailApp.Decorators;
using EmailApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Controller
{
    public class SecurityController : BaseController
    {
     
        private ISecurityService _securityService;

        public SecurityController(IStarterApp main, ISecurityService securityService):base(main)
        {
            _securityService = securityService;
        }

        [View]
        public override void Start()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|          * LOGIN *                  |");
            Console.WriteLine("---------------------------------------\n\n");

            Console.WriteLine("Enter username:");

            string username = Console.ReadLine();

            if (_securityService.Verify(username))
            {
                _securityService.Authenticate(username);
                main.Route("AccountController");

            }
            else
            {
                main.Route("MainController");
            }
        }
    }
}
