using EventManagement.Demo.DTOs;
using EventManagement.Demo.Models;
using EventManagement.Demo.ViewModels;
using System;
using System.Collections.Generic;

namespace EventManagement.Demo.Infrastructure.Repositories;

public interface IEventManagementRepository
{
    void UpdateUserWithId(int id, UpdateProfileViewModel viewModel);
    void DeleteEventApplication(int userId, int eventId);
    void ApplyForEvent(int userId, int eventId);
    void DeleteEvent(int eventId);
    void RescheduleEvent(int eventId, DateTime newDate);

    RegularUser GetUserWithId(int id);
    Group GetGroupWithId(int id);
    Venue GetGroupVenue(int groupId);
    Location GetLocation(int locationId);
    Event GetEvent(int eventId);

    ICollection<SingleGroupMemberDTO> GetGroupMembers(int groupId);
    ICollection<SingleGroupEventDTO> GetGroupEvents(int groupId);
    ICollection<Topic> GetAllTopicsForEvent(int eventId);
    ICollection<string> GetSponsorNamesForEvent(int eventId);
    ICollection<ForthcomingEventDTO> GetForthcomingEvents();
    ICollection<SingleEventSponsorDTO> GetEventSponsors(int eventId);
    ICollection<SingleEventAttendeeDTO> GetAttendees(int eventId);
    ICollection<SingleApplicationDTO> GetAllApplicationsForSpecificUser(int userId);
    ICollection<SingleGroupDTO> GetAllGroupsCreatedBySpecificUser(int userId);
}
