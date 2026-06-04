using LabApp11_1.university.student;
using LabApp11_1.university.group;

Student student1 = new Student(1, "John Doe", "RB12345", "+123456789", "A-25-1");
student1.AddGrade("Math", 90);
student1.AddGrade("Physics", 85);
student1.AddGrade("Chemistry", 92);
student1.AddGrade("Biology", 88);
Console.WriteLine(student1);
Console.WriteLine(student1.StudRecord + "\n");
Console.WriteLine();

Student student2 = new Student(2, "Jane Smith", "RB54321", "+987654321", "A-25-1");
student2.AddGrade("Math", 95);
student2.AddGrade("Physics", 90);
student2.AddGrade("Chemistry", 93);
student2.AddGrade("Biology", 89);
Console.WriteLine(student2);
Console.WriteLine(student2.StudRecord + "\n");
Console.WriteLine();

Student student3 = new Student(3, "Alice Johnson", "RB67890", "+1122334455", "A-25-1");
student3.AddGrade("Math", 85);
student3.AddGrade("Physics", 80);
student3.AddGrade("Chemistry", 88);
student3.AddGrade("Biology", 82);
Console.WriteLine(student3);
Console.WriteLine(student3.StudRecord + "\n");

Group group = new Group(4);
group[0] = student1;
group[1] = student2;
group[2] = student3;
Student? topStudent = group.MostSuccessfulStudent;
Console.WriteLine("Most Successful Student: " + (topStudent?.FullName ?? "None"));