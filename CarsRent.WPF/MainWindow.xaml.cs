using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
using CarsRent.WPF.Pages;
using System.Windows;

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

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new MakeContract();
        }
    }
}