using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Project_KomodoCafe_ClassList
{
    //A meal number, so customers can say "I'll have the #5"
    //A meal name
    //A description
    //A list of ingredients,
    //A price
    public class KomodoCafeMenuItem
    {
        public int MealNum { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> _Ingredients { get; set; }
        public double Price { get; set; }
        public KomodoCafeMenuItem() { }
        public KomodoCafeMenuItem(int mealNum, string mealName, string mealDescription, List<string> _ingredients, double price)
        {
            MealNum = mealNum;
            MealName = mealName;
            MealDescription = mealDescription;
            _Ingredients = _ingredients;
            Price = price;
        }
    }
}
