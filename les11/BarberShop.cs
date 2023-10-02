namespace les11
{
    public class BarberShop
    {
        public Semaphore wRoom;
        public Semaphore bChair;
        public Semaphore bSleepChair;
        public Semaphore wChair;
        public bool noVisitors = false;

        public BarberShop(int nChairs)
        {
            wRoom = new(nChairs, nChairs);
            bChair = new(1, 1);
            bSleepChair = new(0, 1);
            wChair = new(0, 1);
        }

        public void Barber()
        {
            while (!noVisitors)
            {
                Console.WriteLine("Перукар спить...");
                bSleepChair.WaitOne();
                if (!noVisitors)
                {
                    Console.WriteLine("Перукар стриже...");
                    Thread.Sleep(new Random().Next(1, 5) * 100);
                    Console.WriteLine("Перукар завершив стрижку");
                    wChair.Release();
                }
                else
                    Console.WriteLine("Перукар спить...");
            }
        }

        public void Visitor(object number)
        {
            int Number = (int)number;
            Number++;
            Thread.Sleep(new Random().Next(1, 3) * 100);
            Console.WriteLine($"Відвідувач {Number} зайшов у перукарню");
            wRoom.WaitOne();
            Console.WriteLine($"Відвідувач {Number} зайшов до зали очікування");
            bChair.WaitOne();
            wRoom.Release();
            Console.WriteLine($"Відвідувач {Number} підготувався");
            bSleepChair.Release();
            wChair.WaitOne();
            bChair.Release();
            Console.WriteLine($"Відвідувач {Number} виходить з перукарні");
        }

        public void AfterShow()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }
    }
}
