using System;

namespace EventManagement.Demo.DTOs;

public class ForthcomingEventDTO
{
    public int EventId { get; set; }
    public int Number { get; set; }

    public DateTime Date { get; set; }

    public string EventTitle { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DailySchedule { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string GroupName { get; set; } = string.Empty;
    public string Topics { get; set; } = string.Empty;
    public string Sponsors { get; set; } = string.Empty;
}
