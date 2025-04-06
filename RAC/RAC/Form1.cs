using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Linq;

namespace RAC
{
    public partial class Form1 : Form
    {
        private mdbConnect dbHelper;
        private CryptographyHelper cryptoHelper;
        private string generatedOTP; // Store the generated OTP

        public Form1()
        {
            InitializeComponent();
            dbHelper = new mdbConnect(@"Z:\QQ229\LTP1\RAC\RAC\Database1.mdb");
            cryptoHelper = new CryptographyHelper();
        }

        private void regbtn_Click(object sender, EventArgs e)
        {
            Registration registrationForm = new Registration();
            registrationForm.Show();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string username = usertbox.Text.Trim();
            string password = passtbox.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            string getPasswordQuery = "SELECT password FROM users WHERE username = @username";
            OleDbParameter[] passwordParameters = {
                new OleDbParameter("@username", username)
            };

            object passwordResult = null;

            try
            {
                passwordResult = dbHelper.ExecuteScalar(getPasswordQuery, passwordParameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving the password: " + ex.Message);
                return;
            }

            if (passwordResult == null || passwordResult == DBNull.Value)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            string storedPasswordWithSalt = passwordResult.ToString();
            string[] parts = storedPasswordWithSalt.Split(':');
            if (parts.Length != 2)
            {
                MessageBox.Show("Invalid password format in the database.");
                return;
            }

            string storedHashedPassword = parts[0];
            string storedSalt = parts[1];
            string hashedPassword = cryptoHelper.HashPassword(password, storedSalt);

            if (hashedPassword == storedHashedPassword)
            {
                // Generate a 6-digit OTP
                generatedOTP = GenerateOTP();
                MessageBox.Show($"Your OTP is: {generatedOTP}", "OTP Generated");

                // Prompt the user to enter the OTP
                string userOTP = PromptForOTP();
                if (userOTP == generatedOTP)
                {
                    MessageBox.Show("Login successful!");
                    // Proceed to the next step, e.g., open a new form
                }
                else
                {
                    MessageBox.Show("Invalid OTP. Login failed.");
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
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

        private void label1_Click(object sender, EventArgs e) { }
        private void usertbox_TextChanged(object sender, EventArgs e) { }
        private void passtbox_TextChanged(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void forgetPassBtn_Click(object sender, EventArgs e)
        {
            // Create an instance of the ForgetPass form
            ForgetPass forgetPassForm = new ForgetPass();

            // Show the ForgetPass form
            forgetPassForm.Show();

            // Optionally, hide the current form if needed
            // this.Hide();
        }
    }
}