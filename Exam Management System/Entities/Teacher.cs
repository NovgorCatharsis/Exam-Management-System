using Exam_Management_System.Managers;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Management_System.Entities
{
    internal class Teacher
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        public List<int> CoursesID { get; set; }


        public Teacher(string name, int id)
        {
            Name = name;
            ID = id;
            CoursesID = new List<int>();
        }

        internal void DisplayInfo()
        {
            Console.WriteLine(
                "\nName: " + this.Name +
                "\nID: " + this.ID +
                "\nCourses: ");
            foreach (int i in CoursesID)
            {
                if (i != CoursesID.Last())
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
        }

        internal void AddCourse(Course course)
        {
            if (CoursesID.Contains(course.ID))
            {
                Console.WriteLine($"{Name} already teaches {Name}.");
                return;
            }
            CoursesID.Add(course.ID);
        }
        //Teacher details and courses they are responsible for

        //Teacher Management

        //      Adding of teachers
        //      Removing teachers
        //      Viewing teachers
        //      Updating teachers
    }
}
