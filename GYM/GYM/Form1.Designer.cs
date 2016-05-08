namespace GYM
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.radioButton_Personal = new System.Windows.Forms.RadioButton();
            this.radioButton_Cliente = new System.Windows.Forms.RadioButton();
            this.button_login = new System.Windows.Forms.Button();
            this.textBox_user = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_user = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Image = global::GYM.Properties.Resources.Logo;
            this.pictureBox_logo.Location = new System.Drawing.Point(51, 12);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(188, 79);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_logo.TabIndex = 0;
            this.pictureBox_logo.TabStop = false;
            // 
            // radioButton_Personal
            // 
            this.radioButton_Personal.AutoSize = true;
            this.radioButton_Personal.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Personal.Location = new System.Drawing.Point(104, 110);
            this.radioButton_Personal.Name = "radioButton_Personal";
            this.radioButton_Personal.Size = new System.Drawing.Size(68, 17);
            this.radioButton_Personal.TabIndex = 1;
            this.radioButton_Personal.TabStop = true;
            this.radioButton_Personal.Text = "Personal";
            this.radioButton_Personal.UseVisualStyleBackColor = true;
            this.radioButton_Personal.CheckedChanged += new System.EventHandler(this.radioButton_Personal_CheckedChanged);
            // 
            // radioButton_Cliente
            // 
            this.radioButton_Cliente.AutoSize = true;
            this.radioButton_Cliente.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Cliente.Location = new System.Drawing.Point(104, 133);
            this.radioButton_Cliente.Name = "radioButton_Cliente";
            this.radioButton_Cliente.Size = new System.Drawing.Size(60, 17);
            this.radioButton_Cliente.TabIndex = 2;
            this.radioButton_Cliente.TabStop = true;
            this.radioButton_Cliente.Text = "Cliente";
            this.radioButton_Cliente.UseVisualStyleBackColor = true;
            this.radioButton_Cliente.CheckedChanged += new System.EventHandler(this.radioButton_Cliente_CheckedChanged);
            // 
            // button_login
            // 
            this.button_login.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login.Location = new System.Drawing.Point(104, 278);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 23);
            this.button_login.TabIndex = 3;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            // 
            // textBox_user
            // 
            this.textBox_user.Location = new System.Drawing.Point(111, 169);
            this.textBox_user.Name = "textBox_user";
            this.textBox_user.Size = new System.Drawing.Size(141, 20);
            this.textBox_user.TabIndex = 4;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(111, 207);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '•';
            this.textBox_password.Size = new System.Drawing.Size(141, 20);
            this.textBox_password.TabIndex = 5;
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_user.Location = new System.Drawing.Point(43, 172);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(46, 13);
            this.label_user.TabIndex = 6;
            this.label_user.Text = "Usuario";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_password.Location = new System.Drawing.Point(43, 210);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(64, 13);
            this.label_password.TabIndex = 7;
            this.label_password.Text = "Contraseña";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(284, 313);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_user);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.radioButton_Cliente);
            this.Controls.Add(this.radioButton_Personal);
            this.Controls.Add(this.pictureBox_logo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Smart GYM";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.RadioButton radioButton_Personal;
        private System.Windows.Forms.RadioButton radioButton_Cliente;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.TextBox textBox_user;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label_password;
    }
}

