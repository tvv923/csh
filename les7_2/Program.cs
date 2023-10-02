using les7_2;

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
            Console.WriteLine("Маагазин.");
            Console.WriteLine("1. Показати магазин.");
            Console.WriteLine("2. Вийти.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    using (Store store = new(storeNames, storeAddresses, storeTypes))
                    {
                        store.PrintStoreInfo();
                    }                    
                    break;
                case "D2":
                    return;
            }
        }
    }
}
