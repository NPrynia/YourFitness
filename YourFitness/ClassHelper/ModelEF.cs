using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Media.Imaging;

namespace YourFitness.ClassHelper
{
    public class ModelEF
    {
        public partial class News: INotifyPropertyChanged
        {
            public int ID { get; set; }
            public int IDUser { get; set; }
            public string Description { get; set; }
            public Nullable<int> IDWorkout { get; set; }
            public byte[] image { get; set; }
            public System.DateTime timeCreate { get; set; }

            private ObservableCollection<NewsComment> allComments;

            public ObservableCollection<NewsComment> AllComments 
            {

                get
                {
                   
                    return allComments;
                  
                }

                set 
                {
                    allComments = value;
                    OnPropertyChanged("allComments");


                }
            
            }
            private int qtyLike;

          
            public int QtyLike
            {

                get
                {
                    return qtyLike;
                }

                set
                {
                    qtyLike = value;
                    OnPropertyChanged("qtyLike");


                }

            }

            private bool isNewsCurrentUser;
            public bool IsNewsCurrentUser
            {

                get
                {
                    if (IDUser == GlobalParamClass.currentUser.ID)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                set
                {
                    isNewsCurrentUser = value;
                    OnPropertyChanged("isNewsCurrentUser");


                }

            }

            private int qtyComment { get; set; }

            
            public int QtyComment 
            {

                get
                {
                    return qtyComment;
                }

                set
                {
                    qtyComment = value;
                    OnPropertyChanged("qtyComment");


                }

            }


            private  User user;


            public virtual User User
            {

                get
                {
                    return user;
                }

                set
                {
                    user = value;
                    OnPropertyChanged("user");


                }

            }



            private Workout workout;
            public virtual Workout Workout
            {

                get
                {

                    return workout;

                }

                set
                {
                    workout = value;
                    OnPropertyChanged("workout");


                }

            }


            private ICollection<LikeNewsUser> likeNewsUser;
            public virtual ICollection<LikeNewsUser> LikeNewsUser 
            {
                get
                {

                    return likeNewsUser;

                }

                set
                {
                    likeNewsUser = value;
                    OnPropertyChanged("likeNewsUser");


                }

            }

            private bool IsLikeCurrentUser;

            [JsonIgnore]
            public bool isLikeCurrentUser
            {
                get
                {
                    if (LikeNewsUser != null)
                    {
                        var temp = LikeNewsUser.Where(i => i.IDUser == GlobalParamClass.currentUser.ID && i.IsLike == true).FirstOrDefault();
                        if (temp != null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                   

                }
                set 
                {
                    OnPropertyChanged("isLikeCurrentUser");
                }
            }

            private void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            
            }

            public event PropertyChangedEventHandler PropertyChanged;



        }
        public partial class LikeNewsUser
        {
            public int IDNews { get; set; }
            public int IDUser { get; set; }
            public bool IsLike { get; set; }

            public virtual News News { get; set; }
            public virtual User User { get; set; }
        }

        public partial class NewsComment
        {
            public int IDNews { get; set; }
            public int IDUser { get; set; }
            public Nullable<System.DateTime> TimeSentComment { get; set; }
            public string Comment { get; set; }
            public virtual User User { get; set; }

        }

        public partial class User
        {
           

            public int ID { get; set; }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string Mail { get; set; }
            public string Login { get; set; }
            public string PasswordHash { get; set; }
            public string Salt { get; set; }
            public int IDGender { get; set; }
            public int Weitght { get; set; }
            public int Height { get; set; }
            public int IDRole { get; set; }
            public System.DateTime Birthday { get; set; }

            private byte[] imageProfile;
            public byte[]  ImageProfile
            {

                get
                {
                    return imageProfile;
                }

                set
                {
                    imageProfile = value;
                    OnPropertyChanged("imageProfile");


                }

            }
            public string Description { get; set; }
            public string DescriptionTrainer { get; set; }
            public string FIO { get => $"{FirstName} {SecondName}"; }

            private List<HistoryChange> historyChangeCurrentUser;
            [JsonIgnore]
            public List<HistoryChange> HistoryChangeCurrentUser
            {

                get
                {

                    return historyChangeCurrentUser;

                }

                set
                {
                    historyChangeCurrentUser = value;
                    OnPropertyChanged("historyChangeCurrentUser");


                }
            }


            private List<qtyHourOnMuscleForUser_Result> statsMuscle;
            [JsonIgnore]
            public List<qtyHourOnMuscleForUser_Result> StatsMuscle
            {
                get
                {

                    return statsMuscle;

                }

                set
                {
                    statsMuscle = value;
                    OnPropertyChanged("statsMuscle");


                }
            }


            private List<qtyHourWorkoutUser_Result> statsWorkout;
            [JsonIgnore]
            public List<qtyHourWorkoutUser_Result> StatsWorkout
            {
                get
                {

                    return statsWorkout;

                }

                set
                {
                    statsWorkout = value;
                    OnPropertyChanged("historyCstatsWorkouthangeCurrentUser");


                }
            }


            private void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }

            }

            public event PropertyChangedEventHandler PropertyChanged;

        }
        public partial class Gender
        {
            

            public int ID { get; set; }
            public string Name { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<User> User { get; set; }
        }
        public partial class Role
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
         

            public int ID { get; set; }
            public string Name { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<User> User { get; set; }
        }

        public partial class WorkoutReaction : INotifyPropertyChanged
        {
            public int IDWorkout { get; set; }
            public int IDUser { get; set; }

            private System.DateTime timeSent;
            public System.DateTime TimeSent
            {

                get
                {
                    return timeSent;
                }

                set
                {
                    timeSent = value;
                    OnPropertyChanged("timeSent");


                }

            }

            private string review;
            public string Review
            {

                get
                {
                    return review;
                }

                set
                {
                    review = value;
                    OnPropertyChanged("review");


                }

            }
            private int rating;
            public int Rating
            {

                get
                {
                    return rating;
                }

                set
                {
                    rating = value;
                    OnPropertyChanged("rating");


                }

            }

            public virtual User User { get; set; }
            public virtual Workout Workout { get; set; }

            private void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }

            }

            public event PropertyChangedEventHandler PropertyChanged;
        }

        public partial class HistoryChange
        {
            public int ID { get; set; }
            public int IDUser { get; set; }
            public Nullable<int> NewWeitght { get; set; }
            public Nullable<int> NewHeight { get; set; }
            public byte[] ImageFront { get; set; }
            public byte[] ImageSide { get; set; }
            public byte[] ImageBack { get; set; }
            public System.DateTime DataChange { get; set; }

        }
        public partial class ReviewUserTrainer : INotifyPropertyChanged
        {
            public int IDUserTrainer { get; set; }
            public int IDUserReview { get; set; }
            private string review;
            public string Review
            {

                get
                {
                    return review;
                }

                set
                {
                    review = value;
                    OnPropertyChanged("review");


                }

            }
            private int rating;
            public int Rating
            {

                get
                {
                    return rating;
                }

                set
                {
                    rating = value;
                    OnPropertyChanged("rating");


                }

            }

            [JsonIgnore]
            public virtual User User1 { get; set; }


            private void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }

            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
        public partial class Service
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int IDUser { get; set; }
            public string Description { get; set; }



        }

        public partial class Exercise
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
          

            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool isQtyInSecond { get; set; }
            public string PathToGif { get; set; }
            public string MuscleTypeName { get; set; }


        }


        public partial class Message
        {
            public int ID { get; set; }
            public string Message1 { get; set; }
            [JsonIgnore]
            public object MessageCb
            {
                get
                {
                    if (Image != null && ID != 0)
                    {

                        using (var ms = new System.IO.MemoryStream(Image))
                        {
                            var image = new BitmapImage();
                            image.BeginInit();
                            image.CacheOption = BitmapCacheOption.OnLoad; 
                            image.StreamSource = ms;
                            image.EndInit();
                            return image;
                        }

                    }
                    else
                    {
                        return Message1;
                    }
                }
            }
            public int IDUserSent { get; set; }
            public int IDUserGet { get; set; }
            public System.DateTime TimeSent { get; set; }
            public byte[] Image { get; set; }

            [JsonIgnore]
            public string Role
            {
                get
                {
                    if (IDUserSent == GlobalParamClass.currentUser.ID)
                    {

                        return "Sender";
                    }
                    else
                    {
                        return "Receiver";
                    }
                }
            
            }
            [JsonIgnore]
            public string TypeMessage
            {
                get
                {
                    if (Image != null)
                    {

                        return "Image";
                    }
                    else
                    {
                        return "String";
                    }
                }

            }

        }


        public partial class WorkoutType
        {
           

            public int ID { get; set; }
            public string Name { get; set; }
        }

        public partial class Workout : INotifyPropertyChanged
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int IDUser { get; set; }
            public int DurationInMin { get; set; }
            public string Description { get; set; }
            public Nullable<int> IDDificulty { get; set; }
            public string DificultyName { get; set; }
            public int IDWorkoutType { get; set; }

           [JsonIgnore]
            public bool isLikeCurrentUser
            {
                get
                {
                    if (LikeWorkout != null)
                    {
                        var temp = LikeWorkout.Where(i => i.IDUser == GlobalParamClass.currentUser.ID && i.IsLike == true).FirstOrDefault();
                        if (temp != null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                set
                {
                    OnPropertyChanged("isLikeCurrentUser");

                }
            }


            private string imagePath;
            public string ImagePath
            {

                get
                {

                    return imagePath;

                }

                set
                {
                    imagePath = value;
                    if (imagePath != null)
                    {

                        using (WebClient webClient = new WebClient())
                        {
                            var tempPath = Path.GetFileName(imagePath);
                            tempPath = tempPath.Replace('.', '-');
                            if (ID != 0)
                            {
                                byte[] data = webClient.DownloadData(GlobalParamClass.urlServer + $"/api/Workout/GetImage/{tempPath}");

                                workoutImage = data;
                            }
                            else
                            {
                                workoutImage = null;
                            }

                        }
                    }
                    else
                    {
                        workoutImage = null;
                    }


                }

            }

            private byte[] workoutImage;
            public byte[]  WorkoutImage
            {
                get
                {
                    return workoutImage;
                   

                }
                set
                {
                    workoutImage = value;
                }

            }


            public int QtyExersice { get; set; }

            private int avgRating;
            public int AvgRating
            {

                get
                {

                    return avgRating;

                }

                set
                {
                    avgRating = value;
                    OnPropertyChanged("avgRating");


                }

            }

            private ObservableCollection<WorkoutReaction> allWorkoutReaction;
            public ObservableCollection<WorkoutReaction> AllWorkoutReaction
            {

                get
                {

                    return allWorkoutReaction;

                }

                set
                {
                    allWorkoutReaction = value;
                    OnPropertyChanged("allComments");


                }

            }

            public List<qtyMuscleInWorkout_Result> qtyMuscleInWorkout { get; set; }

            private  ICollection<LikeWorkout> likeWorkout { get; set; }


            public virtual ICollection<ExerciseWorkout> ExerciseInWorkout { get; set; }
            public  ICollection<ExerciseWorkout> exerciseWorkout;

            public virtual ICollection<ExerciseWorkout> ExerciseWorkout
            {
                get
                {

                    return exerciseWorkout;

                }

                set
                {
                    exerciseWorkout = value;
                    OnPropertyChanged("exerciseWorkout");


                }
            }

            public virtual ICollection<LikeWorkout> LikeWorkout
            {
                get
                {

                    return likeWorkout;

                }

                set
                {
                    likeWorkout = value;
                    OnPropertyChanged("likeWorkout");


                }
            }



            public WorkoutReaction WorkoutReactionCurrentUser
            {
                get
                {
                    if (AllWorkoutReaction != null)
                    {
                        var temp = AllWorkoutReaction.Where(i => i.IDUser == GlobalParamClass.currentUser.ID).FirstOrDefault();
                        if (temp != null)
                        {
                            return temp;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }


                }
                set 
                {
                    OnPropertyChanged("WorkoutReactionCurrentUser"); 
                }
            }


            public virtual User User { get; set; }



            private void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }

            }

            public event PropertyChangedEventHandler PropertyChanged;

        }

        public partial class LikeWorkout
        {
            public int IDWorkout { get; set; }
            public int IDUser { get; set; }
            public bool IsLike { get; set; }

            public virtual User User { get; set; }
            public virtual Workout Workout { get; set; }
        }

        public partial class Dificulty
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public Dificulty()
            {
                this.Workout = new HashSet<Workout>();
            }

            public int ID { get; set; }
            public string Name { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Workout> Workout { get; set; }
        }
        public partial class ExerciseWorkout : INotifyPropertyChanged
        {
            public int ID { get; set; }
            public int IDExercise { get; set; }
            [JsonIgnore]
            public string Name { get; set; }
            public int IDWorkout { get; set; }
            public int Qty { get; set; }

            public virtual Exercise Exercise { get; set; }

            private string complete= "False";
            public string Complete
            {

                get
                {

                    return complete;

                }

                set
                {
                    complete = value;
                    OnPropertyChanged("complete");


                }

            }

            private void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }

            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
      
        public partial class MuscleTypeExercise
        {
            public int IDMuscleTypeExercise { get; set; }
            public int IDMuscleType { get; set; }
            public int IDExercise { get; set; }

            public virtual Exercise Exercise { get; set; }
            public virtual MuscleType MuscleType { get; set; }
        }
        public partial class MuscleType
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public MuscleType()
            {
                this.MuscleTypeExercise = new HashSet<MuscleTypeExercise>();
            }

            public int ID { get; set; }
            public string Name { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<MuscleTypeExercise> MuscleTypeExercise { get; set; }
        }

        public partial class qtyMuscleInWorkout_Result
        {
            public string Name { get; set; }
            public Nullable<int> qty { get; set; }
            public Nullable<int> qtyInPercent { get; set; }
            public Nullable<int> width { get; set; }

        }


        public partial class HistoryWorkoutUser
        {
            public int ID { get; set; }
            public int IDWorkout { get; set; }
            public int IDUser { get; set; }
            public System.DateTime DateWorkout { get; set; }
            public string nameWorkout { get; set; }
        }

        public partial class qtyHourOnMuscleForUser_Result
        {
            public string name { get; set; }
            public Nullable<int> TimeInMinute { get; set; }
            public Nullable<decimal> percent { get; set; }
        }

        public partial class qtyHourWorkoutUser_Result
        {
            public Nullable<int> qtyMinute { get; set; }
            public string day { get; set; }
        }
    }
}
