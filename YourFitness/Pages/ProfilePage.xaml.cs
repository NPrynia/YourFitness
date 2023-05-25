using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YourFitness.ClassHelper;
using YourFitness.Windows;
using static YourFitness.ClassHelper.ModelEF;

namespace YourFitness.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {

        News newsWhereChangeReviewWorkout = null;
        bool isChangeReviewWorkout = false;
        WorkoutReaction workoutReaction = new WorkoutReaction();
        ObservableCollection<News> listNewsInProfile;
        string pathImageMessage  = null;
        ModelEF.User userInProfile;
        List<Message> listMessage = new List<Message>();

        public ProfilePage(ModelEF.User user, ObservableCollection<News> listNews)
        {
            InitializeComponent();

            lvHistoryWorkoutUser.ItemsSource = ClassHelper.ApiHelperClass.getHistoryWorkoutUser(user.ID).TakeLast(5);
            tbFname.Text = user.FirstName;
            if (user.IDGender == 1)
            {
                tbFnameInProgress.Text = $"{user.FirstName} достиг ";
            }
            else
            {
                tbFnameInProgress.Text = $"{user.FirstName} достигла ";
            }
            tbSurName.Text = user.SecondName;
            tbDescription.Text = user.Description;
            listNewsInProfile = listNews;
            lvNews.ItemsSource = listNewsInProfile;
            tbAge.Text = (DateTime.Now.Year - user.Birthday.Year).ToString();
            tbWeitght.Text = user.Weitght.ToString();
            tbHeight.Text = user.Height.ToString();
            userInProfile = user;
            if (user.ImageProfile != null)
            {

                using (MemoryStream stream = new MemoryStream(user.ImageProfile))
                {
                    Image i = new Image();
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    i.Source = bitmapImage;
                    photoImage.ImageSource = i.Source;
                    gravatarProfile.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                gravatarProfile.Visibility = Visibility.Visible;
            }
            if (user.IDRole == 2)
            {
                btnTrainterService.Height = 40;
                btnTrainterService.IsEnabled = true;
            }
            refreshMessage();


        }
        public async void refreshMessage()
        {
            while (true)
            {
                await Task.Run(() => refreshMessageList());
                await Task.Run(() => Thread.Sleep(1000));
            }
        }

        public void refreshMessageList()
        {
            try
            {
                var tempList = ApiHelperClass.getMessageList(userInProfile.ID, listMessage.Count());
                if (tempList != null)
                {
                    listMessage = tempList;
                    Dispatcher.Invoke((Action)(() =>
                    {
                        listBoxChat.ItemsSource = listMessage;
                    }));
                }
            }
            catch
            {

            }

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

        private void toggleLikeInLvNewsSocial_Click(object sender, RoutedEventArgs e)
        {


            ToggleButton toggleButton = sender as ToggleButton;

            var news = toggleButton.DataContext as News;
            if (toggleButton.IsChecked == true)
            {


                news.QtyLike += 1;
                news.isLikeCurrentUser = true;

                LikeNewsUser likeNewsUser = new LikeNewsUser();
                likeNewsUser.IsLike = true;
                likeNewsUser.IDNews = news.ID;
                likeNewsUser.IDUser = GlobalParamClass.currentUser.ID;

                ApiHelperClass.postLike(likeNewsUser);

                var temp = news.LikeNewsUser.Where(i => i.IDUser == GlobalParamClass.currentUser.ID).FirstOrDefault();
                if (temp != null)
                {

                    temp.IsLike = true;
                }
                else
                {
                    news.LikeNewsUser.Add(likeNewsUser);
                }

                news.isLikeCurrentUser = true;
            }
            else
            {
                news.QtyLike -= 1;

                news.isLikeCurrentUser = false;
                LikeNewsUser likeNewsUser = new LikeNewsUser();
                likeNewsUser.IsLike = false;
                likeNewsUser.IDNews = news.ID;
                likeNewsUser.IDUser = GlobalParamClass.currentUser.ID;

                ApiHelperClass.postLike(likeNewsUser);

                var temp = news.LikeNewsUser.Where(i => i.IDUser == GlobalParamClass.currentUser.ID).FirstOrDefault();
                if (temp != null)
                {

                    temp.IsLike = false;
                }
                else
                {
                    news.LikeNewsUser.Add(likeNewsUser);
                }

                news.isLikeCurrentUser = false;
            }

        }



        //AddComment
        private void tbCommentInlvNews_KeyDown(object sender, KeyEventArgs e)
        {

            TextBox tb = sender as TextBox;
            if (e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(tb.Text) == false)
                {

                    var news = tb.DataContext as News;
                    NewsComment newsComment = new NewsComment();
                    newsComment.Comment = tb.Text;
                    newsComment.IDNews = news.ID;
                    newsComment.User = GlobalParamClass.currentUser;
                    newsComment.TimeSentComment = DateTime.Now;
                    newsComment.IDUser = GlobalParamClass.currentUser.ID;
                    newsComment.User = GlobalParamClass.currentUser;
                    news.AllComments.Add(newsComment);
                    news.QtyComment += 1;
                    ApiHelperClass.postNewsComment(newsComment);
                    tb.Text = "";
                }


            }


        }


        private void btnSendReviewWorkoutInSocial_Click(object sender, RoutedEventArgs e)
        {

            if (isChangeReviewWorkout == true)
            {
                workoutReaction.IDUser = GlobalParamClass.currentUser.ID;
                workoutReaction.User = GlobalParamClass.currentUser;
                workoutReaction.Rating = Convert.ToInt32(rbCreateReviewWorkoutInSocial.Value);
                workoutReaction.Review = tbCreateReviewWorokutInSOcial.Text;
                workoutReaction.TimeSent = DateTime.Now;

                int sumRating = 0;
                if (newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction.Count() != 0)
                {
                    foreach (WorkoutReaction rw in newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction)
                    {
                        sumRating += rw.Rating;
                    }
                    newsWhereChangeReviewWorkout.Workout.AvgRating = sumRating / newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction.Count();
                }
                else
                {

                    newsWhereChangeReviewWorkout.Workout.AvgRating = 0;

                }




                ApiHelperClass.putWorkoutReview(workoutReaction);
            }
            else
            {
                workoutReaction.IDUser = GlobalParamClass.currentUser.ID;
                workoutReaction.User = GlobalParamClass.currentUser;
                workoutReaction.Rating = Convert.ToInt32(rbCreateReviewWorkoutInSocial.Value);
                workoutReaction.Review = tbCreateReviewWorokutInSOcial.Text;
                workoutReaction.TimeSent = DateTime.Now;

                newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction.Add(workoutReaction);

                int sumRating = 0;
                if (newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction.Count() != 0)
                {
                    foreach (WorkoutReaction rw in newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction)
                    {
                        sumRating += rw.Rating;
                    }
                    newsWhereChangeReviewWorkout.Workout.AvgRating = sumRating / newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction.Count();
                }
                else
                {

                    newsWhereChangeReviewWorkout.Workout.AvgRating = 0;
                }





                ApiHelperClass.postWorkoutReview(workoutReaction);
            }

        }

        private void craeteReviewInSocial_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            newsWhereChangeReviewWorkout = btn.DataContext as News;
            if (newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser != null)
            {
                btnSendReviewWorkoutInSocial.Content = "Изменить";
                rbCreateReviewWorkoutInSocial.Value = newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser.Rating;
                tbCreateReviewWorokutInSOcial.Text = newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser.Review;
                isChangeReviewWorkout = true;
                workoutReaction = newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction.Where(i => i.IDUser == newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser.IDUser && i.IDWorkout == newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser.IDWorkout).FirstOrDefault();
                workoutReaction.IDWorkout = newsWhereChangeReviewWorkout.Workout.ID;


            }
            else
            {
                btnSendReviewWorkoutInSocial.Content = "Отправить";
                rbCreateReviewWorkoutInSocial.Value = 0;
                tbCreateReviewWorokutInSOcial.Text = "";
                isChangeReviewWorkout = false;
                workoutReaction.IDWorkout = newsWhereChangeReviewWorkout.Workout.ID;

            }

        }

        private void btnDeleteRivewWorkoutInSocial_Click(object sender, RoutedEventArgs e)
        {

            News newsInLv = GlobalParamClass.listNews.Where(i => i.ID == newsWhereChangeReviewWorkout.ID).FirstOrDefault();
            if (newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser != null)
            {
                ApiHelperClass.deleteWorkoutReview(newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser);

                newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction.Remove(newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser);
                newsInLv.Workout.AllWorkoutReaction.Remove(newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser);


                int sumRating = 0;
                if (newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction.Count() != 0)
                {
                    foreach (WorkoutReaction rw in newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction)
                    {
                        sumRating += rw.Rating;
                    }
                    newsWhereChangeReviewWorkout.Workout.AvgRating = sumRating / newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction.Count();
                    newsInLv.Workout.AvgRating = sumRating / newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction.Count();
                }
                else
                {

                    newsWhereChangeReviewWorkout.Workout.AvgRating = 0;
                    newsInLv.Workout.AvgRating = 0;
                }


            }
            else
            {
                MessageBox.Show("Вы не оставляли комментарий, что бы его удалить");
            }


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

        

        private void btnTrainterService_Click(object sender, RoutedEventArgs e)
        {
            TrainerWindow trainerWindow  = new TrainerWindow(userInProfile);
            trainerWindow.Show();
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && tbMessage.Text != "")
            {
                sentMessage(tbMessage.Text);
            }
        }

        private void btnSentImgInMessageTab_Click(object sender, RoutedEventArgs e)
        {
            sentMessage(tbMessage.Text);
        }

        public void sentMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message) == true)
            {
                return;
            }

            if (message.Contains(" "))
            {
                return;
            }

            ModelEF.Message newMsg = new ModelEF.Message();
            newMsg.Message1 = message;
            newMsg.IDUserGet = userInProfile.ID;
            newMsg.TimeSent = DateTime.Now;
            newMsg.IDUserSent = GlobalParamClass.currentUser.ID;
            ApiHelperClass.postMessage(newMsg);
            tbMessage.Text = "";
            pathImageMessage = null;

        }

        private void btnPickImgImgInMessageTab_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
            openFile.Multiselect = false;
            openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFile.ShowDialog() == true)
            {
                Image i = new Image();
                i.Source = new BitmapImage(new Uri(openFile.FileName));
                pathImageMessage = openFile.FileName;


                ModelEF.Message newMsg = new ModelEF.Message();
                newMsg.Message1 = "Image";
                newMsg.IDUserGet = userInProfile.ID;
                newMsg.TimeSent = DateTime.Now;
                newMsg.IDUserSent = GlobalParamClass.currentUser.ID;
                if (pathImageMessage != null)
                {
                    newMsg.Image = File.ReadAllBytes(pathImageMessage);
                }

                ApiHelperClass.postMessage(newMsg);
                pathImageMessage = null;

            }
        }
    }
}
