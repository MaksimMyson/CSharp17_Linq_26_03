namespace CSharp17_Linq_26_03
{
    /// <summary>
    /// Клас для роботи з масивом міст.
    /// </summary>
    class CityArrayQueries
    {
        /// <summary>
        /// Метод для отримання всього масиву міст.
        /// </summary>
        public static void GetAllCities(string[] cities)
        {
            Console.WriteLine("All cities in the array:");
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання міст з довжиною назви, що дорівнює заданому.
        /// </summary>
        public static void GetCitiesWithLength(string[] cities, int length)
        {
            var citiesWithLength = cities.Where(city => city.Length == length);
            Console.WriteLine($"Cities with name length equal to {length}:");
            foreach (var city in citiesWithLength)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання міст, назви яких починаються з літери A.
        /// </summary>
        public static void GetCitiesStartingWithA(string[] cities)
        {
            var citiesStartingWithA = cities.Where(city => city.StartsWith("A"));
            Console.WriteLine("Cities whose names start with letter 'A':");
            foreach (var city in citiesStartingWithA)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання міст, назви яких закінчуються літерою M.
        /// </summary>
        public static void GetCitiesEndingWithM(string[] cities)
        {
            var citiesEndingWithM = cities.Where(city => city.EndsWith("M"));
            Console.WriteLine("Cities whose names end with letter 'M':");
            foreach (var city in citiesEndingWithM)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання міст, назви яких починаються з літери N і закінчуються літерою K.
        /// </summary>
        public static void GetCitiesStartingWithNAndEndingWithK(string[] cities)
        {
            var citiesStartingWithNAndEndingWithK = cities.Where(city => city.StartsWith("N") && city.EndsWith("K"));
            Console.WriteLine("Cities whose names start with letter 'N' and end with letter 'K':");
            foreach (var city in citiesStartingWithNAndEndingWithK)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання міст, назви яких починаються з 'Ne', результат відсортований за спаданням.
        /// </summary>
        public static void GetCitiesStartingWithNeSortedDescending(string[] cities)
        {
            var citiesStartingWithNe = cities.Where(city => city.StartsWith("Ne")).OrderByDescending(city => city);
            Console.WriteLine("Cities whose names start with 'Ne' (sorted descending):");
            foreach (var city in citiesStartingWithNe)
            {
                Console.WriteLine(city);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string[] cities = { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose" };

            GetAllCities(cities);
            GetCitiesWithLength(cities, 7);
            GetCitiesStartingWithA(cities);
            GetCitiesEndingWithM(cities);
            GetCitiesStartingWithNAndEndingWithK(cities);
            GetCitiesStartingWithNeSortedDescending(cities);
        }
    }
}
