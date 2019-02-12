using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMinifier
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleIO console = new ConsoleIO();
            ValidateFile validateFile = new ValidateFile();

            var run = new Run(console, validateFile);

            run.StartMinimise();
        }
    }
}
