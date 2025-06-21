using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TaxiDriver.Domain.Entitys;
using TaxiDriver.Domain.Interfaces.Entities;
using TaxiDriver.Domain.Interfaces.Repositorys;
using TaxiDriver.Persistance.Context;

namespace TaxiDriver.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public RoleRepository(){}

        public List<Role> GetAll()
        {
            var roles = new List<Role>();

            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_Role, Role FROM Roles", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roles.Add(new Role
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }

            return roles;
        }

        public Role GetById(int id)
        {
            Role role = null;

            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_Role, Role FROM Roles WHERE Id_Role = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        role = new Role
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                    }
                }
            }

            return role;
        }

        public void Add(Role role)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_InsertRole", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Role", role.Name);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Role role)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_UpdateRole", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", role.Id);
                command.Parameters.AddWithValue("@Role", role.Name);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_DeleteRole", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

