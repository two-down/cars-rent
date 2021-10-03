using CarsRent.BL.BDRequests;
using CarsRent.BL.Entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CarsRent.WPF.UI_Utilities
{
    public class ObjectList<T> : BaseObjectList where T : BaseEntity
    {
        public List<T> Objects { get; private set; }
        private StackPanel _stackPanel;
        private int _pageElementsCount;

        public ObjectList(ref StackPanel stackPanel, int pageElementsCount)
        {
            _stackPanel = stackPanel;
            _pageElementsCount = pageElementsCount;

            UpdateList(0);
        }

        public override void UpdateList(int pageNumber)
        {
            Objects = Query<T>.SelectRange(pageNumber * _pageElementsCount, _pageElementsCount);

            ShowList(Objects);
        }

        public override int GetItemsCount()
        {
            return Query<T>.Count();
        }

        public void ShowList(List<T> objects)
        {
            List<UIElement> list = new List<UIElement>();

            foreach (var children in _stackPanel.Children)
            {
                var uiEl = children as UIElement;
                list.Add(uiEl);
            }

            foreach (var children in list)
                _stackPanel.Children.Remove(children);

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

        public override void DeleteSelectedObject()
        {
            var obj = GetSelectedObject();

            Query<T>.Delete(obj);
        }
    }
}