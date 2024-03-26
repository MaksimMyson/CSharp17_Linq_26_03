namespace CSharp17_Linq_26_03
{
    class IntegerArrayQueries
    {
        /// <summary>
        /// Метод для отримання всього масиву цілих чисел.
        /// </summary>
        public static void GetAllIntegers(int[] array)
        {
            Console.WriteLine("All integers in the array:");
            foreach (var num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання парних цілих чисел у масиві.
        /// </summary>
        public static void GetEvenIntegers(int[] array)
        {
            var evenNumbers = array.Where(num => num % 2 == 0);
            Console.WriteLine("Even integers in the array:");
            foreach (var num in evenNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання непарних цілих чисел у масиві.
        /// </summary>
        public static void GetOddIntegers(int[] array)
        {
            var oddNumbers = array.Where(num => num % 2 != 0);
            Console.WriteLine("Odd integers in the array:");
            foreach (var num in oddNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання цілих чисел у масиві, які більші за задане значення.
        /// </summary>
        public static void GetNumbersGreaterThan(int[] array, int threshold)
        {
            var numbersGreaterThanThreshold = array.Where(num => num > threshold);
            Console.WriteLine($"Integers greater than {threshold}:");
            foreach (var num in numbersGreaterThanThreshold)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання цілих чисел у масиві, які знаходяться в заданому діапазоні.
        /// </summary>
        public static void GetNumbersInRange(int[] array, int start, int end)
        {
            var numbersInRange = array.Where(num => num >= start && num <= end);
            Console.WriteLine($"Integers in the range [{start}, {end}]:");
            foreach (var num in numbersInRange)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання чисел у масиві, які кратні семи, відсортованих за зростанням.
        /// </summary>
        public static void GetMultiplesOfSevenSortedAscending(int[] array)
        {
            var multiplesOfSeven = array.Where(num => num % 7 == 0).OrderBy(num => num);
            Console.WriteLine("Multiples of seven sorted in ascending order:");
            foreach (var num in multiplesOfSeven)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання чисел у масиві, які кратні восьми, відсортованих за спаданням.
        /// </summary>
        public static void GetMultiplesOfEightSortedDescending(int[] array)
        {
            var multiplesOfEight = array.Where(num => num % 8 == 0).OrderByDescending(num => num);
            Console.WriteLine("Multiples of eight sorted in descending order:");
            foreach (var num in multiplesOfEight)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 14, 16, 18, 21, 24, 28, 32, 35, 40 };

            GetAllIntegers(numbers);
            GetEvenIntegers(numbers);
            GetOddIntegers(numbers);
            GetNumbersGreaterThan(numbers, 15);
            GetNumbersInRange(numbers, 10, 25);
            GetMultiplesOfSevenSortedAscending(numbers);
            GetMultiplesOfEightSortedDescending(numbers);
        }
    }
}
