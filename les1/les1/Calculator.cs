using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les1
{
    public class Calculator
    {
        public double a;
        public double b;
        public long n;
        public bool errorExists;
        public string errorText = "";        
        public long nFact;

        private void CheckInput(int inputCount,int inputType)
        {
            string? a1;
            string? a2 = "";           
            Console.WriteLine("Введіть " + (inputCount == 2 ? "1 " : "") + "аргумент: ");
            a1 = Console.ReadLine();
            errorExists = false;
            try
            {
                if (inputType == 1) a = Convert.ToDouble(a1);
                else n = Convert.ToInt64(a1);
            }
            catch (Exception)
            {
                errorExists = true;
                errorText = "Помилка у "+ (inputCount == 2 ? "1 " : "") + "аргументі";
            }
            if (!errorExists && inputCount == 2)
            {
                if (inputCount == 2)
                {
                    Console.WriteLine("Введіть 2 аргумент: ");
                    a2 = Console.ReadLine();
                }
                try
                {
                    b = Convert.ToDouble(a2);
                }
                catch (Exception)
                {
                    errorExists = true;
                    errorText = "Помилка у 2 аргументі";
                }
            }
            if (errorExists)
                Console.WriteLine(errorText);
        }
        
        public void Add()
        {
            CheckInput(2, 1);
            if (!errorExists)                
                Console.WriteLine($"{a} + {b} = {a + b}");
            AfterCalculate();
        }
        public void Subtract()
        {
            CheckInput(2, 1);
            if (!errorExists)               
                Console.WriteLine($"{a} - {b} = {a - b}");
            AfterCalculate();
        }
        public void Multiply()
        {
            CheckInput(2, 1);
            if (!errorExists)
                Console.WriteLine($"{a} * {b} = {a * b}");
            AfterCalculate();
        }
        public void Divide()
        {
            CheckInput(2, 1);
            if (!errorExists)
            {
                if (b == 0)
                    Console.WriteLine("На нуль ділити не можна.");
                else
                    Console.WriteLine($"{a} / {b} = {a / b}");
            }
            AfterCalculate();
        }
        public void SquareRoot()
        {
            CheckInput(1, 1);
            if (!errorExists)
            {
                if (a < 0)
                    Console.WriteLine("Не можна обчислити корінь квадратний із негативного числа.");
                else
                    Console.WriteLine($"Квадратний корінь з {a} = {Math.Sqrt(a)}");               
            }
            AfterCalculate();
        }
        public void Power()
        {
            CheckInput(2, 1);
            if (!errorExists)
            {
                Console.WriteLine($"{a} в ступені {b} = {Math.Pow(a, b)}");                
            }
            AfterCalculate();
        }
        public void Factorial()
        {
            CheckInput(1, 2);
            if (!errorExists)
            {
                if (n < 0)
                    Console.WriteLine("Факторіал не визначається для негативних чисел.");
                else
                {
                    nFact = FactorialCount(n);
                    Console.WriteLine($"Факторіал {n} = {nFact}");
                }
            }
            AfterCalculate(); 
        }
        private long FactorialCount(long n)
        {
            if (n == 0 || n == 1) return 1;
            else return n * FactorialCount(n - 1);
        }

        private void AfterCalculate()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }

    }
}
