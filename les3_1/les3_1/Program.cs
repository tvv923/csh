using System;
using les3_1;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int[] arrayData = { 11, 22, 33, 44, 55, 66, 77, 88, 99 };
        les3_1.Array array = new les3_1.Array(arrayData);            
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Масив.");
            Console.WriteLine("1. Відобразити масив.");
            Console.WriteLine("2. Масив з інформаційним повідомленням.");
            Console.WriteLine("3. На вихід.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    array.Show();
                    array.AfterShow();
                    break;
                case "D2":
                    array.Show("Це масив цілих чисел.");
                    array.AfterShow();
                    break;
                case "D3":
                    return;
            }
        }

    }
}