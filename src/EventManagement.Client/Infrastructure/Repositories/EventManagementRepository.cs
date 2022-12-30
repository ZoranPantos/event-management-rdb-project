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

    public void DeleteEventApplication(int userId, int eventId)
    {
        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(DeleteQueries.deleteApplicationForEvent, connection);

            command.Parameters.AddRange(
                new MySqlParameter[]
                {
                    new MySqlParameter
                    {
                        ParameterName = "userId",
                        Value = userId,
                        DbType = DbType.Int32
                    },
                    new MySqlParameter
                    {
                        ParameterName = "eventId",
                        Value = eventId,
                        DbType = DbType.Int32
                    }
                }
            );

            int affectedRows = command.ExecuteNonQuery();

            // Repository should not communicate directly to the UI - change this!
            string message = affectedRows == 1 ? "Application successfully deleted" : "Delete failed";
            MessageBox.Show(message);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    public ICollection<SingleGroupDTO> GetAllGroupsCreatedBySpecificUser(int userId)
    {
        var groups = new List<SingleGroupDTO>();

        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand("user_groups_list", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "userId",
                Value = userId,
                DbType = DbType.Int32,
                Direction = ParameterDirection.Input,
            });

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                groups.Add(new SingleGroupDTO
                {
                    GroupId = (int)reader.GetValue(0),
                    Title = (string)reader.GetValue(1)
                });
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return groups;
    }

    public Group GetGroupWithId(int id)
    {
        var resultGroup = new Group();

        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(SelectQueries.getGroupWithId, connection);

            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "groupId",
                Value = id,
                DbType = DbType.Int32
            });

            var reader = command.ExecuteReader();
            reader.Read();

            resultGroup.Id = id;

            resultGroup.Title = (string)reader.GetValue("Title");
            resultGroup.Description = (string)reader.GetValue("Description");
            resultGroup.MemberCount = (int)reader.GetValue("MemberCount");

            resultGroup.IsSuspended = reader.GetValue("IsSuspended").ToString().Equals("1");
            resultGroup.IsPublic = reader.GetValue("IsPublic").ToString().Equals("1");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return resultGroup;
    }

    public Venue GetGroupVenue(int groupId)
    {
        var resultVenue = new Venue();

        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(SelectQueries.getGroupVenue, connection);

            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "groupId",
                Value = groupId,
                DbType = DbType.Int32
            });

            var reader = command.ExecuteReader();
            reader.Read();

            resultVenue.Id = (int)reader.GetValue("Id");
            resultVenue.FullName = (string)reader.GetValue("FullName");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        return resultVenue;
    }

    public ICollection<SingleGroupMemberDTO> GetGroupMembers(int groupId)
    {
        var members = new List<SingleGroupMemberDTO>();

        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(SelectQueries.getGroupMembers, connection);

            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "groupId",
                Value = groupId,
                DbType = DbType.Int32
            });

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                members.Add(new SingleGroupMemberDTO
                {
                    UserId = (int)reader.GetValue("Id"),
                    FirstName = (string)reader.GetValue("FirstName"),
                    LastName = (string)reader.GetValue("LastName"),
                    Age = (int)reader.GetValue("Age"),
                    Interests = (string)reader.GetValue("Interests")
                });
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return members;
    }

    public ICollection<SingleGroupEventDTO> GetGroupEvents(int groupId)
    {
        var events = new List<SingleGroupEventDTO>();

        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(SelectQueries.getGroupEvents, connection);

            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "groupId",
                Value = groupId,
                DbType = DbType.Int32
            });

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                events.Add(new SingleGroupEventDTO
                {
                    EventId = (int)reader.GetValue("Id"),
                    Title = (string)reader.GetValue("Title")
                });
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return events;
    }

    public ICollection<Topic> GetAllTopicsForEvent(int eventId)
    {
        var topics = new List<Topic>();

        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(SelectQueries.getAllTopicsForEvent, connection);

            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "eventId",
                Value = eventId,
                DbType = DbType.Int32
            });

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                topics.Add(new Topic
                {
                    Id = (int)reader.GetValue("Id"),
                    Title = (string)reader.GetValue("Title"),
                    Description = (string)reader.GetValue("Description")
                });
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return topics;
    }

    public ICollection<string> GetSponsorNamesForEvent(int eventId)
    {
        var sponsorNames = new List<string>();

        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(SelectQueries.getSponsorNamesForEvent, connection);

            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "eventId",
                Value = eventId,
                DbType = DbType.Int32
            });

            var reader = command.ExecuteReader();

            while (reader.Read())
                sponsorNames.Add((string)reader.GetValue("Name"));
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return sponsorNames;
    }

    public ICollection<ForthcomingEventDTO> GetForthcomingEvents()
    {
        var airingEventDTOs = new List<ForthcomingEventDTO>();

        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(SelectQueries.getAiringEventsWithGroupName, connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int eventId = (int)reader.GetValue("Id");

                var topics = GetAllTopicsForEvent(eventId);
                var sponsors = GetSponsorNamesForEvent(eventId);

                var airingEventDTO = new ForthcomingEventDTO
                {
                    EventId = eventId,
                    EventTitle = (string)reader.GetValue("Title"),
                    Date = (DateTime)reader.GetValue("Date"),
                    Description = (string)reader.GetValue("Description"),
                    DailySchedule = (string)reader.GetValue("DailySchedule"),
                    City = (string)reader.GetValue("City"),
                    Street = (string)reader.GetValue("Street"),
                    Number = (int)reader.GetValue("Number"),
                    GroupName = (string)reader.GetValue("GroupName")
                };

                foreach (var topic in topics)
                    airingEventDTO.Topics += $" {topic.Title} ";

                foreach (var sponsor in sponsors)
                    airingEventDTO.Sponsors += $" {sponsor} ";

                airingEventDTOs.Add(airingEventDTO);
            }

        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return airingEventDTOs;
    }

    public void ApplyForEvent(int userId, int eventId)
    {
        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(InsertQueries.applyToEvent, connection);

            command.Parameters.AddRange(
                new MySqlParameter[]
                {
                    new MySqlParameter
                    {
                        ParameterName = "userId",
                        Value = userId,
                        DbType = DbType.Int32
                    },
                    new MySqlParameter
                    {
                        ParameterName = "eventId",
                        Value = eventId,
                        DbType = DbType.Int32
                    }
                }
            );

            int affectedRows = command.ExecuteNonQuery();

            // Repository should not communicate directly to the UI - change this!
            string message = affectedRows == 1 ? "Applied successfully" : "Apply failed";
            MessageBox.Show(message);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    public void DeleteEvent(int eventId)
    {
        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(DeleteQueries.deleteEvent, connection);

            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "eventId",
                Value = eventId,
                DbType = DbType.Int32
            });

            int affectedRows = command.ExecuteNonQuery();

            // Repository should not communicate directly to the UI - change this!
            string message = affectedRows == 1 ? "Event deleted" : "Operation failed";
            MessageBox.Show(message);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    public Location GetLocation(int locationId)
    {
        var location = new Location();

        try
        {
            var tmpConnection = new MySqlConnection(connectionString);
            tmpConnection.Open();

            var command = new MySqlCommand(SelectQueries.getLocation, tmpConnection);

            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "locationId",
                Value = locationId,
                DbType = DbType.Int32
            });

            var reader = command.ExecuteReader();
            reader.Read();

            location.Id = locationId;
            location.City = (string)reader.GetValue("City");
            location.Street = (string)reader.GetValue("Street");
            location.Number = (int)reader.GetValue("Number");
            location.Latitude = (decimal)reader.GetValue("Latitude");
            location.Longitude = (decimal)reader.GetValue("Longitude");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return location;
    }

    public Event GetEvent(int eventId)
    {
        var _event = new Event();

        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(SelectQueries.getEvent, connection);

            command.Parameters.Add(new MySqlParameter
            {
                ParameterName = "eventId",
                Value = eventId,
                DbType = DbType.Int32
            });

            var reader = command.ExecuteReader();
            reader.Read();

            _event.Id = eventId;
            _event.Date = (DateTime)reader.GetValue("Date");
            _event.Title = (string)reader.GetValue("Title");
            _event.Description = (string)reader.GetValue("Description");
            _event.DailySchedule = (string)reader.GetValue("DailySchedule");
            _event.IsReccuring = reader.GetValue("IsRecurring").ToString().Equals("1");
            _event.IsOpen = reader.GetValue("IsOpen").ToString().Equals("1");
            _event.IsSuspended = reader.GetValue("IsSuspended").ToString().Equals("1");

            _event.Location = GetLocation((int)reader.GetValue("LOCATION_Id"));
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return _event;
    }

    public ICollection<SingleEventSponsorDTO> GetEventSponsors(int eventId)
    {
        var sponsors = new List<SingleEventSponsorDTO>();

        try
        {
            connection = new(connectionString);
            connection.Open();

            var command = new MySqlCommand(SelectQueries.getSponsorNameAndMoneyProvidedForEvent, connection);

            command.Parameters.Add(new MySqlParameter()
            {
                ParameterName = "eventId",
                Value = eventId,
                DbType = DbType.Int32
            });

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                sponsors.Add(new SingleEventSponsorDTO()
                {
                    Name = (string)reader.GetValue("Name"),
                    MoneyProvided = (decimal)reader.GetValue("MoneyProvided")
                });
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return sponsors;
    }
}
