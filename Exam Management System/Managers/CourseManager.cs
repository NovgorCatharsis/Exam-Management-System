using Exam_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exam_Management_System.Managers
{
    internal class CourseManager
    {
        private UniversityManager um = new UniversityManager();
        private FileManager fm = new FileManager();

        //public List<Course> courseList = new List<Course>();
        private CourseList courseList;

        private string userInput = string.Empty;
        string fileName = "courses.json";

        public void AddCourse()
        {
            Course course = new Course(
                um.GetInfoFromUser("Name"),
                um.GetInfoFromUser("Description"),
                um.CreateRandomID()
            );
            courseList = fm.GetCourses();
            courseList.Courses.Add(course);
            fm.Post(fileName,courseList);
        }

        public void RemoveCourse()
        {
            userInput = um.GetInfoFromUser("ID of the course to remove");
            courseList = fm.GetCourses();
            foreach (Course course in courseList.Courses)
            {
                if (course.ID.ToString() != userInput) continue;
                //course.RemoveObject();
                courseList.Courses.Remove(course);
                fm.Post(fileName, courseList);

                Console.WriteLine($"{course.Name} was removed.");
                return;
            }
            Console.WriteLine("No such course exists.");
        }

        public void ViewCourses()
        {
            courseList = fm.GetCourses();
            foreach (Course course in courseList.Courses)
            {
                course.DisplayInfo();
            }
        }

        public void UpdateCourse()
        {
            userInput = um.GetInfoFromUser("ID of the course to update");
            courseList = fm.GetCourses();
            foreach (Course course in courseList.Courses)
            {
                if (course.ID.ToString() != userInput) continue;
                course.Update();
                fm.Post(fileName, courseList);

                Console.WriteLine($"{course.Name} was updated.");
                return;
            }
            Console.WriteLine("No such course exists.");
        }


        
    }
}
