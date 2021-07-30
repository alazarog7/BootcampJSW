using EmailApp.Decorators;
using EmailApp.Entities;
using EmailApp.Services.RuleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp.Controller
{
    public class RuleController: BaseController
    {
        private IRuleService _ruleService;

        public RuleController(IStarterApp main, IRuleService ruleService): base(main)
        {
            _ruleService = ruleService;
        }

        [View]
        public override void Start()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Rules");
            Console.WriteLine("---------------------------------------\n\n\n");

            Console.WriteLine("1. Add a Rule");
            Console.WriteLine("2. Remove a Rule");
            Console.WriteLine("3. Return to Main Menu");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    this.CreateRule();
                    break;
                case 2:
                    this.RemoveRule();
                    break;
                default:
                    main.Route("AccountController");
                    break;
            }
        }

        [View]
        private void CreateRule()
        {
            Console.WriteLine("Origin: ");
            string from = Console.ReadLine();

            Console.WriteLine("Subject: ");
            string subject = Console.ReadLine();

            Console.WriteLine("Dest Folder: ");
            string folder = Console.ReadLine();

            _ruleService.Create( new Rule { Id =Guid.NewGuid(), FromEmail =  from , Subject = subject , ToFolder = folder });

            main.Route("AccountController");
        }

        [View]
        private void RemoveRule()
        {
            List<Rule> rules = _ruleService.GetAll();

            foreach(var rule in rules)
            {
                Console.WriteLine($"|{rule.Id}|{rule.FromEmail}|{rule.Subject}|{rule.ToFolder}|");
            }

            Console.WriteLine("Code:");

            string code = Console.ReadLine();

            _ruleService.Delete(new Guid(code));

            main.Route("AccountController");

        }
    }
}
