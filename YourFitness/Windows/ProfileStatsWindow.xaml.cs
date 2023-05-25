using HandyControl.Controls;
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
using System.Windows.Shapes;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using YourFitness.ClassHelper;
using static YourFitness.ClassHelper.ModelEF;
using System.Collections.ObjectModel;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YourFitness.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProfileStatsWindow.xaml
    /// </summary>
    /// 

   



    public partial class ProfileStatsWindow 
    {
        string pathPhotoFontImg;
        string pathPhotoBackImg;
        string pathPhotoSideImg;
        public ProfileStatsWindow()
        {
            InitializeComponent();
            lvHistoryChange.ItemsSource = new ObservableCollection<HistoryChange>(GlobalParamClass.currentUser.HistoryChangeCurrentUser);
            dpDateChange.SelectedDate = DateTime.Today;

        }
       

        private void btnPickFontImg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                Image i = new Image();
                i.Source = new BitmapImage(new Uri(openFile.FileName));
                pathPhotoFontImg = openFile.FileName;
                fontBodyImg.Source = i.Source;

            }
        }

        private void btnPickBackImg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                Image i = new Image();
                i.Source = new BitmapImage(new Uri(openFile.FileName));
                pathPhotoBackImg = openFile.FileName;
                BackBodyImg.Source = i.Source;

            }
        }

        private void btnPickSideImg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                Image i = new Image();
                i.Source = new BitmapImage(new Uri(openFile.FileName));
                pathPhotoSideImg = openFile.FileName;
                SideBodyImg.Source = i.Source;

            }
        }



        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ModelEF.HistoryChange newHistoryChangeUser = new ModelEF.HistoryChange();
            newHistoryChangeUser.IDUser = GlobalParamClass.currentUser.ID;
            if (dpDateChange.SelectedDate == null)
            {
                HandyControl.Controls.MessageBox.Show("Выберите дату");
                return;
            }
            if (int.TryParse(tbWeitght.Text, out int i) != true)
            {

                HandyControl.Controls.MessageBox.Show("Введите число в поле вес");
                return;
            }
            if (int.TryParse(tbHeight.Text, out int a) != true)
            {

                HandyControl.Controls.MessageBox.Show("Введите число в поле рост");
                return;
            }

            if (ValidationClass.validationWeighAndHeight(Convert.ToInt32(tbWeitght.Text)) is false)
            {
                HandyControl.Controls.MessageBox.Show("Некорректный вес");
                return;
            }
            if (ValidationClass.validationWeighAndHeight(Convert.ToInt32(tbHeight.Text)) is false)
            {
                HandyControl.Controls.MessageBox.Show("Некорректный рост");
                return;
            }

            newHistoryChangeUser.NewWeitght = Convert.ToInt32(tbWeitght.Text);
            newHistoryChangeUser.NewHeight = Convert.ToInt32(tbHeight.Text);
            newHistoryChangeUser.DataChange = (DateTime)dpDateChange.SelectedDate;

            if (pathPhotoFontImg != null)
            {
                newHistoryChangeUser.ImageFront = File.ReadAllBytes(pathPhotoFontImg);
            }
            if (pathPhotoBackImg != null)
            {
                newHistoryChangeUser.ImageBack = File.ReadAllBytes(pathPhotoBackImg);
            }
            if (pathPhotoSideImg != null)
            {
                newHistoryChangeUser.ImageSide = File.ReadAllBytes(pathPhotoSideImg);
            }
            GlobalParamClass.currentUser.HistoryChangeCurrentUser.Add(newHistoryChangeUser); 
            lvHistoryChange.ItemsSource = new ObservableCollection<HistoryChange>(GlobalParamClass.currentUser.HistoryChangeCurrentUser);
            ApiHelperClass.postHistoryChange(newHistoryChangeUser);
            dialogHost.IsOpen = false;
            tbHeight.Text = "";
            tbWeitght.Text = "";
            pathPhotoFontImg = null;
            pathPhotoBackImg = null;
            pathPhotoSideImg = null;
            SideBodyImg.Source = new BitmapImage(new Uri(@"/Res/SideMan.png", UriKind.Relative));
            BackBodyImg.Source = new BitmapImage(new Uri(@"/Res/BackMan.png", UriKind.Relative));
            fontBodyImg.Source = new BitmapImage(new Uri(@"/Res/FrontMan.png", UriKind.Relative));

        }


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
    }
}
