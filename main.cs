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

            CreatePost createNewPost = new CreatePost(_currentUserId);

            if (createNewPost.ShowDialog() == DialogResult.OK)
            {
                // Po dodaniu posta do bazy pobierz jego ID (ostatnio utworzony)
                int newPostId = GetLastInsertedPostId(_currentUserId, createNewPost.CreatedTitle);

                UserPost postItem = new UserPost();
                postItem.SetPostData(
                    createNewPost.CreatedTitle,
                    createNewPost.CreatedContent,
                    GetUsernameById(_currentUserId),
                    createNewPost.CreatedAt,
                    newPostId,          // ← przekazujemy ID nowego posta
                    _currentUserId      // ← i ID zalogowanego użytkownika
                );

                postsPanel.Controls.Add(postItem);
                postsPanel.Controls.SetChildIndex(postItem, 0); // dodaje na górę listy

                ArchiveOldPosts();
                LoadPosts();
            }

            LoadPosts();
        }

        private int GetLastInsertedPostId(int userId, string title)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[
                "komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 Id FROM posts WHERE UserId = @userId AND Title = @title ORDER BY Id DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@title", title ?? string.Empty); // zabezpieczenie przed null

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        return Convert.ToInt32(result);
                }
            }

            return 0;
        }


        private void ArchiveOldPosts()
        {
            string cs = ConfigurationManager.ConnectionStrings[
                "komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                // Sprawdź ile jest postów
                string countQuery = "SELECT COUNT(*) FROM posts";
                int postCount = (int)new SqlCommand(countQuery, conn).ExecuteScalar();

                // Archiwizuj tylko, jeśli jest więcej niż 10 postów
                if (postCount > 10)
                {
                    int toArchive = postCount - 10;

                    // Wybierz najstarsze posty do archiwizacji
                    string selectQuery = @"
                SELECT TOP (@toArchive) Id, UserId, Title, Content, CreatedAt
                FROM posts
                ORDER BY CreatedAt ASC";

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

                    // Po zamknięciu readera możemy działać
                    foreach (var post in postsToArchive)
                    {
                        // --- 1️⃣ Archiwizuj komentarze powiązane z tym postem ---
                        using (SqlCommand archiveComments = new SqlCommand(@"
    INSERT INTO comments_archive (PostId, UserId, Content, CreatedAt)
    SELECT PostId, UserId, Content, CreatedAt
    FROM comments
    WHERE PostId = @pid", conn))
                        {
                            archiveComments.Parameters.AddWithValue("@pid", post.Id);
                            archiveComments.ExecuteNonQuery();
                        }

                        // --- 2️⃣ Usuń komentarze powiązane z postem ---
                        using (SqlCommand deleteComments = new SqlCommand("DELETE FROM comments WHERE PostId = @pid", conn))
                        {
                            deleteComments.Parameters.AddWithValue("@pid", post.Id);
                            deleteComments.ExecuteNonQuery();
                        }

                        // --- 3️⃣ Archiwizuj sam post (bez ID konfliktów) ---
                        using (SqlCommand insertCmd = new SqlCommand(@"
                    INSERT INTO posts_archive (OriginalPostId, UserId, Title, Content, CreatedAt)
                    VALUES (@originalId, @userId, @title, @content, @createdAt)", conn))
                        {
                            insertCmd.Parameters.AddWithValue("@originalId", post.Id);
                            insertCmd.Parameters.AddWithValue("@userId", post.UserId);
                            insertCmd.Parameters.AddWithValue("@title", post.Title);
                            insertCmd.Parameters.AddWithValue("@content", post.Content);
                            insertCmd.Parameters.AddWithValue("@createdAt", post.CreatedAt);
                            insertCmd.ExecuteNonQuery();
                        }

                        // --- 4️⃣ Usuń post z głównej tabeli ---
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

            string cs = ConfigurationManager.ConnectionStrings[
                "komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = @"
            SELECT p.Id, p.Title, p.Content, u.Username, p.CreatedAt
            FROM posts p
            JOIN users u ON p.UserId = u.Id
            ORDER BY p.CreatedAt DESC";

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
            string cs = ConfigurationManager.ConnectionStrings[
                "komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = @"
            SELECT c.Id, c.UserId, c.Content, c.CreatedAt, u.Username
            FROM comments c
            JOIN users u ON c.UserId = u.Id
            WHERE c.PostId = @postId
            ORDER BY c.CreatedAt ASC";

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

                            // Utwórz kontrolkę komentarza
                            UserComment commentItem = new UserComment();
                            commentItem.SetCommentData(
                                commentId,       // ID komentarza
                                postId,          // ID posta
                                commentUserId,   // ID autora komentarza
                                author,          // nazwa użytkownika
                                content,         // treść
                                createdAt,       // data
                                _currentUserId   // ID aktualnie zalogowanego użytkownika
                            );

                            // Wizualne formatowanie
                            commentItem.Margin = new Padding(40, 0, 0, 5);
                            commentItem.BackColor = Color.FromArgb(85, 85, 85);

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

        //private void LoadPosts()
        //{
        //    //string connectionString = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
        //    //using (SqlConnection connection = new SqlConnection(connectionString))
        //    //{
        //    //    connection.Open();
        //    //    string selectQuery = "SELECT p.title, p.content, u.username FROM [dbo].[posts] p JOIN [dbo].[users] u ON p.userId = u.id ORDER BY p.id DESC";
        //    //    using (SqlCommand selectCmd = new SqlCommand(selectQuery, connection))
        //    //    {
        //    //        using (SqlDataReader reader = selectCmd.ExecuteReader())
        //    //        {
        //    //            posts_listBox.Items.Clear();
        //    //            while (reader.Read())
        //    //            {
        //    //                string title = reader.GetString(0);
        //    //                string content = reader.GetString(1);
        //    //                string username = reader.GetString(2);
        //    //                posts_listBox.Items.Add($"Tytuł: {title}\nAutor: {username}\nTreść: {content}\n-----------------------");
        //    //            }
        //    //        }
        //    //    }
        //    //}

        //    postsPanel.Controls.Clear();

        //    string connectionString = ConfigurationManager.ConnectionStrings[
        //        "komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        string query = @"
        //    SELECT p.Title, p.Content, u.Username, p.CreatedAt
        //    FROM posts p
        //    JOIN users u ON p.UserId = u.Id
        //    ORDER BY p.CreatedAt DESC";

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                string title = reader.GetString(0);
        //                string content = reader.GetString(1);
        //                string author = reader.GetString(2);
        //                DateTime createdAt = reader.GetDateTime(3);

        //                UserPost postItem = new UserPost();
        //                postItem.SetPostData(title, content, author, createdAt);

        //                postsPanel.Controls.Add(postItem);
        //            }
        //        }
        //    }
        //}

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
    }
}
