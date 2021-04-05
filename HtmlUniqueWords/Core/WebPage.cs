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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(source);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                StreamReader reader = new StreamReader(response.GetResponseStream());

                StreamWriter writer = new StreamWriter(File.Open(@$"{htmlDir}\\" + path, FileMode.Create));

                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(line);
                }

                //client.DownloadFile(source, @$"{htmlDir}\\" + path);
                reader.Close();
                writer.Close();
            }
            catch
            {
                throw new FieldAccessException(@$"Приложение не может получить доступ к файлу {path}");
            }
            
            
        }

    }
}
