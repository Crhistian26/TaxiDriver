using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDriver.Domain.Base;

namespace TaxiDriver.Domain.Entitys
{
    public class User : BaseEntity
    {
        public int UserGroupId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string UrlDocument { get; set; }

        public User() { }

        public User(int userGroupId, string username, string email, string urlDocument)
        {
            UserGroupId = userGroupId;
            Username = username;
            Email = email;
            UrlDocument = urlDocument;
        }

        public User(int id, int userGroupId, string username, string email, string urlDocument)
        {
            Id = id;
            UserGroupId = userGroupId;
            Username = username;
            Email = email;
            UrlDocument = urlDocument;
        }
    }
}
