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

        //public List<Student> studentList = new List<Student>();
        private StudentList studentList;
        private CourseList courseList;

        private string userInput = string.Empty;
        private string userInput_1 = string.Empty;

        string fileName = "students.json";
        //public void AddStudent()
        //{
        //    Student student = new Student(
        //        um.GetInfoFromUser("Name"),
        //        um.GetNumericInfoFromUser("Age"),
        //        um.CreateRandomID()
        //    );
        //    studentList.Add(student);
        //    StreamWriter sw = new StreamWriter(@"..\..\..\TextFiles/Students.txt", true);
        //    sw.WriteLine(student.ID);
        //    sw.Dispose();

        //    Console.WriteLine($"{student.Name} was enrolled.");
        //}
        //public void AddStudent()
        //{
        //    Student student = new Student(
        //        um.GetInfoFromUser("Name"),
        //        um.GetNumericInfoFromUser("Age"),
        //        um.CreateRandomID()
        //    );
        //    string jsonpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory,@"..\..\..\JSON\students.json"));
        //    string content = File.ReadAllText(jsonpath);

        //    StudentList studentList;
        //    if (content is null || content == "")
        //    {
        //        studentList = new StudentList();
        //    }
        //    else
        //    {
        //        studentList = JsonSerializer.Deserialize<StudentList>(content);
        //        //int maxid = studentList.Students.Max(s => s.ID);
        //        //student.ID = maxid + 1;
        //    }

        //    studentList.Students.Add(student);
        //    string jsonstring = JsonSerializer.Serialize(studentList);
        //    File.WriteAllText(jsonpath, jsonstring);
        //}

        public void AddStudent()
        {
            Student student = new Student(
                um.GetInfoFromUser("Name"),
                um.GetNumericInfoFromUser("Age"),
                um.CreateRandomID()
            );

            studentList = fm.GetStudents();
            studentList.Students.Add(student);
            fm.Post(fileName, studentList);
        }

       
        public void RemoveStudent()
        {
            userInput = um.GetInfoFromUser("ID of the student to remove");
            studentList = fm.GetStudents();
            foreach (Student student in studentList.Students)
            {
                if (student.ID.ToString() != userInput) continue;
                this.StudentRemover(student.ID, student.CoursesID);
                studentList.Students.Remove(student);
                fm.Post(fileName, studentList);
                fm.Post("courses.json", courseList);

                Console.WriteLine($"{student.Name} was removed.");
                return;
            }
            Console.WriteLine("No such student exists.");
        }

        public void StudentRemover(int studentID, List <int> coursesID)
        {
            courseList = fm.GetCourses();
            foreach (Course course in courseList.Courses)
            {
                foreach (int id in coursesID)
                {
                    if (course.ID != id) continue;
                    course.StudentsID.Remove(studentID);
                }
            }
        }

        public void ViewStudents()
        {
            studentList = fm.GetStudents();
            foreach (Student student in studentList.Students)
            {
                Console.WriteLine("123 " + student.CoursesID.Count);
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
                fm.Post(fileName, studentList);

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
                    //Console.WriteLine("input " + userInput_1);
                    //Console.WriteLine("id " + course.ID.ToString());
                    if (course.ID.ToString() != userInput_1) continue;

                    student.EnrollInCourse(course);
                    course.EnrollStudent(student);
                    fm.Post(fileName, studentList);
                    fm.Post("courses.json", courseList);

                    Console.WriteLine($"{student.Name} was enrolled.");
                    return;
                }
                Console.WriteLine("No such course exists.");
                return;
            }
            Console.WriteLine("No such student exists.");
        }



    }
}
