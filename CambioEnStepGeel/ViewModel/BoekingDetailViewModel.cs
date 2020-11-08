using CambioEnStepGeel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using CambioEnStepGeel.Messages;
using CambioEnStepGeel.Model;

namespace CambioEnStepGeel.ViewModel
{
    class BoekingDetailViewModel : BaseViewModel
    {

        public BoekingDetailViewModel()
        {
            Console.WriteLine("BoekinDetailviewModel constructor");
            Messenger.Default.Register<BoekingModel>(this, LadenData);
            LadenCommands();
        }

        public void LadenCommands()
        {

            SluitCommand = new BaseCommand(Sluiten);

        }
        public void LadenData(BoekingModel obj)
        {
            Console.WriteLine("LadenData in boekingdetaiilviewmodel"+" "+obj.Locationid+ obj.Location.Omschrijving);
            obj.DateVanaf = obj.DateVanaf.Date;
            Boeking = obj;

            
        }

        public void Sluiten()
        {

            Messenger.Default.Send<CloseMessage>(new CloseMessage(CloseMessage.MessageType.Closed));
            Console.WriteLine("sluitcommand verstuurd");
        }

        private ICommand sluitCommand;
        public ICommand SluitCommand
        {
            get
            {
                return sluitCommand;
            }

            set
            {
                sluitCommand = value;
            }
        }
        private BoekingModel boeking;
        public BoekingModel Boeking
        {
            get
            {
                return boeking;
            }
            set
            {
                boeking = value;
                NotifyPropertyChanged();
            }
        }
       
       
    }
}
