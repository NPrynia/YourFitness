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
    }
}
