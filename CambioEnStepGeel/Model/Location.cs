using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CambioEnStepGeel.Model
{
    class Location : BaseModel
    {


        public Location(int locationID, string coordinaten, string organisatie, string omschrijving)
        {

            Console.WriteLine("Voor toekennen 1:  " + coordinaten + organisatie + omschrijving);
            LocationId = locationID;
            Coordinaten = coordinaten;
            Organisatie = organisatie;
            Omschrijving = omschrijving;





        }

        /* public Location(string coordinaten, string organisatie)
             {
                 Console.WriteLine("Voor toekennen2 :  " + coordinaten + organisatie);
                 this.coordinaten = coordinaten;
                 this.organisatie = organisatie;

             }*/

        public Location()
        {
            Console.WriteLine("Voor toekennen3 :  " );
        }


        private int locationId;
        private string coordinaten;
        private string organisatie;
        private string omschrijving;
        private string kleur;


        public int LocationId { get; set; }
        public string Coordinaten { get; set; }
        public string Organisatie { get; set; }
        public string Omschrijving { get; set; }
        public string Kleur { get; set; }


    }
}

