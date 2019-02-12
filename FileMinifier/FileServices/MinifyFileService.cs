using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMinifier
{
    public static class MinifyFileService
    {
        public static void SplitFile(string inputFilePath, int chunkSize, string path)
        {
            const int BUFFER_SIZE = 20 * 1024;
            byte[] buffer = new byte[BUFFER_SIZE];
            if (File.Exists(path) == false)
            {
                System.IO.Directory.CreateDirectory(path);
            }

            using (Stream input = File.OpenRead(inputFilePath))
            {
                int index = 0;
                while (input.Position < input.Length)
                {
                    using (Stream output = File.Create(path + "\\" + "fileParts" + index))
                    {
                        int remaining = chunkSize, bytesRead;
                        while (remaining > 0 && (bytesRead = input.Read(buffer, 0,
                                Math.Min(remaining, BUFFER_SIZE))) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                            remaining -= bytesRead;
                        }
                    }
                    index++;
                }
            }
        }
    }
}
