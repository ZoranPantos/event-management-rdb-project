namespace EventManagement.Demo.DTOs;

public class SingleGroupMemberDTO
{
    public int UserId { get; set; }
    public int Age { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Interests { get; set; } = string.Empty;
}
