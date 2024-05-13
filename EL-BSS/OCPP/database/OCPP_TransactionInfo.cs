using BatteryChangeCharger.Applications;
using EL_DC_Charger.ocpp.ver16.datatype;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Configuration;

namespace BatteryChangeCharger.OCPP.database
{
    public class OCPP_TransactionInfo
    {
        private const string NAME_DB = @"..\Database_OCPPSetting.db";
        private const string NAME_TABLE = "OCPP_TransactionInfo";



        public OCPP_TransactionInfo()
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
                TransactionID TEXT NOT NULL,
                START_TRANSACTION_YN TEXT,
                STOP_TRANSACTION_YN TEXT,
                RESET_TRIGGER TEXT,
                RESET_REASON TEXT
            );";

            using (var command = new SQLiteCommand(createTableQuery, MyApplication.getInstance().connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public DataTable selectLastInfo()
        {
            string query = $"SELECT * FROM {NAME_TABLE} WHERE id = (SELECT MAX(id) FROM {NAME_TABLE} WHERE STOP_TRANSACTION_YN isnull)";
            using (SQLiteCommand command = new SQLiteCommand(query, MyApplication.getInstance().connection))
            {
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
        public void insertData(string idtag, string tid)
        {

            string sql = $"INSERT INTO {NAME_TABLE} (idTag,TransactionID) VALUES ('{idtag}', '{tid}')";
            using (var command = new SQLiteCommand(sql, MyApplication.getInstance().connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void updateStartTrans(string tid)
        {
            string query = $"UPDATE {NAME_TABLE} SET START_TRANSACTION_YN = 'Y' WHERE TransactionID = '{tid}'";

            using (SQLiteCommand command = new SQLiteCommand(query, MyApplication.getInstance().connection))
            {
                int affectedRows = command.ExecuteNonQuery();
            }
        }
        public void updateStopTrans(string tid)
        {
            string query = $"UPDATE {NAME_TABLE} SET STOP_TRANSACTION_YN = 'Y' WHERE TransactionID = '{tid}'";
            using (SQLiteCommand command = new SQLiteCommand(query, MyApplication.getInstance().connection))
            {
                int affectedRows = command.ExecuteNonQuery();
            }
        }
        public void updateResetTrigger(string tid, string isYN)
        {
            string query = $"UPDATE {NAME_TABLE} SET RESET_TRIGGER = '{isYN}' WHERE TransactionID = '{tid}'";
            using (SQLiteCommand command = new SQLiteCommand(query, MyApplication.getInstance().connection))
            {
                int affectedRows = command.ExecuteNonQuery();
            }
        }
        public void updateResetReason(string tid, string reason)
        {
            string query = $"UPDATE {NAME_TABLE} SET RESET_REASON = '{reason}' WHERE TransactionID = '{tid}'";
            using (SQLiteCommand command = new SQLiteCommand(query, MyApplication.getInstance().connection))
            {
                int affectedRows = command.ExecuteNonQuery();
            }
        }
        //private int updateData(string field, string newValue)
        //{
        //    string query = $"UPDATE {NAME_TABLE} SET SettingValue = '{newValue}' WHERE SettingKey = '{field}'";

        //    using (SQLiteCommand command = new SQLiteCommand(query, connection))
        //    {
        //        command.Parameters.AddWithValue("@newValue", newValue);
        //        int affectedRows = command.ExecuteNonQuery();
        //        return affectedRows;
        //    }
        //}
    }
}
