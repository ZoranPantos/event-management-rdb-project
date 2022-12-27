using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace EventManagement.Demo.Commands;

public class DeleteEventCommand : CommandBase
{
    private int eventId;
    private readonly IEventManagementRepository repository;
    private readonly ObservableCollection<SingleGroupEventViewModel> events;
    private readonly SingleGroupEventViewModel viewModel;

    public DeleteEventCommand(
        IEventManagementRepository repository,
        int eventId,
        ObservableCollection<SingleGroupEventViewModel> events,
        SingleGroupEventViewModel viewModel)
    {
        this.repository = repository;
        this.eventId = eventId;
        this.events = events;
        this.viewModel = viewModel;
    }

    public override void Execute(object? parameter)
    {
        repository.DeleteEvent(eventId);

        // add check if deletion was successful first
        events.Remove(viewModel);
    }
}
