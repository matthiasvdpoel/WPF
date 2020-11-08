using Caliburn.Micro;
using CambioEnStepGeel.Extensions;
using CambioEnStepGeel.Messages;
using CambioEnStepGeel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CambioEnStepGeel.ViewModel
{
    class BoekingViewModel : BaseViewModel 
    {

        private User currentuser;
        private DialogService dialogService;
        public BoekingViewModel()
        {
            Messenger.Default.Register<User>(this, OnUserReceived);
            
            LadenLocations();
            LadenCommands();
            DateUpdate();
            dialogService = new DialogService();
        }

        public void LadenLocations()
        {


            UserDataService contactDS = new UserDataService();
            Locations = new BindableCollection<Location>(contactDS.GetLocations());

            Console.WriteLine("Aantal locations uit db gehaald:" + Locations.Count);
            foreach (Location e in locations)
            {
                Console.WriteLine("boekingViewModel" + e.LocationId + e.Coordinaten + e.Organisatie + e.Omschrijving);
                if (e.Organisatie.Equals("Lime"))
                {
                    e.Kleur = "Lime";
                }
                else if (e.Organisatie.Equals("Cambio"))
                {
                    e.Kleur = "Orange";
                }
            }
            Center = "51.162030, 4.990389";
            Zoom = 12;
        }

        public void LadenCommands()
        {
            TerugCommand = new BaseCommand(Terug);
            BoekenCommand = new BaseCommand(Boeken);
            OverzichtCommand = new BaseCommand(Overzicht);
        }

        public void DateUpdate()
        {
            DateVanaf = DateTime.Now.Date;
            DateTot = DateTime.Now.Date;
            TimeVanaf = DateTime.Now;
            TimeTot = DateTime.Now;
        }

        public void Terug()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();

            pageNavigationService.Navigate("dashboard");
            Messenger.Default.Send<User>(currentuser);

        }

        public void Boeken()
        {
            if (selectedLocation != null)

            { 
                BoekingModel boeking = new BoekingModel(dateVanaf, timeVanaf, dateTot, timeTot, currentuser.UserId, selectedLocation.LocationId, selectedLocation);
                boeking.Location = selectedLocation;
                boekingDataService boekingDS = new boekingDataService();
                UserDataService userDS = new UserDataService();
                boekingDS.InsertBoeking(boeking);
                currentuser.Punten += 100;
                userDS.UpdatePunten(currentuser);
                Messenger.Default.Unregister(this);
                Messenger.Default.Send<BoekingModel>(boeking);
                Messenger.Default.Register<CloseMessage>(this, OnMessageReceived); 
                dialogService.ShowDetailDialog();
                

            }
           

        }
        private void OnUserReceived(User user)
        {
            Console.WriteLine("user received in Boeking");
            Currentuser = user;
        }

       

        private void OnMessageReceived(CloseMessage obj)
        {
            dialogService.CloseDetailDialog();
            Overzicht();
        }
        public void Overzicht()
        {
            Messenger.Default.Unregister(this);
            PageNavigationService pageNavigationService = new PageNavigationService();
            pageNavigationService.Navigate("overzichtboekingen");
            Messenger.Default.Send<User>(currentuser);

        }

        private Location selectedLocation;
        public Location SelectedLocation
        {
            get
            {
                return selectedLocation;
            }
            set
            {
                selectedLocation = value;
                NotifyPropertyChanged();
                Center = selectedLocation.Coordinaten;
                Zoom = 14;
            }
        }

        private string center;
        public string Center
        {
            get
            {
                return center;
            }
            set
            {
                center = value;
                NotifyPropertyChanged();
            }
        }

        private double zoom;
        public double Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                zoom = value;
                NotifyPropertyChanged();
            }
        }


        private BindableCollection<Location> locations;
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
        private ICommand boekenCommand;
        public ICommand BoekenCommand
        {
            get
            {
                return boekenCommand;
            }

            set
            {
                boekenCommand = value;
            }
        }
        public ICommand OverzichtCommand { get; set; }
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
        private DateTime dateVanaf;
        public DateTime DateVanaf
        {
            get
                {
                return dateVanaf;
            }
            set
            {
                dateVanaf = value;
                Console.WriteLine("Date vanaf: " + dateVanaf);
                NotifyPropertyChanged();
            }
        }
        private DateTime dateTot;
        public DateTime DateTot
        {
            get
            {
                return dateTot;
            }
            set
            {
                dateTot = value;
                Console.WriteLine("Date tot: " + dateTot);
                NotifyPropertyChanged();
            }
        }
        private DateTime timeVanaf;
        public DateTime TimeVanaf
        {
            get
            {
                return timeVanaf;
            }
            set
            {
                timeVanaf = value;
                Console.WriteLine("Time vanaf: " + timeVanaf);
                NotifyPropertyChanged();
            }
        }
        private DateTime timeTot;
        public DateTime TimeTot
        {
            get
            {
                return timeTot;
            }
            set
            {
                timeTot = value;
                Console.WriteLine("Time tot: " + timeTot);
                NotifyPropertyChanged();
            }
        }

    }
}
