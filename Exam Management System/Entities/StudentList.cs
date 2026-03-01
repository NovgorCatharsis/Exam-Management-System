using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Management_System.Entities
{
    internal class StudentList
    {
        public List<Student> Students { get; set; } = new List<Student>();
    
        //public void AddStudent(Student student)
        //{
        //    studentList.Add(student);
        //}
    
        //public void RemoveStudent(Student student)
        //{
        //    studentList.Remove(student);
        //}
    
        //public void ViewStudents()
        //{
        //    foreach (Student student in studentList)
        //    {
        //        student.DisplayInfo();
        //    }
        //}
    }
}
