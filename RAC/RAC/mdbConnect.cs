using System;
using System.Data;
using System.Data.OleDb;

namespace RAC
{
    public class mdbConnect
    {
        private static mdbConnect _instance;
        private static string _globalDbPath;
        private string _connectionString;

        // Private constructor
        private mdbConnect()
        {
            _connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_globalDbPath};";
        }

        // Initialize the DB path (call once at startup)
        public static void Initialize(string dbPath)
        {
            _globalDbPath = dbPath;
        }

        // Get singleton instance
        public static mdbConnect GetInstance()
        {
            if (_instance == null)
            {
                if (string.IsNullOrEmpty(_globalDbPath))
                    throw new Exception("Database path not initialized. Call Initialize() first.");

                _instance = new mdbConnect();
            }
            return _instance;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public OleDbDataReader ExecuteReader(string query, OleDbParameter[] parameters = null)
        {
            OleDbConnection connection = new OleDbConnection(_connectionString);
            OleDbCommand command = new OleDbCommand(query, connection);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void ExecuteNonQuery(string query, OleDbParameter[] parameters = null)
        {
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                conn.Open();
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable ExecuteQuery(string query, OleDbParameter[] parameters = null)
        {
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable resultTable = new DataTable();
                adapter.Fill(resultTable);
                return resultTable;
            }
        }
        public object ExecuteScalar(string query, OleDbParameter[] parameters = null)
        {
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                conn.Open();
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
        }
    }
}