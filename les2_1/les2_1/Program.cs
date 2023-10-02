using les2_1;
using System;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Money mon = new();
        Product pro = new();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Гроші і продукти.");
            Console.WriteLine("1. До роботи.");
            Console.WriteLine("2. На вихід.");
            Console.WriteLine("Ваш вибір.");

            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    mon.MoneyInput(1);
                    if (!mon.errorExists)
                    {
                        (pro.currency, pro.majorPart, pro.minorPart, pro.errorExists) = (mon.currency, mon.majorPart, mon.minorPart, mon.errorExists);
                        pro.ProductInput(2);
                    }
                    break;
                case "D2":
                    return;
            }
        }
    }
}