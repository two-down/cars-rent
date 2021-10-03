using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
using CarsRent.WPF.UI_Utilities;
using System.Windows;
using System.Windows.Controls;

namespace CarsRent.WPF.Pages
{
    public partial class ListPage : Page
    {
        private ListPageSwitcher _listPageSwitcher;
        private MainWindow _mainWindow;
        private readonly string _objectType;
        private int _pageNumber;
        private int _itemsCount;

        public ListPage(string objectType, ref MainWindow mainWindow)
        {
            InitializeComponent();

            _pageNumber = 0;

            _listPageSwitcher = new ListPageSwitcher(ref spItems, objectType);
            _itemsCount = _listPageSwitcher.GetItemsCount();
            
            _objectType = objectType;

            _mainWindow = mainWindow;
        }

        private void Update()
        {
            _listPageSwitcher.UpdateList(_pageNumber);
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (_pageNumber != 0)
                ChangePage(_pageNumber - 1);
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (_pageNumber + 1 * _listPageSwitcher._itemsInPageCount <= _itemsCount)
                ChangePage(_pageNumber + 1);
        }

        private void btnGoToPage_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbxPageNumber.Text, out var pageNumber) == true)
            {
                pageNumber--;

                if (pageNumber > 0)
                    if (pageNumber < _itemsCount / _listPageSwitcher._itemsInPageCount)
                        ChangePage(pageNumber);
            }
        }

        private void ChangePage(int targetPageNumber)
        {
            _pageNumber = targetPageNumber;
            Update();
            tbxPageNumber.Text = (_pageNumber + 1).ToString();
        }
    }
}