using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLLiteConsoleSample
{
    class PlateProvidor
    {
        // TODO: Autowiring of database connection in c#
        public async Task<IEnumerable<PlateRepository>> GetPlates(System.Data.SQLite.SQLiteConnection sqLiteConnection)
        {
            using (var connection = sqLiteConnection)
            {
                return await connection.QueryAsync<PlateRepository>("SELECT * FROM Plate;");
            }
        }
    }
}
