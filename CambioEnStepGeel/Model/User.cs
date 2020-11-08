using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioEnStepGeel.Model
{
    class User :BaseModel
    {

        private int userId;
        private string achternaam;
        private string voornaam;
        private string adres;
        private string nr;
        private string woonplaats;
        private string postcode;
        private string gsm;
        private string email;
        private string username;
        private string password;
        private int punten;

        public User(int id, string achternaam, string voornaam, string adres, 
            string nr, string woonplaats, string postcode, string gsm, string email,
            string username, string password, int punten)
        {
          
            Achternaam = achternaam;
            Voornaam = voornaam;
            Adres = adres;
            Nr = nr;
            Woonplaats = woonplaats;
            Postcode = postcode;
            Gsm = gsm;
            Email = email;
            Username = username;
            Password = password;
            Punten = punten;
        }

        public User()
        {
            Console.WriteLine("Default constructor wordt gebruikt");
        }

        public int UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
                NotifyPropertyChanged();
            }
        }
        public string Achternaam
        {
            get
            {
                return achternaam;
            }

            set
            {
                achternaam = value;
                NotifyPropertyChanged();
            }
        }
        public string Voornaam
        {
            get
            {
                return voornaam;
            }

            set
            {
                voornaam = value;
                NotifyPropertyChanged();
            }
        }
        public string Adres
        {
            get
            {
                return adres;
            }

            set
            {
                adres = value;
                NotifyPropertyChanged();
            }
        }
        public string Nr
        {
            get
            {
                return nr;
            }

            set
            {
                nr = value;
                NotifyPropertyChanged();
            }
        }
        public string Woonplaats
        {
            get
            {
                return woonplaats;
            }

            set
            {
                woonplaats = value;
                NotifyPropertyChanged();
            }
        }
        public string Postcode
        {
            get
            {
                return postcode;
            }

            set
            {
                postcode = value;
                NotifyPropertyChanged();
            }
        }
        public string Gsm
        {
            get
            {
                return gsm;
            }

            set
            {
                gsm = value;
                NotifyPropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
                NotifyPropertyChanged();
            }
        }
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
                NotifyPropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                NotifyPropertyChanged();
            }
        }
        public int Punten
        {
            get
            {
                return punten;
            }

            set
            {
                punten  = value;
                NotifyPropertyChanged();
            }
        }

    }
    
}
