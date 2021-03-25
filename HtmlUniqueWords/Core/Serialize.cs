using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HtmlUniqueWords.Core
{
    class Serialize
    {
        private string Path;
        private StreamWriter Writer;
        
        public Serialize(string path)
        {
            Path = path;
            Writer = new StreamWriter(Path);
        }
        /// <summary>
        /// Method for passing a string to a stream 
        /// </summary>
        /// <param name="line"></param>
        public void WriteLine(string line) => Writer.WriteLine(line);
        /// <summary>
        /// Method for closing a stream
        /// </summary>
        public void Dispose() => Writer.Close();
    }
}
