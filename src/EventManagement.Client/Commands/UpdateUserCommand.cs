using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.ViewModels;

namespace EventManagement.Demo.Commands;

public class UpdateUserCommand : CommandBase
{
    private readonly UpdateUserViewModel updateUserViewModel;
    private readonly IEventManagementRepository eventManagementRepository;

    public UpdateUserCommand(
        UpdateUserViewModel updateUserViewModel,
        IEventManagementRepository eventManagementRepository)
    {
        this.updateUserViewModel = updateUserViewModel;
        this.eventManagementRepository = eventManagementRepository;
    }

    public override void Execute(object? parameter)
    {
        // TODO: get this user id from some upper layers
        eventManagementRepository.UpdateUserWithId(2, updateUserViewModel);
    }
}
