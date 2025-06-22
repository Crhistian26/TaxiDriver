using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TaxiDriver.Domain.Entitys;
using TaxiDriver.Domain.Interfaces.Repositorys;
using TaxiDriver.Persistance.Context;

namespace TaxiDriver.Persistence.Repositories
{
    public class UserGroupDetailRepository : IUserGroupDetailRepository
    {
        private readonly string _connectionString;

        public UserGroupDetailRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<UserGroupDetail> GetByGroupId(int groupId)
        {
            var details = new List<UserGroupDetail>();
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_GroupDetail, GroupId, Detail FROM UserGroupDetails WHERE GroupId = @GroupId", connection))
            {
                command.Parameters.AddWithValue("@GroupId", groupId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        details.Add(new UserGroupDetail
                        {
                            Id = reader.GetInt32(0),
                            GroupId = reader.GetInt32(1),
                            Detail = reader.GetString(2)
                        });
                    }
                }
            }
            return details;
        }

        public UserGroupDetail GetById(int id)
        {
            UserGroupDetail detail = null;
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_GroupDetail, GroupId, Detail FROM UserGroupDetails WHERE Id_GroupDetail = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        detail = new UserGroupDetail
                        {
                            Id = reader.GetInt32(0),
                            GroupId = reader.GetInt32(1),
                            Detail = reader.GetString(2)
                        };
                    }
                }
            }
            return detail;
        }

        public void Add(UserGroupDetail detail)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_InsertUserGroupDetail", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupId", detail.GroupId);
                command.Parameters.AddWithValue("@Detail", detail.Detail);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(UserGroupDetail detail)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_UpdateUserGroupDetail", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", detail.Id);
                command.Parameters.AddWithValue("@Detail", detail.Detail);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_DeleteUserGroupDetail", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
