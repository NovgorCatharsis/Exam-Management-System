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


        public Student(string name, int age, int id)
        {
            Name = name;
            Age = age;
            ID = id;
            CoursesID = new List<int>();
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
                Console.WriteLine("TEST");
                Console.WriteLine(i.ToString() + ", ");
            }
        }

        internal void RemoveObject()
        {
            //foreach (Course course in Courses)
            //{
            //    course.Students.Remove(this);
            //}
            // Rewrite the file without the removed object
            File.WriteAllLines(@"..\..\..\TextFiles/Students.txt", File.ReadLines(@"..\..\..\TextFiles/Students.txt").Where(l => l != ID.ToString()).ToList());
        }

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
