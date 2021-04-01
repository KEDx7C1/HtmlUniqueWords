using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HtmlUniqueWords.ADO
{
    /// <summary>
    /// Класс обращений к базе данных SQL
    /// </summary>
    public class DbUsage
    {
        /// <summary>
        /// Добавление данных в базу данных
        /// </summary>
        /// <param name="uniqueWords">Словарь уникальных слов</param>
        /// <param name="source">URL адрес страницы</param>
        public static void InsertValues(Dictionary<string, int> uniqueWords, string source)
        {
            DbConnection connection = new DbConnection();
            int numberOfLines = 0;
            bool notExecutedQuery = false;

            StringBuilder query = new StringBuilder();

            foreach (var s in uniqueWords)
            {
                if (numberOfLines == 0)
                {
                    query = new StringBuilder();
                    query.Append(string.Format("INSERT INTO 'uniquewords' ('word', 'count', 'url') VALUES ('{0}', '{1}', '{2}')", s.Key, s.Value, source));
                    numberOfLines++;
                    notExecutedQuery = true;
                }
                else if (numberOfLines < 100)
                {
                    query.Append(string.Format(", ('{0}', '{1}', '{2}')", s.Key, s.Value, source));
                    numberOfLines++;
                }
                if (numberOfLines == 100)
                {
                    connection.ExecuteInsertQuery(query.ToString());
                    numberOfLines = 0;
                    notExecutedQuery = false;
                }
            }
            if (notExecutedQuery)   //if counts of appended lines less 100 and query is not executed
            {
                connection.ExecuteInsertQuery(query.ToString());
            }
            connection.CloseConnection();
        }
    }
}
