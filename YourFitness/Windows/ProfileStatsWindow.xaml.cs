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
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.Measure;
using System.Windows.Markup;

namespace YourFitness.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProfileStatsWindow.xaml
    /// </summary>
    /// 

    public class ViewModel
    {

        public ISeries[] SeriesWeak { get; set; } =
        {
            new ColumnSeries<double>
            {
                Name = "Количество часов",
                DataLabelsSize = 20,
                Stroke = null,
                Fill = new SolidColorPaint(new SKColor(255, 132, 75, 80)),
                Values = new double[] { 1,0,2, 0, 2 ,1,0},
                IgnoresBarPosition = true
            },

           

        };

        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Labels = new string[] { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" },
                LabelsRotation = 5
            }
        };

        public ViewModel()
        {

            SeriesMuscle = new ISeries[]
            {
                 new PieSeries<double> { Values = new double[] { 10 }, Name = "Спина" ,TooltipLabelFormatter = point => "10 Часов"},
                 new PieSeries<double> { Values = new double[] { 5 }, Name = "Грудь" ,TooltipLabelFormatter = point => $"5 Часов"},
                 new PieSeries<double> { Values = new double[] { 3 }, Name = "Плечи" ,TooltipLabelFormatter = point => $"3 Часа"},
                 new PieSeries<double> { Values = new double[] { 4 }, Name = "Руки"  ,TooltipLabelFormatter = point => $"4 Часв"},
                 new PieSeries<double> { Values = new double[] { 6 }, Name = "Ноги" ,TooltipLabelFormatter = point => $"6 Часов"}
            };


        }

        public IEnumerable<ISeries> SeriesMuscle { get; set; }
    }



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
