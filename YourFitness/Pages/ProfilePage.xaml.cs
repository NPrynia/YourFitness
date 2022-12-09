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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            
        }



        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            string buttonText = (sender as Button).Content as string;
            switch (buttonText)
            {
                case "Сообщение":
                    btnContinue.Content = "Профиль";
                    trProfilemessage.SelectedIndex = 1;
                    break;

                case "Профиль":

                    btnContinue.Content = "Сообщение";
                    trProfilemessage.SelectedIndex = 0;

                    break;
                default:
                    return;
            }

        }
        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (badgedLike.BadgeBackground.ToString() == "#FFFF844B")
            {
                badgedLike.BadgeBackground = Brushes.Gray;
                badgedLike.Badge = 3;
            }
            else
            {
                badgedLike.Badge = 4;
                badgedLike.BadgeBackground = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff844b");
            }
        }

        private void btnComment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            ProfileStatsWindow profileStatsWindow = new ProfileStatsWindow();
            profileStatsWindow.Show();

        }

       


        private void exitProfile_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GlobalParamClass.userFrame.Content = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
