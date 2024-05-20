using Client.Data.Models;

namespace Client.Data;

public static class StaticData
{
    public static List<Store> Stores =
    [
        new Store("STB", new Location('D', 3, 1)),
        new Store("LCW", new Location('B', 7, 1)),
        new Store("KTN", new Location('H', 7, 1)),
        new Store("BGR", new Location('C', 6, 2))
    ];

    public static List<Kiosk> Kiosks =
    [
        new Kiosk(1, new Location('F', 1, 1)),
        new Kiosk(2, new Location('K', 5, 1)),
        new Kiosk(3, new Location('F', 11, 1))
    ];

    public static List<VerticalTransportation> VerticalTransportations =
    [
        new VerticalTransportation("Asansör", new Location('E',5,null)),
        new VerticalTransportation("Merdiven", new Location('A',5,null)),
    ];
}