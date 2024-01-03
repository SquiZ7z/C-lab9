using System;
using System.Collections.Generic;

class Person : IComparable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }

    public int CompareTo(Person other)
    {
        // Порівнюємо за іменем, віком і містом
        int nameComparison = String.Compare(this.Name, other.Name, StringComparison.Ordinal);
        if (nameComparison != 0)
        {
            return nameComparison;
        }

        int ageComparison = this.Age.CompareTo(other.Age);
        if (ageComparison != 0)
        {
            return ageComparison;
        }

        return String.Compare(this.City, other.City, StringComparison.Ordinal);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть дані про людей у форматі: {ім'я} {вік} {місто}");
        Console.WriteLine("Заверште введення, написавши 'КІНЕЦЬ'");

        List<Person> people = new List<Person>();

        // Зчитуємо введення до отримання "КІНЕЦЬ"
        string input;
        while ((input = Console.ReadLine()) != "КІНЕЦЬ")
        {
            string[] tokens = input.Split();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string city = tokens[2];

            people.Add(new Person { Name = name, Age = age, City = city });
        }

        // Сортуємо список людей за допомогою IComparable
        people.Sort();

        // Виводимо статистику
        int equalCount = 0;
        int notEqualCount = 0;

        for (int i = 1; i < people.Count; i++)
        {
            if (people[i - 1].CompareTo(people[i]) == 0)
            {
                equalCount++;
            }
            else
            {
                notEqualCount++;
            }
        }

        // Виводимо результат
        if (equalCount == 0)
        {
            Console.WriteLine("Немає збігів");
        }
        else
        {
            Console.WriteLine($"Кількість рівних: {equalCount}");
            Console.WriteLine($"Кількість нерівних: {notEqualCount}");
            Console.WriteLine($"Загальна кількість: {people.Count}");
        }
    }
}
