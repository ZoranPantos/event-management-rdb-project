using EventManagement.Demo.Infrastructure.Queries;
using EventManagement.Demo.Models;
using MySqlConnector;
using System;
using System.Data;
using System.Windows;

namespace EventManagement.Demo.Infrastructure;

public class EventManagementRepository : IEventManagementRepository
{
    private MySqlConnection? connection;
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

}
