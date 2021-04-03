namespace HtmlUniqueWords.Core
{
    public interface IWebPage
    {
        string source { get; }

        void DownloadPage(string path);
    }
}
