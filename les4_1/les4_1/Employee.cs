using System;

namespace les4_1
{
    public class Employee
    {
        public bool errorExists;
        public string errorText = "";
        public string Name { get; set; }
        private int salary;
        private int addSalary;
        public int Salary
        {
            get => salary;
            set => salary = value <= 0 ? 0 : value;
        }
        public int AddSalary
        {
            get => addSalary;
            set => addSalary = value <= 0 ? 0 : value;
        }
        public void CheckInput()
        {
            string? a1;
            Console.WriteLine("Введіть ціле число: ");
            a1 = Console.ReadLine();
            errorExists = false;
            try
            {
                addSalary = Convert.ToInt32(a1);
            }
            catch (Exception)
            {
                errorExists = true;
                errorText = "Помилка у числі.";
            }
            if (errorExists)
                Console.WriteLine(errorText);
        }
        public void AfterShow()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }
        public Employee(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }        
        public static Employee operator +(Employee emp1, int amount)
        {
            emp1.salary += amount;
            return emp1;
        }
        public static Employee operator -(Employee emp1, int amount)
        {
            if (emp1.salary >= amount)
                emp1.salary -= amount;
            return emp1;
        }
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            return emp1.Salary == emp2.Salary;
        }
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return emp1.Salary != emp2.Salary;
        }
        public static bool operator <(Employee emp1, Employee emp2)
        {
            return emp1.Salary < emp2.Salary;
        }
        public static bool operator >(Employee emp1, Employee emp2)
        {
            return emp1.Salary > emp2.Salary;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Employee otherEmployee = (Employee)obj;
            return this.Salary == otherEmployee.Salary;
        }
        public override int GetHashCode()
        {
            return Salary.GetHashCode();
        }
        public override string ToString()
        {
            return $"Працівник: {Name}, Зарплата: {Salary}";
        }
    }
}
