using _04KomodoCompOutings_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04KomodoCompOutings_ConsoleApp
{
    public class ProgramUI
    {
        private readonly CompanyOutings_Repo _outingsRepo = new CompanyOutings_Repo();
        public void Run()
        {
            SeedOutings();
            RunMenu();
        }
        private void RunMenu()
        {
            bool runApp = true;
            while (runApp)
            {
                Console.Clear();
                Console.WriteLine("\nWelcome to the Komodo Slush Fund Tracker: Company Outings Application.\n" +
                    "Below is the menu for sellecting the approriate action.\n" +
                    "Type the number and hit the enter key to select the action:\n" +
                    "1. Show a list of all outings of any type.\n" +
                    "2. Add an outing to our database.\n" +
                    "3. Update an existing outing.\n" +
                    "4. Show cost of outings combined.\n" +
                    "5. Find cost of outings by type of outing.\n" +
                    "6. Exit the application.");
                string menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1":
                        ShowAllOutings();
                        break;
                    case "2":
                        //add an outing
                        break;
                    case "3":
                        //update
                        break;
                    case "4":
                        //all costs combined
                        break;
                    case "5":
                        //find cost by outing
                        break;
                    case "6":
                        runApp = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease enter a valid number: 1, 2, 3, 4, 5, or 6.\n" +
                            "Press any key to continue...\n");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void ShowAllOutings()
        {
            List<Outings> outingsList = _outingsRepo.ListAllOutings();
            foreach (Outings outing in outingsList)
            {
                Console.WriteLine($"\nEvent Type _____ Number of Atendees _____ Date of outing _____ Cost Per Person _____ Cost of the outing _____ ");
                Console.WriteLine($"\n     {outing.TypeOfEvent}            {outing.NumberAttended}                {outing.EventDate.ToString("MMM dd yyyy")}                {outing.CostPer}             {outing.TotalCost}");
                Console.WriteLine("________________________________________________________________________");
            }
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
        }
        public void CreateOuting()
        {
            Outings newOuting = new Outings();
            bool createMenu = true;
            while (createMenu)
            {
                Console.Clear();
                Console.WriteLine("\nSo, you would like to add a new outing to our company listserve.\n" +
                    "First, what type of company event was this?\n" +
                    "1. A golfing trip.\n" +
                    "2. A bowling get together.\n" +
                    "3. A trip to the local amuzement park.\n" +
                    "4. A concert.");
            }
        }
        private void SeedOutings()
        {
            Outings out1 = new Outings(EventType.AmusementPark, 27, new DateTime(2021, 10, 24), 17.50m);
            Outings out2 = new Outings(EventType.Bowling, 17, new DateTime(2021, 9, 21), 14.55m);
            Outings out3 = new Outings(EventType.Concert, 127, new DateTime(2021, 8, 15), 27.99m);
            Outings out4 = new Outings(EventType.Golf, 7, new DateTime(2021, 7, 9), 19.29m);

            _outingsRepo.AddAnOuting(out1);
            _outingsRepo.AddAnOuting(out2);
            _outingsRepo.AddAnOuting(out3);
            _outingsRepo.AddAnOuting(out4);
        }
    }
}
