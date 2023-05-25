using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Nodes;
using System.Windows.Documents;
using static YourFitness.ClassHelper.GlobalParamClass;
using static YourFitness.ClassHelper.ModelEF;


namespace YourFitness.ClassHelper
{
    class ApiHelperClass
    {
        static readonly HttpClient client = new HttpClient();
        public static async void updateAllUser()
        {
            try
            {
                using HttpResponseMessage response = await client.GetAsync(urlServer + "/api/User");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                GlobalParamClass.listUser = System.Text.Json.JsonSerializer.Deserialize<List<User>>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

           
        }

        public static  void updateAllUserNonAsync()
        {
            try
            {
               
                WebRequest request = WebRequest.Create(urlServer + "/api/User");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string jsonUser = reader.ReadToEnd();
                GlobalParamClass.listUser = System.Text.Json.JsonSerializer.Deserialize<List<User>>(jsonUser);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }


        }

        public static  void postUser(User user)
        {

         

            //try
            //{
            //    using HttpResponseMessage response = await client.PostAsJsonAsync(urlServer + "/api/User", user);
            //    response.EnsureSuccessStatusCode();
            //    // Above three lines can be replaced with new helper method below
            //    // string responseBody = await client.GetStringAsync(uri);

            //}
            //catch (HttpRequestException e)
            //{
            //    Console.WriteLine("\nExce   ption Caught!");
            //    Console.WriteLine("Message :{0} ", e.Message);
            //}

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(GlobalParamClass.urlServer + "/api/User");


            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string postData = JsonConvert.SerializeObject(user);

                streamWriter.Write(postData);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

        }

        public static async void putUser(User user)
        {

            try
            {
                using HttpResponseMessage response = await client.PutAsJsonAsync(urlServer + "/api/User", user);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }
        public static async void postHistoryChange(HistoryChange historyChange)
        {

            try
            {
                using HttpResponseMessage response = await client.PostAsJsonAsync(urlServer + "/api/HistoryChange", historyChange);
                response.EnsureSuccessStatusCode();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

           

        }


        //newsApi


        public static ObservableCollection<HistoryWorkoutUser> getHistoryWorkoutUser(int IDUser)
        {
            try
            {

                WebRequest request = WebRequest.Create(urlServer + $"/api/HistoryWorkoutUser?idUser={IDUser}");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string jsonWorkout = reader.ReadToEnd();
                return new ObservableCollection<HistoryWorkoutUser>(System.Text.Json.JsonSerializer.Deserialize<List<HistoryWorkoutUser>>(jsonWorkout));

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }

      



        public static async void postHistoryWorkoutUser(HistoryWorkoutUser hwu)
        {

            try
            {
                using HttpResponseMessage response = await client.PostAsJsonAsync(urlServer + "/api/HistoryWorkoutUser", hwu);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }


        }

        public static async void getHistoryChange()
        {
            try
            {

                WebRequest request = WebRequest.Create(urlServer + $"/api/HistoryChange?idUser={GlobalParamClass.currentUser.ID}");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string jsonWorkout = reader.ReadToEnd();
                GlobalParamClass.currentUser.HistoryChangeCurrentUser = (System.Text.Json.JsonSerializer.Deserialize<List<HistoryChange>>(jsonWorkout));

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }

        public static async void getStatsWorkout()
        {
            try
            {

                WebRequest request = WebRequest.Create(urlServer + $"/api/StaticticsForUserController/StatsWeek/{GlobalParamClass.currentUser.ID}");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string jsonWorkout = reader.ReadToEnd();
                GlobalParamClass.currentUser.StatsWorkout = (System.Text.Json.JsonSerializer.Deserialize<List<qtyHourWorkoutUser_Result>>(jsonWorkout));

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }


        public static async void getStatsMuscle()
        {
            try
            {

                WebRequest request = WebRequest.Create(urlServer + $"/api/StaticticsForUserController/StatsMuscle/{GlobalParamClass.currentUser.ID}");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string jsonWorkout = reader.ReadToEnd();
                GlobalParamClass.currentUser.StatsMuscle = (System.Text.Json.JsonSerializer.Deserialize<List<qtyHourOnMuscleForUser_Result>>(jsonWorkout));

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }



        public static void getNewsNonAsync()
        {
            try
            {

                WebRequest request = WebRequest.Create(urlServer + "/api/News");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string jsonNews = reader.ReadToEnd();
                GlobalParamClass.listNews = System.Text.Json.JsonSerializer.Deserialize<List<News>>(jsonNews);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

           

        }

        public static void getWorkoutNonAsync()
        {
            try
            {

                WebRequest request = WebRequest.Create(urlServer + "/api/Workout");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string jsonWorkout = reader.ReadToEnd();
                GlobalParamClass.listWorkout = (System.Text.Json.JsonSerializer.Deserialize<List<Workout>>(jsonWorkout));

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }

        public static List<Message> getMessageList(int idUser,int qtyMessage)
        {
            try
            {

                WebRequest request = WebRequest.Create(urlServer + $"/api/Message?idUserGet={idUser}&idUserSent={GlobalParamClass.currentUser.ID}&qtyMessage={qtyMessage}");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string jsonMessage = reader.ReadToEnd();
                return System.Text.Json.JsonSerializer.Deserialize<List<Message>>(jsonMessage);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }



        }

        public static List<User> getUserListWithMessage(int idUser)
        {
            try
            {

                WebRequest request = WebRequest.Create(urlServer + $"/api/Message/listIdUser/{idUser}");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string jsonMessage = reader.ReadToEnd();
                List<int> idUserList = System.Text.Json.JsonSerializer.Deserialize<List<int>>(jsonMessage);
                return GlobalParamClass.listUser.Where(i => idUserList.Contains(i.ID)).ToList();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }



        }
        public static async void postMessage(Message message)
        {

            try
            {
                using HttpResponseMessage response = await client.PostAsJsonAsync(urlServer + "/api/Message", message);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }


        //--NEWS--//
        public static async void deleteNews(News news)
        {
            try
            {
                using HttpResponseMessage response = await client.DeleteAsync(urlServer + $"/api/News?idNews={news.ID}");
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        public static async void postNews(News news)
        {
            try
            {
                using HttpResponseMessage response = await client.PostAsJsonAsync(urlServer + "/api/News", news);
                response.EnsureSuccessStatusCode();
                news.ID = Convert.ToInt32(response.Headers.ToString().Split('%', '%')[1]);
               
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        public static async void postNewsComment(NewsComment newsComment)
        {
            try
            {
                using HttpResponseMessage response = await client.PostAsJsonAsync(urlServer + "/api/NewsComment", newsComment);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        public static async void postWorkoutReview(WorkoutReaction workoutReaction)
        {
            try
            {
                using HttpResponseMessage response = await client.PostAsJsonAsync(urlServer + "/api/WorkoutReaction", workoutReaction);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        public static async void deleteWorkoutReview(WorkoutReaction workoutReaction)
        {
            try
            {
                string uri = $"/api/WorkoutReaction?IDUser={workoutReaction.IDUser}&IDWorkout={workoutReaction.IDWorkout}";
                using HttpResponseMessage response = await client.DeleteAsync(urlServer + uri);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
        public static async void putWorkoutReview(WorkoutReaction workoutReaction)
        {

            try
            {
                using HttpResponseMessage response = await client.PutAsJsonAsync(urlServer + "/api/WorkoutReaction", workoutReaction);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }


        public static async void postLike(LikeNewsUser likeNewsUser)
        {
            try
            {

                using HttpResponseMessage response = await client.PostAsJsonAsync(urlServer + "/api/LikeNewsUser", likeNewsUser);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }

        public static async void postLikeWorkout(LikeWorkout likeWorkout)
        {
            try
            {

                using HttpResponseMessage response = await client.PostAsJsonAsync(urlServer + "/api/LikeWorkout", likeWorkout);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }




      

        public static async void getExercise()
        {
            try
            {

                WebRequest request = WebRequest.Create(urlServer + "/api/Exercise");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string json = reader.ReadToEnd();
                GlobalParamClass.listExercise = System.Text.Json.JsonSerializer.Deserialize<List<Exercise>>(json);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }



        }



        public static  async void  postWorkout(Workout  workout)
        {
            try
            {

                using HttpResponseMessage response = await client.PostAsJsonAsync(urlServer + "/api/Workout", workout);
                response.EnsureSuccessStatusCode();


                int idWorkout =  Convert.ToInt32(response.Headers.ToString().Split('%', '%')[1]);
                if (String.IsNullOrEmpty(workout.ImagePath) != true)
                {
                    WebClient client = new WebClient();
                    byte[] responseBinary = client.UploadFile(urlServer + $"/api/Workout/PostImage/{idWorkout}", workout.ImagePath);
                    string result = Encoding.UTF8.GetString(responseBinary);
                }



            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }


        public static   List<WorkoutType> getTypeWorkout()
        {
            try
            {

                WebRequest request = WebRequest.Create(urlServer + "/api/Workout/GetTypeWorkout");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string json = reader.ReadToEnd();
                return  System.Text.Json.JsonSerializer.Deserialize<List<WorkoutType>>(json);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }



        }
        //-----------SERVICE-----------//
        public static List<Service> getListService(int idTrainer)
        {
            try
            {

                WebRequest request = WebRequest.Create(urlServer + $"/api/ServiceTrainer?idUser={idTrainer}");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string json = reader.ReadToEnd();
                return System.Text.Json.JsonSerializer.Deserialize<List<Service>>(json);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }



        }

        public static async void postService(Service service)
        {

            try
            {
                using HttpResponseMessage response = await client.PostAsJsonAsync(urlServer + "/api/ServiceTrainer", service);
                response.EnsureSuccessStatusCode();
                service.ID = Convert.ToInt32(response.Headers.ToString().Split('%', '%')[1]);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
        public static async void deleteService(int idService)
        {
            try
            {
                using HttpResponseMessage response = await client.DeleteAsync(urlServer + $"/api/ServiceTrainer?IdService={idService}");
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
        public static async void putService(Service service)
        {

            try
            {
                using HttpResponseMessage response = await client.PutAsJsonAsync(urlServer + "/api/ServiceTrainer", service);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }

        //-----------TrainerReview-----------//
        public static List<ReviewUserTrainer> getListTrainerReview(int idTrainer)
        {
            try
            {

                WebRequest request = WebRequest.Create(urlServer + $"/api/ReviewUserTrainer?idUser={idTrainer}");
                request.Method = "Get";
                request.Proxy = null;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string json = reader.ReadToEnd();
                return System.Text.Json.JsonSerializer.Deserialize<List<ReviewUserTrainer>>(json);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }



        }

        public static async void postTrainerReviewe(ReviewUserTrainer reviewUserTrainer)
        {

            try
            {
                using HttpResponseMessage response = await client.PostAsJsonAsync(urlServer + "/api/ReviewUserTrainer", reviewUserTrainer);
                response.EnsureSuccessStatusCode();
                reviewUserTrainer.IDUserTrainer = Convert.ToInt32(response.Headers.ToString().Split('%', '%')[1]);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
        public static async void deleteTrainerReview(ReviewUserTrainer reviewUserTrainer )
        {
            try
            {

                using HttpResponseMessage response = await client.DeleteAsync(urlServer + $"/api/ReviewUserTrainer?IDUserReview={reviewUserTrainer.IDUserReview}&IDTrainer={reviewUserTrainer.IDUserTrainer}");
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
        public static async void putTrainerReview(ReviewUserTrainer reviewUserTrainer)
        {

            try
            {
                using HttpResponseMessage response = await client.PutAsJsonAsync(urlServer + "/api/ReviewUserTrainer", reviewUserTrainer);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nExce   ption Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }


    }


}

    
