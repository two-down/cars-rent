using CarsRent.BL.Settings;
using CarsRent.WPF.UI_Utilities;
using System.Windows.Controls;

namespace CarsRent.WPF.Pages
{
    public partial class SettingsCategory : Page
    {
        public SettingsCategory(SettingsTypes settingsType)
        {
            InitializeComponent();

            CreateSettingsView(settingsType);
        }

        private void CreateSettingsView(SettingsTypes settingsType)
        {
            switch (settingsType)
            {
                case SettingsTypes.GENERAL:
                    ShowGeneral();
                    break;
            }
        }

        private void ShowGeneral()
        {
            var constructor = new SettingsConstructor(ref spLabels, ref spInputs);

            constructor.AddTextBox("SAMPLE");
        }
    }
}
