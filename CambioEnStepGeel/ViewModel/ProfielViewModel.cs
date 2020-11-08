using CambioEnStepGeel.Extensions;
using CambioEnStepGeel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CambioEnStepGeel.ViewModel
{
    class ProfielViewModel : BaseViewModel
    {
        public ProfielViewModel()
        {
            Messenger.Default.Register<User>(this, OnUserReceived);
            LadenCommands();
        }

        public void LadenCommands()
        {
            TerugCommand = new BaseCommand(Terug);
            UpdateCommand = new BaseCommand(Update);
        }

        private void OnUserReceived(User user)
        {
            Console.WriteLine("user received in Profiel");
            Currentuser = user;
        }

        public void Terug()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();

            pageNavigationService.Navigate("dashboard");
            Messenger.Default.Send<User>(currentuser);

        }
        public void Update()
        {
            Console.WriteLine("Update in profiel");
            UserDataService userDS = new UserDataService();
            userDS.UpdateUser(currentuser);
            Terug();
        }

        private ICommand terugCommand;
        public ICommand TerugCommand
        {
            get
            {
                return terugCommand;
            }

            set
            {
                terugCommand = value;
            }
        }
        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }

            set
            {
                updateCommand = value;
            }
        }

        private User currentuser;
        public User Currentuser
        {
            get
            {
                return currentuser;
            }

            set
            {
                currentuser = value;
                NotifyPropertyChanged();
            }
        }
    }
}
