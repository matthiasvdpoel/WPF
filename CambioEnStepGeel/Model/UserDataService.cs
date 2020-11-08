using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;// SQL Server Data Provider 
using System.Configuration;
using Dapper;

namespace CambioEnStepGeel.Model
{
    class UserDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
            ConfigurationManager.ConnectionStrings["Mysql"].ConnectionString;
           // ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);

        public List<User> GetContactPersonen()
        {
            // Stap 2 Dapper
            // Uitschrijven SQL statement & bewaren in een string. 
            string sql = "Select * from User order by Achternaam";


            // Stap 3 Dapper
            // Uitvoeren SQL statement op db instance 
            // Type casten van het generieke return type naar een collectie van contactpersonen
            return (List<User>)db.Query<User>(sql);

        }
        public void InsertUser(User user)
        {
            // SQL statement insert
            string sql = "Insert into users (achternaam, voornaam, adres, nr, woonplaats, postcode, email, gsm, username, password) values (@achternaam, @voornaam, @adres, @nr, @woonplaats, @postcode, @email, @gsm, @username, @password)";

            // Uitvoeren SQL statement en doorgeven parametercollectie

            int i = 0;
            db.Execute(sql, new
            {
                user.Achternaam,
                user.Voornaam,
                user.Adres,
                user.Nr,
                user.Woonplaats,
                user.Postcode,
                user.Email,
                user.Gsm,
                user.Username,
                user.Password,


            });
            Console.WriteLine("gelukt user in database te krijgen");
        }



        public void UpdatePunten(User user)
        {
            string sql = "Update Users set punten = @Punten where userID = @UserId";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new
            {
                user.Punten,
                user.UserId
            });


        }
        public void UpdateUser(User user)
        {
            string sql = "Update Users set achternaam = @achternaam, voornaam = @voornaam, adres = @adres, nr =  @nr, woonplaats = @woonplaats, postcode = @postcode, email = @email, gsm = @gsm, username = @username, password = @password where userID = @UserId";
            db.Execute(sql, new
            {
                user.Achternaam,
                user.Voornaam,
                user.Adres,
                user.Nr,
                user.Woonplaats,
                user.Postcode,
                user.Email,
                user.Gsm,
                user.Username,
                user.Password,
                user.UserId
            });


        }

        public List<User> GetUser(User user)
        {
            Console.WriteLine(user.Username);


            string sql = "Select * from users where username= '" + user.Username + "' And Password = '" + user.Password + "'";
            return (List<User>)db.Query<User>(sql);

        }

        public List<Location> GetLocations()
        {
            string sql = "Select * from Locations";
            return (List<Location>)db.Query<Location>(sql);
        }


        public List<User> GetUsers()
        {
            string sql = "Select * from users order by punten DESC";

            return (List<User>)db.Query<User>(sql);
        }
        
    }
}

