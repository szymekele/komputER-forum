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
        public string CreatedTitle { get; private set; }
        public string CreatedContent { get; private set; }
        public DateTime CreatedAt { get; private set; }


        public CreatePost(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void public_button_Click(object sender, EventArgs e)
        {
            string title = title_textBox.Text.Trim();
            string content = content_richTextBox.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["komputerforum.Properties.Settings.kforumDBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO [dbo].[posts] ([userId], [title], [content]) VALUES (@userId, @title, @content)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@userId", _userId);
                    insertCmd.Parameters.AddWithValue("@title", title);
                    insertCmd.Parameters.AddWithValue("@content", content);
                    int rowsAffected = insertCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        CreatedTitle = title;
                        CreatedContent = content;
                        CreatedAt = DateTime.Now;

                        MessageBox.Show("Post został utworzony pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd podczas tworzenia posta.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
