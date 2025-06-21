using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Entitys;

namespace TaxiDriver.Domain.Interfaces
{
    public interface ITaxiRepository
    {
        List<Taxi> GetAll();
        Taxi GetById(int id);
        void Add(Taxi taxi);
        void Update(Taxi taxi);
        void Delete(int id);
        Taxi GetByLicensePlate(string plate);
        List<Taxi> GetByUserId(int userId);
    }
}
