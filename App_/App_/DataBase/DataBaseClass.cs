using Microsoft.Data.Sqlite;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Windows.Storage;

namespace App_.DataBase
{    
    public class DataBaseClass
    {
        static string connection = "Data Source="+ ApplicationData.Current.LocalFolder.Path + @"\DataBase.db";
        public static void InitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection(connection))
            {
                db.Open();
                string tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS History (Id INTEGER PRIMARY KEY NOT NULL, " +
                    "Amount_money INTEGER NOT NULL," +
                    "Operation TEXT NOT NULL," +
                    "Date TEXT NOT NULL," +
                    "Money INTEGER NOT NULL," +
                    "Category TEXT NOT NULL," +
                    "Comment TEXT NOT NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

    public static void AddData(int amount, string operation, string  date, int money, string category, string comment)
    {
            using (SqliteConnection db = new SqliteConnection(connection))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO History VALUES (Null,@Amount_money,@Operation," +
                        "@Date, @Money,@Category,@Comment)";
                insertCommand.Parameters.AddWithValue("@Amount_money", amount);
                insertCommand.Parameters.AddWithValue("@Operation", operation);
                insertCommand.Parameters.AddWithValue("@Date", date);
                insertCommand.Parameters.AddWithValue("@Money", money);
                insertCommand.Parameters.AddWithValue("@Category", category);
                insertCommand.Parameters.AddWithValue("@Comment", comment);
                insertCommand.ExecuteReader();
            }
        }

            public static ObservableCollection<History> GetAllData()
            {
                ObservableCollection<History> entries = new ObservableCollection<History>();

            using (SqliteConnection db = new SqliteConnection(connection))
            {
                db.Open();

                    SqliteCommand selectCommand = new SqliteCommand
                        ("SELECT * from History", db);

                    SqliteDataReader query = selectCommand.ExecuteReader();
                    while (query.Read())
                    {
                        entries.Add(new History
                        {
                            Amount_money = query.GetInt32(1),
                            Operation = query.GetString(2),
                            Date = query.GetString(3),
                            Money = query.GetInt32(4),
                            Category = query.GetString(5),
                            Comment = query.GetString(6)
                        });
                    }

                    db.Close();
                }

                return entries;
            }

            public static string GetAmountOfMoney()
            {
                string entries = "0";
            using (SqliteConnection db = new SqliteConnection(connection))
            {
                db.Open();

                    SqliteCommand selectCommand = new SqliteCommand
                        ("SELECT Amount_money FROM History WHERE ID = (SELECT MAX(ID) FROM History) ", db);

                    SqliteDataReader query = selectCommand.ExecuteReader();

                    while (query.Read())
                    {
                        entries = query.GetString(0);
                    }

                    db.Close();
                }

                return entries;
            }
        
    }
}
