using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServices.Tests
{
    public class GlueFileServiceTests
    {
        [Test]
        public void CombineMultipleFilesIntoSingleFile_WhenOnlyOneFile_SingleStream()
        {
            var glueService = new GlueFilesService();
            byte[] testData = new byte[] { 250, 141, 123, 115, 84, 21 };
            Stream stream = new MemoryStream(testData);
            MemoryStream outputStream = new MemoryStream();

            glueService.CombineMultipleFilesIntoSingleFile(new Stream[] { stream }, outputStream);

            CollectionAssert.AreEqual(testData, outputStream.ToArray());
        }
        [Test]
        public void CombineMultipleFilesIntoSingleFile_WhenMultipleFiles_GluesFiles()
        {
            var glueService = new GlueFilesService();
            byte[] testData = new byte[] { 250, 141, 123, 115 };
            byte[] testData1 = new byte[] { 123, 141, 123, 115 };
            byte[] testData2 = new byte[] { 123, 115, 84, 21 };
            List<Stream> inputStreams = new List<Stream>
            {
                new MemoryStream(testData),
                new MemoryStream(testData1),
                new MemoryStream(testData2)
            };
            List<byte> allTestData = new List<byte>();
            allTestData.AddRange(testData);
            allTestData.AddRange(testData1);
            allTestData.AddRange(testData2);
            MemoryStream outputStream = new MemoryStream();

            glueService.CombineMultipleFilesIntoSingleFile(inputStreams, outputStream);

            CollectionAssert.AreEqual(allTestData, outputStream.ToArray());
        }
    }
}
