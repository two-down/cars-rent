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
    public partial class ListPage : Page
    {
        private ListPageSwitcher _listPageSwitcher;
        private MainWindow _mainWindow;
        private readonly string _objectType;

        public ListPage(string objectType, ref MainWindow mainWindow)
        {
            InitializeComponent();

            _listPageSwitcher = new ListPageSwitcher(ref spItems, objectType);
            _objectType = objectType;

            _mainWindow = mainWindow;
        }

        private void Update()
        {
            _listPageSwitcher.UpdateList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_objectType == "contracts")
                _mainWindow.mainFrame.Content = new MakeContract();
            else
                _mainWindow.mainFrame.Content = new InsertPage(ref _mainWindow, _objectType);
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var listBox = spItems.Children[0] as ListBox;
            var selectedItem = listBox.SelectedItem as ListBoxItem;

            BaseEntity item;

            if (_objectType == "renters")
                item = Query<Renter>.SelectById(long.Parse(selectedItem.Tag.ToString()));
            else if (_objectType == "cars")
                item = Query<Car>.SelectById(long.Parse(selectedItem.Tag.ToString()));
            else
                item = Query<Contract>.SelectById(long.Parse(selectedItem.Tag.ToString()));

            if (_objectType == "contracts")
                _mainWindow.mainFrame.Content = new MakeContract(item as Contract);
            else
                _mainWindow.mainFrame.Content = new InsertPage(ref _mainWindow, _objectType, item);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _listPageSwitcher.DeleteSelectedItem();
            Update();
        }
    }
}