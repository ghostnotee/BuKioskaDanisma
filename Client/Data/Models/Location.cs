namespace Client.Data.Models;

public class Location(char column, byte row, sbyte? floor)
{
    public char Column { get; set; } = column;
    public byte Row { get; set; } = row;
    public sbyte? Floor { get; set; } = floor;

    public override string ToString()
    {
        return $"Kat: {Floor}. Konum: {Row}-{Column}";
    }
}