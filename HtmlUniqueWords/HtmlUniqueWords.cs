using System;
using NLog;
using System.Net;

namespace HtmlUniqueWords
{
    class HtmlUniqueWords
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2) throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                UI.Message.Show("Syntax error\nUsage: HtmlUniqueWords.exe SOURCEWEBPAGE DESTLOCALFILE\n\nCopy Html file from SOURCEWEBPAGE URL to DESTLOCALFILE.\n" +
                    "Get count of unique words in Html file");
                logger.Error("Arguments error: " + ex.Message.ToString());
                System.Environment.Exit(0);
            }
           

            string line;
            try
            {
                //Core.WebPage webPage = new Core.WebPage(args[0]);
                //Core.Serialize serializeWeb = new Core.Serialize(args[1]);
                //do
                //{
                //    line = webPage.GetText();
                //    serializeWeb.WriteLine(line);
                //}
                //while (line != null);
                //serializeWeb.Dispose();


                Core.LocalPage localPage = new Core.LocalPage(args[1]);
                Core.Parser htmlParser = new Core.Parser();
                foreach (var s in htmlParser.GetWordsStatistic(localPage))
                    UI.Message.Show(s.Key + " " + s.Value);

            }
            catch (WebException ex)
            {
                logger.Error("URL error: " + ex.Message.ToString());
                UI.Message.Show(ex.Message);
                System.Environment.Exit(0);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());
                UI.Message.Show(ex.Message);
                System.Environment.Exit(0);
            }

        }
    }
}
