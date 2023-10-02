using System;
using les2_3;
public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Converter con = new();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Конвертер чисел.");
            Console.WriteLine("1. До роботи.");
            Console.WriteLine("2. На вихід.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    con.CheckInput();
                    if (!con.errorExists)
                    {
                        Console.WriteLine($"Десяткове число: {con.Value}");
                        Console.WriteLine($"Двійкове число: {con.ToBinary()}");
                        Console.WriteLine($"Вісімкове число: {con.ToOctal()}");
                        Console.WriteLine($"Шістнадцяткове число: {con.ToHexadecimal()}");
                    }
                    con.AfterCalculate();
                    break;
                case "D2":
                    return;
            }
        }
    }
}
