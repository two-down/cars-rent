using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CarsRent.WPF.UI_Utilities
{
    public class ObjectList<T> where T : BaseEntity
    {
        private List<T> _objects;
        private StackPanel _stackPanel;

        public ObjectList(ref StackPanel stackPanel)
        {
            _stackPanel = stackPanel;

            UpdateList();

            ShowList(_objects);
        }

        public void UpdateList()
        {
            _objects = Query<T>.SelectAll();
        }

        public void ShowList(List<T> objects)
        {
            foreach (var obj in objects)
            {
                var tbl = new Label();
                tbl.Content = obj.ToString();
                tbl.Tag = obj.Id;

                _stackPanel.Children.Add(tbl);
            }
        }
    }
}