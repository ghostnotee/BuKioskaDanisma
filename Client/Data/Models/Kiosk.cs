namespace Client.Data.Models;

public class Kiosk
{
    public Kiosk(byte id, Location location)
    {
        Id = id;
        Location = location;
    }

    public Kiosk()
    {
    }

    public byte Id { get; set; }
    public Location? Location { get; set; }
}