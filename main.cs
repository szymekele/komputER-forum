using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace komputerforum
{
    public partial class main : Form
    {

        private readonly int _currentUserId = -1;
        public main()
        {
            InitializeComponent();
        }

        public main(int userId) : this()
        {
            _currentUserId = userId;
            LoadPosts();
        }


        private void new_post_button_Click(object sender, EventArgs e)
        {
            if (_currentUserId <= 0)
            {
                MessageBox.Show("Brak zalogowanego użytkownika. Zaloguj się ponownie.");
                return;
            }

            CreatePost createNewPost = new CreatePost(_currentUserId);

            if (createNewPost.ShowDialog() == DialogResult.OK)
            {
                UserPost postItem = new UserPost();
                postItem.SetPostData(
                    createNewPost.CreatedTitle,
                    createNewPost.CreatedContent,
                    GetUsernameById(_currentUserId),
                    createNewPost.CreatedAt
                );

                postsPanel.Controls.Add(postItem);
                postsPanel.Controls.SetChildIndex(postItem, 0); // dodaje na górę listy
            }

            LoadPosts();
        }

        private void logout_button_Click(object sender, EventArgs e)
        {
            home homeView = new home();
            homeView.Show();
            this.Close();
        }

        private void LoadPosts()
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    string selectQuery = "SELECT p.title, p.content, u.username FROM [dbo].[posts] p JOIN [dbo].[users] u ON p.userId = u.id ORDER BY p.id DESC";
            //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, connection))
            //    {
            //        using (SqlDataReader reader = selectCmd.ExecuteReader())
            //        {
            //            posts_listBox.Items.Clear();
            //            while (reader.Read())
            //            {
            //                string title = reader.GetString(0);
            //                string content = reader.GetString(1);
            //                string username = reader.GetString(2);
            //                posts_listBox.Items.Add($"Tytuł: {title}\nAutor: {username}\nTreść: {content}\n-----------------------");
            //            }
            //        }
            //    }
            //}

            postsPanel.Controls.Clear();

            string connectionString = ConfigurationManager.ConnectionStrings[
                "komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT p.Title, p.Content, u.Username, p.CreatedAt
            FROM posts p
            JOIN users u ON p.UserId = u.Id
            ORDER BY p.CreatedAt DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string title = reader.GetString(0);
                        string content = reader.GetString(1);
                        string author = reader.GetString(2);
                        DateTime createdAt = reader.GetDateTime(3);

                        UserPost postItem = new UserPost();
                        postItem.SetPostData(title, content, author, createdAt);

                        postsPanel.Controls.Add(postItem);
                    }
                }
            }
        }

        private string GetUsernameById(int userId)
        {
            string username = "Nieznany";

            string connectionString = ConfigurationManager.ConnectionStrings[
                "komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT username FROM users WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        username = result.ToString();
                }
            }

            return username;
        }

        private void postsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
