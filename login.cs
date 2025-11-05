using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace komputerforum
{
    public partial class login : Form
    {
        private const string ConnectionStringName = "komputerforum.Properties.Settings.kforumDBConnectionString";

        public login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void l_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void l_button_Click(object sender, EventArgs e)
        {
            string username = l_username.Text;
            string password = l_password.Text;

            string connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Wypełnij pola nazwy użytkownika i hasła.", "Błąd Logowania", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Id FROM [dbo].[users] WHERE [username] = @username AND [password] = @password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            int userId = Convert.ToInt32(result);

                            MessageBox.Show("Zalogowano pomyślnie! Witamy w forum!",
                                            "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            main formMain = new main(userId);
                            formMain.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło.",
                                            "Błąd Logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd bazy danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void home_button_Click(object sender, EventArgs e)
        {
            home newHomeView = new home();
            newHomeView.Show();
            this.Hide();
        }
    }
}
