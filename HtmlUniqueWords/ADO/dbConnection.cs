using System.Data.SQLite;
using System.IO;

namespace HtmlUniqueWords.ADO
{
    /// <summary>
    /// Class of SQLite conntection
    /// </summary>
    class DbConnection : IDbConnection
    {
        private readonly string dbName = "local.db";
        private readonly string dbDir = "SQLite";
        private readonly SQLiteConnection connection;
        /// <summary>
        /// 
        /// </summary>
        public DbConnection()
        {
            if (!Directory.Exists(dbDir))
                Directory.CreateDirectory(dbDir);
            if (!File.Exists($@"{dbDir}\\" + dbName))
            {
                SQLiteConnection.CreateFile($@"{dbDir}\\" + dbName);
                connection = new SQLiteConnection(string.Format("Data Source={0};", $@"{dbDir}\\" + dbName));
                connection.Open();
                SQLiteCommand command = new SQLiteCommand("CREATE TABLE uniquewords (id INTEGER PRIMARY KEY, word TEXT NOT NULL, count INTEGER NOT NULL, request INTEGER)", connection);
                command.ExecuteNonQuery();
                command = new SQLiteCommand("CREATE TABLE requests (id INTEGER PRIMARY KEY, url TEXT, datetime TEXT)", connection);
                command.ExecuteNonQuery();


            }
            else
            {
                connection = new SQLiteConnection(string.Format("Data Source={0};", $@"{dbDir}\\" + dbName));
                connection.Open();
            }
        }
        /// <summary>
        /// Метод открытия соединения к базе данных SQLite
        /// </summary>
        /// <returns></returns>
        public SQLiteConnection OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open || connection.State == System.Data.ConnectionState.Broken)
            {
                connection.Open();
            }
            return connection;

        }
        /// <summary>
        /// Метод запросов выборки к базе данных SQLite
        /// </summary>
        /// <param name="query">Текст запроса</param>
        /// <returns></returns>
        public SQLiteDataReader ExecuteSelectQuery(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// Метод запросов вставки к базе данных SQLite
        /// </summary>
        /// <param name="query"></param>
        public void ExecuteInsertQuery(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// Метод закрытия соединения
        /// </summary>
        public void CloseConnection()
        {
            connection.Close();
        }
    }
}
