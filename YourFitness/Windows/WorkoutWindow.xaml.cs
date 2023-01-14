using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace YourFitness.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkoutWindow.xaml
    /// </summary>
    public partial class WorkoutWindow : Window
    {
        public WorkoutWindow()
        {
            InitializeComponent();

        }

        private void tbNameExercise_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DrawerHost.IsBottomDrawerOpen=true;
        }

        private void DrawerHost_DrawerClosing(object sender, MaterialDesignThemes.Wpf.DrawerClosingEventArgs e)
        {
            Storyboard s = (Storyboard)TryFindResource("animCloseDrawerHost");
            s.Begin();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            progressBar.Value = 33;
            toggleBtn.IsChecked=true;
            tbNameExerciseInProgress.Foreground= (SolidColorBrush)new BrushConverter().ConvertFromString("#ff844b");
            borderInProgressExercise.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#ff844b");
            borderInProgressExercise.Width = 0;
            Storyboard s = (Storyboard)TryFindResource("nextExercise");
            s.Begin();
            DispatcherTimer dispatcherTimer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.31) };
            dispatcherTimer.Start();
            dispatcherTimer.Tick += new EventHandler((object c, EventArgs eventArgs) =>
            {

                s.Stop();

            });

            dispatcherTimer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.32) };
            dispatcherTimer.Start();
            dispatcherTimer.Tick += new EventHandler((object c, EventArgs eventArgs) =>
            {

                borderInProgressExercise.Width = 1000;
            });

            //tbNameExercise.Text = "Приседания";
            //imgExercise.Source = new BitmapImage(new Uri(@"\tempWp\sit1.png", UriKind.Relative));
            //imgExercise2.Source = new BitmapImage(new Uri(@"\tempWp\sit2.png", UriKind.Relative));
        }
    }
}
