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
        return "����";
    }
}

class Omnivore : Animal
{
    public override string TypeOfFood()
    {
        return "���� � ��������";
    }
}

class Herbivore : Animal
{
    public override string TypeOfFood()
    {
        return "��������";
    }
}

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();
        animals.Add(new Carnivore { Name = "���" });
        animals.Add(new Omnivore { Name = "�������" });
        animals.Add(new Herbivore { Name = "������" });
        animals.Add(new Herbivore { Name = "�����" });
        animals.Add(new Carnivore { Name = "����" });

        animals.Sort((a1, a2) =>
        {
            int foodComparison = String.Compare(a2.TypeOfFood(), a1.TypeOfFood());
            return foodComparison != 0 ? foodComparison : String.Compare(a1.Name, a2.Name);
        });

        foreach (var animal in animals)
        {
            Console.WriteLine($"���: {animal.Name}, ���: {animal.GetType().Name}, ����: {animal.TypeOfFood()}");
        }
    }
}
