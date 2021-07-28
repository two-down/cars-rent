using System;
using System.Windows.Controls;

namespace CarsRent.WPF.UI_Utilities
{
    public class SettingsConstructor
    {
        private readonly StackPanel _labelsPanel;
        private readonly StackPanel _inputsPanel;

        public SettingsConstructor(ref StackPanel labelsPanel, ref StackPanel inputsPanel)
        {
            if (labelsPanel == null)
                throw new ArgumentNullException(nameof(labelsPanel));
            if (inputsPanel == null)
                throw new ArgumentNullException(nameof(inputsPanel));

            _labelsPanel = labelsPanel;
            _inputsPanel = inputsPanel;
        }

        public void AddTextBox(string labelText)
        {
            var label = new Label();
            label.Content = labelText;

            var textbox = new TextBox();

            _labelsPanel.Children.Add(label);
            _inputsPanel.Children.Add(textbox);
        }
    }
}