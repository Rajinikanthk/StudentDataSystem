using StudentDataSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> StudentData = new List<Student>();
            try
            {
                string path = "D:\\Mphasis\\c#\\StudentDataSystem\\student data.txt";

                string[] student_data = File.ReadAllLines(path);

                foreach (string line in student_data)
                {
                    String[] data = line.Split(',');
                    if (data.Length >= 1)
                    {
                        Student student = new Student();
                        student.Sname = data[0];
                        student.ClassName = data[1];
                        StudentData.Add(student);
                    }
                }
                Student s = new Student();
                StudentData.Sort(s);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Display Student Data");
            foreach (var student in StudentData)
            {
                Console.WriteLine(student.Sname + " " + student.ClassName);
            }
            Console.WriteLine("=======================================");

            Console.WriteLine("Enter Name To Search :");
            string name = Console.ReadLine();

            Student sf = Search(StudentData, name);
            if (sf != null)
            {
                Console.WriteLine(sf.Sname + " " + sf.ClassName);
            }
            else
            {
                Console.WriteLine("Not Found.");
            }

            Console.ReadLine();
        }

        public static Student Search(List<Student> list, string name)
        {
            Student Student_found = list.Find(data => data.Sname == name);
            if (Student_found != null)
            {
                return Student_found;
            }
            else
            {
                return null;
            }
        }


    }
}