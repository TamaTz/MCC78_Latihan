using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Testing.Model;

namespace Testing.View
{
    public class profilingView
    {
        public void Output(Profiling profiling)
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("Employee ID : " + profiling.EmId);
            Console.WriteLine("Education ID : " + profiling.EdId);
            Console.WriteLine("===================================================");
        }

        public void Output(List<Profiling> profilings)
        {
            foreach (var profiling in profilings)
            {
                Output(profiling);
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}
