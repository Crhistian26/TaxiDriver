using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiDriver.Domain.Interfaces.Entities
{
    public interface IRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
