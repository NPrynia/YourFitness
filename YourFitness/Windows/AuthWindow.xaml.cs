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

namespace YourFitness.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        bool isLogin = true;
        string pathPhoto;
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }



        private void topBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void pickImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {
                Image i = new Image();
                i.Source = new BitmapImage(new Uri(openFile.FileName));
                pathPhoto = openFile.FileName;
                gravatar.Visibility = Visibility.Hidden;
                photoImage.ImageSource = i.Source;

            }
        }




        //LoginOrReg
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Header as string;
            switch (tabItem)
            {
                case "Login":

                    btnLogin.Content = "Login";
                    tbMail.Visibility = Visibility.Visible;
                    tbMail.Height = 0;
                    isLogin = true;
                    break;

                case "Registration":
                    btnLogin.Content = "Registration";
                    isLogin = false;
                    tbMail.Visibility = Visibility.Visible;
                    tbMail.Height = 45;
                    break;

                default:
                    return;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string buttonText = (sender as Button).Content as string;
            switch (buttonText)
            {
                case "Login":
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.Show();
                    break;

                case "Registration":
                    RegistrationWindow registrationWindow = new RegistrationWindow();
                    registrationWindow.Show();
                    this.Close();
                    break;

                default:
                    return;
            }

        }

      
    }
}
