using System;
using System.Collections.Generic;
using System.IO;

namespace FileServices
{
    public class GlueFilesService
    {
        public void CombineMultipleFilesIntoSingleFile(string inputDirectoryPath, string inputFileNamePattern, string outputFilePath)
        {
            string[] inputFilePaths = Directory.GetFiles(inputDirectoryPath, inputFileNamePattern);
            Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);
            using (var outputStream = File.Create(outputFilePath))
            {
                List<Stream> inputStreams = new List<Stream>();
                try
                {
                    foreach (var inputFilePath in inputFilePaths)
                    {
                        inputStreams.Add(File.OpenRead(inputFilePath));
                        Console.WriteLine("The file {0} has been processed.", inputFilePath);
                    }
                    CombineMultipleFilesIntoSingleFile(inputStreams, outputStream);
                }
                finally
                {
                    foreach (var inputStream in inputStreams)
                    {
                        inputStream?.Dispose();
                    }
                }
            }
        }
        public void CombineMultipleFilesIntoSingleFile(IEnumerable<Stream> inputStreams, Stream outputStream)
        {
            foreach (var inputStream in inputStreams)
            {
                inputStream.CopyTo(outputStream);
            }
        }
    }
}
