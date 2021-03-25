using System;

namespace HtmlUniqueWords
{
    class HtmlUniqueWords
    {
        static void Main(string[] args)
        {
            string line;
            try
            {
                Core.WebPage webPage = new Core.WebPage(args[0]);
                Core.Serialize serializeWeb = new Core.Serialize(args[1]);
                do
                {
                    line = webPage.GetText();
                    serializeWeb.WriteLine(line);
                }
                while (line != null);
                serializeWeb.Dispose();


                Core.LocalPage localPage = new Core.LocalPage(args[1]);
                foreach (var s in Core.Parser.GetWordsStatistic(localPage))
                    Console.WriteLine(s.Key + " " + s.Value);
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
