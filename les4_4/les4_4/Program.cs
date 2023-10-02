using System;
using les4_4;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CreditCard card1 = new CreditCard("1234 5678 9012 3456", "123", 0);
        CreditCard card2 = new CreditCard("9876 5432 1098 7654", "321", 0);        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Маємо двох картки:");
            Console.WriteLine(card1);
            Console.WriteLine(card2);
            Console.WriteLine("Що будемо робити:");
            Console.WriteLine("1. Встановити баланс першої картки.");
            Console.WriteLine("2. Встановити баланс другої картки.");
            Console.WriteLine("3. Збільшити суму грошей на першій картці.");
            Console.WriteLine("4. Зменшити суму грошей на другій картці.");
            Console.WriteLine("5. Перевірка на рівність CVC коду.");
            Console.WriteLine("6. Перевірка на меншу кількість суми грошей.");
            Console.WriteLine("7. Перевірка на більшу кількість суми грошей.");
            Console.WriteLine("8. Перевірка на нерівність суми грошей.");
            Console.WriteLine("9. Перевірка Equals.");
            Console.WriteLine("0. Вихід.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    card1.SetBalance();
                    if (!card1.errorExists)
                    {                        
                        Console.WriteLine(card1);
                    }
                    card1.AfterShow();
                    break;
                case "D2":
                    card2.SetBalance();
                    if (!card2.errorExists)
                    {
                        Console.WriteLine(card2);
                    }
                    card2.AfterShow();
                    break;
                case "D3":
                    card1.AddMoney();
                    if (!card1.errorExists)
                    {
                        card1 += card1.AddBalance;
                        Console.WriteLine(card1);
                    }
                    card1.AfterShow();
                    break;
                case "D4":
                    card2.AddMoney();
                    if (!card2.errorExists)
                    {
                        card2 -= card2.AddBalance;
                        Console.WriteLine(card2);
                    }
                    card2.AfterShow();
                    break;
                case "D5":
                    Console.WriteLine($"CVC.1 == CVC.2: {card1 == card2}");
                    card1.AfterShow();
                    break;
                case "D6":
                    Console.WriteLine($"Сума картка.1 < Сума картка.2: {card1 < card2}");
                    card1.AfterShow();
                    break;
                case "D7":
                    Console.WriteLine($"Сума картка.1 > Сума картка.2: {card1 > card2}");
                    card1.AfterShow();
                    break;
                case "D8":
                    Console.WriteLine($"Сума картка.1 != Сума картка.2: {card1 != card2}");
                    card1.AfterShow();
                    break;
                case "D9":
                    Console.WriteLine($"картка.1 Equals картка.2: {card1.Equals(card2)}");
                    card1.AfterShow();
                    break;                
                case "D0":
                    return;
            }
        }
    }
}
