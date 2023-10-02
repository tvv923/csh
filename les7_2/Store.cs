
namespace les7_2
{
    public class Store : IDisposable
    {
        private bool disposed = false; 
        private readonly Random random = new(); 

        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Type { get; private set; }
        public Store(string[] names, string[] addresses, string[] types)
        {
            Name = GetRandomFromArray(names);
            Address = GetRandomFromArray(addresses);
            Type = GetRandomFromArray(types);
        }
        public void PrintStoreInfo()
        {
            Console.WriteLine($"Назва магазину: {Name}");
            Console.WriteLine($"Адреса: {Address}");
            Console.WriteLine($"Тип: {Type}");
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void AfterShow()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Console.WriteLine($"Магазин '{Name}' було закрито.");
                    AfterShow();
                }
                disposed = true;
            }
        }
        private string GetRandomFromArray(string[] array)
        {
            return array[random.Next(array.Length)];
        }
        ~Store()
        {
            Dispose(false);
        }
    }
}
