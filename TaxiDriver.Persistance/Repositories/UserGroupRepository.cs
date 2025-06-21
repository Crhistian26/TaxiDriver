using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TaxiDriver.Domain.Entitys;
using TaxiDriver.Domain.Interfaces.Repositorys;
using TaxiDriver.Persistance.Context;

namespace TaxiDriver.Persistence.Repositories
{
    public class UserGroupRepository : IUserGroupRepository
    {
        public UserGroupRepository(){}

        public List<UserGroup> GetAll()
        {
            var groups = new List<UserGroup>(); 
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_UserGroup, GroupName FROM UserGroups", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        groups.Add(new UserGroup
                        {
                            Id = reader.GetInt32(0),
                            GroupName = reader.GetString(1)
                        });
                    }
                }
            }
            return groups;
        }

        public UserGroup GetById(int id)
        {
            UserGroup group = null;
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_UserGroup, GroupName FROM UserGroups WHERE Id_UserGroup = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        group = new UserGroup
                        {
                            Id = reader.GetInt32(0),
                            GroupName = reader.GetString(1)
                        };
                    }
                }
            }
            return group;
        }

        public void Add(UserGroup group)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_InsertUserGroup", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupName", group.GroupName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(UserGroup group)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_UpdateUserGroup", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", group.Id);
                command.Parameters.AddWithValue("@GroupName", group.GroupName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new DBConnection().GetConnection()) 
            using (var command = new SqlCommand("sp_DeleteUserGroup", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

