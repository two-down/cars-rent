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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var landLordPassport = new Passport("Имя", "Фамилия", "Отчество", "1234", "567890", DateTime.Now, "ОФМС", "Новосибирск");
            var renterPassport = new Passport("Имя1", "Фамилия1", "Отчество1", "1234", "567890", DateTime.Now, "ОФМС1", "Новосибирск1");

            var landlord = new LandLord(landLordPassport);
            var renter = new Renter(renterPassport);

            CreateDocument.Create(landlord, renter, @"D:\newdoc.docx");
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new Settings();
        }
    }
}
