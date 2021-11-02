using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04KomodoCompOutings_ClassLibrary
{
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
    public class Outings
    {
        public EventType TypeOfEvent { get; set;}
        public int NumberAttended { get; set; }
        public DateTime EventDate { get; set; }
        public decimal CostPer { get; set; }
        public decimal TotalCost {
            get
            {
                return Convert.ToDecimal(NumberAttended) * CostPer;
            }
         }
        public Outings() { }
        public Outings(EventType eventType, int numAttended, DateTime eventDate, decimal costPer)
        {
            TypeOfEvent = eventType;
            NumberAttended = numAttended;
            EventDate = eventDate;
            CostPer = costPer;
        }
    }
}
