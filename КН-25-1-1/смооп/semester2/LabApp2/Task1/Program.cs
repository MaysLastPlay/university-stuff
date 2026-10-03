using Task1.services;
using Task1.models;

var firmService = new FirmService();
var phoneService = new PhoneService();
var companyService = new CompanyService();


    Console.Write("\nTask (1: Firms, 2: Phones, 3: Company, 0: Exit): ");

    switch (Console.ReadLine())
    {
        case "1": RunFirms(firmService); break;
        case "2": RunPhones(phoneService); break;
        case "3": RunCompany(companyService); break;
        case "0": return;
        default: Console.WriteLine("Invalid choice"); break;
    }

static void RunFirms(FirmService s)
{
    Console.WriteLine($"\n--- Firms ---\nTotal: {s.GetAll().Count}");
    Console.WriteLine($"Food names: {string.Join(", ", s.GetByNameFood().Select(f => f.Name))}");
    Console.WriteLine($"Marketing/IT: {s.GetByProfileMarketingOrIT().Count} | In London: {s.GetInLondon().Count}");
    Console.WriteLine($"Director White: {s.GetByDirectorLastName("White").Count} | Staff > 100: {s.GetWithEmployeesMoreThan(100).Count}");
    Console.WriteLine($"Older 2 yrs: {s.GetOlderThanYears(2).Count} | Black + White: {s.GetWithDirectorBlackAndNameWhite().Count}");
}

static void RunPhones(PhoneService s)
{
    Console.WriteLine($"\n--- Phones ---\nTotal: {s.GetTotalCount()} | Price > $100: {s.CountPriceGreaterThan(100)}");
    Console.WriteLine($"Min: ${s.GetMinPrice()} | Max: ${s.GetMaxPrice()} | Avg: ${s.GetAveragePrice():F1}");
    Console.WriteLine($"Oldest: {s.GetOldestPhone()} | Newest: {s.GetNewestPhone()}");
    Console.WriteLine($"Top 3: {string.Join(", ", s.GetTopExpensive(3).Select(p => $"{p.Model} (${p.Price})"))}");
    Console.WriteLine($"By Brand: {string.Join(", ", s.GetStatsByManufacturer().Select(x => $"{x.Key}:{x.Value}"))}");
}

static void RunCompany(CompanyService s)
{
    Console.WriteLine($"\n--- Company ---\nStaff: {s.GetEmployeesCount()} | Budget: ${s.GetTotalSalaryFund():N2}");
    Console.WriteLine($"Top-exp educated: {s.GetYoungestEducatedAmongTopExperience()}");
    Console.WriteLine($"Managers: {s.GetYoungestManager()} (Youngest) / {s.GetOldestManager()} (Oldest)");

    var vol = s.GetYoungestVolodymyr();
    if (vol != null)
    {
        Console.WriteLine($"Bonus to {vol.Name} {vol.Surname}: ${vol.Salary / 3m:N2}");
    }

    Console.WriteLine("\nBorn in October:");
    foreach (var (role, employees) in s.GetOctoberBornGroupedByRole())
    {
        Console.WriteLine($"[{role}]");
        foreach (var emp in employees)
        {
            Console.WriteLine($"  {emp}");
        }
    }
}

public record Person(string FirstName, string LastName, DateTime BirthDate, string Address, string PhoneNumber);
public record Firm(string Name, DateTime creationDate, string businessProfile, Person Director, int EmployeesCount, string address);
public record Phone(string Manufacturer, string Model, decimal Price, DateTime ReleaseDate)
{
    public override string ToString() => $"{Manufacturer} {Model} - {ReleaseDate:yyyy-MM-dd}, (${Price})";
}