using les7_1;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Piece piece1 = new("Ромео і Джульєтта", "Вільям Шекспір", "Трагедія", 1597);
        Piece piece2 = new("Пігмаліон", "Бернард Шоу", "Комедія", 1912);
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Маємо дві п'єси:");
            Console.WriteLine("1. Вивести першу п'єсу.");
            Console.WriteLine("2. Вивести другу п'єсу.");
            Console.WriteLine("3. Вихід.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    piece1.DisplayInfo();
                    piece1.Dispose();
                    piece1.AfterShow();
                    break;
                case "D2":
                    piece2.DisplayInfo();
                    piece2.Dispose();
                    piece2.AfterShow();
                    break;
                case "D3":
                    return;
            }
        }
    }
}