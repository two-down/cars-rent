using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
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

namespace CarsRent.WPF.Pages
{
    public partial class Renters : Page
    {
        public Renters()
        {
            InitializeComponent();

            rentersFrame.Content = new RentersList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            rentersFrame.Content = new RenterActions();
        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            rentersFrame.Content = new RentersList();
            btnList.Visibility = Visibility.Hidden;
        }
    }
}