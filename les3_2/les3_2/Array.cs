using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les3_2
{
    public class Array : IMath
    {
        public int valueToSearch;        
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
            Console.WriteLine("Введіть ціле число: ");
            a1 = Console.ReadLine();
            errorExists = false;
            try
            {
                valueToSearch = Convert.ToInt32(a1);                
            }
            catch (Exception)
            {
                errorExists = true;
                errorText = "Помилка у числі.";
            }
            if (errorExists)
                Console.WriteLine(errorText);
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
        public int Max()
        {
            int max = data[0];
            foreach (int item in data)
                if (item > max)
                    max = item;
            return max;
        }
        public int Min()
        {
            int min = data[0];
            foreach (int item in data)            
                if (item < min)
                    min = item;            
            return min;
        }
        public float Avg()
        {
            int sum = 0;
            foreach (int item in data)
                sum += item;
            return (float)sum / data.Length;
        }
        public bool Search()
        {
            foreach (int item in data)
                if (item == valueToSearch)
                    return true;
            return false;
        }
        public void AfterCalculate()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }
    }
}
