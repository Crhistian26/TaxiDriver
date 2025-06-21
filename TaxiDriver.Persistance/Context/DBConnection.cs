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
        public SqlConnection conex { get; set; };

    }
}
