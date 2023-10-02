using les7_3;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string[] storeNames = { "Укрпромпостач", "Все для дому", "Нитка", "Міратон" };
        string[] storeAddresses = { "Боголюбова 23/1", "Васильківська 4", "Заньковецької 3/1", "Лесі Українки 19" };
        string[] storeTypes = { "продовольчий", "господарський", "одяг", "взуття" };        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Маємо п'єсу і магазин:");
            Console.WriteLine("1. Вивести в якому магазині була прем'єра п'єси.");
            Console.WriteLine("2. Вихід.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    using (Piece piece = new("Пігмаліон", "Бернард Шоу", "Комедія", 1912))
                    {
                        piece.DisplayInfo();
                    }
                    Store store = new(storeNames, storeAddresses, storeTypes);
                    store.PrintStoreInfo();
                    store.Dispose();
                    store.AfterShow();
                    break;
                case "D2":
                    return;
            }
        }
    }
}