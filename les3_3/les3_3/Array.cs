using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les3_3
{
    public class Array : ISort
    {
        public bool param;
        public bool errorExists;
        string errorText = "";
        private int[] data;
        public Array(int[] data)
        {
            this.data = data;
        }
        public void CheckInput()
        {
            string? a1;
            Console.WriteLine("Введіть параметр (1 - за зростанням, 2 - за зменшенням): ");
            a1 = Console.ReadLine();
            errorExists = false;
            if (a1 == "1") param = true;
            else if (a1 == "2") param = false;
            else
            {
                errorExists = true;
                errorText = "Помилка у параметрі.";
            }
            if (errorExists)
                Console.WriteLine(errorText);
        }
        public void SortAsc()
        {
            System.Array.Sort(data);
        }
        public void SortDesc()
        {
            System.Array.Sort(data);
            System.Array.Reverse(data);
        }
        public void SortByParam(bool param)
        {
            if (param)
                SortAsc();
            else
                SortDesc();
        }
        public void Show()
        {
            Console.WriteLine("Масив: ");
            foreach (int item in data)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public void AfterShow()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }
    }
}
