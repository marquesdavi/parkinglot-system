namespace ParkingLotSystem.Modules;

public class ParkingLot
{
    private decimal parkingPrice;
    private decimal perHour;
    private List<string> cars;

    public ParkingLot(decimal parkingPrice, decimal perHour, List<string> cars)
    {
        this.parkingPrice = parkingPrice;
        this.perHour = perHour;
        this.cars = cars;
    }

    public string AddCar(string carId)
    {
        if (!(cars.Contains(carId)))
        {
            cars.Add(carId);
            return $"O carro com placa {carId} foi cadastrado";
        }
        else
        {
            return $"Um carro com a placa {carId} já está cadastrado! Tente outra placa!";
        }
    }

    public string RemoveCar(string carId, double timeSpent)
    {
        if (cars.Contains(carId))
        {
            decimal finalPrice = (parkingPrice + (perHour * (decimal)timeSpent));
            cars.Remove(carId);
            
            return $"O carro {carId} passou {timeSpent} horas no estacionamento. Valor final de R$ {finalPrice}.";
        }
        else
        {
            return $"O carro {carId} não está no estacionamento!";
        }
    }

    public string ListCars()
    {
        string allcars = "";
        for (int i = 0; i < cars.Count; i++)
        {
            allcars += $"\n{i + 1} - " + cars[i];
        }

        return allcars;
    }
}