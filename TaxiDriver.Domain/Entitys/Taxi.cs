using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Base;

namespace TaxiDriver.Domain.Entitys
{
    public class Taxi : BaseEntity
    {
        public int UserId { get; set; }
        public string LicensePlate { get; set; }
        public string DriverName { get; set; }

        public Taxi() { }

        public Taxi(int userId, string licensePlate, string driverName)
        {
            UserId = userId;
            LicensePlate = licensePlate;
            DriverName = driverName;
        }

        public Taxi(int id, int userId, string licensePlate, string driverName)
        {
            Id = id;
            UserId = userId;
            LicensePlate = licensePlate;
            DriverName = driverName;
        }
    }
}
