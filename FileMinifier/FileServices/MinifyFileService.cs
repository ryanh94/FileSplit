using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMinifier
{
    public class MinifyFileService
    {
        public void SplitFile(string inputFilePath, int chunkSize, string path)
        {
            Directory.CreateDirectory(path);

            using (Stream input = File.OpenRead(inputFilePath))
            {
                int index = 0;
                var splitData = SplitStream(input, chunkSize);
                foreach (var file in splitData)
                {
                    using (Stream output = File.Create(path + "\\" + "fileParts" + index))
                    {
                        output.Write(file, 0, file.Length);
                    }
                    index++;
                }
            }
        }
        //splitting stream
        public IEnumerable<byte[]> SplitStream(Stream input, int chunkSize)
        {
            while (input.Position < input.Length)
            {
                byte[] buffer = new byte[Math.Min(chunkSize, input.Length - input.Position)];
                input.Read(buffer, 0, buffer.Length);

                yield return buffer;

            }
        }
    }
}
