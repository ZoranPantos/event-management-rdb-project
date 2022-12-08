using System;
using System.Collections.Generic;

namespace EventManagement.Demo.Models;

public class RegularUser
{
    public int Id { get; set; }
    public int Age { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    // Will have to filter/format user input somehow in order to populate this collection
    public List<string> Interests { get; set; } = new();
    public DateTime MemberSince { get; set; }

    public bool IsSuspended { get; set; }
}
