namespace komputerforum
{
    partial class register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(register));
            this.authors = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.r_username = new System.Windows.Forms.TextBox();
            this.r_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.l_button = new System.Windows.Forms.Button();
            this.home_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // authors
            // 
            this.authors.AutoSize = true;
            this.authors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.authors.Location = new System.Drawing.Point(14, 520);
            this.authors.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.authors.Name = "authors";
            this.authors.Size = new System.Drawing.Size(441, 50);
            this.authors.TabIndex = 0;
            this.authors.Text = "komputerforum@gmail.com\r\nAutorzy: Szymon Elendt, Wiktor Rogowski\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(315, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(559, 67);
            this.label1.TabIndex = 2;
            this.label1.Text = "komputER forum";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(244, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(767, 49);
            this.label2.TabIndex = 3;
            this.label2.Text = "forum technologiczno-komputerowe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.label3.Location = new System.Drawing.Point(244, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(434, 49);
            this.label3.TabIndex = 4;
            this.label3.Text = "TWORZENIE KONTA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.label4.Location = new System.Drawing.Point(246, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 35);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nazwa użytkownika:";
            // 
            // r_username
            // 
            this.r_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.r_username.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.r_username.ForeColor = System.Drawing.Color.White;
            this.r_username.Location = new System.Drawing.Point(250, 294);
            this.r_username.Name = "r_username";
            this.r_username.Size = new System.Drawing.Size(495, 37);
            this.r_username.TabIndex = 6;
            this.r_username.TextChanged += new System.EventHandler(this.l_username_TextChanged);
            // 
            // r_password
            // 
            this.r_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.r_password.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.r_password.ForeColor = System.Drawing.Color.White;
            this.r_password.Location = new System.Drawing.Point(250, 359);
            this.r_password.Name = "r_password";
            this.r_password.Size = new System.Drawing.Size(495, 37);
            this.r_password.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.label5.Location = new System.Drawing.Point(246, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 35);
            this.label5.TabIndex = 7;
            this.label5.Text = "Hasło:";
            // 
            // l_button
            // 
            this.l_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.l_button.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_button.ForeColor = System.Drawing.Color.White;
            this.l_button.Location = new System.Drawing.Point(553, 418);
            this.l_button.Name = "l_button";
            this.l_button.Size = new System.Drawing.Size(192, 46);
            this.l_button.TabIndex = 9;
            this.l_button.Text = "UTWÓRZ KONTO\r\n";
            this.l_button.UseVisualStyleBackColor = false;
            this.l_button.Click += new System.EventHandler(this.l_button_Click);
            // 
            // home_button
            // 
            this.home_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.home_button.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.home_button.ForeColor = System.Drawing.Color.White;
            this.home_button.Location = new System.Drawing.Point(250, 418);
            this.home_button.Name = "home_button";
            this.home_button.Size = new System.Drawing.Size(84, 46);
            this.home_button.TabIndex = 10;
            this.home_button.Text = "Wróć";
            this.home_button.UseVisualStyleBackColor = false;
            this.home_button.Click += new System.EventHandler(this.home_button_Click);
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.home_button);
            this.Controls.Add(this.l_button);
            this.Controls.Add(this.r_password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.r_username);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.authors);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rejestracja - komputER forum";
            this.Load += new System.EventHandler(this.register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label authors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox r_username;
        private System.Windows.Forms.TextBox r_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button l_button;
        private System.Windows.Forms.Button home_button;
    }
}