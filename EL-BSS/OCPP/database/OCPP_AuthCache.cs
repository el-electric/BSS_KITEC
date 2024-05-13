using BatteryChangeCharger.Applications;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BatteryChangeCharger.OCPP.database
{
    public class OCPP_AuthCache
    {
        protected static string TYPE_TEXT = "TEXT";
        protected static string TYPE_INTEGER = "INTEGER";

        private const string NAME_DB = @"..\Database_OCPPSetting.db";
        private const string NAME_TABLE = "OCPP_AuthCache";

        public OCPP_AuthCache()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            if (!TableExists(NAME_TABLE))
            {
                CreateTables();
            }
        }

        private bool TableExists(string tableName)
        {
            string sql = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';";
            using (var command = new SQLiteCommand(sql, MyApplication.getInstance().connection))
            {
                var result = command.ExecuteScalar();
                return result != null;
            }
        }

        private void CreateTables()
        {
            var createTableQuery = @"
            CREATE TABLE IF NOT EXISTS " + NAME_TABLE + @" (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                idTag TEXT NOT NULL,
                expiryDate TEXT NOT NULL
            );";

            using (var command = new SQLiteCommand(createTableQuery, MyApplication.getInstance().connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void cacheDelete()
        {
            string sql = $"delete from {NAME_TABLE}";
            using (var command = new SQLiteCommand(sql, MyApplication.getInstance().connection))
            {
                command.ExecuteNonQuery();
            }
        }
        public void insertData(string idTag, string expiryDate)
        {
            string sql = $"INSERT INTO {NAME_TABLE} (idTag, expiryDate) VALUES ('{idTag}', '{expiryDate}')";
            using (var command = new SQLiteCommand(sql, MyApplication.getInstance().connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}

