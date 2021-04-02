using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace HtmlUniqueWords.Core
{
    class Parser
    {
        public ILocalFile localFile;

        private Dictionary<string, int> UniqueWords;
        private char[] splitter = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\t', '<', '>' };

        public Parser (ILocalFile localFile)
        {
            this.localFile = localFile;
        }

        public Dictionary<string, int> GetUniqWords()
        {
            UniqueWords = new Dictionary<string, int>();
            StreamReader reader = new StreamReader(localFile.path);
            HtmlDocument doc = new HtmlDocument();
            doc.Load(reader);
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//body");

            if (nodes != null)
            {
                foreach (var node in nodes)
                {

                    string[] words = node.InnerText.ToString().ToUpper().Split(splitter).Select(p => p.Trim()).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();

                    foreach (string s in words)
                    {
                        if (s != String.Empty)
                        {
                            if (UniqueWords.TryGetValue(s, out int count))
                                UniqueWords[s] += 1;
                            else UniqueWords.Add(s, 1);
                        }
                    }
                }
            }

            return UniqueWords;

        }

    }
}
