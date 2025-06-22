using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using TaxiDriver.Domain.Entitys;
using TaxiDriver.Domain.Interfaces.Repositorys;
using TaxiDriver.Persistance.Context;

namespace TaxiDriver.Persistence.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly string _connectionString;

        public UserRoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<UserRole> GetRolesByUserId(int userId)
        {
            var roles = new List<UserRole>();
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT UserId, RoleId FROM UserRole WHERE UserId = @UserId", connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new UserRole
                        {
                            UserId = reader.GetInt32(0),
                            RoleId = reader.GetInt32(1)
                        });
                    }
                }
            }
            return roles;
        }

        public void AssignRole(int userId, int roleId)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_InsertUserRole", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@RoleId", roleId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void RemoveRole(int userId, int roleId)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_DeleteUserRole", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@RoleId", roleId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

