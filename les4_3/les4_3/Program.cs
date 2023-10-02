using System;
using les4_3;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        City city1 = new City("Київ", 8000000);
        City city2 = new City("Варшава", 4000000);
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Маємо два міста:");
            Console.WriteLine(city1);
            Console.WriteLine(city2);
            Console.WriteLine("Що будемо робити:");
            Console.WriteLine("1. Збільшити населення першого міста.");
            Console.WriteLine("2. Зменшити населення другого міста.");
            Console.WriteLine("3. Перевірка на рівність населення міст.");
            Console.WriteLine("4. Перевірка на меншу кількість мешканців.");
            Console.WriteLine("5. Перевірка на більшу кількість мешканців.");
            Console.WriteLine("6. Перевірка на нерівність міст за населенням.");
            Console.WriteLine("7. Перевірка міст Equals.");
            Console.WriteLine("8. Вихід.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    city1.CheckInput();
                    if (!city1.errorExists)
                    {
                        city1 += city1.AddPopulation;
                        Console.WriteLine(city1);
                    }
                    city1.AfterShow();
                    break;
                case "D2":
                    city2.CheckInput();
                    if (!city2.errorExists)
                    {
                        city2 -= city2.AddPopulation;
                        Console.WriteLine(city2);
                    }
                    city2.AfterShow();
                    break;
                case "D3":
                    Console.WriteLine($"місто.1 == місто.2: {city1 == city2}");
                    city1.AfterShow();
                    break;
                case "D4":
                    Console.WriteLine($"місто.1 < місто.2: {city1 < city2}");
                    city1.AfterShow();
                    break;
                case "D5":
                    Console.WriteLine($"місто.1 > місто.2: {city1 > city2}");
                    city1.AfterShow();
                    break;
                case "D6":
                    Console.WriteLine($"місто.1 != місто.2: {city1 != city2}");
                    city1.AfterShow();
                    break;
                case "D7":
                    Console.WriteLine($"місто.1 Equals місто.2: {city1.Equals(city2)}");
                    city1.AfterShow();
                    break;
                case "D8":
                    return;
            }
        }
    }
}

