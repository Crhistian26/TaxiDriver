using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TaxiDriver.Domain.Entitys;
using TaxiDriver.Domain.Interfaces.Repositorys;
using TaxiDriver.Persistance.Context;

namespace TaxiDriver.Persistence.Repositories
{
    public class UserGroupRequestRepository : IUserGroupRequestRepository
    {
        private readonly string _connectionString;

        public UserGroupRequestRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<UserGroupRequest> GetByGroupId(int groupId)
        {
            var requests = new List<UserGroupRequest>();
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_GroupRequest, GroupId, Request FROM UserGroupRequests WHERE GroupId = @GroupId", connection))
            {
                command.Parameters.AddWithValue("@GroupId", groupId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        requests.Add(new UserGroupRequest
                        {
                            Id = reader.GetInt32(0),
                            GroupId = reader.GetInt32(1),
                            Request = reader.GetString(2)
                        });
                    }
                }
            }
            return requests;
        }

        public UserGroupRequest GetById(int id)
        {
            UserGroupRequest request = null;
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_GroupRequest, GroupId, Request FROM UserGroupRequests WHERE Id_GroupRequest = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        request = new UserGroupRequest
                        {
                            Id = reader.GetInt32(0),
                            GroupId = reader.GetInt32(1),
                            Request = reader.GetString(2)
                        };
                    }
                }
            }
            return request;
        }

        public void Add(UserGroupRequest request)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_InsertUserGroupRequest", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupId", request.GroupId);
                command.Parameters.AddWithValue("@Request", request.Request);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(UserGroupRequest request)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_UpdateUserGroupRequest", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", request.Id);
                command.Parameters.AddWithValue("@Request", request.Request);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_DeleteUserGroupRequest", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

