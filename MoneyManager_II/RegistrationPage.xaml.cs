using MoneyManager_II.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Database database = new Database();
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Registrate_Button_Click(object sender, RoutedEventArgs e)
        {
            if (RegistrateSuccess())
            {
                MessageBox.Show("Вы успешно зарегистрировались!");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Зарегистрироваться не получилось!");
            }
        }

        private bool RegistrateSuccess()
        {
            var name = NameTextBox.Text;
            var surname = SurnameTextBox.Text;
            var login = RegLoginTextBox.Text;
            var password = RegPasswordBox.Password;

            if(insertUser(name, surname, login, password))
            {
                return true;
            }

            return false;
        }

        private bool insertUser(string name, string surname, string login, string password)
        {
            string query = $"INSERT INTO Users(Name, Surname, Login, Password) VALUES ('{name}', '{surname}', '{login}', '{password}')";

            try
            {
                SqlCommand command = new SqlCommand(query, database.getConnection());
                database.OpenConnection();
                if(command.ExecuteNonQuery() == 1)
                {
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

        private bool CheckDataRegistration()
        {
            bool emptyFields = SurnameTextBox.Text.Equals("") || NameTextBox.Text.Equals("") ||
                               RegLoginTextBox.Text.Equals("") || RegPasswordBox.Password.Equals("");
            return !emptyFields;
        }

        private void GoBackTextClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
