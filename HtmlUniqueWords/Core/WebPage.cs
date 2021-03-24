using System.IO;
using System.Net;

namespace HtmlUniqueWords.Core
{
    /// <summary>
    /// The Web Resorce class
    /// Conteins methods for getting web page fron Internet to local drive
    /// </summary>
    class WebPage
    {
        public string Source { get; }
        public string LocalFile { get; }

               
        public WebPage(string source, string localFile)
        {
            this.Source = source;
            this.LocalFile = localFile;
        }

        /// <summary>
        /// Get web page from internet to local drive
        /// </summary>
        public void GetPage()
        {
            //Create web request
            WebRequest request = HttpWebRequest.Create(Source);
            request.Method = "GET";
                        
            string line;
            
            //use StreamReader to get WebPage by lines
            //if WabPabe will be very large, it will be downloaded in any way
            using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
            using (StreamWriter writer = new StreamWriter(LocalFile))
            {
                do
                {
                    line = reader.ReadLine();
                    writer.WriteLine(line);
                }
                while (line != null);
            }


        }
    }
}
