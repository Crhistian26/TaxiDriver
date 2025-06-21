using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Entitys;

namespace TaxiDriver.Domain.Interfaces
{
    public interface ITripRepository
    {
        List<Trip> GetAll();
        Trip GetById(int id);
        void Add(Trip trip);
        void Update(Trip trip);
        void Delete(int id);
        List<Trip> GetByTaxiId(int taxiId);
    }
}
