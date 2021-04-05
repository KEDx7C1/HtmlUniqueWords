using NLog;
using System;
using System.IO;
using System.Net;

namespace HtmlUniqueWords.Core
{
    class WebPage : IWebPage
    {
        public string source { get; }

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public WebPage(string source)
        {
            this.source = source;
        }

        public void DownloadPage(string path)
        {
            string htmlDir = "html";
            try
            {
                if (!Directory.Exists(htmlDir))
                    Directory.CreateDirectory(htmlDir);
                UI.Message.Show($"Веб страница {source} сохраняется");

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(source);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new WebException();

                StreamReader reader = new StreamReader(response.GetResponseStream());
                StreamWriter writer = new StreamWriter(File.Open(@$"{htmlDir}\\" + path, FileMode.Create));


                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }

                reader.Close();
                writer.Close();
            }
            catch
            {
                string errorMesssage = $"Не удалось получить доступ к {source}";
                UI.Message.Show(errorMesssage);
                logger.Error(errorMesssage);
                Environment.Exit(1);
            }
        }
    }
}
