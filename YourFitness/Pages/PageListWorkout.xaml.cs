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
using YourFitness.Windows;

namespace YourFitness.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageListWorkout.xaml
    /// </summary>
    public partial class PageListWorkout : Page
    {
        public PageListWorkout()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            transitionerWorkout.SelectedIndex = 2;
        }

        private void btnAddTrain_Click(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow addWorkoutWindow = new AddWorkoutWindow();
            addWorkoutWindow.Show();
        }

        private void borderMyWorkout_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            transitionerWorkout.SelectedIndex = 1;
        }
    }
}
