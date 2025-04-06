using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RAC
{
    public partial class Form1 : Form
    {
        private mdbConnect dbHelper;
        private CryptographyHelper cryptoHelper;
        private string generatedOTP;

        public Form1()
        {
            InitializeComponent();
            dbHelper = mdbConnect.GetInstance();
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

            string getUserQuery = "SELECT password, role FROM users WHERE username = @username";
            OleDbParameter[] userParameters = {
        new OleDbParameter("@username", username)
    };

            try
            {
                using (OleDbDataReader reader = dbHelper.ExecuteReader(getUserQuery, userParameters))
                {
                    if (reader.Read())
                    {
                        string storedPasswordWithSalt = reader["password"].ToString();
                        string role = reader["role"].ToString();

                        string[] parts = storedPasswordWithSalt.Split(':');
                        if (parts.Length != 2)
                        {
                            MessageBox.Show("Invalid password format in database.");
                            return;
                        }

                        string storedHashedPassword = parts[0];
                        string storedSalt = parts[1];
                        string hashedPassword = cryptoHelper.HashPassword(password, storedSalt);

                        if (hashedPassword == storedHashedPassword)
                        {
                            if (role == "admin")
                            {
                                // Skip OTP for admin
                                Form2 adminForm = new Form2();
                                adminForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                // Regular users still need OTP
                                generatedOTP = GenerateOTP();
                                MessageBox.Show($"Your OTP is: {generatedOTP}", "OTP Generated");

                                string userOTP = PromptForOTP();
                                if (userOTP == generatedOTP)
                                {
                                    userhome userForm = new userhome();
                                    userForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid OTP. Login failed.");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message);
            }
        }
        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
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
            ForgetPass forgetPassForm = new ForgetPass();
            forgetPassForm.Show();
        }
    }
}