//int i, j, s = 0;
//for (i = 8, j = 13; i < j; i += 3, j = -2)
//{
//    s += i;
//}
//Console.WriteLine(s);

using Idkwhatisthatttttt;

TestingStuff.WhatIsThat(new int[] { 12, -4, 15, 16, -18, 22, 27, 28, 3, 5, 40 });
Console.WriteLine("Result:");
foreach (int x in TestingStuff.WhatIsThat(new int[] { 12, -4, 15, 16, -18, 22, 27, 28, 3, 5, 40 }))
{
    Console.Write(x + " ");
}
Console.WriteLine();