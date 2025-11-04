namespace komputerforum
{
    partial class home
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.authors = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.close_app_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // authors
            // 
            this.authors.AutoSize = true;
            this.authors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.authors.Location = new System.Drawing.Point(14, 520);
            this.authors.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.authors.Name = "authors";
            this.authors.Size = new System.Drawing.Size(283, 32);
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
            this.label1.Size = new System.Drawing.Size(369, 45);
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
            this.label2.Size = new System.Drawing.Size(501, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "forum technologiczno-komputerowe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.label3.Location = new System.Drawing.Point(192, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(595, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "ZALOGUJ SIĘ LUB UTWÓRZ NOWE KONTO";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.button1.Font = new System.Drawing.Font("Yu Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(133, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 88);
            this.button1.TabIndex = 5;
            this.button1.Text = "ZALOGUJ\r\nSIĘ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.button2.Font = new System.Drawing.Font("Yu Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(599, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(243, 88);
            this.button2.TabIndex = 6;
            this.button2.Text = "ZAREJESTRUJ\r\nSIĘ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // close_app_button
            // 
            this.close_app_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.close_app_button.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.close_app_button.ForeColor = System.Drawing.Color.White;
            this.close_app_button.Location = new System.Drawing.Point(874, 520);
            this.close_app_button.Name = "close_app_button";
            this.close_app_button.Size = new System.Drawing.Size(98, 32);
            this.close_app_button.TabIndex = 7;
            this.close_app_button.Text = "Zamknij";
            this.close_app_button.UseVisualStyleBackColor = false;
            this.close_app_button.Click += new System.EventHandler(this.close_app_button_Click);
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.close_app_button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.authors);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "komputER forum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label authors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button close_app_button;
    }
}

