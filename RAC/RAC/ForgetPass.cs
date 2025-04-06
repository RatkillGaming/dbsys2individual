using System;
using System.Data.OleDb;
using System.Linq; // Required for LINQ methods
using System.Windows.Forms;

namespace RAC
{
    public partial class ForgetPass : Form
    {
        private mdbConnect dbHelper;
        private CryptographyHelper cryptoHelper;
        private string generatedOTP; // Store the generated OTP

        public ForgetPass()
        {
            InitializeComponent();
            dbHelper = mdbConnect.GetInstance();
            cryptoHelper = new CryptographyHelper();

            // Add secret choice questions to the ComboBox
            SecretQComboBox.Items.Add("What is your mother's maiden name?");
            SecretQComboBox.Items.Add("What was the name of your first pet?");
        }

        private void regaddbtn_Click(object sender, EventArgs e)
        {
            string username = userForget.Text.Trim();
            string secretAnswer = secretAnsTBox.Text.Trim();
            int secretChoice = SecretQComboBox.SelectedIndex + 1; // +1 to match 1 or 2 in the database

            // Input validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(secretAnswer) || SecretQComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields and select a secret question.");
                return;
            }

            // Step 1: Check if the user exists
            string query = "SELECT secretAnswer FROM users WHERE username = @username AND secretChoice = @secretChoice";
            OleDbParameter[] parameters = {
                new OleDbParameter("@username", username),
                new OleDbParameter("@secretChoice", secretChoice)
            };

            object secretAnswerResult = null;

            try
            {
                secretAnswerResult = dbHelper.ExecuteScalar(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving the secret answer: " + ex.Message);
                return;
            }

            if (secretAnswerResult == null || secretAnswerResult == DBNull.Value)
            {
                MessageBox.Show("Invalid username or secret question.");
                return;
            }

            // Step 2: Verify the secret answer
            string storedSecretAnswerWithSalt = secretAnswerResult.ToString();
            string[] parts = storedSecretAnswerWithSalt.Split(':');
            if (parts.Length != 2)
            {
                MessageBox.Show("Invalid secret answer format in the database.");
                return;
            }

            string storedHashedSecretAnswer = parts[0];
            string storedSecretAnswerSalt = parts[1];
            string hashedSecretAnswer = cryptoHelper.HashPassword(secretAnswer, storedSecretAnswerSalt);

            if (hashedSecretAnswer == storedHashedSecretAnswer)
            {
                // Step 3: Generate a 6-digit OTP
                generatedOTP = GenerateOTP();
                MessageBox.Show($"Your OTP is: {generatedOTP}", "OTP Generated");

                // Prompt the user to enter the OTP
                string userOTP = PromptForOTP();
                if (userOTP == generatedOTP)
                {
                    // Step 4: Allow user to set a new password
                    string newPassword = PromptForNewPassword();
                    if (!string.IsNullOrEmpty(newPassword))
                    {
                        // Validate the new password
                        if (!IsValidPassword(newPassword))
                        {
                            MessageBox.Show("Password must be at least 12 characters long, contain at least one uppercase letter, and one special character.");
                            return;
                        }

                        // Hash the new password
                        string newPasswordSalt = cryptoHelper.GenerateSalt();
                        string hashedNewPassword = cryptoHelper.HashPassword(newPassword, newPasswordSalt);
                        string newPasswordWithSalt = $"{hashedNewPassword}:{newPasswordSalt}";

                        // Update the password in the database
                        string updateQuery = "UPDATE users SET [password] = @password WHERE [username] = @username";
                        OleDbParameter[] updateParameters = {
                            new OleDbParameter("@password", newPasswordWithSalt),
                            new OleDbParameter("@username", username)
                        };

                        try
                        {
                            dbHelper.ExecuteNonQuery(updateQuery, updateParameters);
                            MessageBox.Show("Password updated successfully!");
                            this.Close(); // Close the form after successful update
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while updating the password: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid OTP. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Invalid secret answer.");
            }
        }

        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); // Generate a 6-digit number
        }

        private string PromptForOTP()
        {
            using (Form otpForm = new Form())
            {
                otpForm.Text = "Enter OTP";
                otpForm.Size = new System.Drawing.Size(300, 150);

                Label label = new Label
                {
                    Text = "Enter the 6-digit OTP:",
                    Location = new System.Drawing.Point(20, 20),
                    AutoSize = true
                };

                TextBox otpBox = new TextBox
                {
                    Location = new System.Drawing.Point(20, 50),
                    Size = new System.Drawing.Size(200, 20),
                    MaxLength = 6
                };

                Button submitButton = new Button
                {
                    Text = "Submit",
                    Location = new System.Drawing.Point(20, 80),
                    Size = new System.Drawing.Size(75, 23)
                };

                string otp = string.Empty;
                submitButton.Click += (s, e) =>
                {
                    otp = otpBox.Text;
                    otpForm.Close();
                };

                otpForm.Controls.Add(label);
                otpForm.Controls.Add(otpBox);
                otpForm.Controls.Add(submitButton);

                otpForm.ShowDialog();
                return otp;
            }
        }

        private string PromptForNewPassword()
        {
            using (Form newPassForm = new Form())
            {
                newPassForm.Text = "Enter New Password";
                newPassForm.Size = new System.Drawing.Size(300, 150);

                Label label = new Label
                {
                    Text = "Enter your new password:",
                    Location = new System.Drawing.Point(20, 20),
                    AutoSize = true
                };

                TextBox newPassBox = new TextBox
                {
                    Location = new System.Drawing.Point(20, 50),
                    Size = new System.Drawing.Size(200, 20),
                    UseSystemPasswordChar = true
                };

                Button submitButton = new Button
                {
                    Text = "Submit",
                    Location = new System.Drawing.Point(20, 80),
                    Size = new System.Drawing.Size(75, 23)
                };

                string newPassword = string.Empty;
                submitButton.Click += (s, e) =>
                {
                    newPassword = newPassBox.Text;
                    newPassForm.Close();
                };

                newPassForm.Controls.Add(label);
                newPassForm.Controls.Add(newPassBox);
                newPassForm.Controls.Add(submitButton);

                newPassForm.ShowDialog();
                return newPassword;
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

        private void userForget_TextChanged(object sender, EventArgs e) { }
        private void newPass_TextChanged(object sender, EventArgs e) { }
        private void SecretQComboBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void secretAnsTBox_TextChanged(object sender, EventArgs e) { }
    }
}