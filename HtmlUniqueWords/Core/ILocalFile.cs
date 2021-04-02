namespace HtmlUniqueWords.Core
{
    interface ILocalFile
    {
        IWebPage webPage { get; }
        string path { get; }
    }
}
