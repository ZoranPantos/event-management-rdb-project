namespace EventManagement.Demo.Models;

public class Group
{
    public int Id { get; set; }
    public int MemberCount { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public bool IsPublic { get; set; }
    public bool IsSuspended { get; set; }

    public RegularUser GroupAdmin { get; set; } = new();
    public Venue Venue { get; set; } = new();
}
