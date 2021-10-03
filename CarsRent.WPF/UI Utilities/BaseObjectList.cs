namespace CarsRent.WPF.UI_Utilities
{
    public abstract class BaseObjectList
    {
        public BaseObjectList() { }

        public abstract void UpdateList(int pageNumber);
        public abstract void DeleteSelectedObject();
        public abstract int GetItemsCount();
    }
}