using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;
using YourFitness.ClassHelper;
using static YourFitness.ClassHelper.ModelEF;

namespace YourFitness.Windows
{
    /// <summary>
    /// Логика взаимодействия для WorkoutWindow.xaml
    /// </summary>
    public partial class WorkoutWindow : Window
    {
        ModelEF.Workout currentWorkout;
        int numberExercise = 0;
        int second = 0;

        string typeExercise;
        public Uri ImageUri { get; set; }

        DispatcherTimer timerExercise = new DispatcherTimer();
        DispatcherTimer timer = new DispatcherTimer();
        ObservableCollection<ExerciseWorkout> lsitExercise;
        public WorkoutWindow(ModelEF.Workout workout)
        {
            InitializeComponent();
            foreach (ExerciseWorkout ew in workout.ExerciseWorkout)
            {
                ew.Complete = "False";
            }

            
            currentWorkout = workout;
            lsitExercise = new ObservableCollection<ExerciseWorkout>(currentWorkout.ExerciseWorkout);
            lvExercise.ItemsSource = lsitExercise;
            nextExercise();
        }

        public void nextExercise()
        {
            second = 30;
            timer.Stop();
            timerExercise.Stop();

            if (currentWorkout.ExerciseWorkout.ToList()[numberExercise].Exercise.isQtyInSecond == true)
            {

                timerExercise = new DispatcherTimer();
                second = currentWorkout.ExerciseWorkout.ToList()[numberExercise].Qty;
                tbQtyExercise.Text = currentWorkout.ExerciseWorkout.ToList()[numberExercise].Qty.ToString();
                timerExercise.Interval = TimeSpan.FromSeconds(1);
                timerExercise.Tick += timerExecise_Tick;
                timerExercise.Start();

                typeExercise = "секунд";
            }
            else
            {
                typeExercise = "раз";
            }

            tbbtnNext.Text = "Следующие";
            spInfoQtyExer.Visibility = Visibility.Visible;
            mainTransitioner.SelectedIndex = 0;

            

            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri($"pack://application:,,,/Res/exercise/{currentWorkout.ExerciseWorkout.ToList()[numberExercise].Exercise.PathToGif.Replace("D:\\exercise\\", "")}");
            image.EndInit();
            ImageBehavior.SetAnimatedSource(imgExercise, image);
            tbNameExercise.Text = currentWorkout.ExerciseWorkout.ToList()[numberExercise].Exercise.Name;
            tbMoreInfoExerciseName.Text = currentWorkout.ExerciseWorkout.ToList()[numberExercise].Exercise.Name;
            tbMoreInfoExerciseDescription.Text = currentWorkout.ExerciseWorkout.ToList()[numberExercise].Exercise.Description;
            tbMoreInfoExerciseMuscleTypeExercise.Text = currentWorkout.ExerciseWorkout.ToList()[numberExercise].Exercise.MuscleTypeName.ToLower();
            tbQtyExercise.Text = currentWorkout.ExerciseWorkout.ToList()[numberExercise].Qty.ToString();

            try
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.SetOutputToDefaultAudioDevice();

                synth.SpeakAsync($"{currentWorkout.ExerciseWorkout.ToList()[numberExercise].Exercise.Name} {currentWorkout.ExerciseWorkout.ToList()[numberExercise].Qty} {typeExercise}");
            }
            catch
            {

            }

            
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
            timerExercise.Stop();



            if (mainTransitioner.SelectedIndex == 0)
            {

                second = 30;
                lsitExercise[numberExercise].Complete = "True";
                progressBar.Value = numberExercise * 100 / currentWorkout.ExerciseWorkout.Count();
                numberExercise += 1;

                if (numberExercise >= lsitExercise.Count)
                {
                    numberExercise += 1;
                    progressBar.Value = numberExercise * 100 / currentWorkout.ExerciseWorkout.Count();
                    HandyControl.Controls.MessageBox.Show("Поздравляю, тренировка завершена!");
                    HistoryWorkoutUser hwu = new HistoryWorkoutUser();
                    hwu.IDUser = GlobalParamClass.currentUser.ID;
                    hwu.IDWorkout = currentWorkout.ID;
                    hwu.DateWorkout = DateTime.Now;
                    hwu.nameWorkout = currentWorkout.Name;
                    ApiHelperClass.postHistoryWorkoutUser(hwu);
                    GlobalParamClass.listHistoryWorkoutUser.Add(hwu);
                    this.Close();
                    return;
                }

                mainTransitioner.SelectedIndex = 1;
                spInfoQtyExer.Visibility = Visibility.Hidden;
                tbbtnNext.Text = "Пропустить";



                //lvExercise.Items.Refresh();
                timer = new DispatcherTimer();
                tbTimerSec.Text = "30";
                timer.Interval =  TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();

            }
            else
            {
                nextExercise();
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            if (numberExercise > 0)
            {

                numberExercise -= 1;
                timer.Stop();
                timer = new DispatcherTimer();
                second = 30;

                lsitExercise[numberExercise].Complete = "False";
                progressBar.Value = numberExercise * 100 / currentWorkout.ExerciseWorkout.Count();

                nextExercise();
                //lvExercise.Items.Refresh();
                spInfoQtyExer.Visibility = Visibility.Visible;
                mainTransitioner.SelectedIndex = 0;
            }
           
        }

        //Timer
        private void timer_Tick(object sender, EventArgs e)
        {

            second--;
            tbTimerSec.Text = second.ToString();
            if (second == 0)
            {
                timerExercise = new DispatcherTimer();
                second = 30;
                nextExercise();
            }
        }
        private void timerExecise_Tick(object sender, EventArgs e)
        {

            second--;
            tbQtyExercise.Text = second.ToString();
            if (second == 0)
            {
                timerExercise.Stop();
                second = 30;

                mainTransitioner.SelectedIndex = 1;
                spInfoQtyExer.Visibility = Visibility.Hidden;
                tbbtnNext.Text = "Пропустить";



                //lvExercise.Items.Refresh();
                timer = new DispatcherTimer();
                tbTimerSec.Text = "30";
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();

            }
        }

        //////////Window Title Bar////////////
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void topBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                if (e.ClickCount == 2)
                {
                    AdjustWindowSize();
                }
                else
                {

                    DragMove();
                }
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            AdjustWindowSize();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void AdjustWindowSize()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }

        }

      

        private void toggleBtn_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            var   workout = button.DataContext as ModelEF.Workout;
        }
    }
}
