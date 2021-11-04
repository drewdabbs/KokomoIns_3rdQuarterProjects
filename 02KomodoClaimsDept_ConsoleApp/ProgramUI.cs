using _02KomodoClaimsDept_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02KomodoClaimsDept_ConsoleApp
{
    public class ProgramUI
    {
        private KomodoClaimsDept_Repo _claimsRepo = new KomodoClaimsDept_Repo();
        public void Run()
        {
            SeedClaimsToQueue();
            RunMenu();
        }
        private void RunMenu()
        {
            bool runApplication = true;
            while (runApplication)
            {
                Console.Clear();
                Console.WriteLine("\n\nWelcome to the Komodo Insurance Claims Application." +
                    "\n\nFrom here you can:" +
                    "\n\n1. See a list of all claims." +
                    "\n\n2. Display and choose to work on the next avalible claim." +
                    "\n\n3. Add a new claim." +
                    "\n\n4. Exit.\n\n");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowAllCurrentClaims();
                        break;
                    case "2":
                        DisplayNextInQueueMenu();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        runApplication = false;
                        break;
                    default:
                        Console.WriteLine("Invalid entry. Please press 1, 2, 3, or 4 and hit enter to make a selection." +
                            "Press anykey to try again.");
                        break;
                }
            }
        }
        private void DisplayNextInQueueMenu()
        {
            Queue<Claim> firstInQueue = _claimsRepo.SeeAllClaims();
            Claim firstClaim = firstInQueue.Peek();
            Console.Clear();
            Console.WriteLine("\nClaim ID _____ Claim Type _____ Claim Amount _____ Date of Incident _____ Date of Claim _____ ");
            Console.WriteLine($"\n    {firstClaim.ClaimID}            {firstClaim.TypeOfCLaim}            {firstClaim.ClaimAmount}              {firstClaim.DateOfIncident.ToString("MMM dd yyyy")}          {firstClaim.DateOfClaim.ToString("MMM dd yyyy")}");
            Console.WriteLine($"\nDescription:  {firstClaim.Description }");
            Console.WriteLine($"\n Is it true or false that the claim was submitted on time?\n" +
                $"\n{firstClaim.IsValid}\n");
            
            Console.WriteLine("\n\nWould you care to take this claim and work on it? (y/n)\n\n");
            while ((Console.ReadLine().ToLower() == "y"))
            {
                firstInQueue.Dequeue();
                Console.WriteLine("\n\nYou have begun working on the claim and it has been removed from the queue.\n\n" +
                    "\nPress any key to continue...\n");
            }
        }
        private void ShowAllCurrentClaims()
        {
            Queue<Claim> currentQueue = _claimsRepo.SeeAllClaims();
            Console.Clear();
            foreach(Claim queuedClaim in currentQueue)
            {
                Console.WriteLine("\nClaim ID _____ Claim Type _____ Claim Amount _____ Date of Incident _____ Date of Claim _____ ");
                Console.WriteLine($"\n    {queuedClaim.ClaimID}            {queuedClaim.TypeOfCLaim}            {queuedClaim.ClaimAmount}              {queuedClaim.DateOfIncident.ToString("MMM dd yyyy")}           {queuedClaim.DateOfClaim.ToString("MMM dd yyyy")}");
                Console.WriteLine($"\nDescription:  {queuedClaim.Description }");
                Console.WriteLine($"\n Is it true or false that the claim was submitted on time?\n" +
                    $"\n{queuedClaim.IsValid}\n");
                Console.WriteLine("_________________________________________________\n");
            }
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
        private void AddNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();
            Console.WriteLine("\n\nLet us get started on a new claim!" +
                "\nFirst what is the claim ID#?");
            string claimNumString = Console.ReadLine();
            try
            {
                newClaim.ClaimID = int.Parse(claimNumString);
            }
            catch
            {
                Console.WriteLine("\n\nSomething went wrong, did you only type a whole number?" +
                    "Press any key to try again.");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("\n\nWhat type of claim is this? Select from the following:" +
                "\n\n1. A new claim on a vehicle." +
                "\n\n2. A new claim on a house." +
                "\n\n3. A theft of some kind.");
            string claimTypeString = Console.ReadLine();
            //bool claimTypeMenu = true;
            switch (claimTypeString)
            {
                case "1":
                    newClaim.TypeOfCLaim = ClaimType.Vehicle;
                    //claimTypeMenu = false;
                    break;
                case "2":
                    newClaim.TypeOfCLaim = ClaimType.Home;
                    //claimTypeMenu = false;
                    break;
                case "3":
                    newClaim.TypeOfCLaim = ClaimType.Theft;
                    //claimTypeMenu = false;
                    break;
                default:
                    Console.WriteLine("\n\nSomething went wrong, only type a 1, 2, or a 3." +
                    "Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
            Console.Clear();
            Console.WriteLine("\n\nPlease carefully type out a description of what the client is claiming.\n\n");
            string description = Console.ReadLine();
            newClaim.Description = description;
            Console.Clear();
            Console.WriteLine("\n\nWhat is the amount of damages the client is claiming?\n\n");
            string claimAmountString = Console.ReadLine();
            try
            {
                newClaim.ClaimAmount = double.Parse(claimAmountString);
            }
            catch
            {
                Console.WriteLine("\n\nSomething went wrong, did you only numbers in a dollar amount format?\n" +
                    "Example: 2359.89\n" +
                    "Press any key to try again.");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("\n\nWhat was the date of the incident?\n\n");
            string incidentDate = Console.ReadLine();
            try
            {
                newClaim.DateOfIncident = DateTime.Parse(incidentDate);
            }
            catch
            {
                Console.WriteLine("\n\nPlease only use a valid date structure." +
                    "\nPress any key to try again...");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("What is the date of the claim?");
            string claimDate = Console.ReadLine();
            try
            {
                newClaim.DateOfClaim = DateTime.Parse(claimDate);
            }
            catch
            {
                Console.WriteLine("\n\nPlease only use a valid date structure." +
                    "\nPress any key to try again...");
                Console.ReadKey();
            }
            _claimsRepo.AddCLaim(newClaim);
        }
        public void SeedClaimsToQueue()
        {
            Claim claim1 = new Claim(1, ClaimType.Vehicle, "Claimant rear ended while sitting at a stoplight",
                4500.56, new DateTime(2021,10, 7), new DateTime(2021, 10, 24));
            Claim claim2 = new Claim(2, ClaimType.Home, "Wind damage from a storm on July, 18, 2021",
                8500.00, new DateTime(2021, 7, 18), new DateTime(2021, 9, 13));
            Claim claim3 = new Claim(3, ClaimType.Theft, "Home was burglarized while the homeowners were away on vacation",
                19075.00, new DateTime(2021, 10, 26), new DateTime(2021, 10, 27));

            _claimsRepo.AddCLaim(claim1);
            _claimsRepo.AddCLaim(claim2);
            _claimsRepo.AddCLaim(claim3);
        }
    }
}
