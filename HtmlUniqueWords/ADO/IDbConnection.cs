using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace HtmlUniqueWords.ADO
{
    interface IDbConnection
    {
        SQLiteConnection OpenConnection();
        SQLiteDataReader ExecuteSelectQuery(string query);
        void ExecuteInsertQuery(string query);
        void CloseConnection();

    }
}
