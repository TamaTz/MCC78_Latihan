using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Model;
using Testing.View;

namespace Testing.Controller
{
    public class profilingController
    {
        private Profiling prof = new Profiling();
        
        public void GetAll()
        {
            var results = prof.GetProfiling();
            var view = new profilingView();
            if (results.Count == 0)
            {
                view.Output("Data Tidak Ada");
            }
            else
            {
                view.Output(results);
            }
        }

        public void Insert(Profiling profiling)
        {
            var result = prof.Insert(profiling);
            var view = new profilingView();
            if (result == 0)
            {
                view.Output("Insert Profiling Gagal");
            }
            else
            {
                view.Output("Insert Profiling Berhasil");
            }
        }
    }
}
