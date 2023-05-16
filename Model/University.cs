using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Context;

namespace Testing.Model
{
    public class University
    {
        public int id { get; set; }
        public string name { get; set; }

        public int Insert(University university)
        {
            int result = 0;
            using var connection = MyConnection.Get();
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

        public List<University> GetUniversities()
        {
            var universities = new List<University>();
            using SqlConnection connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_universities";
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var university = new University();
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
            return new List<University>();
        }

        public int Update(University university)
        {
            int result = 0;
            using var connection = MyConnection.Get();
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

        public int Delete(University university)
        {
            int result = 0;
            using var connection = MyConnection.Get();
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

        public int GetUnId()
        {
            using var connection = MyConnection.Get();
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM tbP_m_universities ORDER BY id DESC", connection);

            int id = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return id;
        }
    }


}
