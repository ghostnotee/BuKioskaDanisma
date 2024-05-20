#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Client.Data.Models;

public class VerticalTransportation
{
    public VerticalTransportation()
    {
    }

    public VerticalTransportation(string name, Location location)
    {
        Name = name;
        Location = location;
    }

    public string Name { get; set; }
    public Location Location { get; set; }
}