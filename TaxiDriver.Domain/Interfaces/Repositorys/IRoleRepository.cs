using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Entitys;
using TaxiDriver.Domain.Interfaces.Entities;

namespace TaxiDriver.Domain.Interfaces.Repositorys
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
        Role GetById(int id);
        void Add(Role role);
        void Update(Role role);
        void Delete(int id);
    }
}
