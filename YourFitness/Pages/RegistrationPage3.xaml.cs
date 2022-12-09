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

namespace YourFitness.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage3.xaml
    /// </summary>
    public partial class RegistrationPage3 : Page
    {
        public RegistrationPage3()
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

                btn.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff844b");
                btn.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff844b");
            }
            switch (btn.Content)
            {
                case "2-3":
                    ug1.Visibility = Visibility.Hidden;
                    ug1.Visibility = Visibility.Visible;
                    break;
                case "3-4":
                    ug2.Visibility = Visibility.Hidden;
                    ug2.Visibility = Visibility.Visible;
                    break;
                case "4-5":
                    ug4.Visibility = Visibility.Hidden;
                    ug4.Visibility = Visibility.Visible;
                    break;
                case "5+":
                    ug5.Visibility = Visibility.Hidden;
                    ug5.Visibility = Visibility.Visible;
                    break;

            }

        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            GlobalParamClass.stepBar.StepIndex += 1;
            GlobalParamClass.registrationFrame.Navigate(new Pages.RegistrationPage4());
        }
    }
}
