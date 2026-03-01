using Exam_Management_System.Managers;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Management_System.Entities
{
    internal class Student
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int ID { get; private set; }
        public List<int> CoursesID { get; set; }
        public List<int> GradesID { get; set; }


        public Student(string name, int age, int id)
        {
            Name = name;
            Age = age;
            ID = id;
            CoursesID = new List<int>();
            GradesID = new List<int>();
        }

        internal void DisplayInfo()
        {
            Console.WriteLine(
                "\nName: " + this.Name +
                "\nID: " + this.ID +
                "\nAge: " + this.Age +
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
        }

        //internal void RemoveObject()
        //{
        //    FileManager fm = new FileManager();
        //    CourseList courseList = fm.GetCourses();
        //    foreach (Course course in courseList.Courses)
        //    {
        //        foreach (int id in CoursesID)
        //        {
        //            if (course.ID != id) continue;
        //            course.StudentsID.Remove(ID);
        //        }
        //    }
        //}
        internal void Update()
        {
            UniversityManager universityManager = new UniversityManager();
            Name = universityManager.GetInfoFromUser("New name");
            Age = universityManager.GetNumericInfoFromUser("New age");
        }

        internal void EnrollInCourse(Course course)
        {
            if (CoursesID.Contains(course.ID))
            {
                Console.WriteLine($"{Name} is already enrolled in {Name}.");
                return;
            }
            CoursesID.Add(course.ID);
        }
        //Student name, age, students, and other useful information should be provided

        //Student Management

        //      Adding of students
        //      Removing students
        //      Viewing students
        //      Updating students
    }
}
