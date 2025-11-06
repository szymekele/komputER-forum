namespace komputerforum
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.logged_in = new System.Windows.Forms.Label();
            this.new_post_button = new System.Windows.Forms.Button();
            this.logout_button = new System.Windows.Forms.Button();
            this.postsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.l_users_name = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // logged_in
            // 
            this.logged_in.AutoSize = true;
            this.logged_in.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.logged_in.ForeColor = System.Drawing.Color.White;
            this.logged_in.Location = new System.Drawing.Point(68, 24);
            this.logged_in.Name = "logged_in";
            this.logged_in.Size = new System.Drawing.Size(191, 23);
            this.logged_in.TabIndex = 0;
            this.logged_in.Text = "komputER forum";
            // 
            // new_post_button
            // 
            this.new_post_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.new_post_button.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.new_post_button.ForeColor = System.Drawing.Color.White;
            this.new_post_button.Location = new System.Drawing.Point(12, 184);
            this.new_post_button.Name = "new_post_button";
            this.new_post_button.Size = new System.Drawing.Size(163, 50);
            this.new_post_button.TabIndex = 2;
            this.new_post_button.Text = "Stwórz post";
            this.new_post_button.UseVisualStyleBackColor = false;
            this.new_post_button.Click += new System.EventHandler(this.new_post_button_Click);
            // 
            // logout_button
            // 
            this.logout_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(210)))), ((int)(((byte)(151)))));
            this.logout_button.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.logout_button.ForeColor = System.Drawing.Color.White;
            this.logout_button.Location = new System.Drawing.Point(755, 18);
            this.logout_button.Name = "logout_button";
            this.logout_button.Size = new System.Drawing.Size(129, 54);
            this.logout_button.TabIndex = 3;
            this.logout_button.Text = "Wyloguj";
            this.logout_button.UseVisualStyleBackColor = false;
            this.logout_button.Click += new System.EventHandler(this.logout_button_Click);
            // 
            // postsPanel
            // 
            this.postsPanel.AutoScroll = true;
            this.postsPanel.BackColor = System.Drawing.Color.Transparent;
            this.postsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.postsPanel.Location = new System.Drawing.Point(12, 240);
            this.postsPanel.Name = "postsPanel";
            this.postsPanel.Padding = new System.Windows.Forms.Padding(20);
            this.postsPanel.Size = new System.Drawing.Size(877, 632);
            this.postsPanel.TabIndex = 4;
            this.postsPanel.WrapContents = false;
            this.postsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.postsPanel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Zalogowano:";
            // 
            // l_users_name
            // 
            this.l_users_name.AutoSize = true;
            this.l_users_name.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_users_name.ForeColor = System.Drawing.SystemColors.Control;
            this.l_users_name.Location = new System.Drawing.Point(188, 75);
            this.l_users_name.Name = "l_users_name";
            this.l_users_name.Size = new System.Drawing.Size(60, 18);
            this.l_users_name.TabIndex = 6;
            this.l_users_name.Text = "label2";
            this.l_users_name.Click += new System.EventHandler(this.l_users_name_Click);
            // 
            // pictureBox2
            // 
            //this.pictureBox2.Image = global::komputerforum.Properties.Resources.reload;
            this.pictureBox2.Location = new System.Drawing.Point(853, 199);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::komputerforum.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(39)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(901, 877);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.l_users_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.postsPanel);
            this.Controls.Add(this.logout_button);
            this.Controls.Add(this.new_post_button);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logged_in);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "komputER forum";
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label logged_in;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button new_post_button;
        private System.Windows.Forms.Button logout_button;
        private System.Windows.Forms.FlowLayoutPanel postsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_users_name;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}