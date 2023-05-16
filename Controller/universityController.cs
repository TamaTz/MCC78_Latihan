using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Model;
using Testing.View;

namespace Testing.Controller
{
    public class universityController
    {
        private static University univ = new();

        public void GetAll()
        {
            var results = univ.GetUniversities();
            var view = new universityView();
            if (results.Count == 0)
            {
                view.Output("Data Not Found");
;
            }
            else
            {
                view.Output(results);
            }
        }

        public void Insert(University university)
        {
            var result = univ.Insert(university);
            var view = new universityView();
            if (result == 0)
            {
                view.Output("Something Wrong!");
            }
            else
            {
                view.Output("Data Has Been Insertedq");
            }
        }

        public void Update(University university)
        {
            var result = univ.Update(university);
            var view = new universityView();
            if(result == 0)
            {
                view.Output("Update Success");
            }
            else
            {
                view.Output("Update Failed");
            }
        }

        public void Delete(University university)
        {
            var result = univ.Delete(university);
            var view = new universityView();
            if (result < 0 )
            {
                view.Output("Delete Success");
            }
            else
            {
                view.Output("Delete Failed");
            }
        }
    }
}
