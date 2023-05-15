using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Universities
    {

        private static readonly string connectionString =
        "Data Source=WINDOWS-8FL63UC;Database=bookingservice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public int id {get;set;}
        public string name { get;set;}

        public static int InsertUniversity(Universities university)
        {
            int result = 0;

            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_universities(name) VALUES (@name)";
                command.Transaction = transaction;

                var zname = new SqlParameter();
                zname.ParameterName = "@name";
                zname.SqlDbType = SqlDbType.VarChar;
                zname.Size = 50;
                zname.Value = university.name;
                command.Parameters.Add(zname);

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

        public static List<Universities> GetUniversities()
        {
            var universities = new List<Universities>();
            using SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_universities";
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var university = new Universities();
                        university.id = reader.GetInt32(0);
                        university.name = reader.GetString(1);

                        universities.Add(university);
                    }
                    return universities;
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
            return new List<Universities>();
        }

        public static int UpdateUniversity(Universities university)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_universities SET name = (@name) WHERE id  = (@id)";
                command.Transaction = transaction;

                var zname = new SqlParameter();
                var zid = new SqlParameter();

                zname.ParameterName = "@name";
                zname.ParameterName = "@id";
                zname.Value = university.name;
                zid.Value = university.id;

                command.Parameters.Add(zname);
                command.Parameters.Add(zid);

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

        public static int DeleteUniversity(Universities university)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tb_m_universities WHERE id = (@id)";
                command.Transaction = transaction;

                var zid = new SqlParameter();
                zid.ParameterName = "@id";
                zid.Value = university.id;

                command.Parameters.Add(zid);
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
