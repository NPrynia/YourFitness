using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static YourFitness.Windows.AddWorkoutWindow;

namespace YourFitness.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWorkoutWindow.xaml
    /// </summary>
    /// 
   
    public partial class AddWorkoutWindow : Window
    {


        List<exerciseInWorkout>  listExercise = new List<exerciseInWorkout>();
        public AddWorkoutWindow()
        {
            InitializeComponent();
        }


        private void addExerciseInWorrkout_Click(object sender, RoutedEventArgs e)
        {
            if (cbExercise.SelectedIndex < 0)
            {
                MessageBox.Show("Не было выбрано упражнение");
                return;
            }
            if (tbQty.Text == "")
            {
                MessageBox.Show("Не было выбрано количество");
                return;
            }

            listExercise.Add(new exerciseInWorkout { exercise = cbExercise.Text, qty =Convert.ToInt32 (tbQty.Text )});
            dataGridExercise.ItemsSource = listExercise;
            dataGridExercise.Items.Refresh();

        }
        class exerciseInWorkout
        {
            public string exercise { get; set; }
            public int qty { get; set; }
        }

        private void dataGridExercise_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                dataGridExercise.Items.RemoveAt(dataGridExercise.SelectedIndex);
            }
        }
    }
}
