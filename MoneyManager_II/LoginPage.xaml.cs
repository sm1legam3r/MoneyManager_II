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
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.Show();
            //this.Close();
        }

        private bool Authorize()
        {
            var login = LoginTextBox.Text;
            var password = PasswordTextBox.Password;
            if(login.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Не все поля заполнены для авторизации.");
            }
            else if(CheckData(login, password))
            {
                return true
            }
            return false;

            private bool CheckData(string login, string password)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                string query = $"SELECT user_id, name, surname FROM users where login = '{login}' AND password = '{password}'";

                try
                {
                    SqlCommand command = new SqlCommand(query, database.GetConnection());
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    if(table.Rows.Count == 1)
                    {
                        MessageBox.Show($"Добро пожаловать, {table.Rows[0].Field<string>("name")}");
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

        }
        private void RegistrateTextClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
