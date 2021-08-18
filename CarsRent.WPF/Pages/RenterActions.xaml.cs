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

            var passport = new Passport(name, surname, patronymic, series, number, issueDate, issuingOrganization, registrationPlace);

            if (_currentRenter == null)
                _currentRenter = new Renter(passport);
            else
                _currentRenter.Passport = passport;

            // TODO: Тут должно быть сохранение.
        }

        private void FillFields(Renter renter = null)
        {
            var name = "";
            var surname = "";
            var patronymic = "";
            var series = "";
            var number = "";
            var issueDate = "";
            var issuingOrganization = "";
            var registrationPlace = "";

            if (renter != null)
            {
                name = renter.Passport.Name;
                surname = renter.Passport.Surname;
                patronymic = renter.Passport.Patronymic;
                series = renter.Passport.Series;
                number = renter.Passport.Number;
                issueDate = renter.Passport.IssueDate.ToString();
                issuingOrganization = renter.Passport.IssuingOrganization;
                registrationPlace = renter.Passport.RegistrationPlace;
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