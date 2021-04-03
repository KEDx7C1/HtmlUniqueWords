using System.IO;

namespace HtmlUniqueWords.Core
{
    public interface ILocalFile
    {
        IWebPage webPage { get; }
        string path { get; }

        StreamReader StreamReader();
    }
}
