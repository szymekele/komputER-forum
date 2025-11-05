namespace komputerforum
{
    partial class UserComment
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
            this.label1 = new System.Windows.Forms.Label();
            this.l_user = new System.Windows.Forms.Label();
            this.l_comment_content = new System.Windows.Forms.Label();
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.l_time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "skomentowane przez:";
            // 
            // l_user
            // 
            this.l_user.AutoSize = true;
            this.l_user.Location = new System.Drawing.Point(273, 31);
            this.l_user.Name = "l_user";
            this.l_user.Size = new System.Drawing.Size(51, 20);
            this.l_user.TabIndex = 1;
            this.l_user.Text = "label1";
            // 
            // l_comment_content
            // 
            this.l_comment_content.AutoSize = true;
            this.l_comment_content.Location = new System.Drawing.Point(57, 116);
            this.l_comment_content.Name = "l_comment_content";
            this.l_comment_content.Size = new System.Drawing.Size(51, 20);
            this.l_comment_content.TabIndex = 2;
            this.l_comment_content.Text = "label3";
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // l_time
            // 
            this.l_time.AutoSize = true;
            this.l_time.Location = new System.Drawing.Point(57, 66);
            this.l_time.Name = "l_time";
            this.l_time.Size = new System.Drawing.Size(51, 20);
            this.l_time.TabIndex = 3;
            this.l_time.Text = "label2";
            // 
            // UserComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.l_time);
            this.Controls.Add(this.l_comment_content);
            this.Controls.Add(this.l_user);
            this.Controls.Add(this.label1);
            this.Name = "UserComment";
            this.Size = new System.Drawing.Size(620, 254);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label l_user;
        public System.Windows.Forms.Label l_comment_content;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        public System.Windows.Forms.Label l_time;
    }
}
