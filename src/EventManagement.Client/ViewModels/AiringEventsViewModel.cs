using System.Collections.ObjectModel;

namespace EventManagement.Demo.ViewModels;

public class AiringEventsViewModel : ViewModelBase
{
    public ObservableCollection<SingleAiringEventViewModel> Airings { get; set; }

    public AiringEventsViewModel()
    {

    }
}
