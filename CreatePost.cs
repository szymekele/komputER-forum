using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace komputerforum
{
    public partial class CreatePost : Form
    {
        private readonly int _userId;
        private readonly int _postId;
        private readonly bool _isEditMode;

        public string CreatedTitle { get; private set; }
        public string CreatedContent { get; private set; }
        public DateTime CreatedAt { get; private set; }


        public CreatePost(int userId, int postId = 0, bool isEditMode = false)
        {
            InitializeComponent();
            _userId = userId;
            _postId = postId;
            _isEditMode = isEditMode;

            if (_isEditMode)
            {
                this.Text = "Edytuj post";
                LoadPostData();
                public_button.Text = "Zapisz zmiany"; // zmień napis na przycisku
            }
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void public_button_Click(object sender, EventArgs e)
        {
            string title = title_textBox.Text.Trim();
            string content = content_richTextBox.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Tytuł i treść nie mogą być puste.");
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                if (_isEditMode)
                {
                    // --- tryb edycji ---
                    string updateQuery = "UPDATE posts SET Title = @title, Content = @content WHERE Id = @id AND UserId = @uid";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@content", content);
                        cmd.Parameters.AddWithValue("@id", _postId);
                        cmd.Parameters.AddWithValue("@uid", _userId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Post został zaktualizowany.", "Sukces");
                }
                else
                {
                    // --- tryb tworzenia (oryginalny kod) ---
                    string insertQuery = "INSERT INTO posts (UserId, Title, Content, CreatedAt) VALUES (@uid, @title, @content, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@uid", _userId);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@content", content);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Post został utworzony.", "Sukces");
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void LoadPostData()
        {
            string cs = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT Title, Content FROM posts WHERE Id = @id AND UserId = @uid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _postId);
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

    }
}
