using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace HtmlUniqueWords.Core
{
    /// <summary>
    /// The class cosist of methods to parse the text
    /// </summary>
    public class Parser
    {
        public Dictionary<string, int> UniqueWords { get; }
        private char[] splitter = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\t', '<', '>' };
        
        public Parser()
        {
            UniqueWords = new Dictionary<string, int>();
        }


        private void SetPairs(string line)
        {
            string[] bodyWords = line.ToUpper().Split(splitter).Select(p => p.Trim()).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();

            foreach (string s in bodyWords)
            {
                if (s != String.Empty)
                {
                    if (UniqueWords.TryGetValue(s, out int count))
                        UniqueWords[s] += 1;
                    else UniqueWords.Add(s, 1);
                }
            }
        }

        private void Pairs (string line)
        {
            HtmlDocument doc = new HtmlDocument();

            doc.LoadHtml(line);

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("*");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    SetPairs(node.InnerText.ToString());
                }
            }
            else throw new FormatException();
        }

        /// <summary>
        /// Получение статистики уникальных слов из html файла
        /// </summary>
        public Dictionary<string, int> GetWordsStatistic (LocalPage localPage)
        {
            string line = "s";

            while (!string.IsNullOrEmpty(line))
            {
                line = localPage.GetText();
                if (!string.IsNullOrEmpty(line)) Pairs(line);
            }

            return UniqueWords;
        }
        /// <summary>
        /// Получение статистики уникальных слов из строки
        /// </summary>
        public Dictionary<string, int> GetWordsStatistic(string line)
        {
            Pairs(line);
            return UniqueWords;
        }
    }
}
