using System.IO;
using System.Net;

namespace HtmlUniqueWords.Core
{
    /// <summary>
    /// The Web Resource class
    /// Conteins method for getting webpage's line from Internet
    /// </summary>
    class WebPage : IHtml
    {

        public string Source { get; }

        private WebRequest request;
        private StreamReader reader;

        public WebPage(string source)
        {
            Source = source;
            request = HttpWebRequest.Create(Source);
            request.Method = "GET";
            reader = new StreamReader(request.GetResponse().GetResponseStream());
    }
        /// <summary>
        /// Get line of Web page from Internet using HttpRequest
        /// </summary>
        /// <returns>WebPage's line</returns>
        public string GetText ()
        {
            string line = reader.ReadLine();
            return line;
        }

    }
}
