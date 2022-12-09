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
using System.Windows.Shapes;
using YourFitness.ClassHelper;
using YourFitness.Pages;

namespace YourFitness.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GlobalParamClass.userFrame = userFrame;
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

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            borderImageAddPost.Height = 300;
        }

        private void btnAddWorkout_Click(object sender, RoutedEventArgs e)
        {
            borderWorkoutAddPost.Height = 45;
    
        }

        private void btnImageDalete_Click(object sender, RoutedEventArgs e)
        {
            borderImageAddPost.Height = 0;
        }

        private void btnDeleteWorkout_Click(object sender, RoutedEventArgs e)
        {
            borderWorkoutAddPost.Width = 0;
        }

       

      

       

      

        private void rightBorderInSocialTab_MouseLeave(object sender, MouseEventArgs e)
        {
            expanderInSocialTab.IsExpanded = false;
        }

        private void tbSearchInSocialTab_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            expanderInSocialTab.IsExpanded = true;
        }

        private void tbSearchInSocialTab_TextChanged(object sender, TextChangedEventArgs e)
        {
            expanderInSocialTab.IsExpanded = true;
        }

        private void StackPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            userFrame.Navigate(new Pages.ProfilePage());
        }
    }
}
