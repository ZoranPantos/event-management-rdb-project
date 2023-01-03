using EventManagement.Demo.Infrastructure.Repositories;

namespace EventManagement.Demo.Commands;

public class ApplyToEventCommand : CommandBase
{
    private readonly int userId, eventId;
    private readonly IEventManagementRepository repository;

    public ApplyToEventCommand(int userId, int eventId, IEventManagementRepository repository)
    {
        this.userId = userId;
        this.eventId = eventId;
        this.repository = repository;
    }

    public override void Execute(object? parameter) =>
        repository.ApplyForEvent(userId, eventId);

    public override bool CanExecute(object? parameter)
    {
        // I think this is not performance-happy. Better solution needed

        var applications = repository.GetAllApplicationsForSpecificUser(userId);

        foreach (var application in applications)
            if (application.EventId == eventId)
                return false;
        
        return base.CanExecute(parameter);
    }
}
