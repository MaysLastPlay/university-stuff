using System;
using System.IO;
using System.Text.Json;
using Task1.services.work;

namespace Task1.services
{
    internal class JsonService
    {
        public void SerializeWorkers(string filePath, Worker[] workers)
        {
            string json = JsonSerializer.Serialize(workers);
            File.WriteAllText(filePath, json);
        }

        public Worker[] DeserializeWorkers(string filePath)
        {
            string json = File.ReadAllText(filePath);
            Worker[]? workers = JsonSerializer.Deserialize<Worker[]>(json);
            return workers ?? Array.Empty<Worker>();
        }
    }
}