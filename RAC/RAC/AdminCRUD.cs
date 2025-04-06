using System;
using System.Data.OleDb;

namespace RAC
{
    public class AdminCRUD
    {
        private mdbConnect dbHelper;

        public AdminCRUD()
        {
            dbHelper = mdbConnect.GetInstance();
        }

        // Updates a user (returns true if successful)
        public bool UpdateUser(int userId, string username, string name)
        {
            try
            {
                string updateQuery = "UPDATE users SET username = @username, name = @name WHERE ID = @id AND role <> 'admin'";
                OleDbParameter[] parameters = {
                    new OleDbParameter("@username", username),
                    new OleDbParameter("@name", name),
                    new OleDbParameter("@id", userId)
                };

                dbHelper.ExecuteNonQuery(updateQuery, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Deletes a user (returns true if successful)
        public bool DeleteUser(int userId)
        {
            try
            {
                string deleteQuery = "DELETE FROM users WHERE ID = @id AND role <> 'admin'";
                OleDbParameter[] parameters = { new OleDbParameter("@id", userId) };

                dbHelper.ExecuteNonQuery(deleteQuery, parameters);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}