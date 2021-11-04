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
                Console.WriteLine("\nWelcome to the Komodo Slush Fund Tracker: Company Outings Application.\n\n" +
                    "Below is the menu for sellecting the approriate action.\n\n" +
                    "Type the number and hit the enter key to select the action:\n\n\n" +
                    "1. Show a list of all outings of any type.\n\n" +
                    "2. Add an outing to our database.\n\n" +
                    "3. Show outings by date.\n\n" +
                    "4. Show cost of outings combined.\n\n" +
                    "5. Find cost of outings by type of outing.\n\n" +
                    "6. Exit the application.\n\n");
                string menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1":
                        ShowAllOutings();
                        break;
                    case "2":
                        CreateOuting();
                        break;
                    case "3":
                        ShowOutingsByDateTime();
                        break;
                    case "4":
                        SumOfAllOutings();
                        break;
                    case "5":
                        FindCostByOuting();
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
        private void FindCostByOuting()
        {
            Console.Clear();
            List<Outings> outingsList = _outingsRepo.ListAllOutings();

            var outingCost = outingsList.GroupBy(type => type.TypeOfEvent).Select(type => new
            {
                TypeOfEvent = type.Key,
                TotalCost = type.Sum(totalAmount => totalAmount.TotalCost)
            }).ToList();
            outingCost.ForEach(
                row => Console.WriteLine($"\n Type of outing: {row.TypeOfEvent}, and it's current total cost: {row.TotalCost}\n"));
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
        private void SumOfAllOutings()
        {
            Console.Clear();
            List<Outings> outingsList = _outingsRepo.ListAllOutings();
            decimal totalCostAll = outingsList.Sum(totalCost => totalCost.TotalCost);
            Console.WriteLine($"\nCurrent cost for all recorded events is ${totalCostAll}\n");
            Console.WriteLine("\n\n\n\n\n\nPress any key to continue...");
            Console.ReadKey();
        }
        private void ShowAllOutings()
        {
            Console.Clear();
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
                Console.Clear();
                Console.WriteLine("\nSo, you would like to add a new outing to our company listserve.\n\n" +
                    "First, what type of company event was this?\n\n\n" +
                    "1. A golfing trip.\n\n" +
                    "2. A bowling get together.\n\n" +
                    "3. A trip to the local amuzement park.\n\n" +
                    "4. A concert.\n\n" +
                    "5. Exit.\n\n");
                string menuNum = Console.ReadLine();
                switch (menuNum)
                {
                    case "1":
                        newOuting.TypeOfEvent = EventType.Golf;
                        break;
                    case "2":
                        newOuting.TypeOfEvent = EventType.Bowling;
                        break;
                    case "3":
                        newOuting.TypeOfEvent = EventType.AmusementPark;
                        break;
                    case "4":
                        newOuting.TypeOfEvent = EventType.Concert;
                        break;
                    default:
                        Console.WriteLine("In Valid number entered. Please enter a number between 1 and 4\n" +
                            "Press any key to continue...\n");
                        Console.ReadKey();
                        break;
                }
            Console.Clear();
            Console.WriteLine("\nHow many people were in attendance?\n");
            string numAttend = Console.ReadLine();
            try
            {
                int numberAttend = int.Parse(numAttend);
                newOuting.NumberAttended = numberAttend;
            }
            catch
            {
                Console.WriteLine("\nNumber was not captured or recognized, please try again...");
            }
            Console.Clear();
            Console.WriteLine("\nWhat was the date of the event?\n" +
                "\nPlease enter the date of the event in the following format: Mon,##, ####.\n" +
                "As in Jan, 1, 2001\n");
            string eventDate = Console.ReadLine();
            DateTime dateOfEvent = DateTime.Parse(eventDate);
            newOuting.EventDate = dateOfEvent;
            Console.Clear();
            Console.WriteLine("\nWhat was the cost per person attending?\n");
            string perPerson = Console.ReadLine();
            decimal costPerPerson = decimal.Parse(perPerson);
            newOuting.CostPer = costPerPerson;
            _outingsRepo.AddAnOuting(newOuting);
            Console.WriteLine("Event has been added to the database.\n" +
                "Press any key to continue...\n\n");
            Console.ReadKey();
        }
        private void ShowOutingsByDateTime()
        {
            Console.Clear();
            Console.WriteLine("\nPlease enter the date of the event in the following format: Mon,##, ####.\n" +
                "As in Jan, 1, 2001\n");
            string dateString = Console.ReadLine();
            DateTime eventDate = DateTime.Parse(dateString);
            Outings outingDate = _outingsRepo.ListAllOutingDates(eventDate);
            if(outingDate != null)
            {
                DisplayOuting(outingDate);
            }
            else
            {
                Console.WriteLine("\nUnable to find that date.\n");
            }
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
        }
        public void DisplayOuting(Outings outing)
        {
            Console.WriteLine($"\nDate of Outing: {outing.EventDate.ToString("MMM dd yyyy")} __________ Type of Outing: {outing.TypeOfEvent.ToString()}\n" +
                $"Number of apeople in attendance: {outing.NumberAttended.ToString()} __________ Cost per person: {outing.CostPer.ToString()}\n" +
                $"Total cost of the outing: {outing.TotalCost.ToString()}");
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
