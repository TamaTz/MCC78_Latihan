using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Model;

namespace Testing.View
{
    public class educationView
    {
        public void Output(Education education)
        {
            Console.WriteLine("=========================================================");
            Console.WriteLine("Id : " + education.id);
            Console.WriteLine("Major  : " + education.major);
            Console.WriteLine("Degree  : " + education.degree);
            Console.WriteLine("GPA  : " + education.gpa);
            Console.WriteLine("University ID : " + education.UniversityId);
            Console.WriteLine("=========================================================");
        }
        public void Output(List<Education> educations)
        {
            foreach (var edu in educations)
            {
                Output(edu);
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }

        public void AllData()
        {
            Console.WriteLine("Menampilkan Semua Data Education");
        }
    }
}
