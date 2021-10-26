using _01Project_KomodoCafe_ClassList;
using KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Project_KomodoCafe
{
    public class ProgramUI
    {
        private readonly KomodoCafe_Repo _cafeRepo = new KomodoCafe_Repo();
        public void Run()
        {
            RunMenu();
        }
        public void RunMenu()
        {
            
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("\n\nWelcome to your Komodo Cafe Menu Application.\n\n" +
                    "From here you can Make, Remove or List all items in the menu.\n\n" +
                    "Choose from the following:\n\n" +
                    "1. Make a new menu item and add it to the menu.\n\n" +
                    "2. List all items currently on the menu.\n\n" +
                    "3. Remove a menu item from the menu.\n\n" +
                    "4. Exit.");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        DisplayAllMenuItems();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter in a valid number between 1 and 4.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddNewMenuItem()
        {
            //Meal Number
            Console.Clear();
            KomodoCafeMenuItem newItem = new KomodoCafeMenuItem();
            Console.WriteLine("Please enter the menu number: \n");
            string newMealNum = Console.ReadLine();
            try
            {
                newItem.MealNum = Convert.ToInt32(newMealNum);
            }
            catch
            {
                Console.WriteLine("\n\nLooks like there was an error. Meal mumbers are whole numbers. Please try again.");
            }
            //Meal Name
            Console.WriteLine("\n\nWhat is the name of this item or meal?");
            newItem.MealName = Console.ReadLine();
            //Meal Price
            Console.WriteLine("\n\nWhat is the price of this menu item, before applying tax?\n\n" +
                "Note: This entry accepts decimal values so type out the dollar and cent amount.\n\n" +
                "Example: 7.95");
            string menuDouble = Console.ReadLine();
            try
            {
                newItem.Price = Convert.ToDouble(menuDouble);
            }
            catch
            {
                Console.WriteLine("\n\nThere was an error reading your price. Please only enter the valuse in dollars and cents.");
            }
            //Description
            Console.WriteLine("\n\nPlease type out a description of the new item:\n\n");
            newItem.MealDescription = Console.ReadLine();

            //Ingredients
            newItem._Ingredients = new List<string>();
            Console.WriteLine("\n\nPlease type out the ingredients in the item separated by a comma.\n\n" +
                "For example: american cheese, beef, lettuce, tomato.");
            string[] ingredientArray = Console.ReadLine().Split(',');
            foreach(string ingredient in ingredientArray)
            {
                newItem._Ingredients.Add(ingredient);
            }
            //Add method
            _cafeRepo.AddNewItemToMenu(newItem);
            Console.WriteLine("\n\nItem Added. Please press any key to continue...");
            Console.ReadKey();

        }
        private void DeleteMenuItem()
        {

            Console.Clear();
            Console.WriteLine("Enter the meal item # you would like to delete: ");
            string menuNum = Console.ReadLine();
            int menuInt = Int32.Parse(menuNum);
            KomodoCafeMenuItem menuItem = _cafeRepo.FindMenuItemByItemNum(menuInt);
            if (menuItem.MealNum == menuInt)
            {
                _cafeRepo.DeleteByMenuItemNum(menuInt, menuItem);
                Console.WriteLine("Menu item removed.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Menu item not found.");
            }


        }
        public void DisplayAllMenuItems()
        {
            Console.Clear();
            List<KomodoCafeMenuItem> _menuItems = _cafeRepo.ShowAllMenuItems();
            foreach (KomodoCafeMenuItem meal in _menuItems)
            {
                DisplayMenuItems(meal);
                Console.WriteLine("__________________________\n");
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
        public void DisplayMenuItems(KomodoCafeMenuItem menuItem)
        {
            Console.WriteLine($"Menu Item #:{menuItem.MealNum}");
            Console.WriteLine($"Item/Meal Name: {menuItem.MealName}");
            Console.WriteLine($"Price: {menuItem.Price}");
            Console.WriteLine($"Description: {menuItem.MealDescription}");
            //menuItem._Ingredients = string.Join(Environment.NewLine, menuItem._Ingredients);
            foreach(string ingredient in menuItem._Ingredients)
            {
                Console.WriteLine(ingredient);
            }
            //Console.WriteLine($"A list of ingredients: {menuItem._Ingredients}");
        }
    }
}
