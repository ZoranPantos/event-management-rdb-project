namespace EventManagement.Demo.Models;

public class Sponsor
{
    public int Id { get; set; }
    public int EstablishmentYear { get; set; }

    public string Name { get; set; } = string.Empty;
    public string DomainOfWork { get; set; } = string.Empty;
    public string CurrentCEO { get; set; } = string.Empty;
    public string Headquarters { get; set; } = string.Empty;
    public string Motto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
