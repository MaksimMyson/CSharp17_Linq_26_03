namespace CSharp17_Linq_26_03
{
    /// <summary>
    /// Представляє користувацький тип "Фірма".
    /// </summary>
    public class Firm
    {
        /// <summary>
        /// Назва фірми.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата заснування фірми.
        /// </summary>
        public DateTime FoundationDate { get; set; }

        /// <summary>
        /// Профіль бізнесу.
        /// </summary>
        public string BusinessProfile { get; set; }

        /// <summary>
        /// ПІБ директора.
        /// </summary>
        public string CEOFullName { get; set; }

        /// <summary>
        /// Кількість працівників.
        /// </summary>
        public int NumberOfEmployees { get; set; }

        /// <summary>
        /// Адреса фірми.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ініціалізує новий екземпляр класу Firm з вказаними параметрами.
        /// </summary>
        /// <param name="name">Назва фірми.</param>
        /// <param name="foundationDate">Дата заснування фірми.</param>
        /// <param name="businessProfile">Профіль бізнесу.</param>
        /// <param name="ceoFullName">ПІБ директора.</param>
        /// <param name="numberOfEmployees">Кількість працівників.</param>
        /// <param name="address">Адреса фірми.</param>
        public Firm(string name, DateTime foundationDate, string businessProfile, string ceoFullName, int numberOfEmployees, string address)
        {
            Name = name;
            FoundationDate = foundationDate;
            BusinessProfile = businessProfile;
            CEOFullName = ceoFullName;
            NumberOfEmployees = numberOfEmployees;
            Address = address;
        }
    }

    /// <summary>
    /// Клас, що містить методи для опрацювання запитів щодо фірм.
    /// </summary>
    public class FirmProcessor
    {
        private List<Firm> firms;

        /// <summary>
        /// Ініціалізує новий екземпляр класу FirmProcessor з вказаним списком фірм.
        /// </summary>
        /// <param name="firms">Список фірм.</param>
        public FirmProcessor(List<Firm> firms)
        {
            this.firms = firms;
        }

        /// <summary>
        /// Отримати інформацію про всі фірми.
        /// </summary>
        public List<Firm> GetAllFirms()
        {
            return firms;
        }

        /// <summary>
        /// Отримати фірми, які мають у назві слово «Food».
        /// </summary>
        public List<Firm> GetFirmsWithNameContaining(string keyword)
        {
            return firms.Where(f => f.Name.Contains(keyword)).ToList();
        }

        /// <summary>
        /// Отримати фірми, які працюють у галузі маркетингу.
        /// </summary>
        public List<Firm> GetMarketingFirms()
        {
            return firms.Where(f => f.BusinessProfile == "Marketing").ToList();
        }

        /// <summary>
        /// Отримати фірми, які працюють у галузі маркетингу або IT.
        /// </summary>
        public List<Firm> GetMarketingOrITFirms()
        {
            return firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT").ToList();
        }

        /// <summary>
        /// Отримати фірми з кількістю працівників більшою, ніж вказано.
        /// </summary>
        public List<Firm> GetFirmsWithMoreEmployeesThan(int employeesCount)
        {
            return firms.Where(f => f.NumberOfEmployees > employeesCount).ToList();
        }

        /// <summary>
        /// Отримати фірми з кількістю працівників у вказаному діапазоні.
        /// </summary>
        public List<Firm> GetFirmsWithEmployeesInRange(int minEmployees, int maxEmployees)
        {
            return firms.Where(f => f.NumberOfEmployees >= minEmployees && f.NumberOfEmployees <= maxEmployees).ToList();
        }

        /// <summary>
        /// Отримати фірми, які знаходяться у вказаному місті.
        /// </summary>
        public List<Firm> GetFirmsInCity(string city)
        {
            return firms.Where(f => f.Address.Contains(city)).ToList();
        }

        /// <summary>
        /// Отримати фірми, в яких прізвище директора є вказаним.
        /// </summary>
        public List<Firm> GetFirmsWithCEOName(string lastName)
        {
            return firms.Where(f => f.CEOFullName.Split().Last() == lastName).ToList();
        }

        /// <summary>
        /// Отримати фірми, які засновані більше двох років тому.
        /// </summary>
        public List<Firm> GetFirmsFoundedBefore(DateTime date)
        {
            return firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays > 730).ToList();
        }

        /// <summary>
        /// Отримати фірми, засновані певну кількість днів тому.
        /// </summary>
        public List<Firm> GetFirmsFoundedDaysAgo(int days)
        {
            return firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays == days).ToList();
        }

        /// <summary>
        /// Отримати фірми, в яких прізвище директора Black і мають у назві фірми слово «White».
        ///</summary>

        /// <summary>
        /// Отримати фірми, в яких прізвище директора Black і мають у назві фірми слово «White».
        /// </summary>
        public List<Firm> GetFirmsWithBlackCEOAndWhiteInName()
        {
            return firms.Where(f => f.CEOFullName.Split().Last() == "Black" && f.Name.Contains("White")).ToList();
        }

        // Методи розширень замість LINQ запитів можуть бути додані тут...
    }

    /// <summary>
    /// Точка входу в програму.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входу в програму.
        /// </summary>
        /// <param name="args">Аргументи командного рядка.</param>
        public static void Main(string[] args)
        {
            // Створюємо декілька фірм
            List<Firm> firms = new List<Firm>
        {
            new Firm("FoodTech", new DateTime(2010, 5, 15), "Food", "John Smith", 150, "123 Main St, London"),
            new Firm("TechSolutions", new DateTime(2015, 10, 20), "IT", "Jane Doe", 250, "456 High St, New York"),
            new Firm("MarketingGenius", new DateTime(2005, 8, 7), "Marketing", "Michael Johnson", 75, "789 Park Ave, Los Angeles"),
            new Firm("White & Co", DateTime.Now.AddYears(-3), "Consulting", "Sarah White", 200, "987 Elm St, London"),
            new Firm("Black Enterprises", DateTime.Now.AddYears(-4), "IT", "David Black", 300, "654 Oak St, Chicago")
        };

            FirmProcessor processor = new FirmProcessor(firms);

            
            Console.WriteLine("All Firms:");
            foreach (var firm in processor.GetAllFirms())
            {
                Console.WriteLine($"Name: {firm.Name}, Business Profile: {firm.BusinessProfile}, CEO: {firm.CEOFullName}");
            }

            Console.WriteLine("\nFirms with 'Food' in name:");
            foreach (var firm in processor.GetFirmsWithNameContaining("Food"))
            {
                Console.WriteLine($"Name: {firm.Name}, Business Profile: {firm.BusinessProfile}, CEO: {firm.CEOFullName}");
            }

            Console.WriteLine("\nMarketing Firms:");
            foreach (var firm in processor.GetMarketingFirms())
            {
                Console.WriteLine($"Name: {firm.Name}, Business Profile: {firm.BusinessProfile}, CEO: {firm.CEOFullName}");
            }

            Console.WriteLine("\nFirms with CEO 'Black' and 'White' in name:");
            foreach (var firm in processor.GetFirmsWithBlackCEOAndWhiteInName())
            {
                Console.WriteLine($"Name: {firm.Name}, Business Profile: {firm.BusinessProfile}, CEO: {firm.CEOFullName}");
            }
        }
    }
}
