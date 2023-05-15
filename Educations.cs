using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Testing
{
    public class Educations
    {
        private static readonly string connectionString =
        "Data Source=WINDOWS-8FL63UC;Database=bookingservice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public int id { get; set; }
        public string major { get; set; }
        public string degree { get; set; }
        public string gpa { get; set; }
        public int university_id { get; set; }

        public static int InsertEducation(Educations educations)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_educations (major,degree,gpa,university_id) VALUES (@major, @degree, @gpa, @university_id";
                command.Transaction = transaction;

                var zmajor = new SqlParameter();
                zmajor.ParameterName = "@major";
                zmajor.SqlDbType = SqlDbType.VarChar;
                zmajor.Size = 100;
                zmajor.Value = educations.major;
                command.Parameters.Add(zmajor);

                var zdegree = new SqlParameter();
                zdegree.ParameterName = "@degree";
                zdegree.SqlDbType = SqlDbType.VarChar;
                zdegree.Size = 100;
                zdegree.Value = educations.degree;
                command.Parameters.Add(zdegree);

                var zgpa = new SqlParameter();
                zgpa.ParameterName = "@gpa";
                zgpa.SqlDbType = SqlDbType.VarChar;
                zgpa.Size = 100;
                zgpa.Value = educations.gpa;
                command.Parameters.Add(zgpa);

                var zuniversity_id = new SqlParameter();
                zuniversity_id.ParameterName = "@university_id";
                zuniversity_id.SqlDbType = SqlDbType.Int;
                zuniversity_id.Value = educations.university_id;
                command.Parameters.Add(zuniversity_id);

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

        public static List<Educations> GetEducations()
        {
            var educations = new List<Educations>();
            using SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_educations";
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var education = new Educations();
                        education.id = reader.GetInt32(0);
                        education.major = reader.GetString(1);
                        education.degree = reader.GetString(2);
                        education.gpa = reader.GetString(3);
                        education.university_id = reader.GetInt32(4);

                        educations.Add(education);
                    }
                    return educations;
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
            return new List<Educations>();
        }

        public static int UpdateEducation(Educations educations)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE tb_m_educations SET major = @major, degree = @degree, gpa = @gpa, university_id = @univ_id WHERE id = @id";
                command.Transaction = transaction;

                var zmajor = new SqlParameter();
                zmajor.ParameterName = "@major";
                zmajor.Value = educations.major;

                var zdegree = new SqlParameter();
                zdegree.ParameterName = "@degree";
                zdegree.Value = educations.degree;

                var zgpa = new SqlParameter();
                zgpa.ParameterName = "@gpa";
                zgpa.Value = educations.gpa;

                var zuniversity_id = new SqlParameter();
                zuniversity_id.ParameterName = "univ_id";
                zuniversity_id.Value = educations.university_id;

                var zid = new SqlParameter();
                zid.ParameterName = "@id";
                zid.Value = educations.id;

                command.Parameters.Add(zmajor);
                command.Parameters.Add(zdegree);
                command.Parameters.Add(zgpa);
                command.Parameters.Add(zuniversity_id);
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
        public static int DeleteEducation(Educations educations)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM tb_m_educations WHERE id = (@id)";
                command.Transaction = transaction;

                var zid = new SqlParameter();
                zid.ParameterName = "@id";
                zid.Value = educations.id;

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
