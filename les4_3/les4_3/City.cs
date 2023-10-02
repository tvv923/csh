using System;


namespace les4_3
{
    public class City
    {
        public bool errorExists;
        public string errorText = "";
        public string Name { get; set; }
        private int population;
        private int addPopulation;
        public int Population
        {
            get => population;
            set => population = value >= 0 ? value : 0;
        } 
        public int AddPopulation
        {
            get => addPopulation;
            set => addPopulation = value >= 0 ? value : 0;
        }
        public void CheckInput()
        {
            string? a1;
            Console.WriteLine("Введіть ціле число: ");
            a1 = Console.ReadLine();
            errorExists = false;
            try
            {
                addPopulation = Convert.ToInt32(a1);
            }
            catch (Exception)
            {
                errorExists = true;
                errorText = "Помилка у числі.";
            }
            if (errorExists)
                Console.WriteLine(errorText);
        }
        public City(string name, int population)
        {
            Name = name;
            Population = population;
        }        
        public static City operator +(City city, int amount)
        {
            city.Population += amount;
            return city;
        }        
        public static City operator -(City city, int amount)
        {
            city.Population -= amount;
            return city;
        }        
        public static bool operator ==(City city1, City city2)
        {
            if (ReferenceEquals(city1, city2))
                return true;

            if (city1 is null || city2 is null)
                return false;

            return city1.Population == city2.Population;
        }        
        public static bool operator !=(City city1, City city2)
        {
            return !(city1 == city2);
        }       
        public static bool operator <(City city1, City city2)
        {
            return city1.Population < city2.Population;
        }        
        public static bool operator >(City city1, City city2)
        {
            return city1.Population > city2.Population;
        }       
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return this == (City)obj;
        }        
        public override int GetHashCode()
        {
            return Population.GetHashCode();
        }
        public override string ToString()
        {
            return $"Місто: {Name}, Населення: {Population}";
        }        
        public void AfterShow()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }
    }

}
