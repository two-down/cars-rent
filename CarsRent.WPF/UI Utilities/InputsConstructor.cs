using System;
using System.Windows.Controls;

namespace CarsRent.WPF.UI_Utilities
{
    public class InputsConstructor
    {
        private readonly StackPanel _labelsPanel;
        private readonly StackPanel _inputsPanel;

        public InputsConstructor(ref StackPanel labelsPanel, ref StackPanel inputsPanel)
        {
            if (labelsPanel == null)
                throw new ArgumentNullException(nameof(labelsPanel));
            if (inputsPanel == null)
                throw new ArgumentNullException(nameof(inputsPanel));

            _labelsPanel = labelsPanel;
            _inputsPanel = inputsPanel;
        }

        public void AddTextBox(string labelText, string textBoxText)
        {
            var label = new Label();
            label.Content = labelText;
            label.FontSize = 18;

            var textbox = new TextBox();
            textbox.FontSize = 24;
            textbox.Text = textBoxText;

            _labelsPanel.Children.Add(label);
            _inputsPanel.Children.Add(textbox);
        }
    }
}