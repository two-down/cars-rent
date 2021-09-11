using System.Collections.Generic;
using System.Windows.Controls;

namespace CarsRent.WPF.UI_Utilities
{
    public static class InputDataToStringList
    {
        public static List<string> Convert(StackPanel panel)
        {
            var list = new List<string>();

            foreach (var children in panel.Children)
            {
                if (children is TextBox)
                {
                    var textBox = children as TextBox;
                    list.Add(textBox.Text);
                }
            }

            return list;
        }
    }
}