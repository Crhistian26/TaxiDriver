using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDriver.Persistance.Context
{
    public class DBConnection
    {
        public SqlConnection conex;

        public DBConnection()
        {
            string _connectionString = $"Data Source=DESKTOP-6Q75L5I;Initial Catalog=TaxiWeb;Integrated Security=True;TrustServerCertificate=True";
            conex = new SqlConnection(_connectionString);
        }

        public SqlConnection GetConnection()
        {
            return conex;
        }
    }
}
