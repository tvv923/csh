using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les2_1
{
    public class Product : Money
    {
        private string? name;
        public void SetProduct(string a0)
        {
            name = a0;
        }
        public void DisplayProduct()
        {
            Console.WriteLine($"Назва продукту: {name}");
            DisplayAmount(2);
        }
        public void ApplyDiscount(int reductionD1, int reductionD2)
        {
            ReducePrice(reductionD1, reductionD2);
        }
        public void ProductInput(int inputType)
        {
            string? a0;
            if (!errorExists)
            {
                Console.WriteLine("Введіть назву продукту: ");
                a0 = Console.ReadLine();
                errorExists = a0.Trim() == "";
                errorText = a0.Trim() == "" ? "Помилка у назві продукту" : "";
                SetProduct(a0);

                if (!errorExists)
                {
                    MoneyInput(2);
                    if (!errorExists)
                    {
                        ApplyDiscount(majorDisc, minorDisc);
                        DisplayProduct();
                        AfterCalculate();
                    }
                }
            }
        }
    }
}
