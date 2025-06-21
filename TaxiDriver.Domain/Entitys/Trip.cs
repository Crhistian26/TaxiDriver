using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Base;

namespace TaxiDriver.Domain.Entitys
{
    public class Trip : BaseEntity
    {
        public int TaxiId { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public string Origin { get; set; }
        public string Final { get; set; }

        public Trip() { }

        public Trip(int taxiId, DateTime dateBegin, DateTime dateEnd, string origin, string final)
        {
            TaxiId = taxiId;
            DateBegin = dateBegin;
            DateEnd = dateEnd;
            Origin = origin;
            Final = final;
        }

        public Trip(int id, int taxiId, DateTime dateBegin, DateTime dateEnd, string origin, string final)
        {
            Id = id;
            TaxiId = taxiId;
            DateBegin = dateBegin;
            DateEnd = dateEnd;
            Origin = origin;
            Final = final;
        }
    }
}
