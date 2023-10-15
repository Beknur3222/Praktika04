using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika04
{
    internal class Exemple5
    {
        class Passenger
        {
            public string Name { get; set; }
            // Другие свойства для пассажира.

            public Ticket RequestTicket(string destination, DateTime dateTime)
            {
                // Создание запроса на билет.
                return new Ticket();
            }
        }

        class Ticket
        {
            public string TrainNumber { get; set; }
            public string Destination { get; set; }
            public DateTime DepartureTime { get; set; }
            public decimal Price { get; set; }
        }

        class Cashier
        {
            public void SetPrices(Dictionary<string, decimal> prices)
            {
                // Установка цен на билеты.
            }

            public Ticket IssueTicket(string trainNumber, string destination, DateTime dateTime)
            {
                // Выдача билета пассажиру.
                return new Ticket();
            }
        }

        class Program
        {
            static void Main()
            {
                // Создаем экземпляр кассира
                Cashier cashier = new Cashier();

                // Устанавливаем цены на билеты
                Dictionary<string, decimal> ticketPrices = new Dictionary<string, decimal>
        {
            { "Train123", 50.00M },
            { "Train456", 70.00M },
            { "Train789", 90.00M }
        };
                cashier.SetPrices(ticketPrices);

                // Создаем экземпляр пассажира
                Passenger passenger = new Passenger { Name = "Пассажир 1" };

                // Пассажир запрашивает билет
                string requestedTrainNumber = "Train123";
                string destination = "Назначение 1";
                DateTime departureTime = DateTime.Now.AddHours(2);
                Ticket requestedTicket = passenger.RequestTicket(destination, departureTime);

                // Кассир выдает билет
                Ticket issuedTicket = cashier.IssueTicket(requestedTrainNumber, destination, departureTime);

                // Выводим информацию о билетах
                Console.WriteLine("Запрошенный билет:");
                Console.WriteLine($"Поезд: {requestedTicket.TrainNumber}, Назначение: {requestedTicket.Destination}, Время отправления: {requestedTicket.DepartureTime}, Цена: {requestedTicket.Price}");

                Console.WriteLine("\nВыданный билет:");
                Console.WriteLine($"Поезд: {issuedTicket.TrainNumber}, Назначение: {issuedTicket.Destination}, Время отправления: {issuedTicket.DepartureTime}, Цена: {issuedTicket.Price}");
            }
        }
    }
}
