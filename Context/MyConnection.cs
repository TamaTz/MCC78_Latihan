using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Context
{
    public class MyConnection
    {
        private static readonly string connectionString =
       "Data Source=WINDOWS-8FL63UC;Database=bookingservice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public static SqlConnection Get()
        {
            var connection = new SqlConnection(connectionString);
            return new SqlConnection (connectionString);
        }
    }
}
