using les11;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        const int nVisitors = 5;
        const int nChairs = 1;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Перукарня:");
            Console.WriteLine("1. Відкрити перукарню.");
            Console.WriteLine("2. Вихід.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    BarberShop bShop = new(nChairs);
                    Thread bThread = new(bShop.Barber);                    
                    bThread.Start();
                    Thread[] visitors = new Thread[nVisitors];
                    for (int i = 0; i < nVisitors; i++)
                    {
                        visitors[i] = new Thread(bShop.Visitor);
                        visitors[i].Start(i);
                    }
                    for (int i = 0; i < nVisitors; i++)
                        visitors[i].Join();

                    bShop.noVisitors = true;
                    bShop.bSleepChair.Release();
                    bThread.Join();                    
                    bShop.AfterShow();
                    break;
                case "D2":                    
                    return;
            }
        }         
    }
}



