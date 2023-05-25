using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        string pathImageUser = null;
        public AuthWindow()
        {
            InitializeComponent();
            ApiHelperClass.updateAllUserNonAsync();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void topBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //PickImage
        private void pickImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
            openFile.Multiselect = false;
            openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFile.ShowDialog() == true)
            {
                Image i = new Image();
                i.Source = new BitmapImage(new Uri(openFile.FileName));
                pathImageUser = openFile.FileName;
                gravatar.Visibility = Visibility.Hidden;
                photoImage.ImageSource = i.Source;

               

            }
        }




        //SwapTabLoginOrReg
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;
            switch (tabItem)
            {
                case "Login":

                    btnLogin.Content = "Login";
                    tbMail.Visibility = Visibility.Visible;
                    tbMail.Height = 0;
                    break;

                case "Registration":
                    btnLogin.Content = "Registration";
                    tbMail.Visibility = Visibility.Visible;
                    tbMail.Height = 45;
                    break;

                default:
                    return;
            }
        }

        //LoginOrReg
        
        private  void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           
                if (ValidationClass.validationLogin(tbLogin.Text) is false)
                {
                    HandyControl.Controls.MessageBox.Show("Некорректный логин");
                    return;
                }

                string buttonText = (sender as Button).Content as string;
                switch (buttonText)
                {
                    case "Login":

                        var user = GlobalParamClass.listUser.Where(s => s.Login == tbLogin.Text).FirstOrDefault();
                        if (user != null)
                        {
                            if (user.PasswordHash == Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(pbPassword.Password + user.Salt))))
                            {
                               tbLoadText.Visibility = Visibility.Visible;

                            viewBoxAnimationWhenLogIn.Visibility = Visibility.Hidden;

                            //loadingCircle.IsRunning = true;
                            //viewBoxAnimationAfterLogin.Visibility = Visibility.Visible;
                            GlobalParamClass.currentUser = user;
                            ApiHelperClass.getHistoryChange();
                            ApiHelperClass.updateAllUser();
                            ApiHelperClass.getWorkoutNonAsync();
                            ApiHelperClass.getNewsNonAsync();
                            ApiHelperClass.getExercise();
                            MainWindow mainWindow = new MainWindow();
                                mainWindow.Show();
                                this.Close();




                            }
                            else
                            {
                            HandyControl.Controls.MessageBox.Show("Неправильный пароль");
                            }
                        }
                        else
                        {
                        HandyControl.Controls.MessageBox.Show("Пользователь не найден");

                        }

                        break;


                    case "Registration":
                        //validation

                        if (ValidationClass.validationPassword(pbPassword.Password) is false)
                        {
                        HandyControl.Controls.MessageBox.Show("Некорректный пароль");
                            return;
                        }
                        var validUser = GlobalParamClass.listUser.Where(s => s.Login == tbLogin.Text).FirstOrDefault();
                        if (validUser != null)
                        {
                        HandyControl.Controls.MessageBox.Show("логин занят");
                            return;
                        }

                        var email = new EmailAddressAttribute();
                        if (email.IsValid(tbMail.Text) is false)
                        {
                        HandyControl.Controls.MessageBox.Show("Некорректная почта");
                            return;
                        }

                        //generate salt
                        string salt = null;
                        for (int i = 0; i < 6; i++)
                        {
                            Random random = new Random();
                            salt = salt + Convert.ToChar(random.Next(0, 26) + 65);
                        }
                        //add New User
                        ModelEF.User newUser = new ModelEF.User();
                        newUser.Login = tbLogin.Text;
                        newUser.Mail = tbMail.Text;
                        newUser.Salt = salt;
                        newUser.PasswordHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(pbPassword.Password + salt)));
                        if (pathImageUser != null)
                        {
                            newUser.ImageProfile = File.ReadAllBytes(pathImageUser);
                        }
                        RegistrationWindow registrationWindow = new RegistrationWindow(newUser);
                        registrationWindow.Show();
                        this.Close();
                        break;

                    default:
                        return;
                }

           
               
          

        }

    }
}
