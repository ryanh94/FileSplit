using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMinifier
{
    public class ConsoleIO
    {
        public string IntakeFilePath()
        {
            string location = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Please enter the file location of your file, that you need to be minimised");
                location = Console.ReadLine();
            } while (string.IsNullOrEmpty(location));
            Console.WriteLine("Finding location...");
            return location;
        }
        public void FileLocationNotFound()
        {
            Console.WriteLine("File Path Not Found");
        }
    }
}
