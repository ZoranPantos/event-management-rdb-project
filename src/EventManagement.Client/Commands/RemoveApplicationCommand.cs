using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace EventManagement.Demo.Commands;

public class RemoveApplicationCommand : CommandBase
{
    private readonly int userId, eventId;
    private readonly IEventManagementRepository repository;
    private readonly ObservableCollection<SingleApplicationViewModel> applications;
    private readonly SingleApplicationViewModel viewModel;

    public RemoveApplicationCommand(
        int userId,
        int eventId,
        IEventManagementRepository repository,
        ObservableCollection<SingleApplicationViewModel> applications,
        SingleApplicationViewModel viewModel)
    {
        this.userId = userId;
        this.eventId = eventId;
        this.repository = repository;
        this.applications = applications;
        this.viewModel = viewModel;
    }

    public override void Execute(object? parameter)
    {
        MessageBox.Show($"User ID: {userId} ; Event ID: {eventId}");
        repository.DeleteEventApplication(userId, eventId);

        // Add check here if deletion in repository was successful first
        applications.Remove(viewModel);
    }
}
