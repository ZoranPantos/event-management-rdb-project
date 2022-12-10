using EventManagement.Demo.Models;

namespace EventManagement.Demo.Infrastructure;

public interface IEventManagementRepository
{
    RegularUser GetUserWithId(int id);
}
