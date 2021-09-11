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
    public partial class InsertPage : Page
    {
        private InputsConstructor _inputsConstructor;
        private MainWindow _mainWindow;
        private readonly string _objectType;

        public InsertPage(ref MainWindow window, string objectType, BaseEntity item = null)
        {
            InitializeComponent();

            _inputsConstructor = new InputsConstructor(ref spLabels, ref spInputs);
            _mainWindow = window;
            _objectType = objectType;

            CreateLayaout(item);
        }

        private void CreateLayaout(BaseEntity item = null)
        {
            var items = new List<string>();
            var labels = new List<string>();

            if (item != null)
            {
                items = item.GetData();

                if (_objectType == "renters")
                    labels = LabelsForInputs.Human;
                else
                    labels = LabelsForInputs.Car;
            }
            else
            {
                int counter;

                if (_objectType == "renters")
                {
                    counter = 8;
                    labels = LabelsForInputs.Human;
                }
                else
                {
                    counter = 13;
                    labels = LabelsForInputs.Car;
                }

                for (var i = 0; i < counter; i++)
                    items.Add("");
            }

            for (var i = 0; i < items.Count; i++)
                _inputsConstructor.AddTextBox(labels[i], items[i]);

            if (item != null)
                _inputsConstructor.AddTextBox("ID", item.Id.ToString());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.mainFrame.Content = new ListPage(_objectType, ref _mainWindow);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var list = InputDataToStringList.Convert(spInputs);

            InsertListAsObject.Insert(list, _objectType);
        }
    }
}