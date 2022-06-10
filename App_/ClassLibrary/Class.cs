using System;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;
using System.Collections.ObjectModel;

namespace ClassLibrary
{
    public class Class
    {
        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("DataBase.db", CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "DataBase.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS History (Id INTEGER PRIMARY KEY , " +
                    "Amount_money INTEGER NOT NULL," +
                    "Operation string NOT NULL," +
                    "Date TEXT NOT NULL," +
                    "Money INTEGER NOT NULL," +
                    "Category TEXT NOT NULL," +
                    "Comment TEXT NOT NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddData(int amount, string operation, string date,
            int money, string category, string comment)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "DataBase.db");
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO History VALUES (Null,@Amount_money,@Operation," +
                    "@Date, @Money,@Category,@Comment)";
                insertCommand.Parameters.AddWithValue("@Amount_money",amount);
                insertCommand.Parameters.AddWithValue("@Operation",operation);
                insertCommand.Parameters.AddWithValue("@Date", date);
                insertCommand.Parameters.AddWithValue("@Money", money);
                insertCommand.Parameters.AddWithValue("@Category", category);
                insertCommand.Parameters.AddWithValue("@Comment", comment);
                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public static ObservableCollection<History> GetAllData()
        {
            ObservableCollection<History> entries = new ObservableCollection<History>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "DataBase.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from History", db);

                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(new History { Amount_money=query.GetInt32(1), Operation= query.GetString(2),
                        Date= query.GetString(3), Money=query.GetInt32(4), Category=query.GetString(5), Comment=query.GetString(6)
                    });
                }

                db.Close();
            }

            return entries;
        }

        public static string GetAmountOfMoney()
        {
            string entries="0";

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "DataBase.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Amount_money FROM History WHERE ID = (SELECT MAX(ID) FROM History) ", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries=query.GetString(0);
                }

                db.Close();
            }

            return entries;
        }
    }
}
