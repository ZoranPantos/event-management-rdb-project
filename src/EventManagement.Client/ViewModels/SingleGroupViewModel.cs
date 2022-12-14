using EventManagement.Demo.DTOs;

namespace EventManagement.Demo.ViewModels;

public class SingleGroupViewModel : ViewModelBase
{
    private readonly SingleGroupDTO groupDTO;

    public int GroupId => groupDTO.GroupId;
    public string Group => groupDTO.Title;

    public SingleGroupViewModel(SingleGroupDTO groupDTO)
    {
        this.groupDTO = groupDTO;
    }
}
