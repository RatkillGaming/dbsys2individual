
namespace RAC
{
    partial class Registration
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
            this.label1 = new System.Windows.Forms.Label();
            this.regaddbtn = new System.Windows.Forms.Button();
            this.userreg = new System.Windows.Forms.TextBox();
            this.passreg = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.namereg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SecretQComboBox = new System.Windows.Forms.ComboBox();
            this.secretAnsTBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "REGISTER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // regaddbtn
            // 
            this.regaddbtn.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regaddbtn.Location = new System.Drawing.Point(77, 253);
            this.regaddbtn.Name = "regaddbtn";
            this.regaddbtn.Size = new System.Drawing.Size(97, 31);
            this.regaddbtn.TabIndex = 4;
            this.regaddbtn.Text = "REGISTER";
            this.regaddbtn.UseVisualStyleBackColor = true;
            this.regaddbtn.Click += new System.EventHandler(this.regaddbtn_Click);
            // 
            // userreg
            // 
            this.userreg.Location = new System.Drawing.Point(64, 56);
            this.userreg.Name = "userreg";
            this.userreg.Size = new System.Drawing.Size(110, 20);
            this.userreg.TabIndex = 1;
            this.userreg.TextChanged += new System.EventHandler(this.userreg_TextChanged);
            // 
            // passreg
            // 
            this.passreg.Location = new System.Drawing.Point(64, 82);
            this.passreg.Name = "passreg";
            this.passreg.PasswordChar = '*';
            this.passreg.Size = new System.Drawing.Size(110, 20);
            this.passreg.TabIndex = 2;
            this.passreg.TextChanged += new System.EventHandler(this.passreg_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.secretAnsTBox);
            this.groupBox1.Controls.Add(this.SecretQComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.namereg);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.regaddbtn);
            this.groupBox1.Controls.Add(this.userreg);
            this.groupBox1.Controls.Add(this.passreg);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 312);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "registration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "NAME";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "PASS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "USER";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // namereg
            // 
            this.namereg.Location = new System.Drawing.Point(64, 108);
            this.namereg.Name = "namereg";
            this.namereg.Size = new System.Drawing.Size(110, 20);
            this.namereg.TabIndex = 5;
            this.namereg.TextChanged += new System.EventHandler(this.namereg_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "SECRET QUESTION";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SecretQComboBox
            // 
            this.SecretQComboBox.FormattingEnabled = true;
            this.SecretQComboBox.Location = new System.Drawing.Point(17, 163);
            this.SecretQComboBox.Name = "SecretQComboBox";
            this.SecretQComboBox.Size = new System.Drawing.Size(157, 21);
            this.SecretQComboBox.TabIndex = 10;
            this.SecretQComboBox.SelectedIndexChanged += new System.EventHandler(this.SecretQComboBox_SelectedIndexChanged);
            // 
            // secretAnsTBox
            // 
            this.secretAnsTBox.Location = new System.Drawing.Point(17, 202);
            this.secretAnsTBox.Name = "secretAnsTBox";
            this.secretAnsTBox.Size = new System.Drawing.Size(157, 20);
            this.secretAnsTBox.TabIndex = 11;
            this.secretAnsTBox.TextChanged += new System.EventHandler(this.secretAnsTBox_TextChanged);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(265, 336);
            this.Controls.Add(this.groupBox1);
            this.Name = "Registration";
            this.Text = "Registration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button regaddbtn;
        private System.Windows.Forms.TextBox userreg;
        private System.Windows.Forms.TextBox passreg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox namereg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox secretAnsTBox;
        private System.Windows.Forms.ComboBox SecretQComboBox;
        private System.Windows.Forms.Label label5;
    }
}