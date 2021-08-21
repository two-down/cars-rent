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
    /// Логика взаимодействия для RenterActions.xaml
    /// </summary>
    public partial class RenterActions : Page
    {
        private Renter _currentRenter;

        public RenterActions(Renter renter = null)
        {
            InitializeComponent();

            _currentRenter = renter;

            FillFields();
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            var name = tbxName.Text;
            var surname = tbxSurname.Text;
            var patronymic = tbxPatronymic.Text;
            var series = tbxSeries.Text;
            var number = tbxNumber.Text;
            var issueDate = DateTime.Parse(tbxIssueDate.Text);
            var issuingOrganization = tbxIssuingOrganization.Text;
            var registrationPlace = tbxRegistrationPlace.Text;

            var renter = new Renter(name, surname, patronymic, series, number, issueDate, issuingOrganization, registrationPlace);

            // TODO: Проверка на существование.

            if (_currentRenter == null)
            {
                _currentRenter = renter;
                Query<Renter>.Insert(_currentRenter);
            }
            else
            {
                var id = _currentRenter.Id;
                _currentRenter = renter;
                _currentRenter.Id = id;
                Query<Renter>.Update(_currentRenter);
            }
        }

        private void FillFields()
        {
            var name = "";
            var surname = "";
            var patronymic = "";
            var series = "";
            var number = "";
            var issueDate = "";
            var issuingOrganization = "";
            var registrationPlace = "";

            if (_currentRenter != null)
            {
                name = _currentRenter.Name;
                surname = _currentRenter.Surname;
                patronymic = _currentRenter.Patronymic;
                series = _currentRenter.Series;
                number = _currentRenter.Number;
                issueDate = _currentRenter.IssueDate.ToString();
                issuingOrganization = _currentRenter.IssuingOrganization;
                registrationPlace = _currentRenter.RegistrationPlace;
            }

            tbxName.Text = name;
            tbxSurname.Text = surname;
            tbxPatronymic.Text = patronymic;
            tbxSeries.Text = series;
            tbxNumber.Text = number;
            tbxIssueDate.Text = issueDate;
            tbxIssuingOrganization.Text = issuingOrganization;
            tbxRegistrationPlace.Text = registrationPlace;
        }
    }
}