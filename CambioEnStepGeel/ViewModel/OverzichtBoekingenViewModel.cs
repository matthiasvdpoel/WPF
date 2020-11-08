using CambioEnStepGeel.Extensions;
using CambioEnStepGeel.Model;
using CambioEnStepGeel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CambioEnStepGeel.ViewModel
{
    class OverzichtBoekingenViewModel : BaseViewModel
    {
        public OverzichtBoekingenViewModel()
        {
            Messenger.Default.Register<User>(this, OnUserReceived);
            LadenCommands();
            
        }

        private void OnUserReceived(User obj)
        {
            Console.WriteLine("Overzichtboekingen user received");
            CurrentUser = obj;
            LadenBoekingen();
        }

        public void LadenCommands()
        {
            HomeCommand = new BaseCommand(Home);
            DeleteCommand = new BaseCommand(Delete);
        }

        private void Home()
        {
            PageNavigationService pageNavigationService = new PageNavigationService();

            pageNavigationService.Navigate("dashboard");
            Messenger.Default.Unregister(this);
            Messenger.Default.Send<User>(currentuser);
        }
        public void Delete()
        {
            boekingDataService boekingDS = new boekingDataService();
            boekingDS.DeleteBoeking(selectedBoeking);
            LadenBoekingen();
        }

        public void LadenBoekingen()
        {

            boekingDataService boekingDS = new boekingDataService();
            Boekingen = new ObservableCollection<BoekingModel>(boekingDS.GetBoekingen(currentuser.UserId));
            Console.WriteLine("Aantal boekingen geladen: " + boekingen.Count);
            
        }
        private User currentuser;
        public User CurrentUser
        {
            get
            {
                return currentuser;
            }
            set
            {
                currentuser = value;
                Console.WriteLine(currentuser.Voornaam + " " + currentuser.UserId);
                NotifyPropertyChanged();
            }
        }
        private ObservableCollection<BoekingModel> boekingen;
        public ObservableCollection<BoekingModel> Boekingen
        {
            get
            {
                return boekingen;
            }
            set
            {
                boekingen = value;
                NotifyPropertyChanged();
            }
        }
        public  ICommand HomeCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private BoekingModel selectedBoeking;
        public BoekingModel SelectedBoeking
        {
            get
            {
                return selectedBoeking;
            }
            set
            {
                selectedBoeking = value;
                NotifyPropertyChanged();
            }
        }
    }
}
