using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task3.workspace;
using Task3.workspace.items;

namespace Task3.workspace
{
    internal class TestingState
    {
        public static async Task RunTests()
        {
            var printer = new Printer();

            printer.Add("Document1", "Yevhenii", Priority.Normal);
            printer.Add("Document2", "Yurii", Priority.High);
            printer.Add("Document3", "Andrii", Priority.Normal);

            // Print Stuff
            printer.Print();
            printer.Print();
            printer.Print();
            printer.Print(); // Attempt to print when no jobs are left

            printer.ShowHistory();
            await printer.SaveHistory("test_stats.txt");
        }
    }
}
