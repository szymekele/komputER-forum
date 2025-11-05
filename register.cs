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
    public partial class register : Form
    {
        private const string ConnectionStringName = "komputerforum.Properties.Settings.kforumDBConnectionString";
        public register()
        {
            InitializeComponent();
        }

        private void l_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void l_button_Click(object sender, EventArgs e)
        {
            string username = r_username.Text;
            string password = r_password.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Wszystkie pola są wymagane.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username.Length > 10 || password.Length > 15)
            {
                MessageBox.Show("Nazwa użytkownika powinna maksymalnie posiadać 10 znaków, a hasło maksymalnie 15!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username.Length < 3 || password.Length < 7)
            {
                MessageBox.Show("Nazwa użytkownika powinna minimalnie posiadać 3 znaków, a hasło minimalnie 7!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringName]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Błąd połączenia z bazą danych!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM [dbo].[users] WHERE [username] = @username";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        if ((int)checkCmd.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("Użytkownik o tej nazwie już istnieje. Wybierz inną nazwę.", "Błąd Rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string maxIdQuery = "SELECT ISNULL(MAX(Id), 0) FROM [dbo].[users]";
                    int newId;

                    using (SqlCommand maxIdCmd = new SqlCommand(maxIdQuery, connection))
                    {
                        object result = maxIdCmd.ExecuteScalar();
                        newId = Convert.ToInt32(result) + 1;
                    }

                    string insertQuery = "INSERT INTO [dbo].[users] ([Id], [username], [password]) VALUES (@Id, @username, @password)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", newId);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Rejestracja zakończona pomyślnie! Zaloguj się na swoje konto.", "Poprawna rejestracja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            login formLogin = new login();
                            formLogin.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Błąd podczas rejestracji!", "Błędna rejestracja", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void register_Load(object sender, EventArgs e)
        {

        }
    }
}
