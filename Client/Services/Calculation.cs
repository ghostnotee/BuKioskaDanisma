using Client.Data;
using Client.Data.Models;

namespace Client.Services;

public class Calculation
{
    public List<string> GetStoreWay(CalculateRequest calculateRequest)
    {
        List<string> path = [$"{calculateRequest.Kiosk!.Id}. Kiosktan {calculateRequest.Store!.Name} mağazasına giden yol: "];
        var totalDistance = 100;
        var closeTransport = new VerticalTransportation();

        if (calculateRequest.Kiosk!.Location!.Floor != calculateRequest.Store!.Location.Floor)
        {
            // Merdiven ve Asansör'den yakın olanı seç.
            foreach (var verticalTransport in StaticData.VerticalTransportations)
            {
                var colDifference = Math.Abs(calculateRequest.Kiosk.Location.Column - verticalTransport.Location.Column);
                var rowDifference = Math.Abs(calculateRequest.Kiosk.Location.Row - verticalTransport.Location.Row);
                if ((colDifference + rowDifference) < totalDistance)
                    closeTransport = verticalTransport;
                totalDistance = colDifference + rowDifference;
            }

            if (calculateRequest.Kiosk.Location.Row != closeTransport.Location.Row)
            {
                // x eksenine göre hareketin tespiti
                if (calculateRequest.Kiosk.Location.Row < closeTransport.Location.Row)
                {
                    while (calculateRequest.Kiosk.Location.Row != closeTransport.Location.Row)
                    {
                        path.Add($"{calculateRequest.Kiosk.Location.Row + 1}{calculateRequest.Kiosk.Location.Column}, ");
                        calculateRequest.Kiosk.Location.Row++;
                    }
                }

                // x eksenine göre hareketin tespiti.
                if (calculateRequest.Kiosk.Location.Row > closeTransport.Location.Row)
                {
                    while (calculateRequest.Kiosk.Location.Row != closeTransport.Location.Row)
                    {
                        path.Add($"{calculateRequest.Kiosk.Location.Row - 1}{calculateRequest.Kiosk.Location.Column}, ");
                        calculateRequest.Kiosk.Location.Row--;
                    }
                }
            }

            if (calculateRequest.Kiosk.Location.Column != closeTransport.Location.Column)
            {
                // y ekseni hareketi yönü
                if (calculateRequest.Kiosk.Location.Column < closeTransport.Location.Column)
                {
                    while (calculateRequest.Kiosk.Location.Column != closeTransport.Location.Column)
                    {
                        path.Add($"{calculateRequest.Kiosk.Location.Row}{Convert.ToChar(calculateRequest.Kiosk.Location.Column + 1)}, ");
                        calculateRequest.Kiosk.Location.Column++;
                    }
                }

                // y ekseni hareketi yönü
                if (calculateRequest.Kiosk.Location.Column > closeTransport.Location.Column)
                {
                    while (calculateRequest.Kiosk.Location.Column != closeTransport.Location.Column)
                    {
                        path.Add($"{calculateRequest.Kiosk.Location.Row}{Convert.ToChar(calculateRequest.Kiosk.Location.Column - 1)}, ");
                        calculateRequest.Kiosk.Location.Column--;
                    }
                }
            }

            path.Add($"{closeTransport.Name} kullanınız.");

            if (closeTransport.Location.Row != calculateRequest.Store.Location.Row)
            {
                if (closeTransport.Location.Row < calculateRequest.Store.Location.Row)
                {
                    while (closeTransport.Location.Row != calculateRequest.Store.Location.Row)
                    {
                        path.Add($"{closeTransport.Location.Row + 1}{closeTransport.Location.Column}");
                        closeTransport.Location.Row++;
                    }
                }

                if (closeTransport.Location.Row > calculateRequest.Store.Location.Row)
                {
                    while (closeTransport.Location.Row != calculateRequest.Store.Location.Row)
                    {
                        path.Add($"{closeTransport.Location.Row - 1}{closeTransport.Location.Column}");
                        closeTransport.Location.Row--;
                    }
                }
            }

            if (closeTransport.Location.Column != calculateRequest.Store.Location.Column)
            {
                if (closeTransport.Location.Column < calculateRequest.Store.Location.Column)
                {
                    while (closeTransport.Location.Column != calculateRequest.Store.Location.Column)
                    {
                        path.Add($"{closeTransport.Location.Row}{Convert.ToChar(closeTransport.Location.Column + 1)}");
                        closeTransport.Location.Column++;
                    }
                }

                if (closeTransport.Location.Column > calculateRequest.Store.Location.Column)
                {
                    while (closeTransport.Location.Column != calculateRequest.Store.Location.Column)
                    {
                        path.Add($"{closeTransport.Location.Row}{Convert.ToChar(closeTransport.Location.Column - 1)}");
                        closeTransport.Location.Column--;
                    }
                }
            }

            return path;
        }

        // Aynı Katta iseler
        if (calculateRequest.Kiosk.Location.Row != calculateRequest.Store.Location.Row)
        {
            // Varılacak Noktanın y eksenine göre haretinin tespiti.
            if (calculateRequest.Kiosk.Location.Row < calculateRequest.Store.Location.Row)
            {
                while (calculateRequest.Kiosk.Location.Row != calculateRequest.Store.Location.Row)
                {
                    path.Add($"{calculateRequest.Kiosk.Location.Row + 1}{calculateRequest.Kiosk.Location.Column}, ");
                    calculateRequest.Kiosk.Location.Row++;
                }
            }

            // Varılacak Noktanın y eksenine göre haretinin tespiti.
            if (calculateRequest.Kiosk.Location.Row > calculateRequest.Store.Location.Row)
            {
                while (calculateRequest.Kiosk.Location.Row != calculateRequest.Store.Location.Row)
                {
                    path.Add($"{calculateRequest.Kiosk.Location.Row - 1}{calculateRequest.Kiosk.Location.Column}, ");
                    calculateRequest.Kiosk.Location.Row--;
                }
            }
        }

        if (calculateRequest.Kiosk.Location.Column != calculateRequest.Store.Location.Column)
        {
            // Varılacak noktanın x eksenine göre hareketinin tespiti.
            if (calculateRequest.Kiosk.Location.Column < calculateRequest.Store.Location.Column)
            {
                while (calculateRequest.Kiosk.Location.Column != calculateRequest.Store.Location.Column)
                {
                    path.Add($"{calculateRequest.Kiosk.Location.Row}{Convert.ToChar(calculateRequest.Kiosk.Location.Column + 1)}, ");
                    closeTransport.Location.Column++;
                }
            }

            // Varılacak noktanın x eksenine göre hareketinin tespiti.
            if (calculateRequest.Kiosk.Location.Column > calculateRequest.Store.Location.Column)
            {
                while (calculateRequest.Kiosk.Location.Column != calculateRequest.Store.Location.Column)
                {
                    path.Add($"{calculateRequest.Kiosk.Location.Row}{Convert.ToChar(calculateRequest.Kiosk.Location.Column - 1)}, ");
                    calculateRequest.Kiosk.Location.Column--;
                }
            }
        }

        return path;
    }
}