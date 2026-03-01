//using Exam_Management_System.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Exam_Management_System.Managers
//{
//    internal class OLD_CourseManager
//    {
//        private UniversityManager um = new UniversityManager();

//        public List<Course> courseList = new List<Course>();

//        private string userInput = string.Empty;

//        public void AddCourse()
//        {
//            Course course = new Course(
//                um.GetInfoFromUser("Name"),
//                um.GetInfoFromUser("Description"),
//                um.CreateRandomID()
//            );
//            courseList.Add(course);
//            StreamWriter sw = new StreamWriter(@"..\..\..\TextFiles/Courses.txt", true);
//            sw.WriteLine(course.ID);
//            sw.Dispose();

//            Console.WriteLine($"{course.Name} was added.");
//        }

//        public void RemoveCourse()
//        {
//            userInput = um.GetInfoFromUser("ID of the course to remove");
//            foreach (Course course in courseList)
//            {
//                if (course.ID.ToString() != userInput) continue;
//                course.RemoveObject();
//                courseList.Remove(course);

//                Console.WriteLine($"{course.Name} was removed.");
//                return;
//            }
//            Console.WriteLine("No such course exists.");
//        }

//        public void ViewCourses()
//        {
//            foreach (Course course in courseList)
//            {
//                course.DisplayInfo();
//            }
//        }

//        public void UpdateCourse()
//        {
//            userInput = um.GetInfoFromUser("ID of the course to update");
//            foreach (Course course in courseList)
//            {
//                if (course.ID.ToString() != userInput) continue;
//                course.Update();

//                Console.WriteLine($"{course.Name} was updated.");
//                return;
//            }
//            Console.WriteLine("No such course exists.");
//        }
//    }
//}
