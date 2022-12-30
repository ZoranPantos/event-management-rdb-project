using EventManagement.Demo.DTOs;
using EventManagement.Demo.Models;
using EventManagement.Demo.ViewModels;
using System.Collections.Generic;

namespace EventManagement.Demo.Infrastructure.Repositories;

public interface IEventManagementRepository
{
    RegularUser GetUserWithId(int id);
    void UpdateUserWithId(int id, UpdateProfileViewModel viewModel);
    ICollection<SingleApplicationDTO> GetAllApplicationsForSpecificUser(int userId);
    void DeleteEventApplication(int userId, int eventId);
    ICollection<SingleGroupDTO> GetAllGroupsCreatedBySpecificUser(int userId);
    Group GetGroupWithId(int id);
    Venue GetGroupVenue(int groupId);
    ICollection<SingleGroupMemberDTO> GetGroupMembers(int groupId);
    ICollection<SingleGroupEventDTO> GetGroupEvents(int groupId);
    ICollection<Topic> GetAllTopicsForEvent(int eventId);
    ICollection<string> GetSponsorNamesForEvent(int eventId);
    ICollection<ForthcomingEventDTO> GetForthcomingEvents();
    void ApplyForEvent(int userId, int eventId);
    void DeleteEvent(int eventId);
    Location GetLocation(int locationId);
    Event GetEvent(int eventId);
    ICollection<SingleEventSponsorDTO> GetEventSponsors(int eventId);
    ICollection<SingleEventAttendeeDTO> GetAttendees(int eventId);
}
