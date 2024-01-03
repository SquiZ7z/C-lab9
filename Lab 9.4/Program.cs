using System;
using System.Collections;
using System.Collections.Generic;

class Озеро : IEnumerable<int>
{
    private List<int> камені;

    // Конструктор класу Озеро, приймає масив каменів
    public Озеро(int[] камені)
    {
        // Ініціалізуємо список каменів
        this.камені = new List<int>(камені);
    }

    // Реалізація методу GetEnumerator() інтерфейсу IEnumerable<int>
    public IEnumerator<int> GetEnumerator()
    {
        // Підказка: Перший прохід - парні позиції в порядку зростання
        Console.WriteLine("Перший прохід: парні позиції в порядку зростання");
        for (int i = 0; i < камені.Count; i += 2)
        {
            Console.WriteLine($"Стрибаємо на камінь {камені[i]}");
            yield return камені[i]; // Повертаємо значення каменя
        }

        // Підказка: Другий прохід - непарні позиції в зворотньому порядку
        Console.WriteLine("Другий прохід: непарні позиції в зворотньому порядку");
        for (int i = камені.Count % 2 == 0 ? камені.Count - 1 : камені.Count - 2; i >= 0; i -= 2)
        {
            Console.WriteLine($"Стрибаємо на камінь {камені[i]}");
            yield return камені[i]; // Повертаємо значення каменя
        }
    }

    // Реалізація необхідного для інтерфейсу IEnumerable методу GetEnumerator()
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        // Підказка: Вхідні дані - номери каменів
        int[] камені = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine("Вхідні дані: номери каменів у порядку");
        foreach (var камінь in камені)
        {
            Console.Write(камінь + " ");
        }

        Console.WriteLine("\n\nЗміна порядку стрибків жаби:\n");

        // Використання класу Озеро та циклу foreach для ітерації через всі камені в порядку, описаному в завданні
        Озеро озеро = new Озеро(камені);
        foreach (int камінь in озеро)
        {
            Console.Write(камінь + " ");
        }
    }
}
