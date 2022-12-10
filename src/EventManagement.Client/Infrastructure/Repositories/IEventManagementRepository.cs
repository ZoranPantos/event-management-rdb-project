using EventManagement.Demo.Models;
using EventManagement.Demo.ViewModels;

namespace EventManagement.Demo.Infrastructure.Repositories;

public interface IEventManagementRepository
{
    RegularUser GetUserWithId(int id);
    void UpdateUserWithId(int id, UpdateUserViewModel viewModel);
}
