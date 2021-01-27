using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Assignment27Jan
{
    [Serializable]
    class DateOfBirth
    {
        public int YearOfBirth;
        public int Date = DateTime.Now.Year;
        public DateOfBirth(int yob)
        {
            YearOfBirth = yob;
        }
        public int Calculation()
        {
            return Date - YearOfBirth;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your Year Of Birth:");
            int y = int.Parse(Console.ReadLine());
            DateOfBirth dob = new DateOfBirth(y);
            FileStream fs = new FileStream(@"DOB.txt", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, dob);
            fs.Seek(0, SeekOrigin.Begin);
            DateOfBirth result = (DateOfBirth)bf.Deserialize(fs);
            Console.WriteLine($"Your Age is :{result.Calculation()}");

            Console.ReadLine();
        }
    }
}
