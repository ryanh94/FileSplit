using FileMinifier;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace FileServices.Tests
{
    public class MinifyFileServiceTests
    {
        [Test]
        public void SplitStream_WhenDataDoesntNeedSplitting_ReturnsSingleByteArray()
        {          
            byte[] testData = new byte[] { 250, 141, 123, 115, 84, 21 };
            Stream stream = new MemoryStream(testData);
            var minifyService = new MinifyFileService();
            
            var result = minifyService.SplitStream(stream, 1000).ToList();

            Assert.AreEqual(1, result.Count());
            CollectionAssert.AreEqual(testData, result.First());
        }

        [Test]
        public void SplitStream_WhenDataDoesNeedSplitting_ReturnsByteArrays()
        {
            byte[] testData = new byte[] { 250, 141, 123, 115, 84, 21 };
            Stream stream = new MemoryStream(testData);
            var minifyService = new MinifyFileService();

            var result = minifyService.SplitStream(stream, 2).ToList();

            Assert.AreEqual(3, result.Count());
            CollectionAssert.AreEqual(new byte[] { 250, 141 }, result[0]);
            CollectionAssert.AreEqual(new byte[] { 123, 115 }, result[1]);
            CollectionAssert.AreEqual(new byte[] { 84, 21 }, result[2]);
        }
    }
}
