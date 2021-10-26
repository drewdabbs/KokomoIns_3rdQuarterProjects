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
                        // Add method
                        break;
                    case "2":
                        // Remove
                        break;
                    case "3":
                        DisplayAllMenuItems();
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
            Console.WriteLine($"A list of ingredients: {menuItem._Ingredients}");
        }
    }
}
