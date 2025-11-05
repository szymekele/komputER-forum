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
        private readonly int _commentId;
        private readonly bool _isEditMode;

        public CreateComment(int postId, int userId, int commentId = 0, bool isEditMode = false)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            _postId = postId;
            _userId = userId;
            _commentId = commentId;
            _isEditMode = isEditMode;

            if (_isEditMode)
            {
                this.Text = "Edytuj komentarz";
                publish_button.Text = "Zapisz zmiany";
                LoadCommentData();
            }
        }

        private void LoadCommentData()
        {
            string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT Content FROM comments WHERE Id = @cid AND UserId = @uid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", _commentId);
                    cmd.Parameters.AddWithValue("@uid", _userId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        comment_textBox.Text = result.ToString();
                }
            }
        }



        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void publish_button_Click_1(object sender, EventArgs e)
        {
            string content = comment_textBox.Text.Trim();
            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Komentarz nie może być pusty.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                if (_isEditMode)
                {
                    string updateQuery = "UPDATE comments SET Content = @content WHERE Id = @cid AND UserId = @uid";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@content", content);
                        cmd.Parameters.AddWithValue("@cid", _commentId);
                        cmd.Parameters.AddWithValue("@uid", _userId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Komentarz został zaktualizowany.", "Sukces");
                }
                else
                {
                    string insertQuery = "INSERT INTO comments (PostId, UserId, Content, CreatedAt) VALUES (@pid, @uid, @content, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", _postId);
                        cmd.Parameters.AddWithValue("@uid", _userId);
                        cmd.Parameters.AddWithValue("@content", content);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Komentarz został dodany.", "Sukces");
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
