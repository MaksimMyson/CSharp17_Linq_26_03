namespace CSharp17_Linq_26_03
{
    /// <summary>
    /// Тип користувача "Студент" з інформацією про ім'я, прізвище, вік та назву навчального закладу.
    /// </summary>
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string SchoolName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Age: {Age}, School: {SchoolName}";
        }
    }

    /// <summary>
    /// Клас для роботи з масивом студентів.
    /// </summary>
    class StudentArrayQueries
    {
        static void Main(string[] args)
        {
            // Створення масиву студентів
            Student[] students = {
            new Student { FirstName = "John", LastName = "Doe", Age = 18, SchoolName = "Harvard" },
            new Student { FirstName = "Boris", LastName = "Johnson", Age = 20, SchoolName = "Oxford" },
            new Student { FirstName = "Anna", LastName = "Brown", Age = 22, SchoolName = "MIT" },
            new Student { FirstName = "Brock", LastName = "Smith", Age = 21, SchoolName = "Stanford" },
            new Student { FirstName = "Mary", LastName = "Brooks", Age = 19, SchoolName = "Yale" },
            new Student { FirstName = "Boris", LastName = "Petrov", Age = 23, SchoolName = "Cambridge" },
            new Student { FirstName = "David", LastName = "Miller", Age = 20, SchoolName = "Princeton" }
        };

            GetAllStudents(students);
            GetStudentsWithFirstName(students, "Boris");
            GetStudentsWithLastNameStartingWith(students, "Bro");
            GetStudentsOlderThan(students, 19);
            GetStudentsBetweenAges(students, 20, 23);
            GetStudentsStudyingAt(students, "MIT");
            GetStudentsStudyingAtAndOlderThan(students, "Oxford", 18);
        }

        /// <summary>
        /// Метод для отримання всього масиву студентів.
        /// </summary>
        public static void GetAllStudents(Student[] students)
        {
            Console.WriteLine("All students in the array:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання списку студентів з певним ім'ям.
        /// </summary>
        public static void GetStudentsWithFirstName(Student[] students, string firstName)
        {
            var filteredStudents = students.Where(student => student.FirstName == firstName);
            Console.WriteLine($"Students with first name '{firstName}':");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання списку студентів з прізвищем, яке починається з певної послідовності символів.
        /// </summary>
        public static void GetStudentsWithLastNameStartingWith(Student[] students, string prefix)
        {
            var filteredStudents = students.Where(student => student.LastName.StartsWith(prefix));
            Console.WriteLine($"Students with last name starting with '{prefix}':");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання списку студентів старших за певний вік.
        /// </summary>
        public static void GetStudentsOlderThan(Student[] students, int age)
        {
            var filteredStudents = students.Where(student => student.Age > age);
            Console.WriteLine($"Students older than {age} years old:");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання списку студентів у певному діапазоні віку.
        /// </summary>
        public static void GetStudentsBetweenAges(Student[] students, int minAge, int maxAge)
        {
            var filteredStudents = students.Where(student => student.Age >= minAge && student.Age <= maxAge);
            Console.WriteLine($"Students between {minAge} and {maxAge} years old:");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання списку студентів, які навчаються в певному навчальному закладі.
        /// </summary>
        public static void GetStudentsStudyingAt(Student[] students, string schoolName)
        {
            var filteredStudents = students.Where(student => student.SchoolName == schoolName);
            Console.WriteLine($"Students studying at {schoolName}:");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для отримання списку студентів, які навчаються в певному навчальному закладі та старше певного віку, відсортований за віком, за спаданням.
        /// </summary>
        public static void GetStudentsStudyingAtAndOlderThan(Student[] students, string schoolName, int minAge)
        {
            var filteredStudents = students.Where(student => student.SchoolName == schoolName && student.Age > minAge)
                                           .OrderByDescending(student => student.Age);
            Console.WriteLine($"Students studying at {schoolName} and older than {minAge} years old (sorted by age, descending):");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }
    }
}
