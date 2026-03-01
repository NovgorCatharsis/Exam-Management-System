using Exam_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exam_Management_System.Managers
{
    internal class StudentManager
    {
        private UniversityManager um = new UniversityManager();
        private FileManager fm = new FileManager();

        private StudentList studentList;
        private CourseList courseList;
        private GradeList gradeList;

        private string userInput = string.Empty;
        private string userInput_1 = string.Empty;

        public void AddStudent()
        {
            Student student = new Student(
                um.GetInfoFromUser("Name"),
                um.GetNumericInfoFromUser("Age"),
                um.CreateRandomID()
            );

            studentList = fm.GetStudents();
            studentList.Students.Add(student);
            fm.Post("students.json", studentList);
        }

       
        public void RemoveStudent()
        {
            userInput = um.GetInfoFromUser("ID of the student to remove");
            studentList = fm.GetStudents();
            foreach (Student student in studentList.Students)
            {
                if (student.ID.ToString() != userInput) continue;
                this.RemoveStudentMentions(student.ID, student.CoursesID, student.GradesID);
                studentList.Students.Remove(student);

                fm.Post("students.json", studentList);
                fm.Post("courses.json", courseList);

                Console.WriteLine($"{student.Name} was removed.");
                return;
            }
            Console.WriteLine("No such student exists.");
        }

        public void RemoveStudentMentions(int studentID, List <int> coursesID, List<int> gradesID)
        {
            courseList = fm.GetCourses();
            gradeList = fm.GetGrades();
            foreach (Course course in courseList.Courses)
            {
                foreach (int id in coursesID)
                {
                    if (course.ID != id) continue;
                    course.StudentsID.Remove(studentID);
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

        public void ViewStudents()
        {
            studentList = fm.GetStudents();
            foreach (Student student in studentList.Students)
            {
                student.DisplayInfo();
            }
        }


        public void UpdateStudent()
        {
            userInput = um.GetInfoFromUser("ID of the student to update");
            studentList = fm.GetStudents();
            foreach (Student student in studentList.Students)
            {
                if (student.ID.ToString() != userInput) continue;
                student.Update();

                fm.Post("students.json", studentList);

                Console.WriteLine($"{student.Name} was updated.");
                return;
            }
            Console.WriteLine("No such student exists.");
        }


        public void EnrollStudent()
        {
            userInput = um.GetInfoFromUser("ID of the student to enroll");
            userInput_1 = um.GetInfoFromUser("ID of the course to enroll to");

            studentList = fm.GetStudents();
            courseList = fm.GetCourses();
            foreach (Student student in studentList.Students)
            {
                if (student.ID.ToString() != userInput) continue;

                // If we have found a student, we proceed to find the course.
                foreach (Course course in courseList.Courses)
                {
                    if (course.ID.ToString() != userInput_1) continue;
                    student.EnrollInCourse(course);
                    course.EnrollStudent(student);

                    fm.Post("students.json", studentList);
                    fm.Post("courses.json", courseList);

                    Console.WriteLine($"{student.Name} was enrolled to {course.Name}.");
                    return;
                }
                Console.WriteLine("No such course exists.");
                return;
            }
            Console.WriteLine("No such student exists.");
        }
    }
}
