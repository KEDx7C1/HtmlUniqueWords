using System.IO;
using System.Text;


namespace HtmlUniqueWords.Core
{
    /// <summary>
    /// The class of local html file
    /// </summary>
    public class LocalPage :IHtml
    {
        /// <summary>
        /// 
        /// </summary>
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
            StringBuilder lines = new StringBuilder();
            string line;
            
            for (int i = 0; i < 200000; i++)
            {
                line = reader.ReadLine();
                if (!string.IsNullOrEmpty(line))
                    lines.Append(line);
                if (reader.EndOfStream) break;
            }

            return (lines.ToString());
        }
    }
}
