using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace HtmlUniqueWords.Core
{
    /// <summary>
    /// The class cosist of methods to parse the text
    /// </summary>
    public class Parser
    {
        private Dictionary<string, int> UniqueWords;
        protected char[] splitter = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\t' };

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

            string line = localPage.GetText();
            doc.LoadHtml(line);

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//body");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    SetPairs(node.InnerText.ToString());
                }
            }
            else throw new FormatException();
            return UniqueWords;
        }

        public Dictionary<string, int> GetWordsStatistic(string line)
        {
            HtmlDocument doc = new HtmlDocument();

            doc.LoadHtml(line);

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//body");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    SetPairs(node.InnerText.ToString());
                }
            }
            else throw new FormatException();
            return UniqueWords;
        }
    }
}
