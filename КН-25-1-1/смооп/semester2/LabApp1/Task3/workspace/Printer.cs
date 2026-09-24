using System;
using System.Collections.Generic;
using System.IO;
using Task3.workspace.items;

namespace Task3.workspace
{
    public class Printer
    {
        public static Queue<PrintJob> _highQueue = new();
        public static Queue<PrintJob> _normalQueue = new();
        public static List<PrintLog> _history = new();

        public void Add(string name, string user, Priority priority)
        {
            var job = new PrintJob(name, user, priority);

            if (priority == Priority.High)
            {
                _highQueue.Enqueue(job);
            }
            else
            {
                _normalQueue.Enqueue(job);
            }

            Console.WriteLine($"Added to queue: {name} by {user} with priority {priority}");
        }

        public void Print()
        {
            if (!_highQueue.TryDequeue(out var job) && !_normalQueue.TryDequeue(out job))
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
                Console.WriteLine($"{log.PrintedAt:yyyy-MM-dd HH:mm:ss} | {log.User,-10} | {log.Name}");
            }
        }

        public void SaveHistory(string filePath = "stats.txt")
        {
            using var writer = new StreamWriter(filePath);
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