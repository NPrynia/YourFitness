using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YourFitness.ClassHelper;
using YourFitness.Windows;

namespace YourFitness.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage4.xaml
    /// </summary>
    public partial class RegistrationPage4 : Page
    {
        ModelEF.User newUser;
        public RegistrationPage4()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Foreground.ToString() == "#FFFF844B")
            {
                btn.Foreground = Brushes.Gray;
                btn.BorderBrush = Brushes.Gray;
            }
            else
            {
                btn1.Foreground = Brushes.Gray;
                btn1.BorderBrush = Brushes.Gray;
                btn2.Foreground = Brushes.Gray;
                btn2.BorderBrush = Brushes.Gray;
                btn3.Foreground = Brushes.Gray;
                btn3.BorderBrush = Brushes.Gray;
                btn4.Foreground = Brushes.Gray;
                btn4.BorderBrush = Brushes.Gray;

                btn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff844b");
                btn.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff844b");
            }
            switch (btn.Content)
            {
                case "5-10 минут":
                    ug1.Visibility = Visibility.Hidden;
                    ug1.Visibility = Visibility.Visible;
                    break;
                case "15-20 минут":
                    ug2.Visibility = Visibility.Hidden;
                    ug2.Visibility = Visibility.Visible;
                    break;
                case "25-30 минут":
                    ug4.Visibility = Visibility.Hidden;
                    ug4.Visibility = Visibility.Visible;
                    break;
                case "30+ минут":
                    ug5.Visibility = Visibility.Hidden;
                    ug5.Visibility = Visibility.Visible;
                    break;

            }

        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            var currentWin = Window.GetWindow(this);
            currentWin.Close();
            authWindow.Show();
        }
    }
}
