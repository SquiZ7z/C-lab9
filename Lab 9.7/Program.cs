using System;
using System.Collections.Generic;

public class Person : IEquatable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Person);
    }

    public bool Equals(Person other)
    {
        if (ReferenceEquals(other, null))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Name == other.Name && Age == other.Age;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Age.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        // Кількість людей N
        Console.WriteLine("Enter the number of people (N):");
        int N = int.Parse(Console.ReadLine());

        // Створення SortedSet і HashSet для об'єктів Person
        SortedSet<Person> sortedSet = new SortedSet<Person>();
        HashSet<Person> hashSet = new HashSet<Person>();

        Console.WriteLine("Enter information about people in the format '<name> <age>':");

        for (int i = 0; i < N; i++)
        {
            // Зчитування введених даних
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            int age = int.Parse(input[1]);

            // Створення об'єкта Person
            Person person = new Person(name, age);

            // Додавання об'єкта до обох множин
            sortedSet.Add(person);
            hashSet.Add(person);
        }

        // Виведення розмірів множин
        Console.WriteLine("\nSize of the SortedSet: " + sortedSet.Count);
        Console.WriteLine("Size of the HashSet: " + hashSet.Count);
    }
}
