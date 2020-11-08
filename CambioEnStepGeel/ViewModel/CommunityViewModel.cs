using Caliburn.Micro;
using CambioEnStepGeel.Extensions;
using CambioEnStepGeel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CambioEnStepGeel.ViewModel
{
    class CommunityViewModel : BaseViewModel
    {

        public CommunityViewModel()
        {
            Messenger.Default.Register<User>(this, OnUserReceived);
            Test = "testgeslaagd";
            LadenUsers();
            LadenCommands();
        }

        public void LadenUsers()
        {
            Console.WriteLine("Laden Users");
            UserDataService userDS =
                       new UserDataService();

            Users = new ObservableCollection<User>(userDS.GetUsers());
            Console.WriteLine("Aantal users: "+Users.Count);
            
        }
        public void LadenCommands() {
            TerugCommand = new BaseCommand(Terug);
        }

        private void Terug()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();

            pageNavigationService.Navigate("dashboard");
            Messenger.Default.Send<User>(currentuser);
        }
        private void OnUserReceived(User user)
        {
            Console.WriteLine("user received in Boeking");
            Currentuser = user;
        }

        private string test;
        public string Test
        {
            get
            {
                return test;
            }
            set
            {
                test = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<User> users;
        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                NotifyPropertyChanged();
            }
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

