namespace CSharp17_Linq_26_03
{
    /// <summary>
    /// Представляє користувацький тип "Фірма".
    /// </summary>
    public class Firm
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string CEOFullName { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Address { get; set; }

        
        public List<Employee> Employees { get; set; }

        // Конструктор
        public Firm(string name, DateTime foundationDate, string businessProfile, string ceoFullName, int numberOfEmployees, string address)
        {
            Name = name;
            FoundationDate = foundationDate;
            BusinessProfile = businessProfile;
            CEOFullName = ceoFullName;
            NumberOfEmployees = numberOfEmployees;
            Address = address;
            Employees = new List<Employee>(); // Ініціалізуємо колекцію працівників
        }
    }

    /// <summary>
    /// Представляє користувацький тип "Працівник".
    /// </summary>
    public class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
    }

    /// <summary>
    /// Клас, що містить методи для опрацювання запитів щодо фірм та працівників.
    /// </summary>
    public class FirmProcessor
    {
        private List<Firm> firms;

        public FirmProcessor(List<Firm> firms)
        {
            this.firms = firms;
        }

        
        public List<Firm> GetAllFirms()
        {
            return firms;
        }

        public List<Firm> GetFirmsWithNameContaining(string keyword)
        {
            return firms.Where(f => f.Name.Contains(keyword)).ToList();
        }

        public List<Firm> GetMarketingFirms()
        {
            return firms.Where(f => f.BusinessProfile == "Marketing").ToList();
        }

        public List<Firm> GetFirmsInBusinessProfiles(params string[] profiles)
        {
            return firms.Where(f => profiles.Contains(f.BusinessProfile)).ToList();
        }

        public List<Firm> GetFirmsWithEmployeeCountGreaterThan(int count)
        {
            return firms.Where(f => f.NumberOfEmployees > count).ToList();
        }

        public List<Firm> GetFirmsWithEmployeeCountInRange(int minCount, int maxCount)
        {
            return firms.Where(f => f.NumberOfEmployees >= minCount && f.NumberOfEmployees <= maxCount).ToList();
        }

        public List<Firm> GetFirmsLocatedIn(string location)
        {
            return firms.Where(f => f.Address.Contains(location)).ToList();
        }

        public List<Firm> GetFirmsWithCEOFullName(string lastName)
        {
            return firms.Where(f => f.CEOFullName.Split().Last() == lastName).ToList();
        }

        public List<Firm> GetFirmsFoundedBefore(DateTime date)
        {
            return firms.Where(f => f.FoundationDate < date).ToList();
        }

        public List<Firm> GetFirmsFoundedExactlyDaysAgo(int daysAgo)
        {
            return firms.Where(f => (DateTime.Now - f.FoundationDate).Days == daysAgo).ToList();
        }

        public List<Employee> GetEmployeesOfFirm(string firmName)
        {
            var firm = firms.FirstOrDefault(f => f.Name == firmName);
            return firm != null ? firm.Employees : new List<Employee>();
        }

        public List<Employee> GetEmployeesWithSalaryGreaterThan(string firmName, decimal salary)
        {
            var firm = firms.FirstOrDefault(f => f.Name == firmName);
            return firm != null ? firm.Employees.Where(e => e.Salary > salary).ToList() : new List<Employee>();
        }

        public List<Employee> GetManagerEmployees()
        {
            return firms.SelectMany(f => f.Employees.Where(e => e.Position == "Manager")).ToList();
        }

        public List<Employee> GetEmployeesWithPhoneStartingWith(string prefix)
        {
            return firms.SelectMany(f => f.Employees.Where(e => e.Phone.StartsWith(prefix))).ToList();
        }

        public List<Employee> GetEmployeesWithEmailStartingWith(string prefix)
        {
            return firms.SelectMany(f => f.Employees.Where(e => e.Email.StartsWith(prefix))).ToList();
        }

        public List<Employee> GetEmployeesWithName(string name)
        {
            return firms.SelectMany(f => f.Employees.Where(e => e.FullName == name)).ToList();
        }
    }

    
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Firm> firms = new List<Firm>
        {
            new Firm("FirmA", DateTime.Now, "ProfileA", "CEO1", 100, "Address1"),
            new Firm("FirmB", DateTime.Now, "ProfileB", "CEO2", 200, "Address2")
        };

            firms[0].Employees.Add(new Employee { FullName = "John Doe", Position = "Manager", Phone = "2345678", Email = "john@example.com", Salary = 50000 });
            firms[0].Employees.Add(new Employee { FullName = "Jane Smith", Position = "Employee", Phone = "2398765", Email = "jane@example.com", Salary = 40000 });
            firms[1].Employees.Add(new Employee { FullName = "Alice Jones", Position = "Manager", Phone = "2390123", Email = "alice@example.com", Salary = 55000 });
            firms[1].Employees.Add(new Employee { FullName = "Bob Brown", Position = "Employee", Phone = "2349876", Email = "bob@example.com", Salary = 45000 });

            FirmProcessor processor = new FirmProcessor(firms);

            
            var firmEmployees = processor.GetEmployeesOfFirm("FirmA");
            foreach (var employee in firmEmployees)
            {
                Console.WriteLine($"FirmA Employee: {employee.FullName}");
            }

            var highSalaryEmployees = processor.GetEmployeesWithSalaryGreaterThan("FirmB", 50000);
            foreach (var employee in highSalaryEmployees)
            {
                Console.WriteLine($"FirmB Employee with high salary: {employee.FullName}");
            }

            var managerEmployees = processor.GetManagerEmployees();
            foreach (var employee in managerEmployees)
            {
                Console.WriteLine($"Manager Employee: {employee.FullName}");
            }

            var phoneEmployees = processor.GetEmployeesWithPhoneStartingWith("23");
            foreach (var employee in phoneEmployees)
            {
                Console.WriteLine($"Employee with phone starting with '23': {employee.FullName}");
            }

            var emailEmployees = processor.GetEmployeesWithEmailStartingWith("24");
            foreach (var employee in emailEmployees)
            {
                Console.WriteLine($"Employee with email starting with 'jo': {employee.FullName}");
            }

            var lionelEmployees = processor.GetEmployeesWithName("Lione");
            foreach (var employee in lionelEmployees)
            {
                Console.WriteLine($"Employee with name 'Lione': {employee.FullName}");
            }
        }
    }
}

