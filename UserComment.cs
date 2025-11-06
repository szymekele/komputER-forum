using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace komputerforum
{
    public partial class UserComment : UserControl
    {
        private int _commentId;
        private int _postId;
        private int _currentUserId;

        public UserComment()
        {
            InitializeComponent();
        }

        public void SetCommentData(int commentId, int postId, int userId, string author, string content, DateTime createdAt, int currentUserId)
        {
            l_user.Text = author;
            l_comment_content.Text = content;
            l_time.Text = createdAt.ToString("yyyy-MM-dd HH:mm");

            _commentId = commentId;
            _postId = postId;
            _currentUserId = currentUserId;
            if (_currentUserId == userId)
            {
                Button editButton = new Button();
                editButton.Text = "✏️ Edytuj";
                editButton.Font = new Font("Segoe UI", 8F);
                editButton.Margin = new Padding(0, 20, 0, 0);
                editButton.AutoSize = true;
                editButton.Location = new Point(10, l_comment_content.Bottom + 20);
                editButton.Click += EditButton_Click;
                this.Controls.Add(editButton);

                Button deleteButton = new Button();
                deleteButton.Text = "🗑️ Usuń";
                deleteButton.Font = new Font("Segoe UI", 8F);
                deleteButton.Margin = new Padding(0, 20, 0, 0);
                deleteButton.AutoSize = true;
                deleteButton.Location = new Point(120, l_comment_content.Bottom + 20);
                deleteButton.Click += DeleteButton_Click;
                this.Controls.Add(deleteButton);
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Czy na pewno chcesz usunąć ten komentarz?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM comments WHERE Id = @commentId AND UserId = @userId";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@commentId", _commentId);
                        cmd.Parameters.AddWithValue("@userId", _currentUserId);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Komentarz został pomyślnie usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (Application.OpenForms["main"] is main mainForm)
                            {
                                mainForm.RefreshList();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nie udało się usunąć komentarza. Upewnij się, że jesteś jego autorem.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            var editForm = new CreatePost(CreatePost.EditorMode.EditComment, _currentUserId, postId: _postId, commentId: _commentId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                ((main)Application.OpenForms["main"]).RefreshList();
            }
        }

        private void UserComment_Load(object sender, EventArgs e)
        {

        }

        private void l_comment_content_Click(object sender, EventArgs e)
        {

        }
    }
}
