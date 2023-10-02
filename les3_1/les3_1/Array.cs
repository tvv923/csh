using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les3_1
{
    public class Array : IOutput
    {
        private int[] data;
        public Array(int[] data)
        {
            this.data = data;
        }
        public void Show()
        {
            Console.WriteLine("Елементи масиву:");
            foreach (int item in data)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public void Show(string info)
        {
            Show();
            Console.WriteLine("Інформаційне повідомлення: " + info);
        }
        public void AfterShow()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }

    }
}
