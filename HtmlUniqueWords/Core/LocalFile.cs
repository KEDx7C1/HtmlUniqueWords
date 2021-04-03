using System.IO;

namespace HtmlUniqueWords.Core
{
    public class LocalFile : ILocalFile
    {
        public IWebPage webPage { get; }
        public string path { get; }

        StreamReader streamReader;

        public LocalFile (IWebPage webPage, string path)
        {
            this.webPage = webPage;
            this.path = path;
            webPage.DownloadPage(path);
        }

        public StreamReader StreamReader()
        {
            string htmlDir = "html";
            streamReader = new StreamReader(@$"{htmlDir}\\" + path);
            return streamReader;
        }

    }
}
