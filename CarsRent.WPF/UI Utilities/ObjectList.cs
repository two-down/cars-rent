using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CarsRent.WPF.UI_Utilities
{
    public class ObjectList<T> where T : BaseEntity
    {
        public List<T> Objects { get; private set; }
        private StackPanel _stackPanel;

        public ObjectList(ref StackPanel stackPanel)
        {
            _stackPanel = stackPanel;

            UpdateList();

            ShowList(Objects);
        }

        public void UpdateList()
        {
            Objects = Query<T>.SelectAll();
        }

        public void ShowList(List<T> objects)
        {
            var listBox = new ListBox();

            foreach (var obj in objects)
            {
                var item = new ListBoxItem();
                item.Content = obj.ToString();
                item.Tag = obj.Id;

                listBox.Items.Add(item);
            }

            _stackPanel.Children.Add(listBox);
        }

        public T GetSelectedObject()
        {
            var listBox = _stackPanel.Children[0] as ListBox;
            var item = listBox.SelectedItem as ListBoxItem;

            T obj;

            try
            {
                obj = Query<T>.SelectById(int.Parse(item.Tag.ToString()));
            }
            catch (NullReferenceException ex)
            {
                obj = null;
            }

            if (obj == null)
                throw new ArgumentException("Выберите из списка, прежде чем удалять/редактировать.");

            return obj;
        }

        public void DeleteSelectedObject()
        {
            var obj = GetSelectedObject();

            Query<T>.Delete(obj);
        }
    }
}