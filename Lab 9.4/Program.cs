using System;
using System.Collections;
using System.Collections.Generic;

class Lake : IEnumerable<int>
{
    private List<int> stones;

    // Конструктор класу Lake, приймає масив каменів
    public Lake(int[] stones)
    {
        // Ініціалізуємо список каменів
        this.stones = new List<int>(stones);
    }

    // Реалізація методу GetEnumerator() інтерфейсу IEnumerable<int>
    public IEnumerator<int> GetEnumerator()
    {
        // Підказка: Перший прохід - парні позиції в порядку зростання
        Console.WriteLine("Перший прохід: парні позиції в порядку зростання");
        for (int i = 0; i < stones.Count; i += 2)
        {
            Console.WriteLine($"Стрибаємо на камінь {stones[i]}");
            yield return stones[i]; // Повертаємо значення каменя
        }

        // Підказка: Другий прохід - непарні позиції в зворотньому порядку
        Console.WriteLine("Другий прохід: непарні позиції в зворотньому порядку");
        for (int i = stones.Count % 2 == 0 ? stones.Count - 1 : stones.Count - 2; i >= 0; i -= 2)
        {
            Console.WriteLine($"Стрибаємо на камінь {stones[i]}");
            yield return stones[i]; // Повертаємо значення каменя
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
    private static readonly int[] stones;

    static void Main()
    {
        // Підказка: Вхідні дані - номери
        int[] камені = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine("Вхідні дані: номери stones у порядку");
        foreach (var stones in stones)
        {
            Console.Write(stones + " ");
        }

        Console.WriteLine("\n\nЗміна порядку стрибків жаби:\n");

        // Використання класу Озеро та циклу foreach для ітерації через всі камені в порядку, описаному в завданні
        Lake lake = new Lake(stones);
        foreach (int камінь in lake)
        {
            Console.Write(камінь + " ");
        }
    }
}
