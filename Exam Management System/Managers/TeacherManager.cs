using Exam_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exam_Management_System.Managers
{
    internal class TeacherManager
    {
        private UniversityManager um = new UniversityManager();
        private FileManager fm = new FileManager();

        private TeacherList teacherList;
        private CourseList courseList;

        private string userInput = string.Empty;
        private string userInput_1 = string.Empty;

        public void AddTeacher()
        {
            Teacher teacher = new Teacher(
                um.GetInfoFromUser("Name"),
                um.CreateRandomID()
            );

            teacherList = fm.GetTeachers();
            teacherList.Teachers.Add(teacher);
            fm.Post("teachers.json", teacherList);
        }


        public void RemoveTeacher()
        {
            userInput = um.GetInfoFromUser("ID of the teacher to remove");
            teacherList = fm.GetTeachers();
            foreach (Teacher teacher in teacherList.Teachers)
            {
                if (teacher.ID.ToString() != userInput) continue;
                this.RemoveTeacherMentions(teacher.ID, teacher.CoursesID);
                teacherList.Teachers.Remove(teacher);

                fm.Post("teachers.json", teacherList);
                fm.Post("courses.json", courseList);

                Console.WriteLine($"{teacher.Name} was removed.");
                return;
            }
            Console.WriteLine("No such teacher exists.");
        }

        public void RemoveTeacherMentions(int teacherID, List<int> coursesID)
        {
            courseList = fm.GetCourses();
            foreach (Course course in courseList.Courses)
            {
                foreach (int id in coursesID)
                {
                    if (course.ID != id) continue;
                    course.TeachersID.Remove(teacherID);
                }
            }
        }

        public void ViewTeachers()
        {
            teacherList = fm.GetTeachers();
            foreach (Teacher teacher in teacherList.Teachers)
            {
                teacher.DisplayInfo();
            }
        }


        public void UpdateTeacher()
        {
            userInput = um.GetInfoFromUser("ID of the teacher to update");
            teacherList = fm.GetTeachers();
            foreach (Teacher teacher in teacherList.Teachers)
            {
                if (teacher.ID.ToString() != userInput) continue;
                teacher.Update();

                fm.Post("teachers.json", teacherList);

                Console.WriteLine($"{teacher.Name} was updated.");
                return;
            }
            Console.WriteLine("No such teacher exists.");
        }


        public void TeachNewCourse()
        {
            userInput = um.GetInfoFromUser("ID of the teacher to add");
            userInput_1 = um.GetInfoFromUser("ID of the course to teach");

            teacherList = fm.GetTeachers();
            courseList = fm.GetCourses();
            foreach (Teacher teacher in teacherList.Teachers)
            {
                if (teacher.ID.ToString() != userInput) continue;

                // If we have found a teacher, we proceed to find the course.
                foreach (Course course in courseList.Courses)
                {
                    if (course.ID.ToString() != userInput_1) continue;
                    teacher.AddCourse(course);
                    course.AddTeacher(teacher);

                    fm.Post("teachers.json", teacherList);
                    fm.Post("courses.json", courseList);

                    Console.WriteLine($"{teacher.Name} now teaches {course.Name}.");
                    return;
                }
                Console.WriteLine("No such course exists.");
                return;
            }
            Console.WriteLine("No such teacher exists.");
        }
    }
}
