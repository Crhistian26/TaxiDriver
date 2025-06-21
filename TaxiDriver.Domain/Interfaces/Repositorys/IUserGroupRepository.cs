using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Entitys;

namespace TaxiDriver.Domain.Interfaces
{
    public interface IUserGroupRepository
    {
        List<UserGroup> GetAll();
        UserGroup GetById(int id);
        void Add(UserGroup group);
        void Update(UserGroup group);
        void Delete(int id);
    }
}
