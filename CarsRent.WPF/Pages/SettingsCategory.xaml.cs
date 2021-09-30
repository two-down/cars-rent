using CarsRent.BL.Settings;
using CarsRent.WPF.UI_Utilities;
using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Windows;
using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
using System.Linq;

namespace CarsRent.WPF.Pages
{
    public partial class SettingsCategory : Page
    {
        private readonly InputsConstructor _constructor;
        private readonly SettingsTypes _settingsType;

        public SettingsCategory(SettingsTypes settingsType)
        {
            InitializeComponent();

            _constructor = new InputsConstructor(ref spLabels, ref spInputs);
            _settingsType = settingsType;

            CreateSettingsView();
        }

        private void CreateSettingsView()
        {
            switch (_settingsType)
            {
                case SettingsTypes.GENERAL:
                    var globalSettings = SettingsManager<GlobalSettings>.Load();
                    ShowGeneral(globalSettings);
                    break;

                case SettingsTypes.DEFAULT_DATA:
                    var defaultDataSettings = SettingsManager<DefaultData>.Load();
                    ShowDefaultData(defaultDataSettings);
                    break;
            }
        }

        private void ShowDefaultData(DefaultData settings)
        {
            var name = "";
            var surname = "";
            var patronymic = "";
            var series = "";
            var number = "";
            var issueDate = "";
            var issuingOrganization = "";
            var registrationPlace = "";

            var landLord = Query<LandLord>.SelectAll().FirstOrDefault();

            if (landLord != null)
            {
                name = landLord.Passport.Name;
                surname = landLord.Passport.Surname;
                patronymic = landLord.Passport.Patronymic;
                series = landLord.Passport.Series;
                number = landLord.Passport.Number;
                issueDate = landLord.Passport.IssueDate;
                issuingOrganization = landLord.Passport.IssuingOrganization;
                registrationPlace = landLord.Passport.RegistrationPlace;
            }

            _constructor.AddTextBox("Имя", name);
            _constructor.AddTextBox("Фамилия", surname);
            _constructor.AddTextBox("Отчество", patronymic);
            _constructor.AddTextBox("Серия паспорта", series);
            _constructor.AddTextBox("Номер паспорта", number);
            _constructor.AddTextBox("Дата выдачи паспорта", issueDate);
            _constructor.AddTextBox("Кем выдан паспорт", issuingOrganization);
            _constructor.AddTextBox("Место регистрации (прописка)", registrationPlace);
        }

        private void ShowGeneral(GlobalSettings settings)
        {
            var contract = "";
            var act = "";
            var notification = "";

            if (settings != null)
            {
                contract = settings.SampleContractPath;
                act = settings.SampleActPath;
                notification = settings.SampleNotificationPath;
            }

            _constructor.AddTextBox("Путь к образцу договора", contract);
            _constructor.AddTextBox("Путь к образцу акта", act);
            _constructor.AddTextBox("Путь к образцу уведомления", notification);
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            var data = new List<object>();

            foreach (var children in spInputs.Children)
            {
                if (children is TextBox)
                {
                    var textBox = children as TextBox;
                    data.Add(textBox.Text);
                }
                else
                    throw new ArgumentException("Невозможно преобразовать инпут в данные.", nameof(children));
            }

            InputsToSettings.ConvertAndSave(_settingsType, data);
        }
    }
}