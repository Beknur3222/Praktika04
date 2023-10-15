using System;
using System.Collections.Generic;

abstract class Animal
{
    public string Name { get; set; }

    public abstract string TypeOfFood();
}

class Carnivore : Animal
{
    public override string TypeOfFood()
    {
        return "Мясо";
    }
}

class Omnivore : Animal
{
    public override string TypeOfFood()
    {
        return "Мясо и растения";
    }
}

class Herbivore : Animal
{
    public override string TypeOfFood()
    {
        return "Растения";
    }
}

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();
        animals.Add(new Carnivore { Name = "Лев" });
        animals.Add(new Omnivore { Name = "Человек" });
        animals.Add(new Herbivore { Name = "Кролик" });
        animals.Add(new Herbivore { Name = "Коала" });
        animals.Add(new Carnivore { Name = "Тигр" });

        animals.Sort((a1, a2) =>
        {
            int foodComparison = String.Compare(a2.TypeOfFood(), a1.TypeOfFood());
            return foodComparison != 0 ? foodComparison : String.Compare(a1.Name, a2.Name);
        });

        foreach (var animal in animals)
        {
            Console.WriteLine($"Имя: {animal.Name}, Тип: {animal.GetType().Name}, Пища: {animal.TypeOfFood()}");
        }
    }
}
