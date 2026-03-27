using System;

namespace Task3
{
    public delegate bool FilterPredicate(int num);

    class Program
    {
        static void FilterArray(int[] numbers, FilterPredicate predicate)
        {
            foreach (int number in numbers)
            {
                if (predicate(number))
                {
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }

        static bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        static bool IsGreaterThanFive(int num)
        {
            return num > 5;
        }

        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.Write("Парні числа: ");
            FilterArray(numbers, IsEven);

            Console.Write("Більше 5: ");
            FilterArray(numbers, IsGreaterThanFive);

            Console.Write("Непарні числа (лямбда): ");
            FilterArray(numbers, x => x % 2 != 0);
        }
    }
}