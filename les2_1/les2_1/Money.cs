using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les2_1
{
    public class Money
    {
        public string currency;
        public int majorPart;
        public int minorPart;
        public int majorDisc;
        public int minorDisc;
        public bool errorExists;
        public string errorText = "";
        public void DisplayAmount(int d0)
        {
            Console.WriteLine("Сума " + (d0 == 1 ? "" : "зі знижкою") + $": {majorPart}.{minorPart:D2} {currency}");
        }
        public void SetCurrency(string a0)
        {
            currency = a0;
        }
        public void SetAmount(int d1, int d2)
        {
            majorPart = d1;
            minorPart = d2;
        }
        public void SetDisc(int d1, int d2)
        {
            majorDisc = d1;
            minorDisc = d2;
        }
        public void ReducePrice(int reductionD1, int reductionD2)
        {
            int total = majorPart * 100 + minorPart;
            int reductionTotalD0 = reductionD1 * 100 + reductionD2;
            int newTotal = total - reductionTotalD0;

            if (newTotal < 0)
            {
                Console.WriteLine("Знижка не може перевищувати загальної суми.");
                errorExists = true;
            }
            if (!errorExists)
            {
                majorPart = newTotal / 100;
                minorPart = newTotal % 100;
            }
        }
        public void MoneyInput(int inputType)
        {
            string? a0;
            string? a1;
            string? a2 = "";
            int d1 = 0, d2 = 0;
            errorExists = false;
            if (inputType == 1)
            {
                Console.WriteLine("Введіть назву валюти (наприклад USD, EUR, UAH): ");
                a0 = Console.ReadLine();
                errorExists = a0.Trim() == "";
                SetCurrency(a0);
            }
            if (!errorExists)
            {
                Console.WriteLine("Введіть цілу частину " + (inputType == 1 ? "валюти: " : "знижки: "));
                a1 = Console.ReadLine();
                errorExists = false;
                try
                {
                    d1 = Convert.ToInt32(a1);
                    if (d1 < 0) SetError(inputType, 1);                    
                }
                catch (Exception)
                {
                    SetError(inputType, 1);
                }
                if (!errorExists)
                {
                    Console.WriteLine("Введіть дробову частину " + (inputType == 1 ? "валюти: " : "знижки: "));
                    a2 = Console.ReadLine();
                    try
                    {
                        d2 = Convert.ToInt32(a2.Trim().Length > 2 ? a2.Trim()[..2] : a2.Trim());
                        if (d2 < 0) SetError(inputType, 2);                        
                    }
                    catch (Exception)
                    {
                        SetError(inputType, 2);
                    }
                }                
             }
            if (errorExists)
            {
                Console.WriteLine(errorText);
                AfterCalculate();
            }
            else
            {
                if (inputType == 1)
                {
                    SetAmount(d1, d2);
                    DisplayAmount(inputType);
                }
                else SetDisc(d1, d2);
            }
         }
        public void AfterCalculate()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }
        private void SetError(int inputType,int inputPart)
        {
            errorExists = true;
            errorText = "Помилка у "+ (inputPart == 1 ? "цілій" : "дробовій") + " частині " + (inputType == 1 ? "валюти: " : "знижки: ");
        }
    }
}
