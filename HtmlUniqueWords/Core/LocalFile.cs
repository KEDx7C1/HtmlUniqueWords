namespace HtmlUniqueWords.Core
{
    class LocalFile : ILocalFile
    {
        public IWebPage webPage { get; }
        public string path { get; }

        public LocalFile (IWebPage webPage, string path)
        {
            this.webPage = webPage;
            this.path = path;
            webPage.DownloadPage(path);
        }

    }
}
