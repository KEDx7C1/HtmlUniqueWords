using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
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
            long unixTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            query.Append($@"INSERT INTO requests ('url', 'datetime') VALUES ('{source}', '{unixTime}')");
            dbConnection.ExecuteInsertQuery(query.ToString());

            SQLiteDataReader reader = dbConnection.ExecuteSelectQuery($"SELECT MAX(id) FROM requests");


            string requestId = null;

            foreach (DbDataRecord record in reader)
            {
                requestId = record["MAX(id)"].ToString();
            }

            foreach (var s in uniqueWords)
            {
                if (numberOfLines == 0)
                {
                    query = new StringBuilder();
                    query.Append(string.Format(@"INSERT INTO 'uniquewords' ('word', 'count', 'request') VALUES ('{0}', '{1}', '{2}')", s.Key, s.Value, requestId));
                    numberOfLines++;
                    notExecutedQuery = true;
                }
                else if (numberOfLines < 100)
                {
                    query.Append(string.Format(@", ('{0}', '{1}', '{2}')", s.Key, s.Value, requestId));
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
