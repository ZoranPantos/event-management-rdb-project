namespace EventManagement.Demo.Models;

public class Location
{
    public int Id { get; set; }
    public int Number { get; set; }

    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;

    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public override string ToString() => $"{City}, {Street} {Number} ({Latitude}, {Longitude})";
}
