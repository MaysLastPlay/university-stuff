
using LabApp7_1.numbers;

// DoubleNums Test
DoubleNums nums = new DoubleNums(3.5, 4.2);

Console.WriteLine(nums.ToShortString());
Console.WriteLine(nums);

//ComplexNum Test
ComplexNum complex = new ComplexNum(2.0, 3.0);
Console.WriteLine(complex.ToShortString());
Console.WriteLine(complex);

//ComplexNum Test
ComplexNum[] complexArr = new ComplexNum[2];
complexArr[0] = new ComplexNum(2.0, 3.0);
complexArr[1] = new ComplexNum(4.0, 5.0);
Console.WriteLine(complexArr[0].ToShortString());
Console.WriteLine(complexArr[0]);
Console.WriteLine(complexArr[1].ToShortString());
Console.WriteLine(complexArr[1]);