using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Base;

namespace TaxiDriver.Domain.Entitys
{
    public class UserGroup : BaseEntity
    {
        public string GroupName { get; set; }

        public UserGroup() { }

        public UserGroup(string groupName)
        {
            GroupName = groupName;
        }

        public UserGroup(int id, string groupName)
        {
            Id = id;
            GroupName = groupName;
        }
    }
}
