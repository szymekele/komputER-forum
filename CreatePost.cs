using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace komputerforum
{
    public partial class CreatePost : Form
    {
        public enum EditorMode
        {
            CreatePost,
            EditPost,
            CreateComment,
            EditComment
        }

        private readonly EditorMode _mode;
        private readonly int _userId;
        private readonly int? _postId;
        private readonly int? _commentId;

        public string CreatedTitle { get; private set; }
        public string CreatedContent { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public CreatePost(EditorMode mode, int userId, int? postId = null, int? commentId = null)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            _mode = mode;
            _userId = userId;
            _postId = postId;
            _commentId = commentId;
            switch (_mode)
            {
                case EditorMode.CreatePost:
                    this.Text = "Nowy post - komputER forum";
                    public_button.Text = "Opublikuj";
                    l_title.Visible = true;
                    title_textBox.Visible = true;
                    break;

                case EditorMode.EditPost:
                    this.Text = "Edytuj post";
                    public_button.Text = "Zapisz zmiany";
                    l_title.Visible = true;
                    title_textBox.Visible = true;
                    LoadPostData();
                    break;

                case EditorMode.CreateComment:
                    this.Text = "Nowy komentarz";
                    public_button.Text = "Opublikuj";
                    l_title.Visible = false;
                    title_textBox.Visible = false;
                    break;

                case EditorMode.EditComment:
                    this.Text = "Edytuj komentarz";
                    public_button.Text = "Zapisz zmiany";
                    l_title.Visible = false;
                    title_textBox.Visible = false;
                    LoadCommentData();
                    break;
            }
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void public_button_Click(object sender, EventArgs e)
        {
            string title = title_textBox.Visible ? title_textBox.Text.Trim() : null;
            string content = content_richTextBox.Text.Trim();

            if ((_mode == EditorMode.CreatePost || _mode == EditorMode.EditPost))
            {
                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
                {
                    MessageBox.Show("Tytuł i treść nie mogą być puste.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(content))
                {
                    MessageBox.Show("Komentarz nie może być pusty.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                switch (_mode)
                {
                    case EditorMode.CreatePost:
                        {
                            string insert = "INSERT INTO posts (UserId, Title, Content, CreatedAt) VALUES (@uid, @title, @content, GETDATE())";
                            using (SqlCommand cmd = new SqlCommand(insert, conn))
                            {
                                cmd.Parameters.AddWithValue("@uid", _userId);
                                cmd.Parameters.AddWithValue("@title", title);
                                cmd.Parameters.AddWithValue("@content", content);
                                cmd.ExecuteNonQuery();
                            }

                            CreatedTitle = title;
                            CreatedContent = content;
                            CreatedAt = DateTime.Now;

                            MessageBox.Show("Post został utworzony.", "Sukces");
                            break;
                        }

                    case EditorMode.EditPost:
                        {
                            if (!_postId.HasValue)
                            {
                                MessageBox.Show("Brak identyfikatora posta.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            string update = "UPDATE posts SET Title = @title, Content = @content WHERE Id = @id AND UserId = @uid";
                            using (SqlCommand cmd = new SqlCommand(update, conn))
                            {
                                cmd.Parameters.AddWithValue("@title", title);
                                cmd.Parameters.AddWithValue("@content", content);
                                cmd.Parameters.AddWithValue("@id", _postId.Value);
                                cmd.Parameters.AddWithValue("@uid", _userId);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Post został zaktualizowany.", "Sukces");
                            break;
                        }

                    case EditorMode.CreateComment:
                        {
                            if (!_postId.HasValue)
                            {
                                MessageBox.Show("Brak identyfikatora posta do skomentowania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            string insert = "INSERT INTO comments (PostId, UserId, Content, CreatedAt) VALUES (@pid, @uid, @content, GETDATE())";
                            using (SqlCommand cmd = new SqlCommand(insert, conn))
                            {
                                cmd.Parameters.AddWithValue("@pid", _postId.Value);
                                cmd.Parameters.AddWithValue("@uid", _userId);
                                cmd.Parameters.AddWithValue("@content", content);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Komentarz został dodany.", "Sukces");
                            break;
                        }

                    case EditorMode.EditComment:
                        {
                            if (!_commentId.HasValue)
                            {
                                MessageBox.Show("Brak identyfikatora komentarza.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            string update = "UPDATE comments SET Content = @content WHERE Id = @cid AND UserId = @uid";
                            using (SqlCommand cmd = new SqlCommand(update, conn))
                            {
                                cmd.Parameters.AddWithValue("@content", content);
                                cmd.Parameters.AddWithValue("@cid", _commentId.Value);
                                cmd.Parameters.AddWithValue("@uid", _userId);
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Komentarz został zaktualizowany.", "Sukces");
                            break;
                        }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoadPostData()
        {
            if (!_postId.HasValue) return;

            string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT Title, Content FROM posts WHERE Id = @id AND UserId = @uid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _postId.Value);
                    cmd.Parameters.AddWithValue("@uid", _userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            title_textBox.Text = reader.GetString(0);
                            content_richTextBox.Text = reader.GetString(1);
                        }
                    }
                }
            }
        }

        private void LoadCommentData()
        {
            if (!_commentId.HasValue) return;

            string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT Content FROM comments WHERE Id = @cid AND UserId = @uid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", _commentId.Value);
                    cmd.Parameters.AddWithValue("@uid", _userId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        content_richTextBox.Text = result.ToString();
                }
            }
        }

        private void CreatePost_Load(object sender, EventArgs e)
        {

        }
    }
}
