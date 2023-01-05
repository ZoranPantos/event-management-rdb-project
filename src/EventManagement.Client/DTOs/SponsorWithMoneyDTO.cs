using EventManagement.Demo.Models;

namespace EventManagement.Demo.DTOs;

public class SponsorWithMoneyDTO
{
    public Sponsor Sponsor { get; set; } = new();
    public decimal MoneyProvided { get; set; }
}
