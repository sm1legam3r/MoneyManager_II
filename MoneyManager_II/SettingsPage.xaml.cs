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
        private ManagerWindow managerWindow;
        private bool isDarkTheme = false; // Переменная для отслеживания текущей темы

        public SettingsPage(ManagerWindow manager)
        {
            InitializeComponent();
            managerWindow = manager;
        }

        private void ColorChange_Click(object sender, RoutedEventArgs e)
        {
            if (isDarkTheme)
            {
                // Включаем светлую тему
                Application.Current.Resources["PrimaryColor"] = new SolidColorBrush(Color.FromRgb(251, 245, 221)); // #FBF5DD
                Application.Current.Resources["SecondaryColor"] = new SolidColorBrush(Color.FromRgb(221, 241, 52)); // #DDF134
                Application.Current.Resources["OneColor"] = new SolidColorBrush(Color.FromRgb(166, 205, 198)); // #A6CDC6
                Application.Current.Resources["TextColor"] = new SolidColorBrush(Color.FromRgb(22, 64, 77)); // #16404D
                Application.Current.Resources["TwoColor"] = new SolidColorBrush(Color.FromRgb(221, 168, 83)); // #DDA853

                ColorChangeButton.Content = "Включить тёмную тему";
            }
            else
            {
                // Включаем тёмную тему
                Application.Current.Resources["PrimaryColor"] = new SolidColorBrush(Color.FromRgb(126, 122, 110)); // #7E7A6E
                Application.Current.Resources["SecondaryColor"] = new SolidColorBrush(Color.FromRgb(75, 83, 6)); // #4B5306
                Application.Current.Resources["OneColor"] = new SolidColorBrush(Color.FromRgb(83, 102, 99)); // #536663
                Application.Current.Resources["TextColor"] = new SolidColorBrush(Color.FromRgb(185, 197, 201)); // #B9C5C9
                Application.Current.Resources["TwoColor"] = new SolidColorBrush(Color.FromRgb(110, 84, 42)); // #6E542A

                ColorChangeButton.Content = "Включить светлую тему";
            }

            isDarkTheme = !isDarkTheme; // Переключаем флаг
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            managerWindow.Logout();
        }
    }
}
