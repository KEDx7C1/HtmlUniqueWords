using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace HtmlUniqueWords.Core.Tests
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void GetWordsStatisticTest()
        {
            string text = "<html>\n<title>Title</title>\n<body>First word,\nsecond Word\n</body>\n</html>";

            Parser parser = new Parser();
            
            Dictionary<string, int> expected = new Dictionary<string, int> { { "FIRST", 1 }, { "WORD", 2 }, { "SECOND", 1 } };
            
            Dictionary<string, int> actual = parser.GetWordsStatistic(text);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetWordsStatisticExtention()
        {
            string text = "";
            Parser parser = new Parser();

            try
            {
                Dictionary<string, int> actual = parser.GetWordsStatistic(text);
                Assert.Fail();
            }
            catch (Exception)
            {

            }

        }

    }
}