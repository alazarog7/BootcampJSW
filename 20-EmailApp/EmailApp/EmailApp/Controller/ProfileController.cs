using EmailApp.Decorators;
using EmailApp.Entities;
using EmailApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Controller
{
    public class ProfileController : BaseController
    {
        private readonly IProfileService _profileService;

        public ProfileController(IStarterApp main, IProfileService profileService): base(main)
        {
            _profileService = profileService;
        }

        [View]
        public override void Start()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|          * REGISTER *               |");
            Console.WriteLine("---------------------------------------\n\n");

            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your full name:");
            string fullName = Console.ReadLine();

            this.CreateProfile( new User { Username = username, FullName = fullName});

        }

        private void CreateProfile( User user)
        {
            _profileService.Create( user);

            if(_profileService.GetCurrent() != null)
            {
                main.Route("AccountController");
            }
            else
            {
                main.Route("MainController");
            }
        }


    }
}
