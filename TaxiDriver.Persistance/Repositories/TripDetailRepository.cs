using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using TaxiDriver.Domain.Entitys;
using TaxiDriver.Domain.Interfaces.Repositorys;
using TaxiDriver.Persistance.Context;

namespace TaxiDriver.Persistence.Repositories
{
    public class TripDetailRepository : ITripDetailRepository
    {
        private readonly string _connectionString;

        public TripDetailRepository(){}

        public List<TripDetail> GetByTripId(int tripId)
        {
            var details = new List<TripDetail>();
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_TripDetail, [Date], Detail, TripId, UserId FROM TripDetails WHERE TripId = @TripId", connection))
            {
                command.Parameters.AddWithValue("@TripId", tripId);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        details.Add(new TripDetail
                        {
                            Id = reader.GetInt32(0),
                            Date = reader.GetDateTime(1),
                            Detail = reader.GetString(2),
                            TripId = reader.GetInt32(3),
                            UserId = reader.GetInt32(4)
                        });
                    }
                }
            }
            return details;
        }

        public TripDetail GetById(int id)
        {
            TripDetail detail = null;
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("SELECT Id_TripDetail, [Date], Detail, TripId, UserId FROM TripDetails WHERE Id_TripDetail = @Id", connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        detail = new TripDetail
                        {
                            Id = reader.GetInt32(0),
                            Date = reader.GetDateTime(1),
                            Detail = reader.GetString(2),
                            TripId = reader.GetInt32(3),
                            UserId = reader.GetInt32(4)
                        };
                    }
                }
            }
            return detail;
        }

        public void Add(TripDetail detail)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_InsertTripDetail", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TripId", detail.TripId);
                command.Parameters.AddWithValue("@UserId", detail.UserId);
                command.Parameters.AddWithValue("@Detail", detail.Detail);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(TripDetail detail)
        {
            using (var connection = new DBConnection().GetConnection())
            using (var command = new SqlCommand("sp_UpdateTripDetail", connection))
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
            using (var command = new SqlCommand("sp_DeleteTripDetail", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
