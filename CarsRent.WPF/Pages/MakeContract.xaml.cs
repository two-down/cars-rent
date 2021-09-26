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
    public partial class MakeContract : Page
    {
        private Dictionary<string, long> _renters = new Dictionary<string, long>();
        private Dictionary<string, long> _cars = new Dictionary<string, long>();

        public MakeContract(Contract contract = null)
        {
            InitializeComponent();

            cbxRideType.ItemsSource = Enum.GetValues(typeof(RideType));

            foreach (var renter in Query<Renter>.SelectAll())
                _renters.Add(renter.ToString(), renter.Id);

            foreach (var car in Query<Car>.SelectAll())
                _cars.Add(car.ToString(), car.Id);

            cbRenter.ItemsSource = _renters.Keys;
            cbCar.ItemsSource = _cars.Keys;

            if (contract != null)
            {

            }
        }

        private void cbRenter_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbRenter.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            var collectionView = (CollectionView)CollectionViewSource.GetDefaultView(cbRenter.ItemsSource);
            collectionView.Filter = s =>
                ((string)s).IndexOf(cbRenter.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private void cbCar_TextChanged(object sender, TextChangedEventArgs e)
        {
            cbCar.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            var collectionView = (CollectionView)CollectionViewSource.GetDefaultView(cbCar.ItemsSource);
            collectionView.Filter = s =>
                ((string)s).IndexOf(cbCar.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private void btnMakeContract_Click(object sender, RoutedEventArgs e)
        {
            var landlord = Query<LandLord>.SelectAll().FirstOrDefault();

            var renter = Query<Renter>.SelectById(_renters[cbRenter.SelectedItem.ToString()]);
            var car = Query<Car>.SelectById(_cars[cbCar.SelectedItem.ToString()]);

            var beginDate = DateTime.Parse(tbxBeginDate.Text);
            var endDate = DateTime.Parse(tbxEndDate.Text);
            var price = double.Parse(tbxRidePrice.Text);
            var rideType = (RideType)cbxRideType.SelectedItem;

            var contract = new Contract(landlord, renter, car, beginDate, endDate, rideType, price);

            // TODO: Проверка на одинаковые договора.

            Query<Contract>.Insert(contract);
        }
    }
}