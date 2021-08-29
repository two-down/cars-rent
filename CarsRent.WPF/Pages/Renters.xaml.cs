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
        private RentersList _currentRentersList;
        public Renters()
        {
            InitializeComponent();

            _currentRentersList = new RentersList();
            rentersFrame.Content = _currentRentersList;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            rentersFrame.Content = new RenterActions();
        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            _currentRentersList = new RentersList();
            rentersFrame.Content = _currentRentersList;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentRentersList.Delete();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}