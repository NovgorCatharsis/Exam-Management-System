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

        private CourseList courseList;
        private StudentList studentList;
        private GradeList gradeList;

        private string userInput = string.Empty;

        public void AddCourse()
        {
            Course course = new Course(
                um.GetInfoFromUser("Name"),
                um.GetInfoFromUser("Description"),
                um.CreateRandomID()
            );
            courseList = fm.GetCourses();
            courseList.Courses.Add(course);
            fm.Post("courses.json",courseList);
        }


        public void RemoveCourse()
        {
            userInput = um.GetInfoFromUser("ID of the course to remove");
            courseList = fm.GetCourses();
            foreach (Course course in courseList.Courses)
            {
                if (course.ID.ToString() != userInput) continue;
                this.RemoveCourseMentions(course.ID, course.StudentsID, course.GradesID);
                courseList.Courses.Remove(course);

                fm.Post("students.json", studentList);
                fm.Post("courses.json", courseList);

                Console.WriteLine($"{course.Name} was removed.");
                return;
            }
            Console.WriteLine("No such course exists.");
        }

        public void RemoveCourseMentions(int courseID, List<int> studentsID, List<int> gradesID)
        {
            studentList = fm.GetStudents();
            gradeList = fm.GetGrades();
            foreach (Student student in studentList.Students) // Loop through all existing students
            {
                foreach (int id in studentsID) // Loop through all existing student IDs
                {
                    if (student.ID != id) continue; // If selected student doesn't have the course, skip to the next student
                    student.CoursesID.Remove(courseID);
                }
            }
            foreach (Grade grade in gradeList.Grades)
            {
                foreach (int id in gradesID)
                {
                    if (grade.ID != id) continue;
                    GradeManager gm = new GradeManager();
                    gm.RemoveGrade(grade);
                }
            }
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

                fm.Post("courses.json", courseList);

                Console.WriteLine($"{course.Name} was updated.");
                return;
            }
            Console.WriteLine("No such course exists.");
        } 
    }
}
