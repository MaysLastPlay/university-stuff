using System;
using System.Collections.Generic;
using System.IO;
using Task3.workspace.items;

namespace Task3.workspace
{
    public class Printer
    {
        public static PriorityQueue<PrintJob, Priority> priorityQueue = new();
        public static List<PrintLog> _history = new();

        public void Add(string name, string user, Priority priority)
        {
            var job = new PrintJob(name, user, priority);

            priorityQueue.Enqueue(job, priority);

            Console.WriteLine($"Added to queue: {name} by {user} with priority {priority}");
        }

        public void Print()
        {
            if (!priorityQueue.TryDequeue(out var job, out _))
            {
                Console.WriteLine("No print jobs in the queue.");
                return;
            }

            Console.WriteLine($"Printing: '{job.Name}' for {job.User}...");

            _history.Add(new PrintLog(job.Name, job.User, DateTime.Now));
        }

        public void ShowHistory()
        {
            if (_history.Count == 0)
            {
                Console.WriteLine("No print jobs have been printed yet.");
                return;
            }

            foreach (var log in _history)
            {
                Console.WriteLine($"{log.PrintedAt:yyyy-MM-dd HH:mm:ss} | {log.User,-2} | {log.Name}");
            }
        }

        public async Task SaveHistory(string filePath = "stats.txt")
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Date | User | Document");
                writer.WriteLine(new string('-', 50));

                foreach (var log in _history)
                {
                    writer.WriteLine($"{log.PrintedAt:yyyy-MM-dd HH:mm:ss} | {log.User} | {log.Name}");
                }

                Console.WriteLine($"Stats saved to {Path.GetFullPath(filePath)}");
            }
        }
    }
}