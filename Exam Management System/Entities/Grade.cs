using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Management_System.Entities
{
    internal class Grade
    {
        public int Value { get; set; }
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }

        public Grade(int value, int id, int studentID, int courseID)
        {
            Value = value;
            ID = id;
            StudentID = studentID;
            CourseID = courseID;
        }

        internal void DisplayInfo()
        {
            Console.WriteLine(
                "\nValue: " + this.Value +
                "\nID: " + this.ID +
                "\nStudent ID: " + this.StudentID +
                "\nCourse ID: " + this.CourseID
                );
        }

        //Grades should contain course and student it is connected along with the actual score, etc

        //Grades Management

        //      Adding of grades
        //      Removing grades
        //      Viewing grades
    }
}
