using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMinifier
{
    public class ValidateFile
    {
        public bool CheckValidLocation(string filePath)
        {
            bool exists = File.Exists(filePath);
            return exists;
        }

    }
}
