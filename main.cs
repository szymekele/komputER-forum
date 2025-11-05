using System;
using System.Collections.Generic;
using System.Drawing;
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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        public main(int userId) : this()
        {
            _currentUserId = userId;
            l_users_name.Text = GetUsernameById(_currentUserId);
            LoadPosts();
        }

        private void new_post_button_Click(object sender, EventArgs e)
        {
            if (_currentUserId <= 0)
            {
                MessageBox.Show("Brak zalogowanego użytkownika. Zaloguj się ponownie.");
                return;
            }

            var createNewPost = new CreatePost(CreatePost.EditorMode.CreatePost, _currentUserId);

            if (createNewPost.ShowDialog() == DialogResult.OK)
            {
                int newPostId = GetLastInsertedPostId(_currentUserId, createNewPost.CreatedTitle);

                UserPost postItem = new UserPost();
                postItem.SetPostData(
                    createNewPost.CreatedTitle,
                    createNewPost.CreatedContent,
                    GetUsernameById(_currentUserId),
                    createNewPost.CreatedAt,
                    newPostId,
                    _currentUserId
                );

                postsPanel.Controls.Add(postItem);
                postsPanel.Controls.SetChildIndex(postItem, 0);

                ArchiveOldPosts();
                LoadPosts();
            }

            LoadPosts();
        }

        private int GetLastInsertedPostId(int userId, string title)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 Id FROM posts WHERE UserId = @userId AND Title = @title ORDER BY Id DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@title", title ?? string.Empty);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        return Convert.ToInt32(result);
                }
            }

            return 0;
        }

        private void ArchiveOldPosts()
        {
            string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                string countQuery = "SELECT COUNT(*) FROM posts";
                int postCount = (int)new SqlCommand(countQuery, conn).ExecuteScalar();

                if (postCount > 10)
                {
                    int toArchive = postCount - 10;

                    string selectQuery = @"SELECT TOP (@toArchive) Id, UserId, Title, Content, CreatedAt FROM posts ORDER BY CreatedAt ASC";

                    var postsToArchive = new List<(int Id, int UserId, string Title, string Content, DateTime CreatedAt)>();

                    using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@toArchive", toArchive);

                        using (SqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                postsToArchive.Add((
                                    reader.GetInt32(0),
                                    reader.GetInt32(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetDateTime(4)
                                ));
                            }
                        }
                    }

                    foreach (var post in postsToArchive)
                    {
                        using (SqlCommand archiveComments = new SqlCommand(@"INSERT INTO comments_archive (PostId, UserId, Content, CreatedAt) SELECT PostId, UserId, Content, CreatedAt FROM comments WHERE PostId = @pid", conn))
                        {
                            archiveComments.Parameters.AddWithValue("@pid", post.Id);
                            archiveComments.ExecuteNonQuery();
                        }

                        using (SqlCommand deleteComments = new SqlCommand("DELETE FROM comments WHERE PostId = @pid", conn))
                        {
                            deleteComments.Parameters.AddWithValue("@pid", post.Id);
                            deleteComments.ExecuteNonQuery();
                        }

                        using (SqlCommand insertCmd = new SqlCommand(@"INSERT INTO posts_archive (OriginalPostId, UserId, Title, Content, CreatedAt) VALUES (@originalId, @userId, @title, @content, @createdAt)", conn))
                        {
                            insertCmd.Parameters.AddWithValue("@originalId", post.Id);
                            insertCmd.Parameters.AddWithValue("@userId", post.UserId);
                            insertCmd.Parameters.AddWithValue("@title", post.Title);
                            insertCmd.Parameters.AddWithValue("@content", post.Content);
                            insertCmd.Parameters.AddWithValue("@createdAt", post.CreatedAt);
                            insertCmd.ExecuteNonQuery();
                        }

                        using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM posts WHERE Id = @id", conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@id", post.Id);
                            deleteCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void logout_button_Click(object sender, EventArgs e)
        {
            home homeView = new home();
            homeView.Show();
            this.Close();
        }

        private void LoadPosts()
        {
            postsPanel.Controls.Clear();

            string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = @"SELECT p.Id, p.Title, p.Content, u.Username, p.CreatedAt FROM posts p JOIN users u ON p.UserId = u.Id ORDER BY p.CreatedAt DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int postId = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        string content = reader.GetString(2);
                        string author = reader.GetString(3);
                        DateTime created = reader.GetDateTime(4);

                        var postItem = new UserPost();
                        postItem.SetPostData(title, content, author, created, postId, _currentUserId);
                        postsPanel.Controls.Add(postItem);

                        LoadCommentsForPost(postId);
                    }
                }
            }
        }

        private void LoadCommentsForPost(int postId)
        {
            string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = @"SELECT c.Id, c.UserId, c.Content, c.CreatedAt, u.Username FROM comments c JOIN users u ON c.UserId = u.Id WHERE c.PostId = @postId ORDER BY c.CreatedAt ASC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@postId", postId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int commentId = reader.GetInt32(0);
                            int commentUserId = reader.GetInt32(1);
                            string content = reader.GetString(2);
                            DateTime createdAt = reader.GetDateTime(3);
                            string author = reader.GetString(4);

                            UserComment commentItem = new UserComment();
                            commentItem.SetCommentData(
                                commentId,
                                postId,
                                commentUserId,
                                author,
                                content,
                                createdAt,
                                _currentUserId
                            );

                            commentItem.Margin = new Padding(40, 0, 0, 0);
                            commentItem.BackColor = Color.FromArgb(65, 65, 65);
                            postsPanel.Controls.Add(commentItem);
                        }
                    }
                }
            }
        }

        public void RefreshList()
        {
            LoadPosts();
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

        private void l_users_name_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoadPosts();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }
    }
}
