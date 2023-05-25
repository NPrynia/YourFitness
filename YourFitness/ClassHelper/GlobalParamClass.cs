using HandyControl.Controls;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using YourFitness.ClassHelper;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using MaterialDesignThemes.Wpf;
using static YourFitness.ClassHelper.ModelEF;

namespace YourFitness.ClassHelper
{
   
    public class GlobalParamClass
    {
        public static StepBar stepBar;
        public static Frame registrationFrame;
        public static Frame userFrame;
        public static DialogHost mainDialogHost;
        //public static string pathImageUser;
        public static List<ModelEF.User> listUser;
        public static List<ModelEF.News> listNews;
        public static List<ModelEF.Exercise> listExercise;
        public static List<ModelEF.Workout> listWorkout;
        public static ModelEF.User currentUser;
        public static ModelEF.Workout PickedWorkout = null;
        public static ObservableCollection<Workout> listWorkoutLiked;
        public static ObservableCollection<HistoryWorkoutUser> listHistoryWorkoutUser;

        //ngrok http https://localhost:44387 --host-header="localhost:44387

        public static string urlServer = "https://localhost:44387";
    }
}
