using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLiteConsoleSample
{
    class Program
    {
        private static void Main(string[] args)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            // Create the file which will be hosting our database
            if (!File.Exists(databaseConnection.getDatabaseFileName()))
            {
                SQLiteConnection.CreateFile(databaseConnection.getDatabaseFileName());
            }
            // Connect to the database 
            using (var connection = new SQLiteConnection(databaseConnection.getDatabaseSourceConnectionString()))
            {
                // Insert database values into Plate table
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open();
                    // Create the table
                    command.CommandText = databaseConnection.getCreateTableQuery();
                    command.ExecuteNonQuery();
                    // Insert entries in database table
                    command.CommandText = "INSERT INTO Plate (Length,Width,Thickness) VALUES ('0.5','0.4','0.3')";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Plate (Length,Width,Thickness) VALUES ('1.5','1.4','1.3')";
                    command.ExecuteNonQuery();

                    PlateProvidor plateProvidor = new PlateProvidor();
                    Task<IEnumerable<PlateRepository>> plateList = plateProvidor.GetPlates(connection);

                    //Task<IEnumerable<PlateRepository>> plateList = connection.QueryAsync<PlateRepository>("SELECT * FROM Plate;");

                    foreach (var plate in plateList.Result)
                    {
                        Console.WriteLine(plate.Length + " : " + plate.Length + " : " + plate.Thickness);
                    }
                }
            }
        }

    }
}