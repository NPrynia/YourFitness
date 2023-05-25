using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
using static YourFitness.ClassHelper.ModelEF;

namespace YourFitness.Pages
{
   
    public partial class ResitrationPage1 : Page
    {
        ModelEF.User newUser;
        public ResitrationPage1(ModelEF.User user)
        {
            InitializeComponent();
            newUser = user;
            dpAge.DisplayDateEnd = DateTime.Today.AddDays(-1200);
        }

        private void heightSlider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            heightTB.Text = (heightSlider.Value).ToString();
        }

        private void weightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            weightTB.Text = (weightSlider.Value).ToString();
        }


        private async void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationClass.validationFIO(tbFname.Text) is false)
            {
                MessageBox.Show("Некорректное имя");
                return;
            }
            if (ValidationClass.validationFIO(tbSurname.Text) is false)
            {
                MessageBox.Show("Некорректная фамилия");
                return;
            }
            if (ValidationClass.validationWeighAndHeight(weightSlider.Value) is false)
            {
                MessageBox.Show("Некорректный вес");
                return;
            }
            if (ValidationClass.validationWeighAndHeight(heightSlider.Value) is false)
            {
                MessageBox.Show("Некорректный рост");
                return;
            }
            if (dpAge.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату рождения");
                return;
            }


            newUser.FirstName = tbFname.Text;
            newUser.IDRole = 1;
            newUser.SecondName = tbSurname.Text;
            newUser.Birthday = (DateTime)dpAge.SelectedDate;
            if (rbGender.IsChecked == true)
            {
                newUser.IDGender = 1;
            }
            else
            {
                newUser.IDGender = 2;
            }
            ApiHelperClass.postUser(newUser);
            GlobalParamClass.currentUser = newUser;
            ClassHelper.ApiHelperClass.updateAllUserNonAsync();
            User tempUser = GlobalParamClass.listUser.Where(i => i.Login == newUser.Login).FirstOrDefault();
            ModelEF.HistoryChange newHistoryChangeUser = new ModelEF.HistoryChange();
            newHistoryChangeUser.IDUser = tempUser.ID;
            newHistoryChangeUser.NewWeitght = (int)weightSlider.Value;
            newHistoryChangeUser.NewHeight = (int)heightSlider.Value;
            newHistoryChangeUser.DataChange = DateTime.Now;
            ApiHelperClass.postHistoryChange(newHistoryChangeUser);
            GlobalParamClass.stepBar.StepIndex += 1;
            GlobalParamClass.registrationFrame.Navigate(new Pages.RegistrationPage2());
        }



       


    }
}
