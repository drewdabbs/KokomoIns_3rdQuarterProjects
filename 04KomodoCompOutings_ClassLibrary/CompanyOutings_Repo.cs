using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04KomodoCompOutings_ClassLibrary
{
    public class CompanyOutings_Repo
    {
        protected readonly List<Outings> _outings = new List<Outings>();
        public bool AddAnOuting(Outings outing)
        {
            int startCount = _outings.Count;
            _outings.Add(outing);
            bool wasAdded = _outings.Count > startCount ? true : false;
            return wasAdded;
        }
        public List<Outings> ListAllOutings()
        {
            return _outings;
        }
    }
}
