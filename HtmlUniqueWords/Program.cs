using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlUniqueWords
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {

            #region Проверка числа аргументов
            try
            {
                if (args.Length != 2) throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                UI.Message.Show("Syntax error\n\nUsage: HtmlUniqueWords.exe SOURCEWEBPAGE DESTLOCALFILE\n\nCopy Html file from SOURCEWEBPAGE URL to DESTLOCALFILE.\n" +
                    "Get count of unique words in Html file");
                logger.Error("Arguments error: " + ex.Message.ToString());
                Environment.Exit(1);
            }
            #endregion

            ADO.DbCommands dbCommands = new ADO.DbCommands(new ADO.DbConnection());

            try
            {
                Core.Parser parser = new Core.Parser(new Core.LocalFile(new Core.WebPage(args[0]), args[1]));

                Dictionary<string, int> uniqueWords;
                uniqueWords = parser.GetUniqWords();

                UI.Message.Show($"Уникальные слова на странице {args[0]}");

                foreach (var uniqueWord in uniqueWords.OrderByDescending(x => x.Value))
                {
                    UI.Message.Show(uniqueWord.Key + " " + uniqueWord.Value);
                }

                dbCommands.InsertValues(uniqueWords, args[0]);

                UI.Message.Show("Для закрытия приложения нажмите любую клавишу");
                UI.Message.ReadKey();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());
                UI.Message.Show(ex.Message);
                Environment.Exit(1);
            }
        }

    }
}
