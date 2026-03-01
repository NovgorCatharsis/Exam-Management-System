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
        
        public string Name { get; set; }
        public int ID { get; set; }

        public Grade(string name, int id)
        {
            Name = name;
            ID = id;
        }
        //Grades should contain course and student it is connected along with the actual score, etc

        //Grades Management

        //      Adding of grades
        //      Removing grades
        //      Viewing grades
    }
}
