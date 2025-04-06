using System;
using System.Data.OleDb;

namespace RAC
{
    public class mdbConnect
    {
        private static mdbConnect instance;
        private string connectionString;

        // Private constructor to prevent instantiation
        public mdbConnect(string dbPath)
        {
            connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={dbPath};";
        }

        // Public method to get the instance of the class
        public static mdbConnect GetInstance(string dbPath)
        {
            if (instance == null)
            {
                instance = new mdbConnect(dbPath);
            }
            return instance;
        }

        // Method to execute a non-query command (INSERT, UPDATE, DELETE)
        public void ExecuteNonQuery(string query, OleDbParameter[] parameters)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to execute a scalar query (SELECT COUNT(*), etc.)
        public object ExecuteScalar(string query, OleDbParameter[] parameters)
        {
            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (var command = new OleDbCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    try
                    {
                        return command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or handle it as needed
                        throw new Exception("Error executing scalar query", ex);
                    }
                }
            }
        }
    }
}