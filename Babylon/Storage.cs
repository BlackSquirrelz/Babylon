using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace Babylon
{
    class Storage
    {
        private SQLiteConnection sqlite;
        private string _db_location = "T:\\01_Documents\\02_Zettelkasten\\Data\\zettel.db";

        public Storage()
        {
            sqlite = new SQLiteConnection(_db_location);
        }

        public DataTable selectQuery(string query)
        {
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand cmd;
                sqlite.Open();  //Initiate connection to the db
                cmd = sqlite.CreateCommand();
                cmd.CommandText = query;  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"{ex}");
            }
            sqlite.Close();
            return dt;
        }
    }
}
