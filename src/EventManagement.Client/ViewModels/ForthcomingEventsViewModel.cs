using EventManagement.Demo.Infrastructure.Repositories;
using System.Collections.ObjectModel;

namespace EventManagement.Demo.ViewModels;

public class ForthcomingEventsViewModel : ViewModelBase
{
    public ObservableCollection<SingleForthcomingEventViewModel> Airings { get; set; }

    public ForthcomingEventsViewModel(IEventManagementRepository repository)
    {
        Airings = new();

        PopulateViewModel(repository);
    }

    private void PopulateViewModel(IEventManagementRepository repository)
    {
        var airingEventDTOs = repository.GetForthcomingEvents();

        foreach (var airingEventDTO in airingEventDTOs)
            Airings.Add(new SingleForthcomingEventViewModel(airingEventDTO));
    }
}
