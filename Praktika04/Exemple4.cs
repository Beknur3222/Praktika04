using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika04
{
    internal class Exemple4
    {
        class Vehicle
        {
            public string Name { get; set; }
            // Другие свойства для автомобиля.

            public bool IsInRepair { get; set; }
            // Другие свойства для статуса автомобиля.
        }

        class Driver
        {
            public string Name { get; set; }
            // Другие свойства для водителя.

            public void RequestRepair()
            {
                // Запрос на ремонт.
            }
        }

        class Dispatcher
        {
            public void AssignDriverAndVehicle(Driver driver, Vehicle vehicle)
            {
                // Назначение водителя и автомобиля на рейс.
            }

            public void SuspendDriver(Driver driver)
            {
                // Отстранение водителя от работы.
            }

            public void RecordTripCompletion(Driver driver, Vehicle vehicle)
            {
                // Запись о выполнении рейса.
            }
        }

        class Program
        {
            static void Main()
            {
                // Создаем экземпляры водителей и автомобилей
                Driver driver1 = new Driver { Name = "Водитель 1" };
                Driver driver2 = new Driver { Name = "Водитель 2" };
                Vehicle vehicle1 = new Vehicle { Name = "Автомобиль 1", IsInRepair = false };
                Vehicle vehicle2 = new Vehicle { Name = "Автомобиль 2", IsInRepair = true };

                // Создаем экземпляр диспетчера
                Dispatcher dispatcher = new Dispatcher();

                // Назначаем водителей и автомобили на рейсы
                dispatcher.AssignDriverAndVehicle(driver1, vehicle1);
                dispatcher.AssignDriverAndVehicle(driver2, vehicle2);

                // Запрашиваем ремонт для автомобиля
                driver2.RequestRepair();

                // Завершаем рейс и записываем выполнение
                dispatcher.RecordTripCompletion(driver1, vehicle1);

                // Отстраняем водителя от работы
                dispatcher.SuspendDriver(driver2);

                // Выводим информацию о состоянии водителей и автомобилей
                Console.WriteLine("Состояние водителей и автомобилей:");
                Console.WriteLine($"{driver1.Name} - Работает");
                Console.WriteLine($"{driver2.Name} - Отстранен");
                Console.WriteLine($"{vehicle1.Name} - {(vehicle1.IsInRepair ? "На ремонте" : "Готов")}");
                Console.WriteLine($"{vehicle2.Name} - {(vehicle2.IsInRepair ? "На ремонте" : "Готов")}");

            }
        }
    }
}
