namespace komputerforum
{
    partial class UserPost
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

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.l_author = new System.Windows.Forms.Label();
            this.l_content = new System.Windows.Forms.Label();
            this.l_title = new System.Windows.Forms.Label();
            this.l_date = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // l_author
            // 
            this.l_author.AutoSize = true;
            this.l_author.BackColor = System.Drawing.Color.Transparent;
            this.l_author.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_author.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.l_author.Location = new System.Drawing.Point(22, 29);
            this.l_author.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_author.Name = "l_author";
            this.l_author.Size = new System.Drawing.Size(66, 18);
            this.l_author.TabIndex = 0;
            this.l_author.Text = "(Autor)";
            // 
            // l_content
            // 
            this.l_content.AutoSize = true;
            this.l_content.BackColor = System.Drawing.Color.Transparent;
            this.l_content.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_content.Location = new System.Drawing.Point(22, 82);
            this.l_content.MaximumSize = new System.Drawing.Size(550, 0);
            this.l_content.MinimumSize = new System.Drawing.Size(550, 0);
            this.l_content.Name = "l_content";
            this.l_content.TabIndex = 1;
            this.l_content.Text = "(Treść)";
            this.l_content.Click += new System.EventHandler(this.l_content_Click);
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.BackColor = System.Drawing.Color.Transparent;
            this.l_title.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_title.Location = new System.Drawing.Point(22, 57);
            this.l_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(72, 18);
            this.l_title.TabIndex = 2;
            this.l_title.Text = "(Tytuł)";
            this.l_title.Click += new System.EventHandler(this.l_title_Click);
            // 
            // l_date
            // 
            this.l_date.AutoSize = true;
            this.l_date.BackColor = System.Drawing.Color.Transparent;
            this.l_date.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_date.Location = new System.Drawing.Point(2, 5);
            this.l_date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_date.Name = "l_date";
            this.l_date.Size = new System.Drawing.Size(44, 13);
            this.l_date.TabIndex = 3;
            this.l_date.Text = "(Data)";
            this.l_date.Click += new System.EventHandler(this.l_date_Click);
            // 
            // UserPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.l_date);
            this.Controls.Add(this.l_title);
            this.Controls.Add(this.l_content);
            this.Controls.Add(this.l_author);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserPost";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(594, 118);
            this.Load += new System.EventHandler(this.UserPost_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_author;
        private System.Windows.Forms.Label l_content;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Label l_date;
    }
}
