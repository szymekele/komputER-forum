namespace komputerforum
{
    partial class CreateComment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateComment));
            this.comment_textBox = new System.Windows.Forms.RichTextBox();
            this.publish_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.l_content = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comment_textBox
            // 
            this.comment_textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.comment_textBox.Location = new System.Drawing.Point(23, 46);
            this.comment_textBox.Name = "comment_textBox";
            this.comment_textBox.Size = new System.Drawing.Size(438, 125);
            this.comment_textBox.TabIndex = 0;
            this.comment_textBox.Text = "";
            // 
            // publish_button
            // 
            this.publish_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.publish_button.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.publish_button.ForeColor = System.Drawing.Color.White;
            this.publish_button.Location = new System.Drawing.Point(23, 177);
            this.publish_button.Name = "publish_button";
            this.publish_button.Size = new System.Drawing.Size(102, 29);
            this.publish_button.TabIndex = 1;
            this.publish_button.Text = "Opublikuj";
            this.publish_button.UseVisualStyleBackColor = false;
            this.publish_button.Click += new System.EventHandler(this.publish_button_Click_1);
            // 
            // cancel_button
            // 
            this.cancel_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.cancel_button.Font = new System.Drawing.Font("Yu Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.cancel_button.ForeColor = System.Drawing.Color.White;
            this.cancel_button.Location = new System.Drawing.Point(387, 177);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(74, 29);
            this.cancel_button.TabIndex = 2;
            this.cancel_button.Text = "Anuluj";
            this.cancel_button.UseVisualStyleBackColor = false;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // l_content
            // 
            this.l_content.Font = new System.Drawing.Font("Verdana", 14.25F);
            this.l_content.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.l_content.Location = new System.Drawing.Point(22, 20);
            this.l_content.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_content.Name = "l_content";
            this.l_content.Size = new System.Drawing.Size(100, 23);
            this.l_content.TabIndex = 3;
            this.l_content.Text = "Treść:";
            // 
            // CreateComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.l_content);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.publish_button);
            this.Controls.Add(this.comment_textBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateComment";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodaj komentarz - komputER forum";
            this.Load += new System.EventHandler(this.CreateComment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox comment_textBox;
        private System.Windows.Forms.Button publish_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Label l_content;
    }
}