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
}
