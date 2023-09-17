/*
 * Business Rule:
 *
 * First, we need to receive the parking price, then, the per-hour price.
 * The menu must have the following fields:
 *  1. Add car - OK
 *  2. Remove car
 *  3. List cars
 *  4. Exit program
 *
 * Features description:
 *  1- Parking Price: Must receive an user input, asking for the parking price
 *  2- Per-hour price: Must receive an user input asking for the hour price
 *
 * Menu features ->
 *  1- Add car: Must receive the car ID (Placa do carro)
 *  2- Remove car: Must receive the car ID, total hours the car spent in the parking lot, and then,
 *      calculate the final price (parkingPrice + (perHourPrice * hoursIn))
 *  3- List cars: Must show all the cars in the parking lot
 *  4- Exit program
 */

using ParkingLotSystem.Modules;

Console.WriteLine("Qual é a capacidade(vagas) do estacionamento? ");
byte parkingLotCapacity = Convert.ToByte(Console.ReadLine());

var carList = new List<string>(parkingLotCapacity);

Console.WriteLine("Digite o preço inicial do estacionamento: ");
decimal parkingPrice = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Digite o preço por hora do estacionamento: ");
decimal perHour = Convert.ToDecimal(Console.ReadLine());

var parkLot = new ParkingLot(parkingPrice, perHour, carList);

Console.Clear();

byte option = 0;
while (option != 4)
{
    Console.WriteLine("ParkIT - Gestão de estacionamentos");
    Console.WriteLine("1 - Cadastrar carro.");
    Console.WriteLine("2 - Remover carro.");
    Console.WriteLine("3 - Listar carros");
    Console.WriteLine("4 - Sair do programa");
    Console.Write("Escolha uma das opcoes acima: ");

    try
    {
        option = Convert.ToByte(Console.ReadLine());
        Console.Clear();

        if (option == 1)
        {
            Console.Write("Digite a placa do carro a ser cadastrado: ");
            string carId = Console.ReadLine();
            string successMessage = parkLot.AddCar(carId);
            Console.WriteLine(successMessage);
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }
        else if (option == 2)
        {
            Console.Write("Digite a placa do carro a ser removido: ");
            string carId = Console.ReadLine();
            Console.Write("Quantidade de horas no estacionamento: ");
            double hoursSpent = Convert.ToDouble(Console.ReadLine());
            string successMessage = parkLot.RemoveCar(carId, hoursSpent);
            Console.WriteLine(successMessage);
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }
        else if (option == 3)
        {
            Console.WriteLine("Todos os carros estacionados: ");
            string successMessage = parkLot.ListCars();
            Console.WriteLine(successMessage);
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    catch (FormatException error)
    {
        Console.WriteLine("\nVocê deve digitar um numero inteiro! (int)\n");
    }
}

