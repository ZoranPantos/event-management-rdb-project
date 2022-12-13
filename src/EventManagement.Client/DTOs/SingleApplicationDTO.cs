using System;

namespace EventManagement.Demo.DTOs;

public class SingleApplicationDTO
{
    public int UserId { get; set; }
    public int EventId { get; set; }

    public string Group { get; set; } = string.Empty;
    public string Event { get; set; } = string.Empty;

    public DateTime EventDate { get; set; }
}
