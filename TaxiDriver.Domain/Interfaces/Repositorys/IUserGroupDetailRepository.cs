using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Entitys;

namespace TaxiDriver.Domain.Interfaces
{
    public interface IUserGroupDetailRepository
    {
        List<UserGroupDetail> GetByGroupId(int groupId);
        UserGroupDetail GetById(int id);
        void Add(UserGroupDetail detail);
        void Update(UserGroupDetail detail);
        void Delete(int id);
    }
}
