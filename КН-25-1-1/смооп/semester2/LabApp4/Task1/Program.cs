using Task1.services;

Console.WriteLine("Choose what you want to do: 1 - XML, 2 - JSON, 0 - Exit");
int.TryParse(Console.ReadLine(), out int numb);

var testingState = new TestingState();

do
{
    switch (numb)
    {
        case 1:
            testingState.TestXml();
            break;
        case 2:
            testingState.TestJson();
            break;
        case 0:
            Console.WriteLine("Exiting the program.");
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
    if (numb != 0)
    {
        Console.WriteLine("\nChoose what you want to do: 1 - XML, 2 - JSON, 0 - Exit");
        int.TryParse(Console.ReadLine(), out numb);
    }
} while (numb != 0);
