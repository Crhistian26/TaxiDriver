using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Base;

namespace TaxiDriver.Domain.Entitys
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public Role() { }

        public Role(string name)
        {
            Name = name;
        }

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
