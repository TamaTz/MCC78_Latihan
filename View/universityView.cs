using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Model;

namespace Testing.View
{
    public class universityView
    {
        public void Output(University university)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("Id  :  " + university.id);
            Console.WriteLine("Name  : " + university.name);
            Console.WriteLine("========================================================");
        }

        public void Output(List<University> universities)
        {
            foreach (var university in universities)
            {
                Output(university);
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}
