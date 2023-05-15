using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Profilings
    {
        private static readonly string connectionString =
       "Data Source=WINDOWS-8FL63UC;Database=bookingservice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public string employee_id { get; set; }
        public int education_id { get; set; }

        public static int InsertProfiling(Profilings profilings)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var employee = new Employees();
            var education = new Educations();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_tr_profilings(employee_id, education_id) VALUES (@employee_id, @education_id)";
                command.Transaction = transaction;

                var zempid = new SqlParameter();
                zempid.ParameterName = "@employee_id";
                zempid.Value = profilings.employee_id;
                command.Parameters.Add(zempid);

                var zeduid = new SqlParameter();
                zeduid.ParameterName = "@education_id";
                zeduid.Value = profilings.education_id;
                command.Parameters.Add(zeduid);

                result = command.ExecuteNonQuery();
                transaction.Commit();

                return result;
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}
