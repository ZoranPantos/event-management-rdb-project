using System;

namespace EventManagement.Demo.Models;

public class Event
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DailySchedule { get; set; } = string.Empty;

    public bool IsReccuring { get; set; }
    public bool IsOpen { get; set; }
    public bool IsSuspended { get; set; }

    public DateTime Date { get; set; }
    public Location Location { get; set; } = new();
}
