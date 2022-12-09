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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YourFitness.ClassHelper;

namespace YourFitness.Pages
{
    /// <summary>
    /// Логика взаимодействия для ResitrationPage1.xaml
    /// </summary>
    public partial class ResitrationPage1 : Page
    {
        public ResitrationPage1()
        {
            InitializeComponent();
        }

        private void heightSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            heightTB.Text = (heightSlider.Value).ToString();
        }

        private void weightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            weightTB.Text = (weightSlider.Value).ToString();
        }


        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            GlobalParamClass.stepBar.StepIndex += 1;
            GlobalParamClass.registrationFrame.Navigate(new Pages.RegistrationPage2());
        }
    }
}
