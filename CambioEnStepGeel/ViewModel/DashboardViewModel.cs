using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CambioEnStepGeel.Model;
using System.Collections.ObjectModel;
using Caliburn.Micro;
using CambioEnStepGeel.Extensions;

namespace CambioEnStepGeel.ViewModel
{    

    class DashboardViewModel: BaseViewModel
    {


        private BindableCollection<Location> locations;
        private User currentuser;
        public DashboardViewModel()
        {
            Messenger.Default.Register<User>(this, OnUserReceived);
            LadenLocations();
            KoppelenCommand();
            Console.WriteLine("voor recieved");
           

        }

        public void LadenLocations()
        {


            UserDataService contactDS =  new UserDataService();
            Locations = new BindableCollection<Location>(contactDS.GetLocations());

            Console.WriteLine("Aantal locations uit db gehaald:" +Locations.Count);
            foreach(Location e in locations)
            {
                Console.WriteLine("dashboardviewmodel"+e.LocationId+e.Coordinaten + e.Organisatie+e.Omschrijving);
                if (e.Organisatie.Equals("Lime")){
                    e.Kleur = "Lime";
                }
                else if (e.Organisatie.Equals("Cambio")){
                    e.Kleur = "Orange";
                }
            }
        }

        public void KoppelenCommand()
        {
            MijnBoekingenCommand = new BaseCommand(NaarBoekingen);
            CommunityCommand = new BaseCommand(NaarCommunity);
            MijnProfielCommand = new BaseCommand(Naarprofiel);
            LogOutCommand = new BaseCommand(NaarLogin);


        }

        public void NaarBoekingen()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            
            pageNavigationService.Navigate("boekingen");
            Messenger.Default.Unregister(this);
            Messenger.Default.Send<User>(currentuser);

        }
        public void NaarCommunity()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("community");
            Messenger.Default.Unregister(this);
            Messenger.Default.Send<User>(currentuser);

        }
        public void Naarprofiel()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("profiel");
            Messenger.Default.Unregister(this);
            Messenger.Default.Send<User>(currentuser);

        }
        public void NaarLogin()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("login");
        }

        private void OnUserReceived(User user)
        {
            Console.WriteLine("user received in dashboard");
            Currentuser = user;
        }

        public BindableCollection<Location> Locations
        {
            get
            {
                return locations;
            }
            set
            {
                locations = value;
                NotifyPropertyChanged();
            }
        }
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

        public BaseCommand MijnBoekingenCommand { get; set; }
        public BaseCommand CommunityCommand { get; set; }
        public BaseCommand MijnProfielCommand { get; set; }
        public BaseCommand LogOutCommand { get; set; }
    }
}
