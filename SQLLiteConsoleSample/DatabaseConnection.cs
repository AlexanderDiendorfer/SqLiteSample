using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLiteConsoleSample
{
    class DatabaseConnection
    {
        private const string DatabaseFileName = "mcut.db";
        private const string DatabaseSourceConnectionString = "data source=" + DatabaseFileName;
        private const string CreateTableQuery = @"CREATE TABLE IF NOT EXISTS [Plate] (
                                               [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                               [Length] REAL NULL,
                                               [Width] REAL NULL,
                                               [Thickness] REAL NULL)";
        public string getDatabaseFileName()
        {
            return DatabaseFileName;
        }

        public string getDatabaseSourceConnectionString()
        {
            return DatabaseSourceConnectionString;
        }

        public string getCreateTableQuery()
        {
            return CreateTableQuery;
        }
    }
}
