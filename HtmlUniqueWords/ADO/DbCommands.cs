using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HtmlUniqueWords.ADO
{
    /// <summary>
    /// Класс обращений к базе данных SQL
    /// </summary>
    class DbCommands : IDbCommands
    {
        public IDbConnection dbConnection { get; set; }
        /// <summary>
        /// Добавление данных в базу данных
        /// </summary>
        /// <param name="uniqueWords">Словарь уникальных слов</param>
        /// <param name="source">URL адрес страницы</param>
        public DbCommands(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }


        public void InsertValues(Dictionary<string, int> uniqueWords, string source)
        {
            dbConnection = new DbConnection();
            int numberOfLines = 0;
            bool notExecutedQuery = false;

            StringBuilder query = new StringBuilder();

            foreach (var s in uniqueWords)
            {
                if (numberOfLines == 0)
                {
                    query = new StringBuilder();
                    query.Append(string.Format(@"INSERT INTO 'uniquewords' ('word', 'count', 'url') VALUES ('{0}', '{1}', '{2}')", s.Key, s.Value, source));
                    numberOfLines++;
                    notExecutedQuery = true;
                }
                else if (numberOfLines < 100)
                {
                    query.Append(string.Format(@", ('{0}', '{1}', '{2}')", s.Key, s.Value, source));
                    numberOfLines++;
                }
                if (numberOfLines == 100)
                {
                    dbConnection.ExecuteInsertQuery(query.ToString());
                    numberOfLines = 0;
                    notExecutedQuery = false;
                }
            }
            if (notExecutedQuery)   //if counts of appended lines less 100 and query is not executed
            {
                dbConnection.ExecuteInsertQuery(query.ToString());
            }
            dbConnection.CloseConnection();
        }
    }
}
