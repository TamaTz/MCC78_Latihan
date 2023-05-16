using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.View
{
    public class menuView
    {
        public void Menu()
        {
            Console.WriteLine("\n Menu");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Select");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Exit");
            Console.WriteLine("\nPilih Menu : ");
        }

        public void Insert()
        {
            Console.WriteLine("\n Pilih tabel yang akan di insert datanya");
            Console.WriteLine("1. University");
            Console.WriteLine("2. Education");
            Console.WriteLine("3. Semua Data");
            Console.WriteLine("Pilih Tabel : ");
        }

        public void Select()
        {
            Console.WriteLine("\n Pilih tabel yang akan di tampilkan datanya");
            Console.WriteLine("1. University");
            Console.WriteLine("2. Education");
            Console.WriteLine("3. Employee");
            Console.WriteLine("4. Profiling");
            Console.WriteLine("5. Semua Data");
            Console.WriteLine("Pilih Tabel : ");
        }

        public void Update()
        {
            Console.WriteLine("\n Pilih tabel yang akan di update datanya");
            Console.WriteLine("1. University");
            Console.WriteLine("2. Education");
            Console.WriteLine("Pilih Tabel : ");
        }

        public void Delete()
        {
            Console.WriteLine("\n Pilih tabel yang akan di hapus datanya");
            Console.WriteLine("1. University");
            Console.WriteLine("2. Education");
            Console.WriteLine("Pilih Tabel : ");
        }
    }
}
