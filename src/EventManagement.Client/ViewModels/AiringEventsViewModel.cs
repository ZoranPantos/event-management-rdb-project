using EventManagement.Demo.Infrastructure.Repositories;
using System.Collections.ObjectModel;

namespace EventManagement.Demo.ViewModels;

public class AiringEventsViewModel : ViewModelBase
{
    public ObservableCollection<SingleAiringEventViewModel> Airings { get; set; }

    public AiringEventsViewModel(IEventManagementRepository repository)
    {
        Airings = new();

        PopulateViewModel(repository);
    }

    private void PopulateViewModel(IEventManagementRepository repository)
    {
        var airingEventDTOs = repository.GetAiringEvents();

        foreach (var airingEventDTO in airingEventDTOs)
            Airings.Add(new SingleAiringEventViewModel(airingEventDTO));
    }
}
