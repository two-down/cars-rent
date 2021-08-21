using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
using CarsRent.WPF.UI_Utilities;
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
    /// <summary>
    /// Логика взаимодействия для RentersList.xaml
    /// </summary>
    public partial class RentersList : Page
    {
        public RentersList()
        {
            InitializeComponent();

            var objList = new ObjectList<Renter>(ref spList);
        }
    }
}