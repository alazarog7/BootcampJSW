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
    public class MainController: BaseController
    {


        public MainController(IStarterApp main): base(main)
        {
        }

        [View]
        public override void Start()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("|          * EMAIL APP *              |");
            Console.WriteLine("---------------------------------------\n\n\n");

            Console.WriteLine("1. Sign in");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit( 3 or other number)");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    main.Route("SecurityController");
                    break;
                case 2:
                    main.Route("ProfileController");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Good Bye ...");
                    break;
            }
        }
    }
}
