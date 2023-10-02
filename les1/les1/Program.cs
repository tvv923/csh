using les1;
using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Calculator calc = new Calculator();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Калькулятор.");
            Console.WriteLine("1. Додавання.");
            Console.WriteLine("2. Віднімання.");
            Console.WriteLine("3. Множення.");
            Console.WriteLine("4. Ділення.");
            Console.WriteLine("5. Корінь квадратний.");
            Console.WriteLine("6. Зведення в ступінь.");
            Console.WriteLine("7. Факторіал.");
            Console.WriteLine("8. Вихід.");
            Console.WriteLine("Ваш вибір.");

            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    calc.Add();
                    break;
                case "D2":
                    calc.Subtract();
                    break; 
                case "D3":
                    calc.Multiply();
                    break;
                case "D4":
                    calc.Divide();
                    break;
                case "D5":
                    calc.SquareRoot();
                    break;
                case "D6":
                    calc.Power();
                    break;
                case "D7":
                    calc.Factorial();
                    break;
                case "D8":
                    return;                    
            }
        }
    }
}
