using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02KomodoClaimsDept_ClassLibrary
{
    public enum ClaimType
    {
        Vehicle = 1, Home, Theft
    }
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfCLaim { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                System.TimeSpan difference = DateOfClaim - DateOfIncident;
                if(difference.Days < 31)
                {
                    return true;
                }
                return false;
            }
        }
        public Claim() { }
        public Claim(int claimID, ClaimType typeOfCLaim, string description, double claimAmmount, DateTime incidentDate, DateTime claimDate)
        {
            ClaimID = claimID;
            TypeOfCLaim = typeOfCLaim;
            Description = description;
            ClaimAmount = claimAmmount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
        }
    }
}
