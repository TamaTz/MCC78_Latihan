using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Testing.Context;
using System.Transactions;

namespace Testing.Model
{
    public class Education
    {
        public int id { get; set; }
        public string major { get; set; }
        public string degree { get; set; }
        public string gpa { get; set; }
        public int UniversityId { get; set; }

        public int Insert(Education educations)
        {
            int result = 0;
            using var connection = MyConnection.Get();
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
                zuniversity_id.Value = educations.UniversityId;
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

        public List<Education> GetEducation()
        {
            var educations = new List<Education>();
            using SqlConnection connection = MyConnection.Get();
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
                        var education = new Education();
                        education.id = reader.GetInt32(0);
                        education.major = reader.GetString(1);
                        education.degree = reader.GetString(2);
                        education.gpa = reader.GetString(3);
                        education.UniversityId = reader.GetInt32(4);

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
            return new List<Education>();
        }

        public int Update(Education educations)
        {
            int result = 0;
            using var connection = MyConnection.Get();
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
                zuniversity_id.Value = educations.UniversityId;

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
        public int DeleteEducation(Education educations)
        {
            int result = 0;
            using var connection = MyConnection.Get();
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

        public int getEduId()
        {
            using var connection = MyConnection.Get();
            connection.Open();

            var command = new SqlCommand("SELECT TOP 1 id FROM tb_m_educations ORDER BY id DESC", connection);

            int id = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return id;
        }
    }
}
