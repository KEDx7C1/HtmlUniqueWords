namespace HtmlUniqueWords.Core
{
    interface IWebPage
    {
        string source { get; }

        void DownloadPage(string path);
    }
}
