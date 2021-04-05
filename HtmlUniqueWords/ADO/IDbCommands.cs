using System.Collections.Generic;

namespace HtmlUniqueWords.ADO
{
    interface IDbCommands
    {
        IDbConnection dbConnection { get; }

        void InsertValues(Dictionary<string, int> uniqueWords, string source);

    }
}
