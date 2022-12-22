using EventManagement.Demo.DTOs;

namespace EventManagement.Demo.ViewModels;

public class SingleGroupEventViewModel : ViewModelBase
{
    private readonly SingleGroupEventDTO groupEventDTO;

    public int EventId => groupEventDTO.EventId;
    public string Title => groupEventDTO.Title;

    public SingleGroupEventViewModel(SingleGroupEventDTO groupEventDTO)
    {
        this.groupEventDTO = groupEventDTO;
    }
}
