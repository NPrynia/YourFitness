using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using YourFitness.ClassHelper;
using static YourFitness.ClassHelper.ModelEF;

namespace YourFitness.Windows
{
    /// <summary>
    /// Логика взаимодействия для ListWorkoutSearchWindow.xaml
    /// </summary>
    public partial class ListWorkoutSearchWindow : Window
    {
        public ListWorkoutSearchWindow()
        {
            InitializeComponent();

           
            lvWorkout.ItemsSource = GlobalParamClass.listWorkout; 
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btnPickWorkout_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            var workout = btn.DataContext as Workout;
            GlobalParamClass.PickedWorkout = workout; 
            this.Close();
        }
    }
}
