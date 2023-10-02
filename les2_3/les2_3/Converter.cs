using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les2_3
{
    public struct Converter
    {
        private int value;
        public bool errorExists;
        public string errorText;
        public void CheckInput()
        {
            string? a1;
            Console.WriteLine("Введіть десяткове число: ");
            a1 = Console.ReadLine();
            errorExists = false;
            try
            {
                value = Convert.ToInt32(a1);
                if (value < 0)
                {
                    errorExists = true;
                    errorText = "Помилка у числі.";
                }
            }
            catch (Exception)
            {
                errorExists = true;
                errorText = "Помилка у числі.";
            }
            
            if (errorExists)
                Console.WriteLine(errorText);
        }
        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public string ToBinary()
        {
            return Convert.ToString(value, 2);
        }
        public string ToOctal()
        {
            return Convert.ToString(value, 8);
        }
        public string ToHexadecimal()
        {
            return Convert.ToString(value, 16).ToUpper();
        }
        public void AfterCalculate()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }
    }
}
