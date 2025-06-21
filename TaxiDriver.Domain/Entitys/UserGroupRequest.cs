using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Base;

namespace TaxiDriver.Domain.Entitys
{
    public class UserGroupRequest : BaseEntity
    {
        public int GroupId { get; set; }
        public string Request { get; set; }

        public UserGroupRequest() { }

        public UserGroupRequest(int groupId, string request)
        {
            GroupId = groupId;
            Request = request;
        }

        public UserGroupRequest(int id, int groupId, string request)
        {
            Id = id;
            GroupId = groupId;
            Request = request;
        }
    }
}
