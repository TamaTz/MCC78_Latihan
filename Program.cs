using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks.Sources;
using Testing.Controller;
using Testing.Model;
using Testing.View;

public class Program
{

    private static menuView MenuView = new();
    private static Education edu = new Education();
    private static Employee emplo = new Employee();
    private static Profiling prof = new Profiling();
    private static University uni = new University();
    private static educationController educationController = new();
    private static universityController universityController = new();
    private static employeeController employeeController = new();
    private static profilingController profilingController = new();

    public static void Main()
    {

        int pilihan;
        do
        {
            MenuView.Menu();
            pilihan = Convert.ToInt32(Console.ReadLine());
            switch (pilihan)
            {
                case 1:
                    MenuView.Insert();
                    int tabel1 = Convert.ToInt32(Console.ReadLine());
                    InsertTabel(tabel1);
                    break;
                case 2:
                    MenuView.Select();
                    int tabel2 = Convert.ToInt32(Console.ReadLine());
                    SelectTabel(tabel2);
                    break;
                case 3:
                    MenuView.Update();
                    int tabel3 = Convert.ToInt32(Console.ReadLine());
                    UpdateTabel(tabel3);
                    break;
                case 4:
                    MenuView.Delete();
                    int tabel4 = Convert.ToInt32(Console.ReadLine());
                    DeleteTabel(tabel4);
                    break;
                case 5:
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("Input Invalid");
                    break;
            }
        } while (pilihan != 5);

    }
    public static void InsertTabel(int tabel1)
    {
        switch (tabel1)
        { 
            case 1:
                Console.WriteLine("=========================================");
                var university = new University();
                Console.WriteLine("Masukkan ID : ");
                int id = Convert.ToInt32(Console.ReadLine());
                university.id = id; 
                Console.Write("Masukkan Nama : ");
                string nama = Console.ReadLine();
                university.name = nama;

                universityController.Insert(university);
                break;    
            case 2:
                Console.WriteLine("========================================");
                Console.WriteLine("Masukkan Major  :  ");
                var major = Console.ReadLine();
                edu.major = major;

                Console.WriteLine("Masukkan Degree  :  ");
                var degree = Console.ReadLine();
                edu.degree = degree;

                Console.WriteLine("Masukkan GPA  :  ");
                var gpa = Console.ReadLine();
                edu.gpa = gpa;

                Console.WriteLine("University ID  :  ");
                var univid = Convert.ToInt32(Console.ReadLine());
                edu.UniversityId = univid;
                break;
            case 3:
                Console.WriteLine("========================================");
                InsertAll();
                break;
        }
    }
    public static void SelectTabel(int table2)
    {
        switch (table2)
        {
            case 1 :
                universityController.GetAll();
                break;
            case 2 :
                educationController.GetAll();
                break;
            case 3 :
                employeeController.GetAll();
                break;
            case 4 :
                profilingController.GetAll();
                break;
            case 5:
                LinqAllData();
                break;
            default:
                Console.WriteLine("Input Salah");
                break;
        }
    }

    public static void UpdateTabel(int tabel3)
    {
        switch (tabel3)
        {
            case 1 :
                var university = new University();
                Console.Write("\nMasukkan ID : ");
                int id = Convert.ToInt32(Console.ReadLine());
                university.id = id;

                Console.Write("Masukkan Nama : ");
                var name = Console.ReadLine();
                university.name = name;

                universityController.Update(university);
                break;
            case 2 :
                var education = new Education();
                Console.WriteLine("Masukkan ID : ");
                education.id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Major  : ");
                education.major = Console.ReadLine();
                Console.WriteLine("Degree  : ");
                education.degree = Console.ReadLine();
                Console.WriteLine("GPA  : ");
                education.gpa = Console.ReadLine();
                Console.WriteLine("University  ID  : ");
                education.UniversityId = Convert.ToInt32(Console.ReadLine());
                
                educationController.Update(education);
                break;
            default :
                Console.WriteLine("Invalid Input");
                break;
        }
    }

    public static void DeleteTabel(int tabel4)
    {
        switch (tabel4)
        {
            case 1:
                var university = new University();

                Console.WriteLine("Masukkan ID : ");
                university.id = Convert.ToInt32(Console.ReadLine());

                universityController.Delete(university);
                break;
            case 2 :
                var education = new Education();

                Console.WriteLine("Masukkan ID : ");
                education.id = Convert.ToInt32(Console.ReadLine());

                educationController.Delete(education);
                break;
        }
    }

    public static void InsertAll()
    {
        
           var employee = new Employee();
           var profiling = new Profiling();
           var education = new Education();
           var university = new University();

           //Employee
           Console.Write("NIK : ");
           var niks = Console.ReadLine();
           employee.nik = niks;

           Console.Write("First Name : ");
           employee.first_name = Console.ReadLine();

           Console.Write("Last Name : ");
           employee.last_name = Console.ReadLine();

           Console.Write("Birthdate  : ");
           employee.birthdate = DateTime.Parse(Console.ReadLine());

           Console.Write("Gender  : ");
           employee.gender = Console.ReadLine();

           Console.Write("Hiring Date  : ");
           employee.hiring_date = DateTime.Parse(Console.ReadLine());

           Console.Write("Email  : ");
           employee.email = Console.ReadLine();

           Console.Write("Phone Number  : ");
           employee.phone_number = Console.ReadLine();

           Console.Write("Department ID  : ");
           employee.department_id = Console.ReadLine();

           //Education
           Console.Write("Major  :  ");
           education.major = Console.ReadLine();

           Console.Write("Degree  :  ");
           education.degree = Console.ReadLine();

           Console.Write("GPA  :  ");
           education.gpa = Console.ReadLine();

           Console.Write("University Name  :  ");
           education.major = Console.ReadLine();

           var result = employee.Insert(employee);
           if (result > 0)
           {
               Console.WriteLine("Insert Success");
           }
           else
           {
               Console.WriteLine("Insert Faied");
           }

            employeeController.Insert(employee);
            universityController.Insert(university);

            education.UniversityId = university.GetUnId();
            education.Insert(education);
            educationController.Insert(education);

            profiling.EmId = employee.GetIdEmp(niks);
            profiling.EmId = employee.GetIdEmp(niks);

            profiling.EdId = education.getEduId();
            profilingController.Insert(profiling);
    }

    public static void LinqAllData()
    {
        Console.WriteLine("Get ALL");
        
        var educationGet = edu.GetEducation();
        var employeesGet = Employee.GetEmployee();
        var profilingGet = prof.GetProfiling();
        var universityGet = uni.GetUniversities();

        var GetAll = from Employees in employeesGet
                     join prof in profilingGet on Employees.id equals prof.EmId
                     join edu in educationGet on prof.EdId equals edu.id
                     join univ in universityGet on edu.UniversityId equals univ.id
                     select new
                     {
                         NIK = Employees.nik,
                         Fullname = Employees.first_name + " " + Employees.last_name,
                         BirthDate = Employees.birthdate,
                         Gender = Employees.gender,
                         HiringDate = Employees.hiring_date,
                         Email = Employees.email,
                         PhoneNumber = Employees.phone_number,
                         Major = edu.major,
                         Degree = edu.degree,
                         GPA = edu.gpa,
                         University = univ.name
                     };
        foreach (var get in GetAll)
        {
            Console.WriteLine($"NIK = {get.NIK}");
            Console.WriteLine($"FullName = {get.Fullname}");
            Console.WriteLine($"Birthdate = {get.BirthDate}");
            Console.WriteLine($"Gender = {get.Gender}");
            Console.WriteLine($"HiringDate = {get.HiringDate}");
            Console.WriteLine($"Email = {get.Email}");
            Console.WriteLine($"PhoneNumber = {get.PhoneNumber}");
            Console.WriteLine($"Major = {get.Major}");
            Console.WriteLine($"Degree = {get.Degree}");
            Console.WriteLine($"GPA = {get.GPA}");
            Console.WriteLine($"University Name = {get.University}");
            Console.WriteLine("===========================================");
        }
    }
}
