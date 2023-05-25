
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace YourFitness.Windows
{
    /// <summary>
    /// Логика взаимодействия для TrainerWindow.xaml
    /// </summary>
    public partial class TrainerWindow : Window
    {

        List<ModelEF.Service> listService = new List<ModelEF.Service>();
        ObservableCollection<ModelEF.Service> newListService = new ObservableCollection<ModelEF.Service>();
        ObservableCollection<ModelEF.ReviewUserTrainer> listReviewTrainer = new ObservableCollection<ModelEF.ReviewUserTrainer>();
        int idUser;

        ModelEF.ReviewUserTrainer reviewUserTrainer = new ReviewUserTrainer();
        bool isChangeReviewTrainer = true;
        public TrainerWindow(ModelEF.User user)
        {
            InitializeComponent();
            idUser = user.ID;
            newListService = new ObservableCollection<ModelEF.Service>(ApiHelperClass.getListService(user.ID));
            listService = ApiHelperClass.getListService(user.ID);
            if (user.ID == GlobalParamClass.currentUser.ID)
            {

                btnChange.Height = 50;
                btnChange.IsEnabled = true;

                lvServiceCreate.ItemsSource = newListService;
                btnCreateReview.Visibility = Visibility.Hidden;
            }
            else
            {
                btnCreateReview.Height = 33;
                btnCreateReview.IsEnabled = true;
            }

            listReviewTrainer = new ObservableCollection<ModelEF.ReviewUserTrainer>(ApiHelperClass.getListTrainerReview(user.ID));
            if (listReviewTrainer.Count != 0)
            {
                int sumRating = 0;
                foreach (ModelEF.ReviewUserTrainer rw in listReviewTrainer)
                {
                    sumRating += rw.Rating;
                }
                sumRating = sumRating / listReviewTrainer.Count;


                lvReaction.ItemsSource = listReviewTrainer;
                rbAvgRating.Value = sumRating;
            }
            else
            {
                rbAvgRating.Value = 0;
            }

            lvService.ItemsSource = listService;
            tbDescriptionTrainer.Text = user.DescriptionTrainer;
            tbDescription.Text = user.DescriptionTrainer;

        }

        private void addService_Click(object sender, RoutedEventArgs e)
        {

            newListService.Add(new ModelEF.Service { Name = "", Description = "", Price = 0, });

        }

       
       

        private void btnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            if (HandyControl.Controls.MessageBox.Show("Удалить услугу ?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Button btn = sender as Button;
                var item = btn.DataContext as ModelEF.Service;

                ApiHelperClass.deleteService(item.ID);
                newListService.Remove(item);
                var item2 = listService.Where(i => i.ID == item.ID).FirstOrDefault();
                listService.Remove(item2); 
            }
            {
                return;
            }
            

        }

        private void btnCancelChange_Click(object sender, RoutedEventArgs e)
        {
            newListService = new ObservableCollection<ModelEF.Service>(listService);
            lvServiceCreate.ItemsSource = newListService;
            lvServiceCreate.Items.Refresh();
        }

        private void btnSaveChange_Click(object sender, RoutedEventArgs e)
        {
            if (tbDescription.Text != GlobalParamClass.currentUser.DescriptionTrainer)
            {
                GlobalParamClass.currentUser.DescriptionTrainer = tbDescription.Text;
                ApiHelperClass.putUser(GlobalParamClass.currentUser);
            }
            foreach(ModelEF.Service service in newListService)
            {
                int index = newListService.IndexOf(service);
                if (service.Price <= 0)
                {
                    HandyControl.Controls.MessageBox.Show($"Некорректная цена {index} услуги");
                }

                if (string.IsNullOrWhiteSpace(service.Name) == true)
                {
                    MessageBox.Show($"Некорректное название {index +1 } услуги");
                    return;
                }
                if (string.IsNullOrWhiteSpace(service.Description) == true)
                {
                    HandyControl.Controls.MessageBox.Show($"Некорректное описание {index +1 } услуги");
                    return;
                }

                if (index < listService.Count)
                {
                    if (System.Text.Json.JsonSerializer.Serialize(service) != System.Text.Json.JsonSerializer.Serialize(listService[index]))
                    {
                        ApiHelperClass.putService(service);
                    }
                }

            }
            if (newListService.Count != listService.Count)
            {
                int qtyService = newListService.Count - listService.Count;
                while (newListService.Count != listService.Count)
                {
                    var i = newListService[listService.Count ];
                    i.IDUser = GlobalParamClass.currentUser.ID;
                    ApiHelperClass.postService(i);
                    listService.Add(i);
                }
            }
            listService = ApiHelperClass.getListService(idUser);
            lvService.ItemsSource = listService;
            lvService.Items.Refresh();
            trTrainer.SelectedIndex = 0;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateReview_Click(object sender, RoutedEventArgs e)
        {
            var reviewCurrentUser = listReviewTrainer.Where(i => i.IDUserReview == GlobalParamClass.currentUser.ID).FirstOrDefault();
            if (reviewCurrentUser != null)
            {
                reviewUserTrainer = reviewCurrentUser;
                btnSent.Content = "Изменить";
                rbReview.Value = reviewCurrentUser.Rating;
                tbReview.Text = reviewCurrentUser.Review;
                isChangeReviewTrainer = true;


            }
            else
            {
                btnSent.Content = "Отправить";
                rbReview.Value = 0;
                tbReview.Text = "";
                isChangeReviewTrainer = false;

            }
        }

        private void btnSent_Click(object sender, RoutedEventArgs e)
        {
            if (rbReview.Value == 0)
            {
                HandyControl.Controls.MessageBox.Show("Выберите рейтинг");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbReview.Text) == true)
            {
                HandyControl.Controls.MessageBox.Show("Оставьте отзыв");
                return;
            }

            reviewUserTrainer.IDUserReview = GlobalParamClass.currentUser.ID;
            reviewUserTrainer.IDUserTrainer = idUser;
            reviewUserTrainer.Rating = Convert.ToInt32(rbReview.Value);
            reviewUserTrainer.Review = tbReview.Text;

            reviewUserTrainer.User1 = GlobalParamClass.currentUser;

            int sumRating = 0;
            if (listReviewTrainer.Count() != 0)
            {
                foreach (ModelEF.ReviewUserTrainer rw in listReviewTrainer)
                {
                    sumRating += rw.Rating;
                }
                sumRating = sumRating / listReviewTrainer.Count;


                lvReaction.ItemsSource = listReviewTrainer;
                rbAvgRating.Value = sumRating;
            }
            else
            {

                rbAvgRating.Value = 0;
            }



            if (isChangeReviewTrainer == true)
            {
                ApiHelperClass.putTrainerReview(reviewUserTrainer);
            }
            else
            {

                listReviewTrainer.Add(reviewUserTrainer);
                ApiHelperClass.postTrainerReviewe(reviewUserTrainer);
            }
        }

        private void dtnDelete_Click(object sender, RoutedEventArgs e)
        {

            var reviewCurrentUser = listReviewTrainer.Where(i => i.IDUserReview == GlobalParamClass.currentUser.ID).FirstOrDefault();
            if (reviewCurrentUser != null)
            {

                ApiHelperClass.deleteTrainerReview(reviewCurrentUser);
                listReviewTrainer.Remove(reviewCurrentUser);

                int sumRating = 0;
                if (listReviewTrainer.Count() != 0)
                {
                    foreach (ModelEF.ReviewUserTrainer rw in listReviewTrainer)
                    {
                        sumRating += rw.Rating;
                    }
                    sumRating = sumRating / listReviewTrainer.Count;


                    lvReaction.ItemsSource = listReviewTrainer;
                    rbAvgRating.Value = sumRating;
                }
                else
                {

                    rbAvgRating.Value = 0;
                }
            }
            else
            {
                HandyControl.Controls.MessageBox.Show("Вы не оставляли комментарий, что бы его удалить");
            }
        }
    }
}
