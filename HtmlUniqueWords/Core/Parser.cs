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
        private Dictionary<string, int> UniqueWords;
        protected char[] splitter = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')' };

        public Parser()
        {
            UniqueWords = new Dictionary<string, int>();
        }


        private void SetPairs(string line)
        {
            string[] bodyWords = line.ToUpper().Split(splitter);
            foreach (string s in bodyWords)
            {
                int count;
                if (s != String.Empty)
                {
                    if (UniqueWords.TryGetValue(s, out count))
                        UniqueWords[s] += 1;
                    else UniqueWords.Add(s, 1);
                }
            }
        }

        /// <summary>
        /// Method to get count of unique words form text
        /// </summary>
        public Dictionary<string, int> GetWordsStatistic (LocalPage localPage)
        {
            HtmlDocument doc = new HtmlDocument();
            
            var result = new Dictionary<string, int>();

            string line = localPage.GetText();
            doc.LoadHtml(line);

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("*");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    SetPairs(node.InnerText.ToString());
                }
            }
            return UniqueWords;
        }

        public Dictionary<string, int> GetWordsStatistic(string line)
        {
            SetPairs(line);
            return UniqueWords;
        }
    }
}
