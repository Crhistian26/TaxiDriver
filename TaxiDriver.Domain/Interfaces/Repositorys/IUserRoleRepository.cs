using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Entitys;

namespace TaxiDriver.Domain.Interfaces
{
    public interface IUserRoleRepository
    {
        List<UserRole> GetRolesByUserId(int userId);
        void AssignRole(int userId, int roleId);
        void RemoveRole(int userId, int roleId);
    }
}
