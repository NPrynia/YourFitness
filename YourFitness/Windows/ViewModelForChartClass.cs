using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using YourFitness.ClassHelper;
using System.Linq;

namespace YourFitness.Windows
{

    public class ViewModelForProfileStats
    {
        public ISeries[] SeriesWeak { get; set; } =
        {

            new ColumnSeries<double>
            {
                Name = "Количество минут",
                DataLabelsSize = 20,
                Stroke = null,
                Fill = new SolidColorPaint(new SKColor(255, 132, 75)),
                Values =  GlobalParamClass.currentUser.StatsWorkout.Select(i => (double)i.qtyMinute).ToList(),
                IgnoresBarPosition = false
            },

        };

        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Labels = GlobalParamClass.currentUser.StatsWorkout.Select(i => i.day.ToString()).ToList(),
                LabelsRotation = 5
            }
        };

        public ViewModelForProfileStats()
        {

            List<ISeries> list = new List<ISeries>();
            foreach (ModelEF.qtyHourOnMuscleForUser_Result i in GlobalParamClass.currentUser.StatsMuscle)
            {
                var temp2 = new PieSeries<double> { Values = new double[] { (double)i.TimeInMinute }, Name = i.name, TooltipLabelFormatter = point => $"{i.TimeInMinute} минут" };



                list.Add(temp2);

              
            }
            SeriesMuscle = list;
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
