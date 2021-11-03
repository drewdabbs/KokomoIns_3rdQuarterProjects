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
                    "3. Show outings by date.\n" +
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
            List<Outings> outingsList = _outingsRepo.ListAllOutings();
            
            
            //var costByOuting =
            //    from outing in outingsList
            //    group outing by outing.TypeOfEvent into eventTypes
            //    select new
            //    {
            //        Event = eventTypes.Key,
            //        OutingCost = eventTypes.Sum(cost => cost.TotalCost)
            //    };
            
            //Console.WriteLine($"Total cost is: {costByOuting}");
            //Console.ReadKey();
            
            
            //foreach (Outings outing in outingsList)
            //{
            //    if(outing.TypeOfEvent == EventType.Golf)
            //    {
            //        decimal golfCost = outing.TotalCost;
            //    }
            //    return 
            //    //outing.TypeOfEvent = EventType.Golf;
            //    //decimal golfCost = outing.Sum(totalCost => totalCost.TotalCost);
            //}
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
                    "4. A concert.\n" +
                    "5. Exit.");
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
                    case "5":
                        createMenu = false;
                        break;
                    default:
                        Console.WriteLine("In Valid number entered. Please enter a number between 1 and 5\n" +
                            "Press any key to continue...\n");
                        Console.ReadKey();
                        break;
                }
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
            Console.WriteLine("\nWhat was the date of the event?\n");
            string eventDate = Console.ReadLine();
            DateTime dateOfEvent = DateTime.Parse(eventDate);
            newOuting.EventDate = dateOfEvent;
            Console.Clear();
            Console.WriteLine("\nWhat was the cost per person attending?\n");
            string perPerson = Console.ReadLine();
            decimal costPerPerson = decimal.Parse(perPerson);
            newOuting.CostPer = costPerPerson;
            _outingsRepo.AddAnOuting(newOuting);
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
