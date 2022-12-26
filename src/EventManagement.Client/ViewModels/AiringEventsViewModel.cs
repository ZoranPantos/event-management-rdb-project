using EventManagement.Demo.Infrastructure.Repositories;
using System.Collections.ObjectModel;

namespace EventManagement.Demo.ViewModels;

public class AiringEventsViewModel : ViewModelBase
{
    public ObservableCollection<SingleForthcomingEventViewModel> Airings { get; set; }

    public AiringEventsViewModel(IEventManagementRepository repository)
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
