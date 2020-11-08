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
    class LocationDataService
    {
        // Ophalen ConnectionString uit App.config
        private static string connectionString =
             ConfigurationManager.ConnectionStrings["Mysql"].ConnectionString;
          //  ConfigurationManager.ConnectionStrings["azure"].ConnectionString;

        // Stap 1 Dapper
        // Aanmaken van een object uit de IDbConnection class en 
        // instantiëren van een SqlConnection.
        // Dit betekent dat de connectie met de database automatisch geopend wordt.
        private static IDbConnection db = new SqlConnection(connectionString);


        public List<Location> GetLocations()
        {
            string sql = "Select * from Locations";
            return (List<Location>)db.Query<Location>(sql);
        }
    }
}
