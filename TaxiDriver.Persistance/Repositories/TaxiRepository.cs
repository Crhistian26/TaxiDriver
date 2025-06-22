using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TaxiDriver.Domain.Entitys;
using TaxiDriver.Domain.Interfaces.Entities;
using TaxiDriver.Domain.Interfaces.Repositorys;
using TaxiDriver.Persistance.Context;
using TaxiDriver.Persistance.Exceptions;

namespace TaxiDriver.Persistence.Repositories
{
    public class TaxiRepository : ITaxiRepository
    {
        public TaxiRepository(){}

        public List<Taxi> GetAll()
        {
            var taxis = new List<Taxi>();
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_Taxi, UserId, LicensePlate, DriverName FROM Taxi", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        taxis.Add(new Taxi
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            LicensePlate = reader.GetString(2),
                            DriverName = reader.GetString(3)
                        });
                    }
                }
            }
            return taxis;
        }

        public Taxi GetById(int id)
        {
            Taxi taxi = null;
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_Taxi, UserId, LicensePlate, DriverName FROM Taxi WHERE Id_Taxi = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        taxi = new Taxi
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            LicensePlate = reader.GetString(2),
                            DriverName = reader.GetString(3)
                        };
                    }
                }
            }
            return taxi;
        }

        public Taxi GetByLicensePlate(string plate)
        {
            Taxi taxi = null;
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_Taxi, UserId, LicensePlate, DriverName FROM Taxi WHERE LicensePlate = @Plate", connection))
            {
                command.Parameters.AddWithValue("@Plate", plate);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        taxi = new Taxi
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            LicensePlate = reader.GetString(2),
                            DriverName = reader.GetString(3)
                        };
                    }
                }
            }
            return taxi;
        }

        public List<Taxi> GetByUserId(int userId)
        {
            var taxis = new List<Taxi>();
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_Taxi, UserId, LicensePlate, DriverName FROM Taxi WHERE UserId = @UserId", connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        taxis.Add(new Taxi
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            LicensePlate = reader.GetString(2),
                            DriverName = reader.GetString(3)
                        });
                    }
                }
            }
            if (taxis.Count < 0)
            {
                throw new EntityNotFoundException($"No se encontraron los taxis del usuario.");
            }
            return taxis;
        }

        public void Add(Taxi taxi)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_InsertTaxi", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", taxi.UserId);
                command.Parameters.AddWithValue("@LicensePlate", taxi.LicensePlate);
                command.Parameters.AddWithValue("@DriverName", taxi.DriverName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Taxi taxi)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_UpdateTaxi", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", taxi.Id);
                command.Parameters.AddWithValue("@LicensePlate", taxi.LicensePlate);
                command.Parameters.AddWithValue("@DriverName", taxi.DriverName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_DeleteTaxi", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
