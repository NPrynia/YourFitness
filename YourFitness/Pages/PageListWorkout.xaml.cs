using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using static YourFitness.ClassHelper.ModelEF;

namespace YourFitness.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageListWorkout.xaml
    /// </summary>
    public partial class PageListWorkout : Page
    {


        ObservableCollection<Workout> listWorkout = new ObservableCollection<Workout>(GlobalParamClass.listWorkout);
        Workout reviewWorkout = new Workout();
        bool isChangeReviewWorkout;
        string tagTab;
        WorkoutReaction workoutReaction = new WorkoutReaction();
        public PageListWorkout()
        {
            InitializeComponent();
        }

        private void btnAddTrain_Click(object sender, RoutedEventArgs e)
        {
            AddWorkoutWindow addWorkoutWindow = new AddWorkoutWindow(listWorkout);
            addWorkoutWindow.Show();
        }

        private void border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tagTab = (sender as Border).Tag as string;
            switch (tagTab)
            {
                case "MyWorkout":
                    cvTrain.ItemsSource = listWorkout.Where(i => i.IDUser == GlobalParamClass.currentUser.ID);

                    break;

                case "BestWorkout":
                    cvTrain.ItemsSource = listWorkout.Where(i => i.AvgRating > 4.2);
                    break;
                case "Cardio":
                    cvTrain.ItemsSource = listWorkout.Where(i => i.IDWorkoutType == 1);
                    break;
                case "Stretching":
                    cvTrain.ItemsSource = listWorkout.Where(i => i.IDWorkoutType == 2);
                    break;

                case "AllBodyWorkout":
                    cvTrain.ItemsSource = listWorkout.Where(i => i.IDWorkoutType == 3);
                    break;
                case "ArmsWorkout":
                    cvTrain.ItemsSource = listWorkout.Where(i => i.IDWorkoutType == 4);
                    break;
                case "ShouldersWorkout":
                    cvTrain.ItemsSource = listWorkout.Where(i => i.IDWorkoutType == 5);
                    break;
                case "BackWorkout":
                    cvTrain.ItemsSource = listWorkout.Where(i => i.IDWorkoutType == 6);
                    break;

                case "ChestWorkout":
                    cvTrain.ItemsSource = listWorkout.Where(i => i.IDWorkoutType == 7);
                    break;
                case "FootWorkout":
                    cvTrain.ItemsSource = listWorkout.Where(i => i.IDWorkoutType == 8);
                    break;
                case "AbsWorkout":
                    cvTrain.ItemsSource = listWorkout.Where(i => i.IDWorkoutType == 9);
                    break;

                default:
                    return;
            }


            transitionerWorkout.SelectedIndex = 1;

        }

      

        private void btnStartWorkout_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var workout = button.DataContext as ModelEF.Workout;
            WorkoutWindow workoutWindow = new WorkoutWindow(workout);
            workoutWindow.Show();
            

        }

        private void btnFavoriteWorkout_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Workout dataContext = btn.DataContext as Workout;


            if (dataContext.isLikeCurrentUser == true)
            {
                if (MessageBox.Show("Удалить тренировку из понравившегося?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {

                   
                    
                    LikeWorkout likeWorkout = new LikeWorkout();
                    likeWorkout.IsLike = false;
                    likeWorkout.IDWorkout = dataContext.ID;
                    likeWorkout.IDUser = GlobalParamClass.currentUser.ID;
                    GlobalParamClass.listWorkoutLiked.Remove(dataContext);
                    ApiHelperClass.postLikeWorkout(likeWorkout);
                    var temp = dataContext.LikeWorkout.Where(i => i.IDUser == GlobalParamClass.currentUser.ID).FirstOrDefault();
                    if (temp != null)
                    {

                        temp.IsLike = false;
                    }
                    else
                    {
                        dataContext.LikeWorkout.Add(likeWorkout);
                    }

                     dataContext.isLikeCurrentUser = false;
                }
                else
                {
                    return;
                }
            }
            else
            {

              

              
                LikeWorkout likeWorkout = new LikeWorkout();
                likeWorkout.IsLike = true;
                likeWorkout.IDWorkout = dataContext.ID;
                likeWorkout.IDUser = GlobalParamClass.currentUser.ID;
                GlobalParamClass.listWorkoutLiked.Add(dataContext);
                ApiHelperClass.postLikeWorkout(likeWorkout);
                var temp = dataContext.LikeWorkout.Where(i => i.IDUser == GlobalParamClass.currentUser.ID).FirstOrDefault();
                if (temp != null)
                {

                    temp.IsLike = true;
                }
                else
                {
                    dataContext.LikeWorkout.Add(likeWorkout);
                }
                dataContext.isLikeCurrentUser = true;

            }
        }


        private void craeteReviewInSocial_Click(object sender, RoutedEventArgs e)
        {
            dialogHostReviewWorkout.IsOpen = true;
            if (dialogHostReviewWorkout.IsOpen == false)
            {
                return;
            }

            Button btn = sender as Button;
            dialogHostReviewWorkout.IsOpen = true;

            var temp = btn.DataContext as Workout;
            reviewWorkout = btn.DataContext as Workout;


            if (temp.WorkoutReactionCurrentUser != null)
            {
                btnSendReviewWorkout.Content = "Изменить";
                rbCreateReviewWorkout.Value = temp.WorkoutReactionCurrentUser.Rating;
                tbCreateReviewWorokut.Text = temp.WorkoutReactionCurrentUser.Review;

                isChangeReviewWorkout = true;
                workoutReaction = temp.AllWorkoutReaction.Where(i => i.IDUser == temp.WorkoutReactionCurrentUser.IDUser && i.IDWorkout == temp.WorkoutReactionCurrentUser.IDWorkout).FirstOrDefault();
                workoutReaction.IDWorkout = temp.ID;


            }
            else
            {
                btnSendReviewWorkout.Content = "Отправить";
                rbCreateReviewWorkout.Value = 0;
                tbCreateReviewWorokut.Text = "";

                isChangeReviewWorkout = false;
                workoutReaction.IDWorkout = temp.ID;

            }

        }

        private void btnDeleteRivewWorkoutInSocial_Click(object sender, RoutedEventArgs e)
        {

                if (reviewWorkout.WorkoutReactionCurrentUser != null)
                {

                    ApiHelperClass.deleteWorkoutReview(reviewWorkout.WorkoutReactionCurrentUser);

                    reviewWorkout.AllWorkoutReaction.Remove(reviewWorkout.WorkoutReactionCurrentUser);


                    int sumRating = 0;
                    if (reviewWorkout.AllWorkoutReaction.Count() != 0)
                    {
                        foreach (WorkoutReaction rw in reviewWorkout.AllWorkoutReaction)
                        {
                            sumRating += rw.Rating;
                        }
                        reviewWorkout.AvgRating = sumRating / reviewWorkout.AllWorkoutReaction.Count();
                    }
                    else
                    {

                        reviewWorkout.AvgRating = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Вы не оставляли комментарий, что бы его удалить");
                }
          



        }


        private void btnSendReviewWorkoutInSocial_Click(object sender, RoutedEventArgs e)
        {

            if (isChangeReviewWorkout == true)
            {
                workoutReaction.IDUser = GlobalParamClass.currentUser.ID;
                workoutReaction.User = GlobalParamClass.currentUser;
                workoutReaction.Rating = Convert.ToInt32(rbCreateReviewWorkout.Value);
                workoutReaction.Review = tbCreateReviewWorokut.Text;
                workoutReaction.TimeSent = DateTime.Now;

                int sumRating = 0;
                if (reviewWorkout.AllWorkoutReaction.Count() != 0)
                {
                    foreach (WorkoutReaction rw in reviewWorkout.AllWorkoutReaction)
                    {
                        sumRating += rw.Rating;
                    }
                    reviewWorkout.AvgRating = sumRating / reviewWorkout.AllWorkoutReaction.Count();
                }
                else
                {

                    reviewWorkout.AvgRating = 0;

                }




                ApiHelperClass.putWorkoutReview(workoutReaction);
            }
            else
            {
                workoutReaction.IDUser = GlobalParamClass.currentUser.ID;
                workoutReaction.User = GlobalParamClass.currentUser;
                workoutReaction.Rating = Convert.ToInt32(rbCreateReviewWorkout.Value);
                workoutReaction.Review = tbCreateReviewWorokut.Text;
                workoutReaction.TimeSent = DateTime.Now;

                reviewWorkout.AllWorkoutReaction.Add(workoutReaction);

                int sumRating = 0;
                if (reviewWorkout.AllWorkoutReaction.Count() != 0)
                {
                    foreach (WorkoutReaction rw in reviewWorkout.AllWorkoutReaction)
                    {
                        sumRating += rw.Rating;
                    }
                    reviewWorkout.AvgRating = sumRating / reviewWorkout.AllWorkoutReaction.Count();
                }
                else
                {

                    reviewWorkout.AvgRating = 0;
                }





                ApiHelperClass.postWorkoutReview(workoutReaction);
            }

        }

        public void filterForWorkout()
        {
            if(transitionerWorkout.SelectedIndex == 1)
            {
                List<Workout> filterListWorkout = listWorkout.ToList();
                if (tbSearchLikedWorkout.Text != "")
                {

                    filterListWorkout = filterListWorkout.Where(i => i.Name.ToLower().Contains(tbSearchLikedWorkout.Text.ToLower())).ToList();

                }


                if (lbFilterDiffucltEasy.IsSelected == false)
                {
                    filterListWorkout = filterListWorkout.Where(i => i.IDDificulty != 1).ToList();
                }

                if (lbFilterDiffucltMid.IsSelected == false)
                {
                    filterListWorkout = filterListWorkout.Where(i => i.IDDificulty != 2).ToList();
                }
                if (lbFilterDiffucltHard.IsSelected == false)
                {
                    filterListWorkout = filterListWorkout.Where(i => i.IDDificulty != 3).ToList();
                }


                if (lbFilterDurationShort.IsSelected == false)
                {
                    filterListWorkout = filterListWorkout.Where(i => i.DurationInMin > 10).ToList();
                }

                if (lbFilterDurationMid.IsSelected == false)
                {
                    filterListWorkout = filterListWorkout.Where(i => i.DurationInMin < 10 || i.DurationInMin > 30).ToList();
                }
                if (lbFilterDurationLong.IsSelected == false)
                {
                    filterListWorkout = filterListWorkout.Where(i => i.DurationInMin < 30).ToList();
                }
                switch (cbSortLikedWorkout.SelectedIndex)
                {
                    case 0:
                        filterListWorkout = filterListWorkout.OrderByDescending(i => i.ID).ToList();
                        break;
                    case 1:
                        filterListWorkout = filterListWorkout.OrderByDescending(i => i.IDDificulty).ToList();
                        break;
                    case 2:
                        filterListWorkout = filterListWorkout.OrderByDescending(i => i.AvgRating).ToList();
                        break;
                    case 3:
                        filterListWorkout = filterListWorkout.OrderByDescending(i => i.DurationInMin).ToList();
                        break;
                }



                Dispatcher.Invoke((Action)(() =>
                {

                    switch (tagTab)
                    {
                        case "MyWorkout":
                            cvTrain.ItemsSource = new ObservableCollection<Workout>(filterListWorkout.Where(i => i.IDUser == GlobalParamClass.currentUser.ID)) ;
                            break;
                        case "BestWorkout":
                            cvTrain.ItemsSource = new ObservableCollection<Workout>(filterListWorkout.Where(i => i.AvgRating > 4.2)) ;
                            break;
                        case "Cardio":
                            cvTrain.ItemsSource = new ObservableCollection<Workout>(filterListWorkout.Where(i => i.IDWorkoutType == 1))  ;
                            break;
                        case "Stretching":
                            cvTrain.ItemsSource = new ObservableCollection<Workout>(filterListWorkout.Where(i => i.IDWorkoutType == 2));
                            break;

                        case "AllBodyWorkout":
                            cvTrain.ItemsSource = new ObservableCollection<Workout>(filterListWorkout.Where(i => i.IDWorkoutType == 3))  ;
                            break;
                        case "ArmsWorkout":
                            cvTrain.ItemsSource = new ObservableCollection<Workout>(filterListWorkout.Where(i => i.IDWorkoutType == 4)) ;
                            break;
                        case "ShouldersWorkout":
                            cvTrain.ItemsSource = new ObservableCollection<Workout>(filterListWorkout.Where(i => i.IDWorkoutType == 5))  ;
                            break;
                        case "BackWorkout":
                            cvTrain.ItemsSource = new ObservableCollection<Workout>(filterListWorkout.Where(i => i.IDWorkoutType == 6)) ;
                            break;

                        case "ChestWorkout":
                            cvTrain.ItemsSource = new ObservableCollection<Workout>(filterListWorkout.Where(i => i.IDWorkoutType == 7)) ;
                            break;
                        case "FootWorkout":
                            cvTrain.ItemsSource = new ObservableCollection<Workout>(filterListWorkout.Where(i => i.IDWorkoutType == 8));
                            break;
                        case "AbsWorkout":
                            cvTrain.ItemsSource = new ObservableCollection<Workout>(filterListWorkout.Where(i => i.IDWorkoutType == 9))  ;
                            break;

                        default:
                            return;
                    }

                }));

            }
            else
            {
                return;
            }
           



        }

        private void tbSearchLikedWorkout_TextChanged(object sender, TextChangedEventArgs e)
        {

                filterForWorkout();
        }

        private void cbSortLikedWorkout_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                filterForWorkout();
        }

        private void dialogHostReviewWorkout_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                dialogHostReviewWorkout.IsOpen = false;
            }
        }
    }
}
