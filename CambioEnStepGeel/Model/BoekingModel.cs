using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioEnStepGeel.Model
{
    class BoekingModel : BaseModel
    {

        private int locationid;
        private int userid;
        private DateTime dateVanaf;
        private DateTime timeVanaf;
        private DateTime dateTot;
        private DateTime timeTot;
        private Location location;
        private string omschrijving;
        public BoekingModel()
        {

        }
        public BoekingModel(DateTime dateVanaf, DateTime timeVanaf, DateTime dateTot, DateTime timeTot, int userid, int locationid, Location location)
        {
            DateVanaf = dateVanaf;
            TimeVanaf = timeVanaf;
            DateTot = dateTot;
            TimeTot = timeTot;
            Userid = userid;
            Locationid = locationid;
            Location = location;
           
        }
        public int Userid
        {
            get
            {
                return userid;
            }
            set
            {
                userid = value;
                NotifyPropertyChanged();
            }
        }
        public int Locationid
        {
            get
            {
                return locationid;
            }
            set
            {
                locationid = value;
                NotifyPropertyChanged();
            }
        }
        public string Omschrijving
        {
            get
            {
                return omschrijving;
            }
            set
            {
                omschrijving = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime DateVanaf
        {
            get
            {
                return dateVanaf;
            }
            set
            {
                dateVanaf = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime TimeVanaf
        {
            get
            {
                return timeVanaf;
            }
            set
            {
                timeVanaf = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime DateTot
        {
            get
            {
                return dateTot;
            }
            set
            {
                dateTot = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime TimeTot
        {
            get
            {
                return timeTot;
            }
            set
            {
                timeTot = value;
                NotifyPropertyChanged();
            }
        }
        public Location Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                NotifyPropertyChanged();
            }
        }
    }
}
