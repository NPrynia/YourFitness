using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
using YourFitness.ClassHelper;
using static YourFitness.ClassHelper.ModelEF;
using static YourFitness.Windows.AddWorkoutWindow;

namespace YourFitness.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWorkoutWindow.xaml
    /// </summary>
    /// 
   
    public partial class AddWorkoutWindow : Window
    {


        List<ModelEF.ExerciseWorkout>  listExerciseInWorkout = new List<ModelEF.ExerciseWorkout>();
        ObservableCollection<Workout> listWorkout;
        int idWorkout;
        public AddWorkoutWindow(ObservableCollection<Workout> listW)
        {
            InitializeComponent();
            listWorkout = listW;

            idWorkout = GlobalParamClass.listWorkout.Last().ID + 1;
            ClassHelper.ApiHelperClass.getExercise();
            List<ModelEF.WorkoutType> workoutType = ClassHelper.ApiHelperClass.getTypeWorkout();
            cbExercise.ItemsSource = GlobalParamClass.listExercise;
            cbExercise.DisplayMemberPath = "Name";
            cbExercise.SelectedValuePath = "ID";
            cbTypeWorkout.ItemsSource = workoutType;
            cbTypeWorkout.DisplayMemberPath = "Name";
            cbTypeWorkout.SelectedValuePath = "ID";

        }


        private void addExerciseInWorrkout_Click(object sender, RoutedEventArgs e)
        {
            if (cbExercise.SelectedIndex < 0)
            {
                HandyControl.Controls.MessageBox.Show("Не было выбрано упражнение");
                return;
            }
            if (tbQty.Text == "")
            {
                HandyControl.Controls.MessageBox.Show("Не было выбрано количество");
                return;
            }
            if (int.TryParse(tbQty.Text, out int n) != true)
            {
                HandyControl.Controls.MessageBox.Show("Неккоретное число");
                return;
            }

            listExerciseInWorkout.Add(new ModelEF.ExerciseWorkout { Name = cbExercise.Text, IDExercise = (int)cbExercise.SelectedValue, IDWorkout = idWorkout, Qty = Convert.ToInt32(tbQty.Text) });
            dataGridExercise.ItemsSource = listExerciseInWorkout;
            dataGridExercise.Items.Refresh();

        }
       

        private void dataGridExercise_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                dataGridExercise.Items.RemoveAt(dataGridExercise.SelectedIndex);
            }
        }











        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void topBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
                    DragMove();
        }


        private void cbExercise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbExercise.SelectedIndex != 0)
                {
                    ModelEF.Exercise temp = cbExercise.SelectedItem as ModelEF.Exercise;
                    if (temp.isQtyInSecond == true)
                    {
                        tbTypeExercise.Text = "Секунд: ";


                    }
                    else
                    {
                        tbTypeExercise.Text = "Количество: ";
                    }
                }
               
            }
            catch
            { 
            
            }
           
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if ( tbNameWorkout.Text == "")
            {
                HandyControl.Controls.MessageBox.Show("Введите название тренировки");
                return;
            }

            if (cbTypeWorkout.SelectedIndex < 0)
            {
                HandyControl.Controls.MessageBox.Show("Выберите тип тренировки");
                return;
            }
            if (listExerciseInWorkout.Count < 2)
            {
                HandyControl.Controls.MessageBox.Show("Количетсво упражнений должно быть больше 2");
                return;
            }
            dhImgPicker.IsOpen = true;
        }

        private void btnSaveWorkout_Click(object sender, RoutedEventArgs e)
        {

            ModelEF.Workout workout = new ModelEF.Workout();
            if (isWorkout.Uri != null)
            {
                workout.ImagePath = isWorkout.Uri.LocalPath;
                workout.WorkoutImage = File.ReadAllBytes(isWorkout.Uri.LocalPath);

            }
            else 
            {
                workout.ImagePath = null;
                workout.WorkoutImage = null;

            }
            workout.ID = idWorkout;
            workout.Name = tbNameWorkout.Text;
            workout.Description = tbDescriptionWorkout.Text;
            workout.IDDificulty = (int)sliderDificultyWorkout.Value;
            workout.IDUser = GlobalParamClass.currentUser.ID;
            workout.ExerciseInWorkout = listExerciseInWorkout;
            workout.IDWorkoutType = Convert.ToInt32(cbTypeWorkout.SelectedValue);
            ApiHelperClass.postWorkout(workout);
            HandyControl.Controls.MessageBox.Show("Тренировка добавлена !");
            GlobalParamClass.listWorkout.Add(workout);
            listWorkout.Add(workout);
            this.Close();
        }

       
    }
}
