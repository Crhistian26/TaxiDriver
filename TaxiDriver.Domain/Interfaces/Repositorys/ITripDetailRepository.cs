using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Entitys;

namespace TaxiDriver.Domain.Interfaces
{
    public interface ITripDetailRepository
    {
        List<TripDetail> GetByTripId(int tripId);
        TripDetail GetById(int id);
        void Add(TripDetail detail);
        void Update(TripDetail detail);
        void Delete(int id);
    }
}
