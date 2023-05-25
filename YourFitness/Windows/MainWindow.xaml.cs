
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Windows.Shapes;
using System.Xml.Linq;
using YourFitness.ClassHelper;
using YourFitness.Pages;
using static YourFitness.ClassHelper.ModelEF;

namespace YourFitness.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        string pathToImageNews = null;
        List<User> newUserList;
        List<User> oldUserList;
        List<News> oldNewsInSocialList;
        string pathImageMessage = null;
        int idUserGetMessage = 0 ;
        List<Message> listMessage = new List<Message>();
        News news = new News();
        WorkoutReaction workoutReaction = new WorkoutReaction();
        News newsWhereChangeReviewWorkout = null;
        bool isChangeReviewWorkout=false;

        ObservableCollection<News> listNews = new ObservableCollection<News>(GlobalParamClass.listNews);
        ObservableCollection<News> listNewsInProfile = new ObservableCollection<News>(GlobalParamClass.listNews);






        public MainWindow()
        {

            InitializeComponent();
            GlobalParamClass.listHistoryWorkoutUser = ApiHelperClass.getHistoryWorkoutUser(GlobalParamClass.currentUser.ID);
            if (GlobalParamClass.listHistoryWorkoutUser != null)
            {

                lvHistoryWorkoutUser.ItemsSource = GlobalParamClass.listHistoryWorkoutUser.TakeLast(5);
            }
            GlobalParamClass.listWorkoutLiked = new ObservableCollection<Workout>(GlobalParamClass.listWorkout.Where(i => i.isLikeCurrentUser == true)); 

            cvLikeTrain.ItemsSource = GlobalParamClass.listWorkoutLiked;
           
            newUserList = GlobalParamClass.listUser;
            newUserList.RemoveAll(r => r.ID == GlobalParamClass.currentUser.ID);

            lvUserInSocial.ItemsSource = newUserList;

            lvNewsInSocial.ItemsSource = null;
            lvNewsInSocial.ItemsSource = listNews;

            listNewsInProfile = new ObservableCollection<News> (listNews.Where(i => i.IDUser == GlobalParamClass.currentUser.ID).ToList());
            lvNewsInProfile.ItemsSource = listNewsInProfile;

            GlobalParamClass.userFrame = userFrame;

            updateProfilePage(GlobalParamClass.currentUser);
            frameListWorkout.Navigate(new Pages.PageListWorkout());


        }

        public void refreshListViewUserInSocialTab()
        {
            try
            {
                ApiHelperClass.updateAllUser();
                newUserList = GlobalParamClass.listUser;
                newUserList.RemoveAll(r => r.ID == GlobalParamClass.currentUser.ID);

                if (JsonConvert.SerializeObject(newUserList) != JsonConvert.SerializeObject(oldUserList))
                {
                    Dispatcher.Invoke((Action)(() =>
                    {

                        lvUserInSocial.ItemsSource = newUserList;
                    }));
                    oldUserList = newUserList;
                }
            }
            catch
            {

            }
        }


        public void refreshListViewNewsInSocialTab()
        {

            ApiHelperClass.getNewsNonAsync();
            if (JsonConvert.SerializeObject(GlobalParamClass.listNews) != JsonConvert.SerializeObject(oldNewsInSocialList))
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    lvNewsInSocial.ItemsSource = null;
                    listNews = new ObservableCollection<News>(GlobalParamClass.listNews);
                    lvNewsInSocial.ItemsSource = listNews;
                }));
                oldNewsInSocialList = GlobalParamClass.listNews;
            }



        }



        public void refreshListViewNewsInProfileTab()
        {
            try
            {

                //ApiHelperClass.getNewsNonAsync();
                //List<News> newsCurrentUser = GlobalParamClass.listNews.Where(i => i.IDUser == GlobalParamClass.currentUser.ID).ToList();
               
                //    Dispatcher.Invoke((Action)(() =>
                //    {

                //        listNews = new ObservableCollection<News>(newsCurrentUser);
                //        lvNewsInProfile.ItemsSource = null;
                //        lvNewsInProfile.ItemsSource = listNews;
                //    }));
              

               

            }
            catch
            {

            }


        }

        private void updateProfilePage(User user)
        {
            if (user.IDRole == 2)
            {
                btnTrainterService.Height = 40;
                btnTrainterService.IsEnabled = true;
            }

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
                    photoImageProfile.ImageSource = i.Source;
                    imgEditProfileImg.Source = i.Source;
                    gravatarInProfileTab.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                gravatarInProfileTab.Visibility = Visibility.Visible;
            }
            tboxFnameChangeInProfileTab.Text = user.FirstName;
            tboxSurNameChangeInProfileTab.Text = user.SecondName;
            tboxDescriptionChangeInProfileTab.Text = user.Description;
            tbDescription.Text = user.Description;
            tbFnameInProfileTab.Text = user.FirstName;
            tbSurNameInProfileTab.Text = user.SecondName;
            gravatarEditProfileImg.Id = user.Login;
            gravatarInProfileTab.Id = user.Login;
            tbWeightInProfileTab.Text = user.Weitght.ToString();
            tbHeightInProfileTab.Text = user.Height.ToString();
            tbAgeInProfileTab.Text = (DateTime.Now.Year - user.Birthday.Year).ToString();
        }




        private void btnMoreInfo_Click(object sender, RoutedEventArgs e)
        {

            ApiHelperClass.getStatsMuscle();
            ApiHelperClass.getStatsWorkout();
            ProfileStatsWindow profileStatsWindow = new ProfileStatsWindow();
            profileStatsWindow.Show();

        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag.ToString() == "social")
            {
                Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
                openFile.Multiselect = false;
                openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (openFile.ShowDialog() == true)
                {
                    Image i = new Image();
                    i.Source = new BitmapImage(new Uri(openFile.FileName));
                    imgPostNewsInSocial.Source = i.Source;
                }
                pathToImageNews = openFile.FileName;
                borderImageAddPostNews.Height = 300;

            }
            else
            {
                Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
                openFile.Multiselect = false;
                openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (openFile.ShowDialog() == true)
                {
                    Image i = new Image();
                    i.Source = new BitmapImage(new Uri(openFile.FileName));
                    imgCreateNewsInProfileTab.Source = i.Source;
                }
                pathToImageNews = openFile.FileName;
                borderImageAddPost.Height = 300;
            }

        }

        private void btnAddWorkout_Click(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;


            if (news.IDWorkout == null)
            {
                if (btn.Tag.ToString() == "social")
                {
                    ListWorkoutSearchWindow listWorkoutSearchWindow = new ListWorkoutSearchWindow();
                    listWorkoutSearchWindow.ShowDialog();
                    if (GlobalParamClass.PickedWorkout != null)
                    {

                        tbNameWorkoutInSocial.Text = GlobalParamClass.PickedWorkout.Name.ToString();
                        borderWorkoutAddPostNews.Height = 45;
                    }

                }
                else
                {
                    ListWorkoutSearchWindow listWorkoutSearchWindow = new ListWorkoutSearchWindow();
                    listWorkoutSearchWindow.ShowDialog();
                    if (GlobalParamClass.PickedWorkout != null)
                    {
                        tbNameWorkoutInProfile.Text = GlobalParamClass.PickedWorkout.Name.ToString();
                        borderWorkoutAddPost.Height = 45;
                    }
                }

            }
            else 
            {
                HandyControl.Controls.MessageBox.Show("Вы уже добавили тренировку");
            }
           

        }

        private void btnImageDalete_Click(object sender, RoutedEventArgs e)
        {
            imgCreateNewsInProfileTab.Source = null;
            imgPostNewsInSocial.Source = null;
            pathToImageNews = null;
            borderImageAddPost.Height = 0;
            borderImageAddPostNews.Height = 0;
        }

        private void btnDeleteWorkout_Click(object sender, RoutedEventArgs e)
        {
            GlobalParamClass.PickedWorkout = null;
            borderWorkoutAddPost.Height = 0;
            borderWorkoutAddPostNews.Height = 0;
        }
        private void rightBorderInSocialTab_MouseLeave(object sender, MouseEventArgs e)
        {

            expanderInSocialTab.IsExpanded = false;
        }

        private async void tbSearchInSocialTab_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            await Task.Run(() => refreshListViewUserInSocialTab());
            expanderInSocialTab.IsExpanded = true;
        }

        private async void tbSearchInSocialTab_TextChanged(object sender, TextChangedEventArgs e)
        {
            await Task.Run(() => refreshListViewUserInSocialTab());
            expanderInSocialTab.IsExpanded = true;
        }

      

      

        private void btnStartWorkout_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var workout = button.DataContext as ModelEF.Workout;
            WorkoutWindow workoutWindow = new WorkoutWindow(workout);
            workoutWindow.ShowDialog();
            lvHistoryWorkoutUser.ItemsSource = GlobalParamClass.listHistoryWorkoutUser.TakeLast(5);
            lvHistoryWorkoutUser.Items.Refresh();
        }




        private void btnSaveChangeInProfileTab_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationClass.validationFIO(tboxFnameChangeInProfileTab.Text) is false)
            {
                HandyControl.Controls.MessageBox.Show("Некорректное имя");
                return;
            }
            if (ValidationClass.validationFIO(tboxSurNameChangeInProfileTab.Text) is false)
            {
                HandyControl.Controls.MessageBox.Show("Некорректная фамилия");
                return;
            }

            if (imgSeelctorEditProfileImg.Uri != null)
            {
                GlobalParamClass.currentUser.ImageProfile = File.ReadAllBytes(imgSeelctorEditProfileImg.Uri.LocalPath);
            }
            GlobalParamClass.currentUser.FirstName = tboxFnameChangeInProfileTab.Text;
            GlobalParamClass.currentUser.SecondName = tboxSurNameChangeInProfileTab.Text;
            GlobalParamClass.currentUser.Description = tboxDescriptionChangeInProfileTab.Text;

            ApiHelperClass.putUser(GlobalParamClass.currentUser);
            updateProfilePage(GlobalParamClass.currentUser);
            trChangerUserInProfileTab.SelectedIndex = 0;
        }


        //News
        private void btnSaveNews_Click(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;

            if (btn.Tag.ToString() == "social")
            {
                if (tboxCreatePostInSocialTab.Text == "")
                {
                    HandyControl.Controls.MessageBox.Show("Введите текст новости");
                    return;
                }

                news.Description = tboxCreatePostInSocialTab.Text;
            }
            else
            {
                if (tboxCreatePostInProfileTab.Text == "")
                {
                    HandyControl.Controls.MessageBox.Show("Введите текст новости");
                    return;
                }

                news.Description = tboxCreatePostInProfileTab.Text;
            }

            if (GlobalParamClass.PickedWorkout != null)
            {
                news.IDWorkout = GlobalParamClass.PickedWorkout.ID;
                news.Workout = GlobalParamClass.PickedWorkout;
            }

            if (pathToImageNews is not null)
            {
                news.image = File.ReadAllBytes(pathToImageNews);
            }

            news.User = GlobalParamClass.currentUser;
            news.IDUser = GlobalParamClass.currentUser.ID;
            news.timeCreate = DateTime.Now;
            news.LikeNewsUser = new List<LikeNewsUser>();

            ApiHelperClass.postNews(news);
            news.AllComments = new ObservableCollection<NewsComment>();

            GlobalParamClass.listNews.Add(news);

            listNews.Add(news);
            listNewsInProfile.Add(news);

            if (btn.Tag.ToString() == "social")
            {
                tboxCreatePostInSocialTab.Text = "";
                pathToImageNews = null;
                dialogHostPostInSocial.IsOpen = false;
                borderWorkoutAddPostNews.Height = 0;
            }
            else
            {
                tboxCreatePostInProfileTab.Text = "";
                pathToImageNews = null;
                dialogHostPost.IsOpen = false;
                borderWorkoutAddPost.Height = 0;
            }

            GlobalParamClass.PickedWorkout = null;
            news = new News();
            HandyControl.Controls.MessageBox.Show("Успешно!");


            ApiHelperClass.getNewsNonAsync();
        }
        



        private void btnAddPost_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag.ToString() == "social")
            {
                dialogHostPostInSocial.IsOpen = true;
            }
            else
            {

                dialogHostPost.IsOpen = true;
            }
        }


        //Like
        private void toggleLikeInLvNewsSocial_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = sender as ToggleButton;
            var news = toggleButton.DataContext as News;
            if (toggleButton.IsChecked == true)
            {
                news.QtyLike += 1;
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
                    //var tempNews = GlobalParamClass.listNews.Where(i => i.ID == news.ID).FirstOrDefault();
                    //tempNews.AllComments.Add(newsComment);
                    //tempNews.QtyComment += 1;

                    ApiHelperClass.postNewsComment(newsComment);

                    GlobalParamClass.listNews.Add(news);

                    //listNews.Add(news);
                    //listNewsInProfile.Add(news);
                    tb.Text = "";
                }


            }


        }





        private async void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string content = (sender as Label).Content as string;
            switch (content)
            {
                case "Сообщество":
                    //await Task.Run(() => refreshListViewNewsInSocialTab());
                    listNews = new ObservableCollection<News>(GlobalParamClass.listNews);
                    break;

                case "Профиль":
                    //listNewsInProfile = new ObservableCollection<News>(GlobalParamClass.listNews.Where(i => i.IDUser == GlobalParamClass.currentUser.ID).ToList());

                    break;
                case "Личные сообщения":

                    var listUser = ApiHelperClass.getUserListWithMessage(GlobalParamClass.currentUser.ID);
                    lvUserListInMessageTab.ItemsSource = listUser;
                   
                    refreshMessage();
                    

                    break;

                default:
                    return;
            }
        }

        public async void refreshMessage()
        {
            await Task.Run(() => Thread.Sleep(2000));
            while (tabControlInMainWindow.SelectedIndex == 5)
            {
                await Task.Run(() => refreshMessageList());
                await Task.Run(() => Thread.Sleep(1000));
            }
        }

        public void refreshMessageList()
        {
            try
            {
                var tempList = ApiHelperClass.getMessageList(idUserGetMessage, listMessage.Count());
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


        //ReviewWorkout
        private void btnSendReviewWorkoutInSocial_Click(object sender, RoutedEventArgs e)
        {
            if (rbCreateReviewWorkout.Value == 0)
            {
                HandyControl.Controls.MessageBox.Show("Выберите рейтинг");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbCreateReviewWorokut.Text) == true)
            {
                HandyControl.Controls.MessageBox.Show("Оставьте отзыв");
                return;
            }
            if (dialogHostReviewWorkout.IsOpen == false)
            {
                return;
            }
            workoutReaction.IDUser = GlobalParamClass.currentUser.ID;
            workoutReaction.User = GlobalParamClass.currentUser;
            workoutReaction.Rating = Convert.ToInt32(rbCreateReviewWorkout.Value);
            workoutReaction.Review = tbCreateReviewWorokut.Text;
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

            if (isChangeReviewWorkout == true)
            {
                ApiHelperClass.putWorkoutReview(workoutReaction);
            }
            else
            {
                ApiHelperClass.postWorkoutReview(workoutReaction);
            }
            dialogHostReviewWorkout.IsOpen = false;
        }

        private void craeteReviewInSocial_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            dialogHostReviewWorkout.IsOpen = true;

            if (btn.Tag.ToString() == "news")
            {
                newsWhereChangeReviewWorkout = btn.DataContext as News;
            }

            else 
            {
                newsWhereChangeReviewWorkout = new News();
                newsWhereChangeReviewWorkout.Workout = btn.DataContext as Workout;
            }


            if (newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser != null)
            {
                btnSendReviewWorkout.Content = "Изменить";
                rbCreateReviewWorkout.Value = newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser.Rating;
                tbCreateReviewWorokut.Text = newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser.Review;
                isChangeReviewWorkout = true;
                workoutReaction = newsWhereChangeReviewWorkout.Workout.AllWorkoutReaction.Where(i => i.IDUser == newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser.IDUser && i.IDWorkout == newsWhereChangeReviewWorkout.Workout.WorkoutReactionCurrentUser.IDWorkout).FirstOrDefault();
                workoutReaction.IDWorkout = newsWhereChangeReviewWorkout.Workout.ID;
               
              
            }
            else 
            {
                btnSendReviewWorkout.Content = "Отправить";
                rbCreateReviewWorkout.Value = 0;
                tbCreateReviewWorokut.Text = "";
                isChangeReviewWorkout = false;
                workoutReaction.IDWorkout = newsWhereChangeReviewWorkout.Workout.ID;

            }

        }

        private void btnDeleteRivewWorkoutInSocial_Click(object sender, RoutedEventArgs e)
        {

            News newsInLv = GlobalParamClass.listNews.Where(i => i.ID == newsWhereChangeReviewWorkout.ID).FirstOrDefault();
            Workout workout = newsWhereChangeReviewWorkout.Workout;
            if (newsInLv != null)
            {
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
                    HandyControl.Controls.MessageBox.Show("Вы не оставляли комментарий, что бы его удалить");
                }
            }
            else
            {
                if (workout.WorkoutReactionCurrentUser != null)
                {

                    ApiHelperClass.deleteWorkoutReview(workout.WorkoutReactionCurrentUser);
                    workout.AllWorkoutReaction.Remove(workout.WorkoutReactionCurrentUser);

                    int sumRating = 0;
                    if (workout.AllWorkoutReaction.Count() != 0)
                    {
                        foreach (WorkoutReaction rw in workout.AllWorkoutReaction)
                        {
                            sumRating += rw.Rating;
                        }
                        workout.AvgRating = sumRating / workout.AllWorkoutReaction.Count();
                    }
                    else
                    {

                        workout.AvgRating = 0;
                    }
                }
                else
                {
                    HandyControl.Controls.MessageBox.Show("Вы не оставляли комментарий, что бы его удалить");
                }

                  
            }
           


        }

        private void spBorderUser_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {


            StackPanel sp = sender as StackPanel;
            User dataContext = sp.DataContext as User;

            userFrame.Navigate(new Pages.ProfilePage(dataContext, new ObservableCollection<News>(GlobalParamClass.listNews.Where(i => i.IDUser == dataContext.ID).ToList())));

        }



        public void filter()
        {
            // ApiHelperClass.getNewsNonAsync();


            var filterListNews = GlobalParamClass.listNews;
            bool rbSwitchNewsReactionState = false, toggleFirstlyIntrerestState = false, toggleFilterOnlyTrainState = false;

            Dispatcher.Invoke((Action)(() =>
            {
                rbSwitchNewsReactionState = (bool)rbSwitchNewsReaction.IsChecked;
                toggleFirstlyIntrerestState = (bool)toggleFirstlyIntrerest.IsChecked;
                toggleFilterOnlyTrainState = (bool)toggleFilterOnlyTrain.IsChecked;
            }));


            if (rbSwitchNewsReactionState == false)
            {
                filterListNews = filterListNews.Where(i => i.isLikeCurrentUser == true).ToList();
            }

            if (toggleFirstlyIntrerestState == true)
            {

                filterListNews = filterListNews.OrderByDescending(i => i.QtyComment).ToList();


            }
            if (toggleFilterOnlyTrainState == true)
            {
                filterListNews = filterListNews.Where(i => i.IDWorkout != null).ToList();
            }


            Dispatcher.Invoke((Action)(() =>
            {
                listNews = new ObservableCollection<News>(filterListNews);
                lvNewsInSocial.ItemsSource = listNews;
            }));




        }

        public void filterForWorkout()
        {

            List<Workout> filterListWorkout = GlobalParamClass.listWorkout.Where(i => i.isLikeCurrentUser == true).ToList();
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
                GlobalParamClass.listWorkoutLiked = new ObservableCollection<Workout>(filterListWorkout);
                cvLikeTrain.ItemsSource = GlobalParamClass.listWorkoutLiked;
            }));




        }



        private async void rbSwitchNewsReaction_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => filter()); 
            
        }

        private async void toggleFirstlyIntrerest_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => filter());
        }

        private void piDeleteFromFavorite_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            PackIcon pi = sender as PackIcon;
            Workout dataContext = pi.DataContext as Workout;
            if (HandyControl.Controls.MessageBox.Show("Удалить тренировку из понравившегося?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
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

        private void tbSearchLikedWorkout_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tabControlInMainWindow.SelectedIndex == 2)
            {

                filterForWorkout();
            }
        }

        private void cbSortLikedWorkout_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControlInMainWindow.SelectedIndex == 2)
            {

                filterForWorkout();
            }
        }

        ///SENT MESSAGE METHODS///
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
            if (idUserGetMessage == 0)
            {
                HandyControl.Controls.MessageBox.Show("Выберите кому отправить сообщение");
                return;
            }

            if (string.IsNullOrWhiteSpace(message) == true)
            {
                return;
            }

         

            ModelEF.Message newMsg = new ModelEF.Message();
            newMsg.Message1 = message;
            newMsg.IDUserGet = idUserGetMessage;
            newMsg.TimeSent = DateTime.Now;
            newMsg.IDUserSent = GlobalParamClass.currentUser.ID;
            ApiHelperClass.postMessage(newMsg);
            tbMessage.Text = "";
            pathImageMessage = null;

        }

        private void btnPickImgImgInMessageTab_Click(object sender, RoutedEventArgs e)
        {
            if (idUserGetMessage == 0)
            {
                return;
            }

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
                newMsg.IDUserGet = idUserGetMessage;
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

        private void lvUserListInMessageTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var item = e.AddedItems[0] as User;
                tbFsUser.Visibility = Visibility.Visible;
                tbDesriptionInMessageTab.Visibility = Visibility.Visible;
                tbFsUser.Text = item.FIO;
                tbDesriptionInMessageTab.Text = item.Description;

                if (item.ImageProfile != null)
                {

                    using (MemoryStream stream = new MemoryStream(item.ImageProfile))
                    {
                        Image i = new Image();
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                        bitmapImage.StreamSource = stream;
                        bitmapImage.EndInit();
                        i.Source = bitmapImage;
                       photoImageUserInmessageTab.ImageSource = i.Source;
                        gvProfileImgInMessageTab.Visibility = Visibility.Hidden;
                    }
                }
                else
                {

                    photoImageUserInmessageTab.ImageSource = null;
                   gvProfileImgInMessageTab.Id = item.Login;
                    gvProfileImgInMessageTab.Visibility = Visibility.Visible;
                }

                idUserGetMessage = item.ID;
            }
            else 
            {
                tbFsUser.Visibility = Visibility.Hidden;
                tbDesriptionInMessageTab.Visibility = Visibility.Hidden;
                gvProfileImgInMessageTab.Visibility = Visibility.Visible;
                idUserGetMessage = 0;
            }



        }



        //////////Window Title Bar////////////
         private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

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

        private void dialogHostReviewWorkout_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                dialogHostReviewWorkout.IsOpen = false;
                
            }
        }

        private void btnTrainterService_Click(object sender, RoutedEventArgs e)
        {
            TrainerWindow trainerWindow = new TrainerWindow(GlobalParamClass.currentUser);
            trainerWindow.Show();
        }

        private void btnOptionNews_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string contentBtn = btn.Content.ToString();
            if (contentBtn == "Удалить")
            {
                var context = btn.DataContext as News;

                ApiHelperClass.deleteNews(context);
                if (oldNewsInSocialList != null)
                {
                    oldNewsInSocialList.Remove(context);

                }
                if (listNews != null)
                {
                    listNews.Remove(context);

                }
                if (listNewsInProfile != null)
                {
                    listNewsInProfile.Remove(context);

                }
            }
           

        }
    }
}
