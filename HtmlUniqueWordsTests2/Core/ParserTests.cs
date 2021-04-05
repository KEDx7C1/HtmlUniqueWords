using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlUniqueWords.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Moq; 

namespace HtmlUniqueWords.Core.Tests
{
    [TestClass()]
    public class ParserTests
    {
        private static Mock<ILocalFile> GetMockLocalFile (string testString)
        {
            Mock<ILocalFile> mockLocalFile = new Mock<ILocalFile>();
            UTF8Encoding encoding = new UTF8Encoding();
            UnicodeEncoding uniEncoding = new UnicodeEncoding();
            byte[] testArray = encoding.GetBytes(testString);
            MemoryStream memoryStream = new MemoryStream(testArray);
            StreamReader streamReader = new StreamReader(memoryStream);
            mockLocalFile.Setup(x => x.GetStreamReader()).Returns(streamReader);

            return mockLocalFile;
        }
        [TestMethod()]
        public void GetUniqWordsTest()
        {
            string testString = "<html><head><title>Test title</title></head>\n<body>First test line\nSecond test line\n</body>\n</html>";

            Mock<ILocalFile> mockLocalFile = GetMockLocalFile(testString);
            Dictionary<string, int> expected = new Dictionary<string, int> { { "FIRST", 1 }, { "TEST", 2 }, { "LINE", 2 }, { "SECOND", 1 } };

            Parser parser = new Parser(mockLocalFile.Object);
            Dictionary<string, int> actual = parser.GetUniqWords();

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void GetUniqueWordsIsNotHtmlException()
        {
            try
            {
                string testString = "Some test not HTML string ";
                Mock<ILocalFile> mockLocalFile = GetMockLocalFile(testString);

                Parser parser = new Parser(mockLocalFile.Object);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }


        [TestMethod()]
        public void GetUniqueWordsIsNullException()
        {
            try
            {
                string testString = null;
                Mock<ILocalFile> mockLocalFile = GetMockLocalFile(testString);

                Parser parser = new Parser(mockLocalFile.Object);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}