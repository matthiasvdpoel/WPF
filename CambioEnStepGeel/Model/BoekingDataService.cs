using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;// SQL Server Data Provider 
using System.Configuration;
using Dapper;
using CambioEnStepGeel.View;

namespace CambioEnStepGeel.Model
{
    class boekingDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
             ConfigurationManager.ConnectionStrings["Mysql"].ConnectionString;
        //    ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);



        public void InsertBoeking(BoekingModel boeking)
        {

            string sql = "Insert into Boekingen (dateVanaf, timeVanaf, dateTot, timeTot, userId, locationId) values (@dateVanaf, @timeVanaf, @dateTot, @timeTot, @userId, @locationId)";
            Console.WriteLine("Wordt in db gestoken: " + boeking.DateVanaf + " " +
                    boeking.TimeVanaf + " " +
                    boeking.DateTot + " " +
                    boeking.TimeTot + " " +
                    boeking.Userid + " " +
                    boeking.Locationid);
            db.Execute(sql, new
            {
                boeking.DateVanaf,
                boeking.TimeVanaf,
                boeking.DateTot,
                boeking.TimeTot,
                boeking.Userid,
                boeking.Locationid

            });

            Console.WriteLine("gelukt boeking in database te krijgen");

        }


     
        public List<BoekingModel> GetBoekingen(int userId)
        {

            Console.WriteLine("UserID = " + userId);
            string sql = "select Boekingen.Id, Boekingen.dateVanaf, Boekingen.timeVanaf, Boekingen.dateTot, Boekingen.timeTot, Boekingen.userId, Locations.omschrijving from Boekingen Inner Join Locations on Boekingen.locationId = Locations.locationID where userId='"+userId+"'";
            return (List<BoekingModel>)db.Query<BoekingModel>(sql);

        }

        public void DeleteBoeking(BoekingModel boeking)
        {
            string sql = "Delete Boekingen where TimeVanaf = @TimeVanaf";

            // Uitvoeren SQL statement en doorgeven parametercollectie
            db.Execute(sql, new { boeking.TimeVanaf });

        }
    }
}

