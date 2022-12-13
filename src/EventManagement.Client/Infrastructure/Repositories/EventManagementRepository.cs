using EventManagement.Demo.DTOs;
using EventManagement.Demo.Infrastructure.Queries;
using EventManagement.Demo.Models;
using EventManagement.Demo.ViewModels;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace EventManagement.Demo.Infrastructure.Repositories;

public class EventManagementRepository : IEventManagementRepository
{
    private MySqlConnection? connection;

    // TODO: Put this string into a config file
    private readonly string connectionString = "server=localhost;user ID=root;password=root;database=event_management";

    public RegularUser GetUserWithId(int id)
    {
        var resultUser = new RegularUser();

        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(SelectQueries.getUserWithId, connection);

            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "id",
                Value = id,
                DbType = DbType.Int32
            });

            var reader = command.ExecuteReader();
            reader.Read();

            // Maybe add a Populate method in the RegularUser entity and move this mapping there?
            resultUser.Id = id;

            resultUser.FirstName = (string)reader.GetValue("FirstName");
            resultUser.LastName = (string)reader.GetValue("LastName");
            resultUser.Age = (int)reader.GetValue("Age");

            resultUser.IsSuspended = reader.GetValue("IsSuspended").ToString().Equals("1");

            resultUser.MemberSince = (DateTime)reader.GetValue("MemberSince");
            resultUser.Interests = (string)reader.GetValue("Interests");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return resultUser;
    }

    public void UpdateUserWithId(int id, UpdateProfileViewModel viewModel)
    {
        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(UpdateQueries.updateUserWithId, connection);

            command.Parameters.AddRange(
                new MySqlParameter[]
                {
                    new MySqlParameter
                    {
                        ParameterName = "id",
                        Value = id,
                        DbType = DbType.Int32
                    },
                    new MySqlParameter
                    {
                        ParameterName = "newFirstName",
                        Value = viewModel.FirstName,
                        DbType = DbType.String
                    },
                    new MySqlParameter
                    {
                        ParameterName = "newLastName",
                        Value = viewModel.LastName,
                        DbType = DbType.String
                    }
                }
            );

            int affectedRows = command.ExecuteNonQuery();

            // Repository should not communicate directly to the UI - change this!
            string message = affectedRows == 1 ? "User successfully updated" : "Update failed";
            MessageBox.Show(message);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    public ICollection<SingleApplicationDTO> GetAllApplicationsForSpecificUser(int userId)
    {
        var applications = new List<SingleApplicationDTO>();

        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(SelectQueries.getAllApplicationsForSpecificUser, connection);

            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "id",
                Value = userId,
                DbType = DbType.Int32
            });

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                applications.Add(new SingleApplicationDTO
                {
                    UserId = (int)reader.GetValue(0),
                    EventId = (int)reader.GetValue(1),
                    Event = (string)reader.GetValue(2),
                    EventDate = (DateTime)reader.GetValue(3),
                    Group = (string)reader.GetValue(4)
                });
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return applications;
    }
}
