var workers = File.ReadAllLines("workers.txt")
    .Select(line => line.Split(','))
    .Select(parts => new Worker(
        int.Parse(parts[0]),
        parts[1],
        parts[2],
        parts[3],
        DateTime.Parse(parts[4])
    ))
    .ToList();
var salaries = File.ReadAllLines("salaries.txt")
    .Select(line => line.Split(','))
    .Select(parts => new Salary(
        int.Parse(parts[0]),
        decimal.Parse(parts[1]),
        decimal.Parse(parts[2])
    ))
    .ToList();

List<Worker> olderThan35 = workers.Where(w => (DateTime.Now.Year - w.BirthDate.Year) > 35).ToList();
Console.WriteLine($"Older than 35: {olderThan35.Count}, Names: {string.Join(", ", olderThan35.Select(w => w.FullName))}");

List<Worker> biggestSalarySecondHalf = workers
    .Join(salaries, w => w.IndentNumber, s => s.IndentNumber, (w, s) => new { Worker = w, Salary = s })
    .Where(ws => ws.Salary.AmountSecondHalfYear == salaries.Max(s => s.AmountSecondHalfYear))
    .Select(ws => ws.Worker)
    .ToList();
Console.WriteLine($"Ident Code: {biggestSalarySecondHalf.First().IndentNumber}, Profession: {biggestSalarySecondHalf.First().Profession}, Biggest salary (second half): {biggestSalarySecondHalf.Count}");

List<Worker> lowestInYear = workers
    .Join(salaries, w => w.IndentNumber, s => s.IndentNumber, (w, s) => new { Worker = w, Salary = s })
    .Where(ws => (ws.Salary.AmountFirstHalfYear + ws.Salary.AmountSecondHalfYear) == salaries.Min(s => s.AmountFirstHalfYear + s.AmountSecondHalfYear))
    .Select(ws => ws.Worker)
    .ToList();
Console.WriteLine($"Names: {string.Join(", ", lowestInYear.Select(w => w.FullName))}, Education: {lowestInYear.First().Education}, Lowest in year: {lowestInYear.Count}");

int mySalary = 60000;
List<Worker> mySalaryWorkers = workers
    .Join(salaries, w => w.IndentNumber, s => s.IndentNumber, (w, s) => new { Worker = w, Salary = s })
    .Where(ws => (ws.Salary.AmountFirstHalfYear) > mySalary)
    .Select(ws => ws.Worker)
    .ToList();
Console.WriteLine($"Names: {string.Join(", ", mySalaryWorkers.Select(w => w.FullName))}, Education: {mySalaryWorkers.First().Education}, Salary more than {mySalary}: {mySalaryWorkers.Count}");

public record Worker(int IndentNumber, string FullName, string Education, string Profession, DateTime BirthDate);
public record Salary(int IndentNumber, decimal AmountFirstHalfYear, decimal AmountSecondHalfYear);