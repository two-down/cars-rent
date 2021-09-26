using CarsRent.BL.Entities;
using System.Windows.Controls;

namespace CarsRent.WPF.UI_Utilities
{
    public class ListPageSwitcher
    {
        private BaseObjectList objectList;

        public ListPageSwitcher(ref StackPanel stackPanel, string objectType)
        {
            switch (objectType)
            {
                case "renters":
                    objectList = new ObjectList<Renter>(ref stackPanel);
                    break;

                case "cars":
                    objectList = new ObjectList<Car>(ref stackPanel);
                    break;

                case "contracts":
                    objectList = new ObjectList<Contract>(ref stackPanel);
                    break;
            }
        }

        public void UpdateList()
        {
            objectList.UpdateList();
        }

        public void DeleteSelectedItem()
        {
            objectList.DeleteSelectedObject();
        }
    }
}