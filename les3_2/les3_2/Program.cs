using System;
using les3_2;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int[] arrayData = { 10, 25, 7, 14, 32, 18, 42, 31, 4, 56 };
        les3_2.Array array = new les3_2.Array(arrayData);
        while (true)
        {
            Console.Clear();
            array.Show();
            Console.WriteLine("Що шукаємо:");
            Console.WriteLine("1. Максимум.");
            Console.WriteLine("2. Мінімум.");
            Console.WriteLine("3. Середнє арифметичне.");
            Console.WriteLine("4. Конкретне значення.");
            Console.WriteLine("5. Вихід.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    Console.WriteLine("Максимум: " + array.Max());
                    array.AfterCalculate();
                    break;
                case "D2":
                    Console.WriteLine("Мінімум: " + array.Min());
                    array.AfterCalculate();
                    break;
                case "D3":
                    Console.WriteLine("Середнє арифметичне: " + array.Avg());
                    array.AfterCalculate();
                    break;
                case "D4":
                    array.CheckInput();
                    if (!array.errorExists)
                        if (array.Search())
                            Console.WriteLine("Значення " + array.valueToSearch + " знайдено.");
                        else
                            Console.WriteLine("Значення " + array.valueToSearch + " не знайдено.");
                    array.AfterCalculate();
                    break;
                case "D5":
                    return;
            }
        }
    }
}