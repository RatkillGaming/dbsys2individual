
namespace RAC
{
    partial class ForgetPass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userForget = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.secretAnsTBox = new System.Windows.Forms.TextBox();
            this.SecretQComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.regaddbtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userForget
            // 
            this.userForget.Location = new System.Drawing.Point(94, 79);
            this.userForget.Name = "userForget";
            this.userForget.Size = new System.Drawing.Size(110, 20);
            this.userForget.TabIndex = 1;
            this.userForget.TextChanged += new System.EventHandler(this.userForget_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.secretAnsTBox);
            this.groupBox1.Controls.Add(this.SecretQComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.regaddbtn);
            this.groupBox1.Controls.Add(this.userForget);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 222);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "registration";
            // 
            // secretAnsTBox
            // 
            this.secretAnsTBox.Location = new System.Drawing.Point(17, 152);
            this.secretAnsTBox.Name = "secretAnsTBox";
            this.secretAnsTBox.Size = new System.Drawing.Size(157, 20);
            this.secretAnsTBox.TabIndex = 11;
            this.secretAnsTBox.TextChanged += new System.EventHandler(this.secretAnsTBox_TextChanged);
            // 
            // SecretQComboBox
            // 
            this.SecretQComboBox.FormattingEnabled = true;
            this.SecretQComboBox.Location = new System.Drawing.Point(17, 125);
            this.SecretQComboBox.Name = "SecretQComboBox";
            this.SecretQComboBox.Size = new System.Drawing.Size(157, 21);
            this.SecretQComboBox.TabIndex = 10;
            this.SecretQComboBox.SelectedIndexChanged += new System.EventHandler(this.SecretQComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "SECRET QUESTION";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "USER";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "FORGET PASS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // regaddbtn
            // 
            this.regaddbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regaddbtn.Location = new System.Drawing.Point(128, 178);
            this.regaddbtn.Name = "regaddbtn";
            this.regaddbtn.Size = new System.Drawing.Size(97, 31);
            this.regaddbtn.TabIndex = 4;
            this.regaddbtn.Text = "SEND CODE";
            this.regaddbtn.UseVisualStyleBackColor = true;
            this.regaddbtn.Click += new System.EventHandler(this.regaddbtn_Click);
            // 
            // ForgetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(256, 245);
            this.Controls.Add(this.groupBox1);
            this.Name = "ForgetPass";
            this.Text = "ForgetPass";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox secretAnsTBox;
        private System.Windows.Forms.ComboBox SecretQComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button regaddbtn;
        private System.Windows.Forms.TextBox userForget;
    }
}