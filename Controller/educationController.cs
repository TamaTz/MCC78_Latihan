using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Model;
using Testing.View;

namespace Testing.Controller
{
    public class educationController
    {
        private static Education edu = new();

        public void GetAll()
        {
            var results = edu.GetEducation();
            var view = new educationView();
            if(results.Count == 0)
            {
                view.Output("Data Tidak Ada");
            }
            else{
                view.Output(results);
            }
        }

        public void Insert(Education education)
        {
            var result = edu.Insert(education);
            var view = new educationView();
            if (result == 0)
            {
                view.Output("Ada Yang Salah!");
            }
            else
            {
                view.Output("Data Berhasil Dimasukkan");
            }
        }

        public void Update(Education education)
        {
            var results = edu.Update(education);
            var view = new educationView();
            if (results > 0)
            {
                view.Output("Update Gagal");
            }
            else
            {
                view.Output("Update Berhasil");
            }
        }

        public void Delete(Education education)
        {
            var results = edu.DeleteEducation(education);
            var view = new educationView();
            if (results > 0)
            {
                view.Output("Delete Success");
            }
            else
            {
                view.Output("Delete Gagal");
            }
        }
    }
}
