using LabApp11_1.university.student;
using LabApp11_1.university.group;

Student student1 = new Student(1, "John Doe", "RB12345", "+123456789");
student1.AddGrade("Math", 90);
student1.AddGrade("Physics", 85);
student1.AddGrade("Chemistry", 92);
student1.AddGrade("Biology", 88);

Console.WriteLine(student1);
Console.WriteLine($"Best Subject: {student1.TopSubject}");
Console.WriteLine($"Lowest Subject: {student1.LowestSubject}");
Console.WriteLine($"Average Grade: {student1.AverageGrade}");
Console.WriteLine();

Student student2 = new Student(2, "Jane Smith", "RB54321", "+987654321");
student2.AddGrade("Math", 95);
student2.AddGrade("Physics", 90);
student2.AddGrade("Chemistry", 93);
student2.AddGrade("Biology", 89);

Console.WriteLine(student2);
Console.WriteLine($"Best Subject: {student2.TopSubject}");
Console.WriteLine($"Lowest Subject: {student2.LowestSubject}");
Console.WriteLine($"Average Grade: {student2.AverageGrade}");
Console.WriteLine();

Group group = new Group(3);
group[0] = student1;
group[1] = student2;
Student? topStudent = group.MostSuccessfulStudent;
Console.WriteLine("Most Successful Student: " + (topStudent?.FullName ?? "None"));