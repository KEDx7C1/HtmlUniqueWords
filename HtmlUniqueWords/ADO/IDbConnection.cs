using System.Data.SQLite;

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
