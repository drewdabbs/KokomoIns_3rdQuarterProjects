using _01Project_KomodoCafe_ClassList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01UnitTests_KomodoCafe
{
    [TestClass]
    public class Test_KomodoCafeMethods
    {
        private KomodoCafe_Repo _cafeRepo;
        private KomodoCafeMenuItem _menuItem;
        private KomodoCafeMenuItem _menuItem2;

        [TestInitialize]
        public void Arrange()
        {
            _cafeRepo = new KomodoCafe_Repo();
            _menuItem = new KomodoCafeMenuItem(5, "Tomato Soup and Grilled Cheese Sandwich", "Creamy tomato and basil soup served with our 3 cheese grilled cheese sandwich.", new List<string> { "Tomato", "condensed milk", "basil", "sourdouogh bread", "cheddar cheese", "havarti cheese", "provolone cheese", "salt", "pepper" }, 11.25);
            _menuItem2 = new KomodoCafeMenuItem(6, "House Salad", "Mix of iceberg and romaine lettuce, cherry tomatoes, red onion, feta cheese is optional.", new List<string> { "Iceberg lettuce", "Romaine lettuce", "cherry tomatoes", "feta cheese", "house dressing" }, 9.25);
            _cafeRepo.AddNewItemToMenu(_menuItem);
        }
        [TestMethod]
        public void Test_AddNewItemToMenu()
        {
            bool itemAdded = _cafeRepo.AddNewItemToMenu(_menuItem2);

            Assert.AreEqual(true, itemAdded);
        }
        [TestMethod]
        public void Test_ShowAllMenuItems()
        {
            List<KomodoCafeMenuItem> _menuList = _cafeRepo.ShowAllMenuItems();

            Assert.IsNotNull(_menuList);

        }
        [TestMethod]
        public void Test_DeleteByMenuItemNumber()
        {

            bool itemDeleted = _cafeRepo.DeleteByMenuItemNum(_menuItem.MealNum, _menuItem);

            Assert.IsTrue(itemDeleted);
        }
        [TestMethod]
        public void Test_FindMenuItemByItemNum()
        {
            KomodoCafeMenuItem menuItem = _cafeRepo.FindMenuItemByItemNum(_menuItem.MealNum);

            Assert.IsNotNull(menuItem);
        }
    }

}
