using System;
using les4_1;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Employee emp1 = new Employee("Іван", 2500);
        Employee emp2 = new Employee("Степан", 3500);
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Маємо двох працівників:");
            Console.WriteLine(emp1);
            Console.WriteLine(emp2);            
            Console.WriteLine("Що будемо робити:");
            Console.WriteLine("1. Збільшити зарплату першому працівнику.");
            Console.WriteLine("2. Зменшити зарплату другому працівнику.");
            Console.WriteLine("3. Перевірка на рівність зарплат працівників.");
            Console.WriteLine("4. Перевірка на меншу кількість зарплат працівників.");
            Console.WriteLine("5. Перевірка на більшу кількість зарплат працівників.");
            Console.WriteLine("6. Перевірка на нерівність зарплат працівників.");
            Console.WriteLine("7. Перевірка зарплат Equals.");
            Console.WriteLine("8. Вихід.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    emp1.CheckInput();
                    if (!emp1.errorExists)
                    {
                        emp1 += emp1.AddSalary;
                        Console.WriteLine(emp1);
                    }
                    emp1.AfterShow();
                    break;
                case "D2":
                    emp2.CheckInput();
                    if (!emp2.errorExists)
                    {
                        emp2 -= emp2.AddSalary;
                        Console.WriteLine(emp2);
                    }
                    emp2.AfterShow();
                    break;
                case "D3":
                    Console.WriteLine($"Зарплата праців.1 == праців.2: {emp1 == emp2}");
                    emp1.AfterShow();
                    break;
                case "D4":
                    Console.WriteLine($"Зарплата праців.1 < праців.2: {emp1 < emp2}");
                    emp1.AfterShow();
                    break;
                case "D5":
                    Console.WriteLine($"Зарплата праців.1 > праців.2: {emp1 > emp2}");
                    emp1.AfterShow();
                    break;
                case "D6":
                    Console.WriteLine($"Зарплата праців.1 != праців.2: {emp1 != emp2}");
                    emp1.AfterShow();
                    break;
                case "D7":
                    Console.WriteLine($"Зарплата праців.1 Equals праців.2: {emp1.Equals(emp2)}");
                    emp1.AfterShow();
                    break;
                case "D8":
                    return;
            }
        }
    }
}
