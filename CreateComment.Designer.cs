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
            this.SuspendLayout();
            // 
            // comment_textBox
            // 
            this.comment_textBox.Location = new System.Drawing.Point(179, 96);
            this.comment_textBox.Name = "comment_textBox";
            this.comment_textBox.Size = new System.Drawing.Size(298, 96);
            this.comment_textBox.TabIndex = 0;
            this.comment_textBox.Text = "";
            // 
            // publish_button
            // 
            this.publish_button.Location = new System.Drawing.Point(179, 326);
            this.publish_button.Name = "publish_button";
            this.publish_button.Size = new System.Drawing.Size(122, 50);
            this.publish_button.TabIndex = 1;
            this.publish_button.Text = "Opublikuj";
            this.publish_button.UseVisualStyleBackColor = true;
            this.publish_button.Click += new System.EventHandler(this.publish_button_Click_1);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(355, 326);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(122, 50);
            this.cancel_button.TabIndex = 2;
            this.cancel_button.Text = "Anuluj";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // CreateComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.publish_button);
            this.Controls.Add(this.comment_textBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateComment";
            this.Text = "CreateComment";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox comment_textBox;
        private System.Windows.Forms.Button publish_button;
        private System.Windows.Forms.Button cancel_button;
    }
}