using System;
using System.Collections.Generic;
using System.Reflection;
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
    /// Логика взаимодействия для TrainerWindow.xaml
    /// </summary>
    public partial class TrainerWindow : Window
    {

        List<service> listService = new List<service>();
        public TrainerWindow()
        {
            InitializeComponent();
            listService.Add(new service { serviceName = "Название услуги", description = "ОбомнеобомнеОбомнеобомнеОбомнеобомнеОбомнеобомнеОбомнеобомнеОбомнеобомнеОбомнеобомнеОбомнеобомнеОбомнеобомне", cost = "4000", });
            lvService.ItemsSource = listService;
            lvService.Items.Refresh();
        }

        private void addService_Click(object sender, RoutedEventArgs e)
        {

            listService.Add(new service { serviceName = "", description = "", cost = "", });
            lvService.ItemsSource = listService;
            lvService.Items.Refresh();

        }

        class service
        {
            public string serviceName { get; set; }
            public string description { get; set; }
            public string cost { get; set; }
        }

       

        private void btnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var item = btn.DataContext as service;
            listService.Remove(item);
            lvService.ItemsSource = listService;
            lvService.Items.Refresh();

        }
    }
}
