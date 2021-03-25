using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace HtmlUniqueWords.Core
{
    /// <summary>
    /// The class of local html file
    /// </summary>
    class LocalPage :IHtml
    {
        public string Source { get; }
        private StreamReader reader;

        public LocalPage(string source)
        {
            Source = source;
            reader = new StreamReader(Source);
        }

        /// <summary>
        /// Get content of html file
        /// </summary>
        public string GetText()
        {
            string line = reader.ReadToEnd();

            return (Regex.Replace(line.ToString(), @"\s+", " ")); //replace repeating spaces and empty lines
        }
    }
}
