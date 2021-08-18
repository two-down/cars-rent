using CarsRent.BL.Settings;
using CarsRent.WPF.UI_Utilities;
using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Windows;

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
                    var settings = SettingsManager<GlobalSettings>.Load();
                    ShowGeneral(settings);
                    break;
            }
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