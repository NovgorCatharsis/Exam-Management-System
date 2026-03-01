using Exam_Management_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Management_System.Managers
{
    internal class UniversityManager
    {
        public int outNumber;

        public int CreateRandomID()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }

        public string GetInfoFromUser(string message)
        {
            Console.WriteLine("\nEnter " + message + ": ");
            return Console.ReadLine();
        }

        public int GetNumericInfoFromUser(string message)
        {
            Console.WriteLine("Enter " + message + ": ");
            if (int.TryParse(Console.ReadLine(), out outNumber))
            {
                return outNumber;
            }
            else
            {
                Console.WriteLine("Are you drunk again, Archchancellor? Try again.");
                return GetNumericInfoFromUser(message);
            }
        }
    }
}
