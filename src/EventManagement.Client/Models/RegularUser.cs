using System;
using System.Collections.Generic;

namespace EventManagement.Demo.Models;

public class RegularUser
{
    public int Id { get; set; }
    public int Age { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Interests { get; set; } = string.Empty;

    public DateTime MemberSince { get; set; }

    public bool IsSuspended { get; set; }
}
