using CarsRent.BL;
using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
using CarsRent.BL.Word;
using CarsRent.WPF.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace CarsRent.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // TODO: По другому инициализировать базу данных.
            Query<Car>.SelectAll();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new Settings();
        }

        private void btnUsersList_Click(object sender, RoutedEventArgs e)
        {
            var window = this;

            mainFrame.Content = new ListPage("renters", ref window);
        }

        private void btnCarsList_Click(object sender, RoutedEventArgs e)
        {
            var window = this;

            mainFrame.Content = new ListPage("cars", ref window);
        }
    }
}