using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace komputerforum
{
    public partial class CreateComment : Form
    {
        private readonly int _postId;
        private readonly int _userId;

        public string CreatedContent { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public CreateComment(int postId, int userId)
        {
            InitializeComponent();
            _postId = postId;
            _userId = userId;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void publish_button_Click(object sender, EventArgs e)
        {
            string content = comment_textBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Komentarz nie może być pusty.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings[
                "komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO comments (PostId, UserId, Content) VALUES (@postId, @userId, @content)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@postId", _postId);
                        cmd.Parameters.AddWithValue("@userId", _userId);
                        cmd.Parameters.AddWithValue("@content", content);
                        cmd.ExecuteNonQuery();
                    }
                }

                CreatedContent = content;
                CreatedAt = DateTime.Now;
                MessageBox.Show("Komentarz został opublikowany.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas dodawania komentarza: " + ex.Message);
            }
        }
    }
}
