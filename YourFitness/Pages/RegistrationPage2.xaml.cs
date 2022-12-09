using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для RegistrationPage2.xaml
    /// </summary>
    public partial class RegistrationPage2 : Page
    {
        public RegistrationPage2()
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
                case "Похудение":
                    ug1.Visibility = Visibility.Hidden;
                    ug1.Visibility = Visibility.Visible;
                    break;
                case "Укрепление здоровья":
                    ug2.Visibility = Visibility.Hidden;
                    ug2.Visibility = Visibility.Visible;
                    break;
                case "Увелечение выносливости":
                    ug3.Visibility = Visibility.Hidden;
                    ug3.Visibility = Visibility.Visible;
                    break;
                case "Снятие усталости":
                    ug4.Visibility = Visibility.Hidden;
                    ug4.Visibility = Visibility.Visible;
                    break;
                case "Увелечение мышц":
                    ug5.Visibility = Visibility.Hidden;
                    ug5.Visibility = Visibility.Visible;
                    break;
                case "Увелечение гибкости":
                    ug6.Visibility = Visibility.Hidden;
                    ug6.Visibility = Visibility.Visible;
                    break;


            }
           
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {

            GlobalParamClass.stepBar.StepIndex += 1;
            GlobalParamClass.registrationFrame.Navigate(new Pages.RegistrationPage3());
        }
    }
}
