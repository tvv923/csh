using System;
using les3_3;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int[] arrayData = { 10, 25, 7, 14, 32, 18, 42, 31, 4, 56 };
        les3_3.Array array = new les3_3.Array(arrayData);
        while (true)
        {
            Console.Clear();
            array.Show();
            Console.WriteLine("Сортування масива:");
            Console.WriteLine("1. За зростанням.");
            Console.WriteLine("2. За зменшенням.");
            Console.WriteLine("3. За параметром.");
            Console.WriteLine("4. Вихід.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    array.SortAsc();
                    array.Show();
                    array.AfterShow();
                    break;
                case "D2":
                    array.SortDesc();
                    array.Show();
                    array.AfterShow();
                    break;
                case "D3":
                    array.CheckInput();
                    if (!array.errorExists)
                    {
                        array.SortByParam(array.param);
                        array.Show();
                    }
                    array.AfterShow();
                    break;
                case "D4":
                    return;
            }
        }
    }
}
