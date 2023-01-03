using EventManagement.Demo.Commands;
using EventManagement.Demo.DTOs;
using EventManagement.Demo.Infrastructure.Repositories;
using System.Windows.Input;
using System.Collections.ObjectModel;
using EventManagement.Demo.Stores;

namespace EventManagement.Demo.ViewModels;

public class SingleGroupEventViewModel : ViewModelBase
{
    private readonly SingleGroupEventDTO groupEventDTO;
    private readonly IEventManagementRepository repository;
    private readonly NavigationStore navigationStore;
    private readonly int groupId;

    public int EventId => groupEventDTO.EventId;
    public string Title => groupEventDTO.Title;

    public ICommand VisitEventPageCommand { get; }
    public ICommand DeleteEventCommand { get; }

    public SingleGroupEventViewModel(
        SingleGroupEventDTO groupEventDTO,
        IEventManagementRepository repository,
        ObservableCollection<SingleGroupEventViewModel> events,
        NavigationStore navigationStore,
        int groupId)
    {
        this.groupEventDTO = groupEventDTO;
        this.repository = repository;
        this.navigationStore = navigationStore;
        this.groupId = groupId;

        VisitEventPageCommand = new NavigateCommand(navigationStore, CreateEventDetailsViewModel);
        DeleteEventCommand = new DeleteEventCommand(repository, EventId, events, this);
    }

    private EventDetailsViewModel CreateEventDetailsViewModel() =>
        new(repository, EventId, CreateGroupDetailsViewModel, navigationStore);

    private GroupDetailsViewModel CreateGroupDetailsViewModel() =>
        new(groupId, repository, navigationStore);
}
