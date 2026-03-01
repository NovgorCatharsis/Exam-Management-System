using Exam_Management_System.Managers;
using System;

namespace Exam_Management_System
{
    internal class Menu
    {
        private StudentManager sm = new StudentManager();
        private CourseManager cm = new CourseManager();
        private GradeManager gm = new GradeManager();
        private TeacherManager tm = new TeacherManager();
        private string userInput = string.Empty;
        public void Start()
        {
            Console.WriteLine(
                "UNSEEN UNIVERSITY EXAM MANAGEMENT SYSTEM" +
                "\nWelcome, Archchancellor! What is your will today?" +
                "\n1. Manage students." +
                "\n2. Manage teachers." +
                "\n3. Manage courses." +
                "\n4. Manage grades." +
                "\n5. Leave."
                );
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    this.ManageStudents();
                    break;
                case "2":
                    Console.Clear();
                    this.ManageTeachers();
                    break;
                case "3":
                    Console.Clear();
                    this.ManageCourses();
                    break;
                case "4":
                    Console.Clear();
                    this.ManageGrades();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    this.AreYouDrunk();
                    this.Start();
                    break;
            }

        }

        void ManageStudents()
        {
            Console.WriteLine(
                    "\nSTUDENTS MANAGEMENT" +
                    "\n1. Add a student." +
                    "\n2. Remove a student." +
                    "\n3. View students." +
                    "\n4. Update a student."+
                    "\n5. Enroll a student." +
                    "\n6. Back."
                    );
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    sm.AddStudent();
                    this.ManageStudents();
                    break;
                case "2":
                    sm.RemoveStudent();
                    this.ManageStudents();
                    break;
                case "3":
                    sm.ViewStudents();
                    this.ManageStudents();
                    break;
                case "4":
                    sm.UpdateStudent();
                    this.ManageStudents();
                    break;
                case "5":
                    sm.EnrollStudent();
                    this.ManageStudents();
                    break;
                case "6":
                    Console.Clear();
                    this.Start ();
                    break;
                default:
                    this.AreYouDrunk();
                    this.ManageStudents();
                    break;
            }
        }


        void ManageCourses()
        {
            Console.WriteLine(
                    "\nCOURSES MANAGEMENT" +
                    "\n1. Add a course." +
                    "\n2. Remove a course." +
                    "\n3. View courses." +
                    "\n4. Update a course." +
                    "\n5. Enroll a student." +
                    "\n6. Back."
                    );
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    cm.AddCourse();
                    this.ManageCourses();
                    break;
                case "2":
                    cm.RemoveCourse();
                    this.ManageCourses();
                    break;
                case "3":
                    cm.ViewCourses();
                    this.ManageCourses();
                    break;
                case "4":
                    cm.UpdateCourse();
                    this.ManageCourses();
                    break;
                case "5":
                    sm.EnrollStudent();
                    this.ManageCourses();
                    break;
                case "6":
                    Console.Clear();
                    this.Start();
                    break;
                default:
                    this.AreYouDrunk();
                    this.ManageCourses();
                    break;
            }
        }


        void ManageGrades()
        {
            Console.WriteLine(
                    "\nGRADES MANAGEMENT" +
                    "\n1. Add a grade." +
                    "\n2. Remove a grade." +
                    "\n3. View grades." +
                    "\n4. Back."
                    );
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    gm.AddGrade();
                    this.ManageGrades();
                    break;
                case "2":
                    gm.RemoveGrade();
                    this.ManageGrades();
                    break;
                case "3":
                    gm.ViewGrades();
                    this.ManageGrades();
                    break;
                case "4":
                    Console.Clear();
                    this.Start();
                    break;
                default:
                    this.AreYouDrunk();
                    this.ManageGrades();
                    break;
            }
        }

        void ManageTeachers()
        {
            Console.WriteLine(
                    "\nTEACHERS MANAGEMENT" +
                    "\n1. Add a teacher." +
                    "\n2. Remove a teacher." +
                    "\n3. View teachers." +
                    "\n4. Update a teacher." +
                    "\n5. Add a teacher to a course." +
                    "\n6. Back."
                    );
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    tm.AddTeacher();
                    this.ManageTeachers();
                    break;
                case "2":
                    tm.RemoveTeacher();
                    this.ManageTeachers();
                    break;
                case "3":
                    tm.ViewTeachers();
                    this.ManageTeachers();
                    break;
                case "4":
                    tm.UpdateTeacher();
                    this.ManageTeachers();
                    break;
                case "5":
                    tm.TeachNewCourse();
                    this.ManageTeachers();
                    break;
                case "6":
                    Console.Clear();
                    this.Start();
                    break;
                default:
                    this.AreYouDrunk();
                    this.ManageTeachers();
                    break;
            }
        }

        void AreYouDrunk() 
        {
            Console.Clear();
            Console.WriteLine("Are you drunk again, Archchancellor? Try again.\n");
        }
        
    }
}
