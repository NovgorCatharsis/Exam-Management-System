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


        public Course(string name, string description, int id)
        {
            Name = name;
            Description = description;
            ID = id;
            StudentsID = new List<int>();
        }

        internal void DisplayInfo()
        {
            Console.WriteLine(
                "\nName: " + this.Name +
                "\nID: " + this.ID +
                "\nDescription: " + this.Description +
                "\nStudents: ");
            //foreach (Student student in Students)
            //{
            //    Console.WriteLine(student.ID + ", ");
            //}
        }

        internal void RemoveObject()
        {
            //foreach (Student student in Students)
            //{
            //    student.Courses.Remove(this);
            //}
            // Rewrite the file without the removed object
            File.WriteAllLines(@"..\..\..\TextFiles/Courses.txt", File.ReadLines(@"..\..\..\TextFiles/Courses.txt").Where(l => l != ID.ToString()).ToList());
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
        //Courses name, id, description, etc should be collected

        //Course Management

        //      Adding of course
        //      Removing course
        //      Viewing course
        //      Updating course
    }
}
