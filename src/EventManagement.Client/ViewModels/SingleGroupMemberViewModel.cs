using EventManagement.Demo.DTOs;

namespace EventManagement.Demo.ViewModels;

public class SingleGroupMemberViewModel : ViewModelBase
{
    private readonly SingleGroupMemberDTO groupMemberDTO;

    public int UserId => groupMemberDTO.UserId;
    public string FirstName => groupMemberDTO.FirstName;
    public string LastName => groupMemberDTO.LastName;
    public int Age => groupMemberDTO.Age;
    public string Interests => groupMemberDTO.Interests;

    public SingleGroupMemberViewModel(SingleGroupMemberDTO groupMemberDTO) =>
        this.groupMemberDTO = groupMemberDTO;
}
