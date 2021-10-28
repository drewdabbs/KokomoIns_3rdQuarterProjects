using _01Project_KomodoCafe_ClassList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _01UnitTests_KomodoCafe
{
    [TestClass]
    public class Test_KomodoCafeMethods
    {
        KomodoCafe_Repo _cafeRepo = new KomodoCafe_Repo();

        [TestMethod]
        public void Test_AddNewItemToMenu()
        {
            
            KomodoCafeMenuItem menuItem = new KomodoCafeMenuItem();
            List<KomodoCafeMenuItem> menuList = _cafeRepo.ShowAllMenuItems();
            int count = menuList.Count;

            _cafeRepo.AddNewItemToMenu(menuItem);

            List<KomodoCafeMenuItem> updatedMenuList = _cafeRepo.ShowAllMenuItems();
            int newCount = updatedMenuList.Count;

            bool result = newCount == (count + 1) ? true : false;
        }
        [TestMethod]
        public void Test_ShowAllMenuItems()
        {
            

        }
        [TestMethod]
        public void Test_DeleteByMenuItemNumber()
        {
            KomodoCafeMenuItem menuItem = new KomodoCafeMenuItem();
            menuItem.MealNum = 1;
            _cafeRepo.AddNewItemToMenu(menuItem);

            bool actual = _cafeRepo.DeleteByMenuItemNum(1,menuItem);
            bool expected = true;

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Test_FindMenuItemByItemNum()
        {
            //KomodoCafeMenuItem menuItem = new KomodoCafeMenuItem();
            //menuItem.MealNum = 1;
            //_cafeRepo.AddNewItemToMenu(menuItem);



            //int menuItemInt = Convert.ToInt32(menuItem.MealNum);
            //int mealNumber = _cafeRepo.FindMenuItemByItemNum(menuItemInt);

            //Assert.IsNotNull(mealNumber);
            //Assert.AreEqual(mealNumber, menuItem.MealNum);
        }
    }

}
