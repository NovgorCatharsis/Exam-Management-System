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
    internal class FileManager
    {
        string jsonPath;
        string content;
        string jsonString;

        private CourseList courseList;
        private StudentList studentList;

        public void Post(string fileName, StudentList studentList)
        {
            jsonPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\JSON\" + fileName));
            jsonString = JsonSerializer.Serialize(studentList);
            File.WriteAllText(jsonPath, jsonString);
        }
        public void Post(string fileName, CourseList courseList)
        {
            jsonPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\JSON\" + fileName));
            jsonString = JsonSerializer.Serialize(courseList);
            File.WriteAllText(jsonPath, jsonString);
        }
        

        public CourseList GetCourses()
        {
            jsonPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\JSON\courses.json"));
            content = File.ReadAllText(jsonPath);
            if (content is null || content == "")
            {
                courseList = new CourseList();
            }
            else
            {
                courseList = JsonSerializer.Deserialize<CourseList>(content);
            }
            return courseList;
        }
        public StudentList GetStudents()
        {
            jsonPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\JSON\students.json"));
            content = File.ReadAllText(jsonPath);
            if (content is null || content == "")
            {
                studentList = new StudentList();
            }
            else
            {
                studentList = JsonSerializer.Deserialize<StudentList>(content);
            }
            return studentList;
        }
    }
}
