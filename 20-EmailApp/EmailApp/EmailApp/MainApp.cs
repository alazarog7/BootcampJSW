using EmailApp.Controller;
using EmailApp.DB;
using EmailApp.Services;
using EmailApp.Services.RuleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp
{
    public class MainApp : IStarterApp
    {
        private readonly DataSource _dataSource;
        private readonly IMailService _mailService;
        private readonly IFolderService _folderService;
        private readonly IProfileService _profileService;
        private readonly ISecurityService _securityService;
        private readonly IRuleService _ruleService;

        private Dictionary<string, BaseController> controllers = new Dictionary<string, BaseController>();

        public MainApp()
        {
            _dataSource = new DataSource();
            _ruleService = new RuleService(_dataSource);
            _mailService = new MailService( _dataSource, _ruleService );
            _securityService = new SecurityService( _dataSource );
            _profileService = new ProfileService( _dataSource , _securityService);
            _folderService = new FolderService(_dataSource, _mailService);

            controllers.Add("MainController", new MainController(this));
            
            controllers.Add("ProfileController", new ProfileController(this, _profileService));
            controllers.Add("SecurityController", new SecurityController(this, _securityService));

            controllers.Add("AccountController", new AccountController(this, _profileService, _securityService));
          
            controllers.Add("FolderController", new FolderController(this, _profileService, _folderService));
            controllers.Add("MailController", new MailController(this, _mailService, _profileService, _folderService));
            controllers.Add("RuleController", new RuleController(this, _ruleService));
        }

        public void Start()
        {
            controllers["MainController"].Start();
        }

        public void Route(String controller)
        {
            controllers[controller].Start();
        }

    

    }
}
