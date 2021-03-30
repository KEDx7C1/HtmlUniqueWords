using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HtmlUniqueWords.ADO
{
    public class dbUsage
    {
        // 
        public static void InsertValues(Dictionary<string, int> uniqueWords, string source)
        {
            dbConnection connection = new dbConnection();
            //string query = string.Format("INSERT INTO 'urls' ('url') VALUES ('{0}')", source);
            //connection.ExecuteInsertQuery(query);

            //string a = connection.ExecuteSelectQuery(string.Format("SELECT id FROM urls WHERE url={0}", source))[0].ToString();


            foreach (var s in uniqueWords)
            {
                string query = string.Format("INSERT INTO 'uniquewords' ('word', 'count', 'url') VALUES ('{0}', '{1}', '{2}')", s.Key, s.Value, source);
                connection.ExecuteInsertQuery(query);
            }

        
        }

    }
}
