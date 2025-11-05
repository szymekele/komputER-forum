//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Configuration;
//using System.Data.SqlClient;

//namespace komputerforum
//{
//    public partial class UserPost : UserControl
//    {

//        private int _postId;
//        private int _currentUserId;

//        public UserPost()
//        {
//            InitializeComponent();
//            this.Margin = new Padding(10);
//            this.AutoSize = true;
//            this.AutoSizeMode = AutoSizeMode.GrowOnly;
//            this.Anchor = AnchorStyles.Left | AnchorStyles.Right;
//            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
//            this.AutoSize = true;
//            this.Dock = DockStyle.Top;
//            l_content.TextAlign = ContentAlignment.TopLeft;

//            //this.Margin = new Padding(10);
//            //this.AutoSize = false;

//            //this.BackColor = Color.FromArgb(97, 97, 97);

//            //// szerokość narzucisz w main.cs, tutaj blokada
//            //this.MinimumSize = new Size(900, 0);
//            //this.MaximumSize = new Size(900, 5000);

//            //// zawijanie tekstu
//            //l_content.AutoSize = true;
//            //l_content.MaximumSize = new Size(860, 0);
//        }

//        public void SetPostData(string title, string content, string username, DateTime createdAt, int postId, int currentUserId)
//        {
//            l_title.Text = title;
//            l_content.Text = content;
//            l_author.Text = $"Autor: {username}";
//            l_date.Text = createdAt.ToString("yyyy-MM-dd HH:mm");

//            _postId = postId;
//            _currentUserId = currentUserId;

//            Button commentButton = new Button();
//            commentButton.Text = "💬 Komentuj";
//            commentButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
//            commentButton.AutoSize = true;
//            commentButton.Location = new Point(10, l_content.Bottom + 10);
//            commentButton.Click += CommentButton_Click;
//            this.Controls.Add(commentButton);

//            if (GetPostAuthorId() == _currentUserId) // sprawdź, czy ten post należy do zalogowanego użytkownika
//            {
//                Button editButton = new Button();
//                editButton.Text = "✏️ Edytuj";
//                editButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
//                editButton.AutoSize = true;
//                editButton.Location = new Point(120, l_content.Bottom + 10);
//                editButton.Click += EditButton_Click;
//                this.Controls.Add(editButton);
//            }
//        }

//        private int GetPostAuthorId()
//        {
//            int authorId = -1;
//            string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
//            using (SqlConnection conn = new SqlConnection(cs))
//            {
//                conn.Open();
//                string query = "SELECT UserId FROM posts WHERE Id = @postId";
//                using (SqlCommand cmd = new SqlCommand(query, conn))
//                {
//                    cmd.Parameters.AddWithValue("@postId", _postId);
//                    object result = cmd.ExecuteScalar();
//                    if (result != null)
//                        authorId = Convert.ToInt32(result);
//                }
//            }
//            return authorId;
//        }

//        private void EditButton_Click(object sender, EventArgs e)
//        {
//            // Otwórz CreatePost w trybie edycji
//            CreatePost editForm = new CreatePost(_currentUserId, _postId, true);

//            if (editForm.ShowDialog() == DialogResult.OK)
//            {
//                // Odśwież listę po edycji
//                ((main)Application.OpenForms["main"]).RefreshList();
//            }
//        }



//        private void CommentButton_Click(object sender, EventArgs e)
//        {
//            // Tu otwieramy nowe okno tworzenia komentarza
//            CreateComment commentForm = new CreateComment(_postId, _currentUserId);
//            if (commentForm.ShowDialog() == DialogResult.OK)
//            {
//                // Po pomyślnym dodaniu komentarza
//                //MessageBox.Show("Komentarz dodany!");
//                // Możesz tu odświeżyć komentarze (LoadComments()) jeśli je wczytujesz
//                if (Application.OpenForms["main"] is main mainForm)
//                {
//                    mainForm.RefreshList();
//                }
//            }
//        }

//        private void l_title_Click(object sender, EventArgs e)
//        {

//        }

//        private void UserPost_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}


////using System;
////using System.Configuration;
////using System.Data.SqlClient;
////using System.Drawing;
////using System.Windows.Forms;

////namespace komputerforum
////{
////    public partial class UserPost : UserControl
////    {
////        private int _postId;
////        private int _currentUserId;

////        public UserPost()
////        {
////            InitializeComponent();
////            this.Margin = new Padding(10);
////            this.BorderStyle = BorderStyle.FixedSingle;
////            this.BackColor = Color.WhiteSmoke;
////        }

////        // Dodaliśmy dwa nowe parametry: postId i currentUserId
////        public void SetPostData(string title, string content, string username, DateTime createdAt, int postId, int currentUserId)
////        {
////            l_title.Text = title;
////            l_content.Text = content;
////            l_author.Text = $"Autor: {username}";
////            l_date.Text = createdAt.ToString("yyyy-MM-dd HH:mm");

////            _postId = postId;
////            _currentUserId = currentUserId;

////            Button commentButton = new Button();
////            commentButton.Text = "💬 Komentuj";
////            commentButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
////            commentButton.AutoSize = true;
////            commentButton.Location = new Point(10, l_content.Bottom + 10);
////            commentButton.Click += CommentButton_Click;
////            this.Controls.Add(commentButton);
////        }

////        private void CommentButton_Click(object sender, EventArgs e)
////        {
////            if (_postId <= 0 || _currentUserId <= 0)
////            {
////                MessageBox.Show("Nie można dodać komentarza. Brak identyfikatora posta lub użytkownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
////                return;
////            }

////            using (CreateComment commentForm = new CreateComment(_postId, _currentUserId))
////            {
////                if (commentForm.ShowDialog() == DialogResult.OK)
////                {
////                    MessageBox.Show("Komentarz dodany pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
////                }
////            }
////        }
////    }
////}


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

            // Komentuj
            Button commentButton = new Button();
            commentButton.Text = "💬 Komentuj";
            commentButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            commentButton.AutoSize = true;
            commentButton.Location = new Point(10, l_content.Bottom + 10);
            commentButton.Click += CommentButton_Click;
            this.Controls.Add(commentButton);

            // Edytuj post (tylko autor)
            if (GetPostAuthorId() == _currentUserId)
            {
                Button editButton = new Button();
                editButton.Text = "✏️ Edytuj";
                editButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                editButton.AutoSize = true;
                editButton.Location = new Point(120, l_content.Bottom + 10);
                editButton.Click += EditButton_Click;
                this.Controls.Add(editButton);
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

        private void l_title_Click(object sender, EventArgs e) { }
        private void UserPost_Load(object sender, EventArgs e) { }
    }
}
