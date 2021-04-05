using System;
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

        public StreamReader GetStreamReader()
        {
            string htmlDir = "html";
            try
            {
                streamReader = new StreamReader(@$"{htmlDir}\\" + path);
            }
            catch
            {
                throw new Exception($"Не удалось получить доступ к {path}");
            }
            return streamReader;


        }

    }
}
