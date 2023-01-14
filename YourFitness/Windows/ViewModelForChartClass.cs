using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourFitness.Windows
{

    public class ViewModelForProfileStats
    {
        public ISeries[] SeriesWeak { get; set; } =
        {
            new ColumnSeries<double>
            {
                Name = "Количество часов",
                DataLabelsSize = 20,
                Stroke = null,
                Fill = new SolidColorPaint(new SKColor(255, 132, 75)),
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

        public ViewModelForProfileStats()
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

    public class ViewModelForWorkoutMuscle
    {
        public ISeries[] Series { get; set; } =
        {
           new RowSeries<int>
           {
               Values = new List<int> { 8, -3, 4 },
               Stroke = null,
               DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
               DataLabelsSize = 14,
               DataLabelsPosition = DataLabelsPosition.End
           }

        };

        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Labels = new string[] { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" },
                LabelsRotation = 5
            }
        };

    }


    class ViewModelForChartClass
    {


    }
}
