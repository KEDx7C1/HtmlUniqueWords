using System;

namespace HtmlUniqueWords
{
    class HtmlUniqueWords
    {
        static void Main(string[] args)
        {
            Core.WebPage webPage = new Core.WebPage(args[0], args[1]);
            try
            {
                webPage.GetPage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
