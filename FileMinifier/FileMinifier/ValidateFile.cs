using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public string GetFileType(string filePath)
        {
            //Get the file name based on user input
            string splitPattern = @"\\";
            string fileName = Regex.Split(filePath, splitPattern).Last();
            //Get the file type splliting on '.' for .exe or .odt etc
            string splitFileNamePattern = @"\.";
            string fileType = Regex.Split(fileName, splitFileNamePattern).Last();

            return fileType;
        }
    }
}
