using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CambioEnStepGeel.Model;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using CambioEnStepGeel.Extensions;

namespace CambioEnStepGeel.ViewModel
{
    class RegisterViewModel : BaseViewModel
    {
        private User user;

        public RegisterViewModel()
        {
            LadenUser();
            KoppelenCommand();
        }

        private void LadenUser()
        {
            user = new User();
        }

        private void KoppelenCommand()
        {
            InsertUserCommand = new BaseCommand(InsertUser);
            GetUserCommand = new BaseCommand(GetUser);
            NaarRegistrerenCommand = new BaseCommand(NaarRegistreren);
            TerugCommand = new BaseCommand(NaarLogin);
        }

        private void InsertUser()
        {   if(user.Voornaam != null && user.Achternaam !=null && user.Username != null && user.Password!=null) { 
            UserDataService userDS =  new UserDataService();
            userDS.InsertUser(user);
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("login");
            }
        }

        public void GetUser()
        {
           UserDataService contactDS = new UserDataService();
           ObservableCollection<User> Users = new ObservableCollection<User>(contactDS.GetUser(user));
           Console.WriteLine("Gevonden users"+ Users.Count());
            if (Users.Count() > 0)
            {
                Console.WriteLine("Deze user wordt doorgegeven:" +Users[0].UserId+ Users[0].Username+ Users[0].Password+Users[0].GetHashCode());
                PageNavigationService pageNavigationService = new PageNavigationService();
                pageNavigationService.Navigate("dashboard");
                User currentuser = Users[0];
                Messenger.Default.Send<User>(currentuser);
            }
        }

        public void NaarRegistreren()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("registreren");
        }

        public void NaarLogin()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("login");
        }
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand insertUserCommand;
        public ICommand InsertUserCommand
        {
            get
            {
                return insertUserCommand;
            }

            set
            {
                insertUserCommand = value;
            }
        }
        private ICommand getUserCommand;
        public ICommand GetUserCommand
        {
            get
            {
                return getUserCommand;
            }

            set
            {
                getUserCommand = value;
            }
        }
        private ICommand naarRegistrerenCommand;
        public ICommand NaarRegistrerenCommand
        {
            get
            {
                return naarRegistrerenCommand;
            }

            set
            {
                naarRegistrerenCommand = value;
            }
        }
        public ICommand TerugCommand { get; set; }

    }
}





