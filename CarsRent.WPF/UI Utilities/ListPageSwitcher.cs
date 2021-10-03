using CarsRent.BL.Entities;
using System.Windows.Controls;

namespace CarsRent.WPF.UI_Utilities
{
    public class ListPageSwitcher
    {
        private BaseObjectList objectList;
        public readonly int _itemsInPageCount = 1;

        public ListPageSwitcher(ref StackPanel stackPanel, string objectType)
        {
            switch (objectType)
            {
                case "renters":
                    objectList = new ObjectList<Renter>(ref stackPanel, _itemsInPageCount);
                    break;

                case "cars":
                    objectList = new ObjectList<Car>(ref stackPanel, _itemsInPageCount);
                    break;

                case "contracts":
                    objectList = new ObjectList<Contract>(ref stackPanel, _itemsInPageCount);
                    break;
            }
        }

        public void UpdateList(int pageNumber)
        {
            objectList.UpdateList(pageNumber);
        }

        public void DeleteSelectedItem()
        {
            objectList.DeleteSelectedObject();
        }

        public int GetItemsCount()
        {
            return objectList.GetItemsCount();
        }
    }
}