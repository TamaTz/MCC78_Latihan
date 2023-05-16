using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Model;
using Testing.View;

namespace Testing.Controller
{
    public class employeeController
    {
        private static Employee Employee = new Employee();

        public void GetAll()
        {
            var results = Employee.GetEmployee();
            var view = new employeeView();
            if (results.Count == 0)
            {
                view.Output("Data Tidak Ada");
            }
            else
            {
                view.Output(results);
            }
        }

        public void Insert(Employee employee)
        {
            var result = Employee.Insert(employee);
            var view = new employeeView();
            if (result == 0)
            {
                view.Output("Gagal Memasukkan Data");
            }
            else
            {
                view.Output("Berhasil Memasukkan Data");
            }
        }
    }
}
