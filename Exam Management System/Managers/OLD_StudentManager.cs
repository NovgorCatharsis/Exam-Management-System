//using Exam_Management_System.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace Exam_Management_System.Managers
//{
//    internal class OLD_StudentManager
//    {
//        private UniversityManager um = new UniversityManager();

//        //public List<Student> studentList = new List<Student>();
//        StudentList studentList;

//        private string userInput = string.Empty;
//        private string userInput_1 = string.Empty;

//        string jsonPath;
//        string content;
//        string jsonString;
//        //public void AddStudent()
//        //{
//        //    Student student = new Student(
//        //        um.GetInfoFromUser("Name"),
//        //        um.GetNumericInfoFromUser("Age"),
//        //        um.CreateRandomID()
//        //    );
//        //    studentList.Add(student);
//        //    StreamWriter sw = new StreamWriter(@"..\..\..\TextFiles/Students.txt", true);
//        //    sw.WriteLine(student.ID);
//        //    sw.Dispose();

//        //    Console.WriteLine($"{student.Name} was enrolled.");
//        //}
//        //public void AddStudent()
//        //{
//        //    Student student = new Student(
//        //        um.GetInfoFromUser("Name"),
//        //        um.GetNumericInfoFromUser("Age"),
//        //        um.CreateRandomID()
//        //    );
//        //    string jsonpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory,@"..\..\..\JSON\students.json"));
//        //    string content = File.ReadAllText(jsonpath);

//        //    StudentList studentList;
//        //    if (content is null || content == "")
//        //    {
//        //        studentList = new StudentList();
//        //    }
//        //    else
//        //    {
//        //        studentList = JsonSerializer.Deserialize<StudentList>(content);
//        //        //int maxid = studentList.Students.Max(s => s.ID);
//        //        //student.ID = maxid + 1;
//        //    }

//        //    studentList.Students.Add(student);
//        //    string jsonstring = JsonSerializer.Serialize(studentList);
//        //    File.WriteAllText(jsonpath, jsonstring);
//        //}

//        public void AddStudent()
//        {
//            Student student = new Student(
//                um.GetInfoFromUser("Name"),
//                um.GetNumericInfoFromUser("Age"),
//                um.CreateRandomID()
//            );

//            studentList = this.GetStudentsFromFile();
//            studentList.Students.Add(student);
//            this.SaveStudentsToFile(studentList);
//        }

//        public void SaveStudentsToFile(StudentList studentList)
//        {
//            jsonString = JsonSerializer.Serialize(studentList);
//            File.WriteAllText(jsonPath, jsonString);
//        }
//        public StudentList GetStudentsFromFile()
//        {
//            jsonPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\JSON\students.json"));
//            content = File.ReadAllText(jsonPath);
//            if (content is null || content == "")
//            {
//                studentList = new StudentList();
//            }
//            else
//            {
//                studentList = JsonSerializer.Deserialize<StudentList>(content);
//                //int maxid = studentList.Students.Max(s => s.ID);
//                //student.ID = maxid + 1;
//            }
//            return studentList;
//        }

//        public void RemoveStudent()
//        {
//            userInput = um.GetInfoFromUser("ID of the student to remove");
//            studentList = this.GetStudentsFromFile();
//            foreach (Student student in studentList.Students)
//            {
//                if (student.ID.ToString() != userInput) continue;
//                //student.RemoveObject();
//                studentList.Students.Remove(student);
//                this.SaveStudentsToFile(studentList);
//                Console.WriteLine($"{student.Name} was removed.");
//                return;
//            }
//            Console.WriteLine("No such student exists.");
//        }
//        //public void RemoveStudent()
//        //{
//        //    userInput = um.GetInfoFromUser("ID of the student to remove");
//        //    foreach (Student student in studentList)
//        //    {
//        //        if (student.ID.ToString() != userInput) continue;
//        //        student.RemoveObject();
//        //        studentList.Remove(student);

//        //        Console.WriteLine($"{student.Name} was removed.");
//        //        return;
//        //    }
//        //    Console.WriteLine("No such student exists.");
//        //}

//        public void ViewStudents()
//        {
//            studentList = this.GetStudentsFromFile();
//            foreach (Student student in studentList.Students)
//            {
//                student.DisplayInfo();
//            }
//        }
//        //public void ViewStudents()
//        //{
//        //    foreach (Student student in studentList)
//        //    {
//        //        student.DisplayInfo();
//        //    }
//        //}

//        public void UpdateStudent()
//        {
//            userInput = um.GetInfoFromUser("ID of the student to update");
//            studentList = this.GetStudentsFromFile();
//            foreach (Student student in studentList.Students)
//            {
//                if (student.ID.ToString() != userInput) continue;
//                student.Update();
//                this.SaveStudentsToFile(studentList);

//                Console.WriteLine($"{student.Name} was updated.");
//                return;
//            }
//            Console.WriteLine("No such student exists.");
//        }
//        //public void UpdateStudent()
//        //{
//        //    userInput = um.GetInfoFromUser("ID of the student to update");
//        //    foreach (Student student in studentList)
//        //    {
//        //        if (student.ID.ToString() != userInput) continue;
//        //        student.Update();

//        //        Console.WriteLine($"{student.Name} was updated.");
//        //        return;
//        //    }
//        //    Console.WriteLine("No such student exists.");
//        //}

//        //public void EnrollStudent()
//        //{
//        //    userInput = um.GetInfoFromUser("ID of the student to enroll");
//        //    userInput_1 = um.GetInfoFromUser("ID of the course to enroll to");
//        //    foreach (Student student in studentList)
//        //    {
//        //        if (student.ID.ToString() != userInput) continue;

//        //        // If we have found a student, we proceed to find the course.
//        //        Console.WriteLine(cm.courseList.Count);
//        //        foreach (Course course in cm.courseList)
//        //        {
//        //            Console.WriteLine("input " + userInput_1);
//        //            Console.WriteLine("id " + course.ID.ToString());
//        //            if (course.ID.ToString() != userInput_1) continue;

//        //            student.EnrollInCourse(course);
//        //            course.EnrollStudent(student);
//        //            Console.WriteLine($"{student.Name} was enrolled.");
//        //            return;
//        //        }
//        //        Console.WriteLine("No such course exists.");
//        //        return;
//        //    }
//        //    Console.WriteLine("No such student exists.");
//        //}
//    }
//}
