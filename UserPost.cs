using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97))))); ;
        }

        public void SetPostData(string title, string content, string username, DateTime createdAt)
        {
            l_title.Text = title;
            l_content.Text = content;
            l_author.Text = $"Autor: {username}";
            l_date.Text = createdAt.ToString("yyyy-MM-dd HH:mm");

            Button commentButton = new Button();
            commentButton.Text = "💬 Komentuj";
            commentButton.Margin = new Padding(0);
            commentButton.Location = new Point(10, l_content.Bottom + 10);
            commentButton.Click += CommentButton_Click;
            this.Controls.Add(commentButton);
        }

        private void CommentButton_Click(object sender, EventArgs e)
        {
            // Tu otwieramy nowe okno tworzenia komentarza
            CreateComment commentForm = new CreateComment(_postId, _currentUserId);
            if (commentForm.ShowDialog() == DialogResult.OK)
            {
                // Po pomyślnym dodaniu komentarza
                MessageBox.Show("Komentarz dodany!");
                // Możesz tu odświeżyć komentarze (LoadComments()) jeśli je wczytujesz
            }
        }

        private void l_title_Click(object sender, EventArgs e)
        {

        }

        private void UserPost_Load(object sender, EventArgs e)
        {

        }
    }
}


//using System;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.Windows.Forms;

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
//            this.BorderStyle = BorderStyle.FixedSingle;
//            this.BackColor = Color.WhiteSmoke;
//        }

//        // Dodaliśmy dwa nowe parametry: postId i currentUserId
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
//        }

//        private void CommentButton_Click(object sender, EventArgs e)
//        {
//            if (_postId <= 0 || _currentUserId <= 0)
//            {
//                MessageBox.Show("Nie można dodać komentarza. Brak identyfikatora posta lub użytkownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            using (CreateComment commentForm = new CreateComment(_postId, _currentUserId))
//            {
//                if (commentForm.ShowDialog() == DialogResult.OK)
//                {
//                    MessageBox.Show("Komentarz dodany pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//            }
//        }
//    }
//}
