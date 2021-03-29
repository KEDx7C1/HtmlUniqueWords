using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace HtmlUniqueWords.ADO
{
    public class dbConnection
    {
        private string dbName = "local.db";
        private SQLiteConnection connection;

        public dbConnection()
        {
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(dbName);
                connection = new SQLiteConnection(string.Format("Data Source={0};", dbName));
                SQLiteCommand command = new SQLiteCommand("CREATE TABLE urls (id INTEGER PRIMARY KEY, url TEXT)", connection);
                connection.Open();
                //command.ExecuteNonQuery();
                command = new SQLiteCommand("CREATE TABLE uniquewords (id INTEGER PRIMARY KEY, word TEXT, count INTEGER, url TEXT)", connection);
                command.ExecuteNonQuery();
                
            }
            else
            {
                connection = new SQLiteConnection(string.Format("Data Source={0};", dbName));
                connection.Open();
            }
        }

        public SQLiteConnection OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open || connection.State == System.Data.ConnectionState.Broken)
            {
                connection.Open();
            }
            return connection;
        
        }

        public SQLiteDataReader ExecuteSelectQuery (string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void ExecuteInsertQuery (string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void CloseConnection()
        {
            connection.Close();
        }
    }
}
