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

        [TestInitialize]
        public void Arrange()
        {
            _cafeRepo = new KomodoCafe_Repo();
            _menuItem = new KomodoCafeMenuItem(5, "Tomato Soup and Grilled Cheese Sandwich", "Creamy tomato and basil soup served with our 3 cheese grilled cheese sandwich.", new List<string> { "Tomato", "condensed milk", "basil", "sourdouogh bread", "cheddar cheese", "havarti cheese", "provolone cheese", "salt", "pepper" }, 11.25);
            _cafeRepo.AddNewItemToMenu(_menuItem);
        }
        [TestMethod]
        public void Test_AddNewItemToMenu()
        {
            bool itemAdded = _cafeRepo.AddNewItemToMenu(_menuItem);

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
            //KomodoCafeMenuItem menuItem = _cafeRepo.DeleteByMenuItemNum(_menuItem.MealNum, menuItem);

            bool itemDeleted = _cafeRepo.DeleteByMenuItemNum(_menuItem.MealName);
            //menuItem.MealNum = 1;
            //_cafeRepo.AddNewItemToMenu(menuItem);

            //bool actual = _cafeRepo.DeleteByMenuItemNum(1,menuItem);
            //bool expected = true;

            //Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Test_FindMenuItemByItemNum()
        {
            KomodoCafeMenuItem menuItem = _cafeRepo.FindMenuItemByItemNum(_menuItem.MealNum);

            Assert.IsNotNull(menuItem);
        }
    }

}
