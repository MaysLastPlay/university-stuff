using System;
using Task1.services.work;

namespace Task1.services
{
    internal class TestingState
    {
        private readonly Worker[] _workers = new Worker[]
        {
            new Worker("John Doe", "Manager", 50000m, new DateTime(2018, 1, 15)),
            new Worker("Jane Smith", "Developer", 60000m, new DateTime(2022, 3, 10)),
            new Worker("Alice Johnson", "Designer", 55000m, new DateTime(2019, 7, 20))
        };

        private readonly XmlService xml = new XmlService();
        private readonly JsonService json = new JsonService();

        public void TestXml()
        {
            Console.WriteLine("Xml:");
            xml.SerializeWorkers("workers.xml", _workers);
            Worker[] loaded = xml.DeserializeWorkers("workers.xml");
            ProcessWorkers(loaded);
        }

        public void TestJson()
        {
            Console.WriteLine("\nJson:");
            json.SerializeWorkers("workers.json", _workers);
            Worker[] loaded = json.DeserializeWorkers("workers.json");
            ProcessWorkers(loaded);
        }

        private void ProcessWorkers(Worker[] list)
        {
            DateTime now = DateTime.Today;

            foreach (var w in list)
            {
                int exp = now.Year - w.HireDate.Year;
                if (now < w.HireDate.AddYears(exp)) exp--;

                if (exp > 5)
                {
                    w.Salary *= 1.04m;
                    Console.WriteLine($"{w.FullName} | Exp: {exp} yrs | New Salary (+4%): {w.Salary:F2}");
                }
            }
        }
    }
}