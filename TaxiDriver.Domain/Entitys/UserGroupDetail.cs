using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Base;

namespace TaxiDriver.Domain.Entitys
{
    public class UserGroupDetail : BaseEntity
    {
        public int GroupId { get; set; }
        public string Detail { get; set; }

        public UserGroupDetail() { }

        public UserGroupDetail(int groupId, string detail)
        {
            GroupId = groupId;
            Detail = detail;
        }

        public UserGroupDetail(int id, int groupId, string detail)
        {
            Id = id;
            GroupId = groupId;
            Detail = detail;
        }
    }
}
