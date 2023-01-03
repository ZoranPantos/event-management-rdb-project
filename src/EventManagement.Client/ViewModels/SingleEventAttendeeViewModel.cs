using EventManagement.Demo.DTOs;

namespace EventManagement.Demo.ViewModels;

public class SingleEventAttendeeViewModel : ViewModelBase
{
    private SingleEventAttendeeDTO attendeeDTO;

    public string FirstName => attendeeDTO.FirstName;
    public string LastName => attendeeDTO.LastName;

    public SingleEventAttendeeViewModel(SingleEventAttendeeDTO attendeeDTO) =>
        this.attendeeDTO = attendeeDTO;
}
