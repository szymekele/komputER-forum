namespace komputerforum
{
    partial class CreatePost
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
            this.l_title = new System.Windows.Forms.Label();
            this.title_textBox = new System.Windows.Forms.TextBox();
            this.l_content = new System.Windows.Forms.Label();
            this.content_richTextBox = new System.Windows.Forms.RichTextBox();
            this.close_button = new System.Windows.Forms.Button();
            this.public_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.l_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.l_title.Location = new System.Drawing.Point(42, 19);
            this.l_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(65, 23);
            this.l_title.TabIndex = 0;
            this.l_title.Text = "Tytuł:";
            // 
            // title_textBox
            // 
            this.title_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.title_textBox.Font = new System.Drawing.Font("Verdana", 12F);
            this.title_textBox.ForeColor = System.Drawing.Color.White;
            this.title_textBox.Location = new System.Drawing.Point(46, 44);
            this.title_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.title_textBox.Name = "title_textBox";
            this.title_textBox.Size = new System.Drawing.Size(391, 27);
            this.title_textBox.TabIndex = 1;
            // 
            // l_content
            // 
            this.l_content.AutoSize = true;
            this.l_content.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.l_content.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.l_content.Location = new System.Drawing.Point(42, 83);
            this.l_content.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_content.Name = "l_content";
            this.l_content.Size = new System.Drawing.Size(68, 23);
            this.l_content.TabIndex = 2;
            this.l_content.Text = "Treść:";
            // 
            // content_richTextBox
            // 
            this.content_richTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.content_richTextBox.Font = new System.Drawing.Font("Verdana", 12F);
            this.content_richTextBox.Location = new System.Drawing.Point(45, 108);
            this.content_richTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.content_richTextBox.Name = "content_richTextBox";
            this.content_richTextBox.Size = new System.Drawing.Size(392, 64);
            this.content_richTextBox.TabIndex = 8;
            this.content_richTextBox.Text = "";
            // 
            // close_button
            // 
            this.close_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.close_button.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.close_button.ForeColor = System.Drawing.Color.White;
            this.close_button.Location = new System.Drawing.Point(363, 205);
            this.close_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(74, 29);
            this.close_button.TabIndex = 9;
            this.close_button.Text = "Anuluj";
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // public_button
            // 
            this.public_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.public_button.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.public_button.ForeColor = System.Drawing.Color.White;
            this.public_button.Location = new System.Drawing.Point(45, 205);
            this.public_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.public_button.Name = "public_button";
            this.public_button.Size = new System.Drawing.Size(102, 29);
            this.public_button.TabIndex = 10;
            this.public_button.Text = "Opublikuj";
            this.public_button.UseVisualStyleBackColor = false;
            this.public_button.Click += new System.EventHandler(this.public_button_Click);
            // 
            // CreatePost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.public_button);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.content_richTextBox);
            this.Controls.Add(this.l_content);
            this.Controls.Add(this.title_textBox);
            this.Controls.Add(this.l_title);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CreatePost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nowy post - komputER forum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.TextBox title_textBox;
        private System.Windows.Forms.Label l_content;
        private System.Windows.Forms.RichTextBox content_richTextBox;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Button public_button;
    }
}