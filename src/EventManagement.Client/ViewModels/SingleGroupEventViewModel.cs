using EventManagement.Demo.Commands;
using EventManagement.Demo.DTOs;
using EventManagement.Demo.Infrastructure.Repositories;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace EventManagement.Demo.ViewModels;

public class SingleGroupEventViewModel : ViewModelBase
{
    private readonly SingleGroupEventDTO groupEventDTO;

    public int EventId => groupEventDTO.EventId;
    public string Title => groupEventDTO.Title;

    public ICommand VisitEventPageCommand { get; }
    public ICommand DeleteEventCommand { get; }

    public SingleGroupEventViewModel(
        SingleGroupEventDTO groupEventDTO,
        IEventManagementRepository repository,
        ObservableCollection<SingleGroupEventViewModel> events)
    {
        this.groupEventDTO = groupEventDTO;

        DeleteEventCommand = new DeleteEventCommand(repository, EventId, events, this);
    }
}
