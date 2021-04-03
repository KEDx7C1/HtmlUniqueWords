using System;
using System.IO;
using System.Net;

namespace HtmlUniqueWords.Core
{
    class WebPage:IWebPage
    {
        public string source { get; }

        public WebPage(string source)
        {
            this.source = source;
        }

        public void DownloadPage (string path)
        {
            WebClient client = new WebClient();
            string htmlDir = "html";

            try
            {
                if (!Directory.Exists(htmlDir))
                    Directory.CreateDirectory(htmlDir);
                UI.Message.Show($"Веб страница {source} сохраняется");
                client.DownloadFile(source, @$"{htmlDir}\\" + path);
            }
            catch
            {
                throw new FieldAccessException(@$"Приложение не может получить доступ к файлу {path}");
            }
            
            
        }

    }
}
