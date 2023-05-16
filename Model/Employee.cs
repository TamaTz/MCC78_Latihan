using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Context;

namespace Testing.Model
{
    public class Employee
    {
        private static readonly string connectionString =
        "Data Source=WINDOWS-8FL63UC;Database=bookingservice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public string id { get; set; }
        public string nik { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birthdate { get; set; }
        public string gender { get; set; }
        public DateTime hiring_date { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string department_id { get; set; }

        public int Insert(Employee employees)
        {
            int result = 0;
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_employees (nik, first_name, last_name, birthdate, gender, hiring_date, email, phone_number, department_id)" +
                    "VALUES (@nik, @first_name, @last_name, @birthdate, @gender, @hiring_date, @email, @phone_number, @department_id)";
                command.Transaction = transaction;

                var znik = new SqlParameter();
                znik.ParameterName = "@nik";
                znik.SqlDbType = SqlDbType.VarChar;
                znik.Size = 6;
                znik.Value = employees.nik;
                command.Parameters.Add(znik);

                var zname = new SqlParameter();
                zname.ParameterName = "@first_name";
                zname.SqlDbType = SqlDbType.VarChar;
                zname.Value = employees.first_name;
                zname.Size = 50;
                command.Parameters.Add(zname);

                var zname2 = new SqlParameter();
                zname2.ParameterName = "@last_name";
                zname2.Size = 50;
                zname2.Value = employees.last_name;
                command.Parameters.Add(zname2);

                var zbirth = new SqlParameter();
                zbirth.ParameterName = "@birthdate";
                zbirth.Value = employees.birthdate;
                zbirth.SqlDbType = SqlDbType.DateTime;
                command.Parameters.Add(zbirth);

                var zgender = new SqlParameter();
                zgender.ParameterName = "@gender";
                zgender.SqlDbType = SqlDbType.VarChar;
                zgender.Size = 10;
                zgender.Value = employees.gender;
                command.Parameters.Add(zgender);

                var zhiring = new SqlParameter();
                zhiring.ParameterName = "@hiring_date";
                zhiring.SqlDbType = SqlDbType.DateTime;
                zhiring.Value = employees.hiring_date;
                command.Parameters.Add(zhiring);

                var zmail = new SqlParameter();
                zmail.ParameterName = "@email";
                zmail.SqlDbType = SqlDbType.VarChar;
                zmail.Size = 50;
                zmail.Value = employees.email;
                command.Parameters.Add(zmail);

                var znumber = new SqlParameter();
                znumber.ParameterName = "@phone_number";
                znumber.SqlDbType = SqlDbType.VarChar;
                znumber.Size = 20;
                znumber.Value = employees.phone_number;
                command.Parameters.Add(znumber);

                var zdepid = new SqlParameter();
                zdepid.ParameterName = "@department_id";
                zdepid.SqlDbType = SqlDbType.Int;
                zdepid.Size = 4;
                zdepid.Value = employees.department_id;
                command.Parameters.Add(zdepid);

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

        public string GetIdEmp(string NIK)
        {
            using SqlConnection connection = MyConnection.Get();
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT id FROM tb_m_employees WHERE nik = (@nik)", connection);

            var niks = new SqlParameter();
            niks.ParameterName = "@nik";
            niks.Value = NIK;
            command.Parameters.Add(niks);

            string lastIdEmp = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return lastIdEmp;
        }

        public static List<Employee> GetEmployee()
        {
            var employees = new List<Employee>();
            using SqlConnection connection = MyConnection.Get();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_employees";
                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var employeess = new Employee();
                        employeess.id = reader.GetGuid(0).ToString();
                        employeess.nik = reader.GetString(1);
                        employeess.first_name = reader.GetString(2);
                        employeess.last_name = reader.GetString(3);
                        employeess.birthdate = reader.GetDateTime(4);
                        employeess.gender = reader.GetString(5);
                        employeess.hiring_date = reader.GetDateTime(6);
                        employeess.email = reader.GetString(7);
                        employeess.phone_number = reader.GetString(8);
                        employeess.department_id = reader.GetString(9);

                        employees.Add(employeess);
                    }
                    return employees;
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
            return new List<Employee>();
        }
    }
}
