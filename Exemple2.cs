using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

abstract class Animal : IComparable<Animal>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    public abstract double CalculateFoodAmount();

    public int CompareTo(Animal other)
    {
        int foodComparison = other.CalculateFoodAmount().CompareTo(CalculateFoodAmount());
        if (foodComparison == 0)
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        return foodComparison;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Type: {Type}, Food Amount: {CalculateFoodAmount()}";
    }
}

class Predator : Animal
{
    public override double CalculateFoodAmount()
    {
        // Расчет количества пищи для хищника
        return 10.0;
    }
}

class Omnivore : Animal
{
    public override double CalculateFoodAmount()
    {
        // Расчет количества пищи для всеядного
        return 5.0;
    }
}

class Herbivore : Animal
{
    public override double CalculateFoodAmount()
    {
        // Расчет количества пищи для травоядного
        return 2.0;
    }
}

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>
        {
            new Predator { Id = 1, Name = "Lion", Type = "Predator" },
            new Predator { Id = 2, Name = "Tiger", Type = "Predator" },
            new Omnivore { Id = 3, Name = "Bear", Type = "Omnivore" },
            new Omnivore { Id = 4, Name = "Raccoon", Type = "Omnivore" },
            new Herbivore { Id = 5, Name = "Giraffe", Type = "Herbivore" },
            new Herbivore { Id = 6, Name = "Elephant", Type = "Herbivore" },
        };

        animals.Sort();
        Console.WriteLine("Сортировка по убыванию количества пищи и имени:");
        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }

        Console.WriteLine("\nПервые 5 имен животных:");
        foreach (var animal in animals.Take(5))
        {
            Console.WriteLine(animal.Name);
        }

        Console.WriteLine("\nПоследние 3 идентификатора животных:");
        foreach (var animal in animals.Skip(animals.Count - 3))
        {
            Console.WriteLine(animal.Id);
        }

        // Запись в файл
        using (StreamWriter writer = new StreamWriter("animals.txt"))
        {
            foreach (var animal in animals)
            {
                writer.WriteLine($"{animal.Id},{animal.Name},{animal.Type}");
            }
        }

        // Чтение из файла
        List<Animal> animalsFromFile = new List<Animal>();
        try
        {
            using (StreamReader reader = new StreamReader("animals.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    string type = parts[2];

                    Animal animal = null;
                    if (type == "Predator")
                        animal = new Predator { Id = id, Name = name, Type = type };
                    else if (type == "Omnivore")
                        animal = new Omnivore { Id = id, Name = name, Type = type };
                    else if (type == "Herbivore")
                        animal = new Herbivore { Id = id, Name = name, Type = type };

                    if (animal != null)
                        animalsFromFile.Add(animal);
                }
            }

            Console.WriteLine("\nДанные из файла:");
            foreach (var animal in animalsFromFile)
            {
                Console.WriteLine(animal);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка при чтении файла: " + e.Message);
        }
    }
}
