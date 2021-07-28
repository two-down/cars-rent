using CarsRent.BL.Settings;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CarsRent.WPF.Pages
{
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();

            treeViewSettingsCategory.ItemsSource = TreeViewConverter.SettingsTypesToString.Keys;
        }

        private void treeViewSettingsCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewConverter.SettingsTypesToString.TryGetValue(treeViewSettingsCategory.SelectedItem.ToString(), out var category);
            settingsFrame.Content = new SettingsCategory(category);
        }
    }
}