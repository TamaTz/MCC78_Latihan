using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Employees
    {
        private static readonly string connectionString =
        "Data Source=WINDOWS-8FL63UC;Database=bookingservice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public int id { get; set; }
        public string nik { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birthdate { get; set; }
        public string gender { get; set; }
        public DateTime hiring_date { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string department_id { get; set; }

        public static int InsertEmployee(Employees employees)
        {
            int result = 0;
            using var connection = new  SqlConnection(connectionString);
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

        public static string GetIdEmp(string NIK)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT id FROM tb_m_employees WHERE nik = (@nik)", connection);

            var niks = new SqlParameter();
            niks.ParameterName = "@nik";
            niks.Value =  NIK;
            command.Parameters.Add(niks);

            string lastIdEmp = Convert.ToString(command.ExecuteScalar());
            connection.Close();

            return lastIdEmp;
        }

        public static int GetEdUnId(int pilihan)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            if (pilihan == 1)
            {
                SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM tb_m_universities ORDER BY id DESC", connection);

                int id = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return id;
            }
            else
            {
                SqlCommand command = new SqlCommand("SELECT TOP 1 id FROM tb_m_educations ORDER BY id DESC", connection);

                int id = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return id;
            }
        }

        public static void CetakEmployee()
        {
            var employee = new Employees();
            var profiling = new Profilings();
            var education = new Educations();
            var university = new Universities();

            //Employee
            Console.Write("NIK : ");
            var niks = Console.ReadLine();
            employee.nik = niks;

            Console.Write("First Name : ");
            employee.first_name = Console.ReadLine();

            Console.Write("Last Name : ");
            employee.last_name = Console.ReadLine();

            Console.Write("Birthdate  : ");
            employee.birthdate = DateTime.Parse(Console.ReadLine());

            Console.Write("Gender  : ");
            employee.gender = Console.ReadLine();

            Console.Write("Hiring Date  : ");
            employee.hiring_date = DateTime.Parse(Console.ReadLine());

            Console.Write("Email  : ");
            employee.email = Console.ReadLine();

            Console.Write("Phone Number  : ");
            employee.phone_number = Console.ReadLine();

            Console.Write("Department ID  : ");
            employee.department_id = Console.ReadLine();

            //Education
            Console.Write("Major  :  ");
            education.major = Console.ReadLine();

            Console.Write("Degree  :  ");
            education.degree = Console.ReadLine();

            Console.Write("GPA  :  ");
            education.gpa = Console.ReadLine();

            Console.Write("University Name  :  ");
            education.major = Console.ReadLine();

            var result = Employees.InsertEmployee(employee);
            if (result > 0)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Faied");
            }

            Universities.InsertUniversity(university);

            education.university_id = GetEdUnId(1);
            Educations.InsertEducation(education);

            profiling.employee_id = GetIdEmp(niks);
            profiling.education_id = GetEdUnId(2);
            Profilings.InsertProfiling(profiling);
        }
    }
}
