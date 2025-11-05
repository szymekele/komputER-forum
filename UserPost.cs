using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace komputerforum
{
    public partial class UserPost : UserControl
    {
        private int _postId;
        private int _currentUserId;

        public UserPost()
        {
            InitializeComponent();
            this.Margin = new Padding(10);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.AutoSize = true;
            this.Dock = DockStyle.Top;
            l_content.TextAlign = ContentAlignment.TopLeft;
        }

        public void SetPostData(string title, string content, string username, DateTime createdAt, int postId, int currentUserId)
        {
            l_title.Text = title;
            l_content.Text = content;
            l_author.Text = $"Autor: {username}";
            l_date.Text = createdAt.ToString("yyyy-MM-dd HH:mm");

            _postId = postId;
            _currentUserId = currentUserId;

            Button commentButton = new Button();
            commentButton.Text = "💬 Komentuj";
            commentButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            commentButton.AutoSize = true;
            commentButton.Location = new Point(10, l_content.Bottom + 20);
            commentButton.Click += CommentButton_Click;
            this.Controls.Add(commentButton);

            if (GetPostAuthorId() == _currentUserId)
            {
                Button editButton = new Button();
                editButton.Text = "✏️ Edytuj";
                editButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                editButton.AutoSize = true;
                editButton.Location = new Point(120, l_content.Bottom + 20);
                editButton.Click += EditButton_Click;
                this.Controls.Add(editButton);

                Button deleteButton = new Button();
                deleteButton.Text = "🗑️ Usuń";
                deleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                deleteButton.AutoSize = true;
                deleteButton.Location = new Point(230, l_content.Bottom + 20);
                deleteButton.Click += DeleteButton_Click;
                this.Controls.Add(deleteButton);
            }
        }

        private int GetPostAuthorId()
        {
            int authorId = -1;
            string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT UserId FROM posts WHERE Id = @postId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@postId", _postId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        authorId = Convert.ToInt32(result);
                }
            }
            return authorId;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var editForm = new CreatePost(CreatePost.EditorMode.EditPost, _currentUserId, postId: _postId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                ((main)Application.OpenForms["main"]).RefreshList();
            }
        }

        private void CommentButton_Click(object sender, EventArgs e)
        {
            var commentForm = new CreatePost(CreatePost.EditorMode.CreateComment, _currentUserId, postId: _postId);
            if (commentForm.ShowDialog() == DialogResult.OK)
            {
                if (Application.OpenForms["main"] is main mainForm)
                {
                    mainForm.RefreshList();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć ten post?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM posts WHERE Id = @postId AND UserId = @userId";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@postId", _postId);
                        cmd.Parameters.AddWithValue("@userId", _currentUserId);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Post został pomyślnie usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (Application.OpenForms["main"] is main mainForm)
                            {
                                mainForm.RefreshList();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nie udało się usunąć posta. Upewnij się, że jesteś jego autorem.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            }


        private void l_title_Click(object sender, EventArgs e) { }
        private void UserPost_Load(object sender, EventArgs e) { }

        private void l_date_Click(object sender, EventArgs e)
        {

        }

        private void l_content_Click(object sender, EventArgs e)
        {

        }
    }
}
