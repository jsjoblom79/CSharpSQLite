using System;
using System.Data.SQLite;

namespace _DatabaseHelper
{
    public class DBHelper
    {
        public DBHelper()
        {
            //Constructor
        }
        public SQLiteConnection ConnectToDB(String Database)
        {
            //Database string should be in format of "Data Source={filename};Version=3"
            var conn = SQLiteConnection(Database);
            conn.Open();
        }
    }
}
