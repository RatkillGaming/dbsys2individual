using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Linq;

namespace RAC
{
    public partial class Registration : Form
    {
        private mdbConnect dbHelper;
        private CryptographyHelper cryptoHelper;

        public Registration()
        {
            InitializeComponent();
            dbHelper = mdbConnect.GetInstance(@"Z:\QQ229\LTP1\RAC\RAC\Database1.mdb");
            cryptoHelper = new CryptographyHelper();

            // Add secret choice questions to the ComboBox
            SecretQComboBox.Items.Add("What is your mother's maiden name?");
            SecretQComboBox.Items.Add("What was the name of your first pet?");
        }

        private void regaddbtn_Click(object sender, EventArgs e)
        {
            string username = userreg.Text.Trim(); // Get username from textbox  
            string password = passreg.Text.Trim(); // Get password from textbox  
            string name = namereg.Text.Trim(); // Get name from textbox  
            string role = "user"; // Default role, or get it from a control  
            string secretAnswer = secretAnsTBox.Text.Trim(); // Get secret answer from textbox

            // Get the selected secret choice question
            int secretChoice = SecretQComboBox.SelectedIndex + 1; // +1 to match 1 or 2 in the database

            // Input validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(secretAnswer) || SecretQComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields and select a secret question.");
                return;
            }

            // Password complexity validation
            if (!IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 12 characters long, contain at least one uppercase letter, and one special character.");
                return;
            }

            // Step 1: Generate a salt for the password  
            string passwordSalt = cryptoHelper.GenerateSalt();

            // Step 2: Hash the password with the salt  
            string hashedPassword = cryptoHelper.HashPassword(password, passwordSalt);

            // Step 3: Concatenate the hashed password and salt
            string passwordWithSalt = $"{hashedPassword}:{passwordSalt}"; // Use a delimiter to separate them

            // Step 4: Generate a salt for the secret answer  
            string secretAnswerSalt = cryptoHelper.GenerateSalt();

            // Step 5: Hash the secret answer with the salt  
            string hashedSecretAnswer = cryptoHelper.HashPassword(secretAnswer, secretAnswerSalt);

            // Step 6: Concatenate the hashed secret answer and salt
            string secretAnswerWithSalt = $"{hashedSecretAnswer}:{secretAnswerSalt}"; // Use a delimiter to separate them

            // Step 7: Save to database  
            string query = "INSERT INTO users ([username], [password], [role], [name], [secretChoice], [secretAnswer]) " +
                           "VALUES (@username, @password, @role, @name, @secretChoice, @secretAnswer)";
            OleDbParameter[] parameters = {
                new OleDbParameter("@username", username),
                new OleDbParameter("@password", passwordWithSalt), // Save the concatenated password and salt
                new OleDbParameter("@role", role),
                new OleDbParameter("@name", name),
                new OleDbParameter("@secretChoice", secretChoice), // Save the secret choice (1 or 2)
                new OleDbParameter("@secretAnswer", secretAnswerWithSalt) // Save the concatenated secret answer and salt
            };

            try
            {
                dbHelper.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Registration successful!");
                this.Close(); // Close the registration form after successful registration
            }
            catch (OleDbException ex) when (ex.ErrorCode == -2147467259) // Example error code for unique constraint violation
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                // LogError(ex); // Implement a logging mechanism
                MessageBox.Show("An error occurred during registration. Please try again.");
            }
        }

        // Method to validate password complexity
        private bool IsValidPassword(string password)
        {
            if (password.Length < 12)
                return false;

            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasUpperCase && hasSpecialChar;
        }

        private void userreg_TextChanged(object sender, EventArgs e) { }
        private void passreg_TextChanged(object sender, EventArgs e) { }
        private void namereg_TextChanged(object sender, EventArgs e) { }
        private void secretAnsTBox_TextChanged(object sender, EventArgs e) { }
        private void SecretQComboBox_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}