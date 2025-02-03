using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        ManagerWindow managerWindow;
        private bool isDarkTheme = false; // Переменная для отслеживания текущей темы

        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isDarkTheme)
            {
                // Включаем светлую тему
                Application.Current.Resources["PrimaryColor"] = new SolidColorBrush(Color.FromRgb(251, 245, 221)); // #FBF5DD
                Application.Current.Resources["OneColor"] = new SolidColorBrush(Color.FromRgb(166, 205, 198)); // #A6CDC6
                Application.Current.Resources["TextColor"] = new SolidColorBrush(Color.FromRgb(22, 64, 77)); // #16404D
                Application.Current.Resources["TwoColor"] = new SolidColorBrush(Color.FromRgb(221, 168, 83)); // #DDA853
            }
            else
            {
                // Включаем тёмную тему
                Application.Current.Resources["PrimaryColor"] = new SolidColorBrush(Color.FromRgb(126, 122, 110)); // #7E7A6E
                Application.Current.Resources["OneColor"] = new SolidColorBrush(Color.FromRgb(83, 102, 99)); // #536663
                Application.Current.Resources["TextColor"] = new SolidColorBrush(Color.FromRgb(33, 96, 116)); // #216074
                Application.Current.Resources["TwoColor"] = new SolidColorBrush(Color.FromRgb(110, 84, 42)); // #6E542A
            }

            isDarkTheme = !isDarkTheme; // Переключаем флаг
            ColorChangeButton.Content = "Включить светлую тему";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            managerWindow.Close();
        }
    }
}
