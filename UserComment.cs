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

            // przycisk edycji tylko dla autora komentarza
            if (_currentUserId == userId)
            {
                Button editButton = new Button();
                editButton.Text = "✏️ Edytuj";
                editButton.Font = new Font("Segoe UI", 8F);
                editButton.AutoSize = true;
                editButton.Location = new Point(5, l_comment_content.Bottom + 5);
                editButton.Click += EditButton_Click;
                this.Controls.Add(editButton);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            CreateComment editForm = new CreateComment(_postId, _currentUserId, _commentId, true);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Odśwież listę po edycji
                ((main)Application.OpenForms["main"]).RefreshList();
            }
        }
    }
}
