using Exam_Management_System.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Management_System.Entities
{
    internal class Course
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ID { get; private set; }
        public List<int> StudentsID { get; set; }
        public List<int> GradesID { get; set; }
        public List<int> TeachersID { get; set; }


        public Course(string name, string description, int id)
        {
            Name = name;
            Description = description;
            ID = id;
            StudentsID = new List<int>();
            GradesID = new List<int>();
            TeachersID = new List<int>();
        }

        internal void DisplayInfo()
        {
            Console.WriteLine(
                "\nName: " + this.Name +
                "\nID: " + this.ID +
                "\nDescription: " + this.Description +
                "\nStudents: ");
            foreach (int i in StudentsID)
            {
                if (i != StudentsID.Last())
                {
                    Console.Write(i.ToString() + ", ");
                }
                else
                {
                    Console.Write(i.ToString() + "\n");
                }
            }

            Console.WriteLine("Grades: ");
            foreach (int i in GradesID)
            {
                if (i != GradesID.Last())
                {
                    Console.Write(i.ToString() + ", ");
                }
                else
                {
                    Console.Write(i.ToString() + "\n");
                }
            }

            Console.WriteLine("Teachers: ");
            foreach (int i in TeachersID)
            {
                if (i != TeachersID.Last())
                {
                    Console.Write(i.ToString() + ", ");
                }
                else
                {
                    Console.Write(i.ToString() + "\n");
                }
            }
        }

        internal void Update()
        {
            UniversityManager universityManager = new UniversityManager();
            Name = universityManager.GetInfoFromUser("New name");
            Description = universityManager.GetInfoFromUser("New description");
        }

        internal void EnrollStudent(Student student)
        {
            if (StudentsID.Contains(student.ID))
            {
                Console.WriteLine($"{student.Name} is already enrolled in {Name}.");
                return;
            }
            StudentsID.Add(student.ID);
        }

        internal void AddTeacher(Teacher teacher)
        {
            if (TeachersID.Contains(teacher.ID))
            {
                Console.WriteLine($"{teacher.Name} already teaches {Name}.");
                return;
            }
            TeachersID.Add(teacher.ID);
        }
        //Courses name, id, description, etc should be collected

        //Course Management

        //      Adding of course
        //      Removing course
        //      Viewing course
        //      Updating course
    }
}
