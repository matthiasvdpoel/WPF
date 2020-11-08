using CambioEnStepGeel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioEnStepGeel.Messages
{
    class BoekingDetailMessage
    {
        
        public BoekingDetailMessage(Location location , BoekingModel boekingg)
        {
            Location = location;
            Boeking = boekingg;
            Console.WriteLine("BoekingdetailMessage: " + location.Omschrijving + " " + boekingg.Locationid);
        }
        private Location location;
        public  Location Location { get; set; }
        private BoekingModel boekingg;
        public BoekingModel Boeking { get; set; }

       
    }
}
