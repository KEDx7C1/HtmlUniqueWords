using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
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
            bool isNotExecutedQuery = false;

            StringBuilder query = new StringBuilder();
            long unixTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            query.Append($@"INSERT INTO requests ('url', 'datetime') VALUES ('{source}', '{unixTime}')");
            dbConnection.ExecuteInsertQuery(query.ToString());

            SQLiteDataReader records = dbConnection.ExecuteSelectQuery($"SELECT MAX(id) FROM requests");
            string requestId = null;

            foreach (DbDataRecord record in records)
            {
                requestId = record["MAX(id)"].ToString();
            }

            foreach (var uniqueWord in uniqueWords)
            {
                if (numberOfLines == 0)
                {
                    query = new StringBuilder();
                    query.Append(string.Format(@"INSERT INTO 'uniquewords' ('word', 'count', 'request') VALUES ('{0}', '{1}', '{2}')", uniqueWord.Key, uniqueWord.Value, requestId));
                    numberOfLines++;
                    isNotExecutedQuery = true;
                }
                else if (numberOfLines < 100)
                {
                    query.Append(string.Format(@", ('{0}', '{1}', '{2}')", uniqueWord.Key, uniqueWord.Value, requestId));
                    numberOfLines++;
                }
                if (numberOfLines == 100)
                {
                    dbConnection.ExecuteInsertQuery(query.ToString());
                    numberOfLines = 0;
                    isNotExecutedQuery = false;
                }
            }
            if (isNotExecutedQuery)   //if counts of appended lines less 100 and query is not executed
            {
                dbConnection.ExecuteInsertQuery(query.ToString());
            }
            dbConnection.CloseConnection();
        }
    }
}
