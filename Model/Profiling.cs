using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Context;

namespace Testing.Model
{
    public class Profiling
    {

        public string EmId { get; set; }
        public int EdId { get; set; }

        public int Insert(Profiling profilings)
        {
            int result = 0;
            using var connection = MyConnection.Get();
            connection.Open();
            var employee = new Employee();
            var education = new Education();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_tr_profilings(employee_id, education_id) VALUES (@employee_id, @education_id)";
                command.Transaction = transaction;

                var zempid = new SqlParameter();
                zempid.ParameterName = "@employee_id";
                zempid.Value = profilings.EmId;
                command.Parameters.Add(zempid);

                var zeduid = new SqlParameter();
                zeduid.ParameterName = "@education_id";
                zeduid.Value = profilings.EdId;
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

        public List<Profiling> GetProfiling()
        {
            var profilings = new List<Profiling>();
            using SqlConnection connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_tr_profilings";
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var profiling = new Profiling();
                        profiling.EmId = reader.GetGuid(0).ToString();
                        profiling.EdId = reader.GetInt32(1);

                        profilings.Add(profiling);
                    }
                    return profilings;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return new List<Profiling>();
        }
    }
}
