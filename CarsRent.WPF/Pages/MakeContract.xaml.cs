using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
using CarsRent.BL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CarsRent.WPF.Pages
{
    public partial class MakeContract : Page
    {
        private Dictionary<string, long> _renters = new Dictionary<string, long>();
        private Dictionary<string, long> _cars = new Dictionary<string, long>();

        private Contract _currentContract;

        public MakeContract(Contract contract = null)
        {
            InitializeComponent();

            _currentContract = contract;

            cbxRideType.ItemsSource = Enum.GetValues(typeof(RideType));
            cbxRideType.SelectedItem = cbxRideType.Items[0];

            foreach (var renter in Query<Renter>.SelectAll())
                _renters.Add(renter.ToString(), renter.Id);

            foreach (var car in Query<Car>.SelectAll())
                _cars.Add($"{car.Brand} {car.Color}", car.Id);

            cbRenter.ItemsSource = _renters.Keys;
            cbCar.ItemsSource = _cars.Keys;

            if (_currentContract != null)
            {
                cbCar.SelectedItem = _cars.Where(x => x.Value == _currentContract.Car.Id).FirstOrDefault().Key;
                cbRenter.SelectedItem = _renters.Where(x => x.Value == _currentContract.Renter.Id).FirstOrDefault().Key;
                tbxBeginDate.Text = _currentContract.ConclusionDate;
                tbxEndDate.Text = _currentContract.EndDate;
                tbxRidePrice.Text = _currentContract.RidePrice.ToString();
                cbxRideType.SelectedItem = _currentContract.RideType;
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

            Renter renter;
            if (cbRenter.SelectedItem != null)
                renter = Query<Renter>.SelectById(_renters[cbRenter.SelectedItem.ToString()]);
            else
                renter = null;

            Car car;
            if (cbRenter.SelectedItem != null)
                car = Query<Car>.SelectById(_cars[cbCar.SelectedItem.ToString()]);
            else
                car = null;

            var beginDate = tbxBeginDate.Text;
            var endDate = tbxEndDate.Text;
            var price = tbxRidePrice.Text;

            RideType rideType;
            if (cbxRideType.SelectedItem != null)
                rideType = (RideType)cbxRideType.SelectedItem;
            else
                rideType = RideType.InTheCity;

            if (_currentContract != null)
            {
                _currentContract.LandLord = landlord;
                _currentContract.Renter = renter;
                _currentContract.Car = car;
                _currentContract.ConclusionDate = beginDate;
                _currentContract.EndDate = endDate;
                _currentContract.RideType = rideType;
                _currentContract.RidePrice = price;

                var validator = new ValidationHelper<Contract>();

                if (validator.Validate(_currentContract) == true)
                    Query<Contract>.Update(_currentContract);
                else
                    MessageBox.Show(validator.Error, "Ошибка валидации");
            }
            else
            {
                _currentContract = new Contract(landlord, renter, car, beginDate, endDate, rideType, price);

                var validator = new ValidationHelper<Contract>();

                if (validator.Validate(_currentContract) == true)
                    Query<Contract>.Insert(_currentContract);
                else
                    MessageBox.Show(validator.Error, "Ошибка валидации");
            }
        }
    }
}