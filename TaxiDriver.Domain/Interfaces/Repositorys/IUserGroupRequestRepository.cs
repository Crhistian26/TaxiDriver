using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Entitys;

namespace TaxiDriver.Domain.Interfaces
{
    public interface IUserGroupRequestRepository
    {
        List<UserGroupRequest> GetByGroupId(int groupId);
        UserGroupRequest GetById(int id);
        void Add(UserGroupRequest request);
        void Update(UserGroupRequest request);
        void Delete(int id);
    }
}
