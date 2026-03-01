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

        private StudentList studentList;
        private CourseList courseList;
        private GradeList gradeList;
        private TeacherList teacherList;


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
        public void Post(string fileName, GradeList gradeList)
        {
            jsonPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\JSON\" + fileName));
            jsonString = JsonSerializer.Serialize(gradeList);
            File.WriteAllText(jsonPath, jsonString);
        }
        public void Post(string fileName, TeacherList teacherList)
        {
            jsonPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\JSON\" + fileName));
            jsonString = JsonSerializer.Serialize(teacherList);
            File.WriteAllText(jsonPath, jsonString);
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

        public GradeList GetGrades()
        {
            jsonPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\JSON\grades.json"));
            content = File.ReadAllText(jsonPath);
            if (content is null || content == "")
            {
                gradeList = new GradeList();
            }
            else
            {
                gradeList = JsonSerializer.Deserialize<GradeList>(content);
            }
            return gradeList;
        }

        public TeacherList GetTeachers()
        {
            jsonPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\JSON\teachers.json"));
            content = File.ReadAllText(jsonPath);
            if (content is null || content == "")
            {
                teacherList = new TeacherList();
            }
            else
            {
                teacherList = JsonSerializer.Deserialize<TeacherList>(content);
            }
            return teacherList;
        }
    }
}
