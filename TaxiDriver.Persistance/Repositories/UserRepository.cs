using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TaxiDriver.Domain.Entitys;
using TaxiDriver.Domain.Interfaces.Repositorys;
using TaxiDriver.Persistance.Context;

namespace TaxiDriver.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(){}

        public List<User> GetAll()
        {
            var users = new List<User>();
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_User, UserGroupId, Username, Email, Url_Document FROM Users", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            UserGroupId = reader.GetInt32(1),
                            Username = reader.GetString(2),
                            Email = reader.GetString(3),
                            UrlDocument = reader.GetString(4)
                        });
                    }
                }
            }
            return users;
        }

        public User GetById(int id)
        {
            User user = null;
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_User, UserGroupId, Username, Email, Url_Document FROM Users WHERE Id_User = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            Id = reader.GetInt32(0),
                            UserGroupId = reader.GetInt32(1),
                            Username = reader.GetString(2),
                            Email = reader.GetString(3),
                            UrlDocument = reader.GetString(4)
                        };
                    }
                }
            }
            return user;
        }

        public User GetByEmail(string email)
        {
            User user = null;
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_User, UserGroupId, Username, Email, Url_Document FROM Users WHERE Email = @Email", connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            Id = reader.GetInt32(0),
                            UserGroupId = reader.GetInt32(1),
                            Username = reader.GetString(2),
                            Email = reader.GetString(3),
                            UrlDocument = reader.GetString(4)
                        };
                    }
                }
            }
            return user;
        }

        public void Add(User user)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_InsertUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserGroupId", user.UserGroupId);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Url_Document", user.UrlDocument);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(User user)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_UpdateUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Url_Document", user.UrlDocument);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_DeleteUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

