using Exam_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Management_System.Managers
{
    internal class GradeManager
    {
        private UniversityManager um = new UniversityManager();
        private FileManager fm = new FileManager();

        private StudentList studentList;
        private CourseList courseList;
        private GradeList gradeList;

        private string userInput = string.Empty;
        private string userInput_1 = string.Empty;
        private int outNumber;
        private int outNumber_1;

        public void AddGrade()
        {
            userInput = um.GetInfoFromUser("ID of the student to grade");
            userInput_1 = um.GetInfoFromUser("ID of the course to grade");

            studentList = fm.GetStudents();
            courseList = fm.GetCourses();
            gradeList = fm.GetGrades();
            foreach (Student student in studentList.Students)
            {
                if (student.ID.ToString() != userInput) continue;

                // If we have found a student, we proceed to find the course.
                foreach (Course course in courseList.Courses)
                {
                    if (course.ID.ToString() != userInput_1) continue;
                    if (!student.CoursesID.Contains(course.ID))
                    {
                        Console.WriteLine($"{student.Name} is not enrolled in {course.Name}.");
                        return;
                    }

                    Grade grade = new Grade(
                        um.GetNumericInfoFromUser("Value"),
                        um.CreateRandomID(),
                        Int32.Parse(userInput), // Student ID
                        Int32.Parse(userInput_1) // Course ID
                    );
                    gradeList.Grades.Add(grade);
                    student.GradesID.Add(grade.ID);
                    course.GradesID.Add(grade.ID);

                    fm.Post("students.json", studentList);
                    fm.Post("courses.json", courseList);
                    fm.Post("grades.json", gradeList);

                    Console.WriteLine($"{grade.Value} was added to {student.Name} for {course.Name}.");
                    return;
                }
                Console.WriteLine("No such course exists.");
                return;
            }
            Console.WriteLine("No such student exists.");
        }


        public void RemoveGrade()
        {
            userInput = um.GetInfoFromUser("ID of the grade to remove");
            gradeList = fm.GetGrades();
            foreach (Grade grade in gradeList.Grades)
            {
                if (grade.ID.ToString() != userInput) continue;
                this.RemoveGradeMentions(grade.ID, grade.StudentID, grade.CourseID);
                gradeList.Grades.Remove(grade);

                fm.Post("students.json", studentList);
                fm.Post("courses.json", courseList);
                fm.Post("grade.json", gradeList);

                Console.WriteLine($"Grade {grade.Value} was removed.");
                return;
            }
            Console.WriteLine("No such grade exists.");
        }

        public void RemoveGrade(Grade grade) // Grade removal when student/course is removed
        {
            this.RemoveGradeMentions(grade.ID, grade.StudentID, grade.CourseID);
            gradeList.Grades.Remove(grade);

            fm.Post("students.json", studentList);
            fm.Post("courses.json", courseList);
            fm.Post("grades.json", gradeList);
            return;
        }


        public void RemoveGradeMentions(int gradeID, int studentID, int courseID)
        {
            studentList = fm.GetStudents();
            courseList = fm.GetCourses();
            foreach (Student student in studentList.Students)
            {
                if (student.ID != studentID) continue;
                student.GradesID.Remove(gradeID);
            }
            foreach (Course course in courseList.Courses)
            {
                if (course.ID != courseID) continue;
                course.GradesID.Remove(gradeID);
            }
        }


        public void ViewGrades()
        {
            gradeList = fm.GetGrades();
            foreach (Grade grade in gradeList.Grades)
            {
                grade.DisplayInfo();
            }
        }
    }
}
