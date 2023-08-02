// Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк,
//  длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, 
//  либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями,
//   лучше обойтись исключительно массивами.

// Примеры:
// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []

using System;

namespace ShortStringsFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = GetUserInput("Введите количество элементов массива:", minValue: 0);

            string[] inputArray = new string[n];
            Console.WriteLine("Введите строки массива:");
            for (int i = 0; i < n; i++)
            {
                inputArray[i] = Console.ReadLine();
            }

            int maxLength = GetUserInput("Введите максимальную длину строки для фильтрации:", minValue: 0);

            // Выводим исходный массив
            Console.WriteLine("Исходный массив:");
            PrintArray(inputArray);

            // Формируем новый массив из строк, длина которых меньше или равна заданной
            string[] filteredArray = FilterStrings(inputArray, maxLength);

            // Выводим новый массив
            Console.WriteLine("\nОтфильтрованный массив:");
            PrintArray(filteredArray);
        }

        static int GetUserInput(string message, int minValue)
        {
            int value;
            do
            {
                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine(), out value) && value >= minValue)
                {
                    return value;
                }
                Console.WriteLine($"Пожалуйста, введите целое число, не меньше {minValue}.");
            } while (true);
        }

        static string[] FilterStrings(string[] array, int maxLength)
        {
            int count = 0;

            // Считаем количество подходящих строк
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length <= maxLength)
                {
                    count++;
                }
            }

            string[] resultArray = new string[count];
            int index = 0;

            // Заполняем новый массив подходящими строками
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length <= maxLength)
                {
                    resultArray[index++] = array[i];
                }
            }

            return resultArray;
        }

        static void PrintArray(string[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("\"" + array[i] + "\"");
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }
    }
}
