using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks.Sources;
using Testing;

public class Program
{
    private static readonly string connectionString =
        "Data Source=WINDOWS-8FL63UC;Database=bookingservice;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    
    public static void Menu()
    {
        Console.WriteLine("\n Menu");
        Console.WriteLine("1. Insert");
        Console.WriteLine("2. Select");
        Console.WriteLine("3. Update");
        Console.WriteLine("4. Delete");
        Console.WriteLine("5. Insert Semua Data");
        Console.WriteLine("6. Exit");
        Console.WriteLine("\nPilih Menu : ");
    }

    public static void Main()
    {

        int pilihan;
        do
        {
            Menu();
            pilihan = Convert.ToInt32(Console.ReadLine());
            switch (pilihan)
            {
                case 1:
                    Console.WriteLine("\n Pilih tabel yang akan di insert datanya");
                    Console.WriteLine("1. University");
                    Console.WriteLine("2. Education");
                    Console.WriteLine("Pilih Tabel : ");
                    int tabel = Convert.ToInt32(Console.ReadLine());
                    if (tabel == 1)
                    {
                        var university = new Universities();
                        Console.WriteLine("Masukkan Nama : ");
                        string nama = Console.ReadLine();
                        university.name = nama;

                        var result = Universities.InsertUniversity(university);
                        if (result > 0)
                        {
                            Console.WriteLine("Insert Success");
                        }
                        else
                        {
                            Console.WriteLine("Insert Failed");
                        }
                    }
                    else if (tabel == 2)
                    {
                        var education = new Educations();
                        Console.WriteLine("Masukkan Major : ");
                        var major = Console.ReadLine();
                        education.major = major;

                        Console.WriteLine("Masukkan Degree : ");
                        var degree = Console.ReadLine();
                        education.degree = degree;

                        Console.WriteLine("Masukkan GPA : ");
                        var gpa = Console.ReadLine();
                        education.gpa = gpa;

                        Console.WriteLine("University ID : ");
                        var university_id = Convert.ToInt32(Console.ReadLine());
                        education.university_id = university_id;

                        var result = Educations.InsertEducation(education);
                        if (result > 0)
                        {
                            Console.WriteLine("Insert Success");
                        }
                        else
                        {
                            Console.WriteLine("Insert Failed");
                        }
                    }
                    else
                    {

                    }
                    break;
                case 2:
                    Console.WriteLine("\n Pilih tabel yang akan di insert datanya");
                    Console.WriteLine("1. University");
                    Console.WriteLine("2. Education");
                    Console.WriteLine("Pilih Tabel : ");
                    int tabel2 = Convert.ToInt32(Console.ReadLine());
                    if (tabel2 == 1)
                    {
                        Console.WriteLine("SELECT ALL");
                        var results = Universities.GetUniversities();
                        foreach (var result in results)
                        {
                            Console.WriteLine("Id : " + result.id);
                            Console.WriteLine("Name : " + result.name);
                        }
                    }
                    if (tabel2 == 2)
                    {
                        Console.WriteLine("SELECT ALL");
                        var results = Educations.GetEducations();
                        foreach (var result in results)
                        {
                            Console.WriteLine("Id : " + result.id);
                            Console.WriteLine("Major  : " + result.major);
                            Console.WriteLine("Degree  : " + result.degree);
                            Console.WriteLine("GPA  : " + result.gpa);
                            Console.WriteLine("University ID : " + result.university_id);
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("\n Pilih tabel yang akan di insert datanya");
                    Console.WriteLine("1. University");
                    Console.WriteLine("2. Education");
                    Console.WriteLine("Pilih Tabel : ");
                    int tabel3 = Convert.ToInt32(Console.ReadLine());
                    if (tabel3 == 1)
                    {
                        var university = new Universities();

                        Console.WriteLine("Masukkan ID :");
                        int id = Convert.ToInt32(Console.ReadLine());
                        university.id = id;

                        Console.WriteLine("Masukkan Nama : ");
                        var name3 = Console.ReadLine();
                        university.name = name3;

                        var result = Universities.UpdateUniversity(university);
                        if (result > 0)
                        {
                            Console.WriteLine("Update Success");
                        }
                        else
                        {
                            Console.WriteLine("Update Failed");
                        }
                    }

                    if (tabel3 == 2)
                    {
                        var education = new Educations();
                        Console.WriteLine("Masukkan ID : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Major  : ");
                        string major = Console.ReadLine();
                        Console.WriteLine("Degree  : ");
                        string degree = Console.ReadLine();
                        Console.WriteLine("GPA  : ");
                        string gpa = Console.ReadLine();
                        Console.WriteLine("University  ID  : ");
                        int univ_id = Convert.ToInt32(Console.ReadLine());

                        education.id = id;
                        education.major = major;
                        education.degree = degree;
                        education.gpa = gpa;
                        education.university_id = univ_id;

                        var results = Educations.UpdateEducation(education);
                        if (results > 0)
                        {
                            Console.WriteLine("Update Success");
                        }
                        else
                        {
                            Console.WriteLine("Update Failed");
                        }

                    }
                    break;
                case 4:
                    Console.WriteLine("\n Pilih tabel yang akan di insert datanya");
                    Console.WriteLine("1. University");
                    Console.WriteLine("2. Education");
                    Console.WriteLine("Pilih Tabel : ");
                    int tabel4 = Convert.ToInt32(Console.ReadLine());
                    if (tabel4 == 1)
                    {
                        var university = new Universities();

                        Console.WriteLine("Masukkan ID : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        university.id = id;

                        var result = Universities.DeleteUniversity(university);
                        if (result > 0)
                        {
                            Console.WriteLine("Delete Success");
                        }
                        else
                        {
                            Console.WriteLine("Delete Failed");
                        }
                    }
                    else if (tabel4 == 2)
                    {
                        var education = new Educations();

                        Console.WriteLine("Masukkan ID : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        education.id = id;

                        var result = Educations.DeleteEducation(education);
                        if (result > 0)
                        {
                            Console.WriteLine("Delete Success");
                        }
                        else
                        {
                            Console.WriteLine("Delete Failed");
                        }
                    }
                    break;
                case 5:
                    Employees.CetakEmployee();
                    break;
                default:
                    Console.WriteLine("Input Invalid");
                    break;
            }
        } while (pilihan != 6);
    }

}