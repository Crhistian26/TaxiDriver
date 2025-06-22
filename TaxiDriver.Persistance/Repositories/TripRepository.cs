using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TaxiDriver.Domain.Entitys;
using TaxiDriver.Domain.Interfaces.Repositorys;
using TaxiDriver.Persistance.Context;

namespace TaxiDriver.Persistence.Repositories
{
    public class TripRepository : ITripRepository
    {
        public TripRepository(){}

        public List<Trip> GetAll()
        {
            var trips = new List<Trip>();
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_Trip, TaxiId, Origin, Final FROM Trip", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        trips.Add(new Trip
                        {
                            Id = reader.GetInt32(0),
                            TaxiId = reader.GetInt32(1),
                            Origin = reader.GetString(2),
                            Final = reader.GetString(3)
                        });
                    }
                }
            }
            return trips;
        }

        public Trip GetById(int id)
        {
            Trip trip = null;
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_Trip, TaxiId, Origin, Final FROM Trip WHERE Id_Trip = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        trip = new Trip
                        {
                            Id = reader.GetInt32(0),
                            TaxiId = reader.GetInt32(1),
                            Origin = reader.GetString(2),
                            Final = reader.GetString(3)
                        };
                    }
                }
            }
            return trip;
        }

        public List<Trip> GetByTaxiId(int taxiId)
        {
            var trips = new List<Trip>();
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_Trip, TaxiId, Origin, Final FROM Trip WHERE TaxiId = @TaxiId", connection))
            {
                command.Parameters.AddWithValue("@TaxiId", taxiId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        trips.Add(new Trip
                        {
                            Id = reader.GetInt32(0),
                            TaxiId = reader.GetInt32(1),
                            Origin = reader.GetString(2),
                            Final = reader.GetString(3)
                        });
                    }
                }
            }
            return trips;
        }

        public void Add(Trip trip)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_InsertTrip", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TaxiId", trip.TaxiId);
                command.Parameters.AddWithValue("@Origin", trip.Origin);
                command.Parameters.AddWithValue("@Final", trip.Final);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Trip trip)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_UpdateTrip", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", trip.Id);
                command.Parameters.AddWithValue("@Origin", trip.Origin);
                command.Parameters.AddWithValue("@Final", trip.Final);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_DeleteTrip", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

