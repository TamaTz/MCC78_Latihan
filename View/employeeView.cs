using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Model;

namespace Testing.View
{
    public class employeeView
    {
        public void Output(Employee employee)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("Id : " + employee.id);
            Console.WriteLine("NIK : " + employee.nik);
            Console.WriteLine("First Name :" + employee.first_name);
            Console.WriteLine("Last Name : " + employee.last_name);
            Console.WriteLine("Birthdate " + employee.birthdate);
            Console.WriteLine("Gender : " + employee.gender);
            Console.WriteLine("Hiring Date : " + employee.hiring_date);
            Console.WriteLine("Email : " + employee.email);
            Console.WriteLine("Phone Number : " + employee.phone_number);
            Console.WriteLine("Department ID " + employee.department_id);
            Console.WriteLine("==========================================");
        }

        public void Output(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Output(employee);
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }

    }
}
