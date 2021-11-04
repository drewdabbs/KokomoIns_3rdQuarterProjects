using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02KomodoClaimsDept_ClassLibrary
{
    public class KomodoClaimsDept_Repo
    {
        public Queue<Claim> _queueList = new Queue<Claim>();
        public bool AddCLaim(Claim claim)
        {
            int startingCount = _queueList.Count;
            _queueList.Enqueue(claim);
            bool wasAdded = _queueList.Count > startingCount ? true : false;
            return wasAdded;
        }
        public Queue<Claim> SeeAllClaims()
        {
            return _queueList;
        }
        public bool DequeueClaim(Claim claim)
        {
            int startingCount = _queueList.Count;
            _queueList.Dequeue();
            bool wasDeleted = _queueList.Count < startingCount ? true : false;
            return wasDeleted;
        }
    }
    
}
