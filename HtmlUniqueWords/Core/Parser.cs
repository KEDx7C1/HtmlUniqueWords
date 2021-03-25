using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace HtmlUniqueWords.Core
{
    /// <summary>
    /// The class cosist of methods to parse the text
    /// </summary>
    class Parser
    {
        /// <summary>
        /// Method to get count of unique words form with html
        /// </summary>
        public static Dictionary<string, int> GetWordsStatistic (LocalPage localPage)
        {
            HtmlDocument doc = new HtmlDocument();
            char[] splitter = new char[] { ' ', ',', ':', ';', '.', '"', '(', ')', '?' };
            var result = new Dictionary<string, int>();

            string line = localPage.GetText();
            doc.LoadHtml(line);

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("*");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {

                    string[] bodyWords = node.InnerText.ToString().ToUpper().Split(splitter);

                    foreach (string s in bodyWords)
                    {
                        int count;
                        if (s != String.Empty)
                        {
                            if (result.TryGetValue(s, out count))
                                result[s] += 1;
                            else result.Add(s, 1);
                        }

                    }
                }
            }
            return result;
        }
    }
}
