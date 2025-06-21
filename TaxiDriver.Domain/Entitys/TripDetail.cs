using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Base;

namespace TaxiDriver.Domain.Entitys
{
    public class TripDetail : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Detail { get; set; }
        public int TripId { get; set; }
        public int UserId { get; set; }

        public TripDetail() { }

        public TripDetail(DateTime date, string detail, int tripId, int userId)
        {
            Date = date;
            Detail = detail;
            TripId = tripId;
            UserId = userId;
        }

        public TripDetail(int id, DateTime date, string detail, int tripId, int userId)
        {
            Id = id;
            Date = date;
            Detail = detail;
            TripId = tripId;
            UserId = userId;
        }
    }
}
