using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RAC
{
    public partial class Form2 : Form
    {
        private mdbConnect dbHelper;
        private CryptographyHelper cryptoHelper;

        public Form2()
        {
            InitializeComponent();
            dbHelper = mdbConnect.GetInstance();
            cryptoHelper = new CryptographyHelper();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                // Clear the existing data
                this.database1DataSet.users.Clear();

                // Fill with fresh data
                this.usersTableAdapter.Fill(this.database1DataSet.users);

                // Explicitly rebind the DataGridView
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = this.database1DataSet.users;

                // Refresh the DataGridView
                dataGridView1.Update();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }
        }

        private void readbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idtbox.Text))
            {
                LoadUsers();
                return;
            }

            try
            {
                string query = "SELECT * FROM users WHERE ID = @id";
                OleDbParameter[] parameters = {
                    new OleDbParameter("@id", idtbox.Text)
                };

                DataTable result = dbHelper.ExecuteQuery(query, parameters);
                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];
                    idtbox.Text = row["ID"].ToString();
                    usernametbox.Text = row["username"].ToString();
                    nametbox.Text = row["name"].ToString();
                    // Note: Password and secret answer are not shown for security
                }
                else
                {
                    MessageBox.Show("User not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading user: {ex.Message}");
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idtbox.Text))
            {
                MessageBox.Show("Please select a user to update");
                return;
            }

            try
            {
                string query = "UPDATE users SET username = @username, name = @name WHERE ID = @id";
                OleDbParameter[] parameters = {
            new OleDbParameter("@username", usernametbox.Text),
            new OleDbParameter("@name", nametbox.Text),
            new OleDbParameter("@id", idtbox.Text)
        };

                dbHelper.ExecuteNonQuery(query, parameters);
                MessageBox.Show("User updated successfully");

                // Force a complete reload of data
                this.database1DataSet.users.Clear();
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}");
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idtbox.Text))
            {
                MessageBox.Show("Please select a user to delete");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM users WHERE ID = @id";
                    OleDbParameter[] parameters = {
                new OleDbParameter("@id", idtbox.Text)
            };

                    dbHelper.ExecuteNonQuery(query, parameters);
                    MessageBox.Show("User deleted successfully");

                    // Force a complete reload of data
                    this.database1DataSet.users.Clear();
                    LoadUsers();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}");
                }
            }
        }

        private void ClearForm()
        {
            idtbox.Clear();
            usernametbox.Clear();
            nametbox.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                idtbox.Text = row.Cells["ID"].Value.ToString();
                usernametbox.Text = row.Cells["username"].Value.ToString();
                nametbox.Text = row.Cells["name"].Value.ToString();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Optionally, you can ask the user for confirmation before closing
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true; // Cancel the closing event
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Terminate the application immediately
            Environment.Exit(0);

            // Alternative if Environment.Exit causes issues:
            // Application.ExitThread();
            // Application.Exit();
        }
        // Empty event handlers to prevent errors
        private void idtbox_TextChanged(object sender, EventArgs e) { }
        private void nametbox_TextChanged(object sender, EventArgs e) { }
        private void usernametbox_TextChanged(object sender, EventArgs e) { }
    }
}