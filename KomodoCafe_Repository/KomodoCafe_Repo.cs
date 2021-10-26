using _01Project_KomodoCafe_ClassList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class KomodoCafe_Repo
    {
        public Dictionary<int, KomodoCafeMenuItem> _menu = new Dictionary<int, KomodoCafeMenuItem>();

        //Create
        public bool AddNewItemToMenu(KomodoCafeMenuItem menuItem)
        {
            int startCount = _menu.Count;
            _menu.Add(menuItem.MealNum, menuItem);
            bool wasAdded = _menu.Count > startCount ? true : false;
            return wasAdded;
        }

        //Read
        public List<KomodoCafeMenuItem> ShowAllMenuItems()
        {
            List<KomodoCafeMenuItem> _menuList = new List<KomodoCafeMenuItem>();
            foreach (KeyValuePair<int, KomodoCafeMenuItem> kvp in _menu)
            {
                _menuList.Add(kvp.Value);
            }
            return _menuList;
        }

        //Delete
        public bool DeleteByMenuItemNum(int menuKey, KomodoCafeMenuItem menuItem)
        {
            KomodoCafeMenuItem menuMeal = FindMenuItemByItemNum(menuKey);
            bool deleteResult = _menu.Remove(menuKey);
            return deleteResult;
        }

        //Find
        public KomodoCafeMenuItem FindMenuItemByItemNum(int menuEntry)
        {
            foreach (KeyValuePair<int, KomodoCafeMenuItem> kvp in _menu)
            {
                if (kvp.Key == menuEntry)
                    return kvp.Value;
            }
            return null;
        }
    }

}
