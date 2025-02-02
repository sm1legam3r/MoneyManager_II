using MoneyManager_II.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoneyManager_II
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Window loginWindow;
        Database database = new Database();
        public LoginPage()
        {
            InitializeComponent();
            this.loginWindow = new Window();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Authorize())
            {
                ManagerWindow managerWindow = new ManagerWindow();
                managerWindow.Show();
                loginWindow.Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
        }

        private bool Authorize()
        {
            var login = LoginTextBox.Text;
            var password = PasswordTextBox.Password;

            using (SHA256 hash = SHA256.Create())
            {
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                password = builder.ToString();
            }

            if (login.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Не все поля заполнены для авторизации.");
            }
            else if (CheckData(login, password))
            {
                return true;
            }
            return false;
        }
        private bool CheckData(string login, string password)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"SELECT UserID, Name, Surname FROM Users WHERE Login = '{login}' AND Password = '{password}'";

            try
            {
                SqlCommand command = new SqlCommand(query, database.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    MessageBox.Show($"Добро пожаловать, {table.Rows[0].Field<string>("Name")}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void RegistrateTextClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
