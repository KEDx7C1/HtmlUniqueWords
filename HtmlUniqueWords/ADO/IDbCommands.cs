using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlUniqueWords.ADO
{
    interface IDbCommands
    {
        IDbConnection dbConnection { get; }

        void InsertValues(Dictionary<string, int> uniqueWords, string source);

    }
}
