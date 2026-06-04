using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using LabApp11_1.university.student;

namespace LabApp11_1.university.student
{
    //  Принцип 1 SOLID: Single Responsibility Principle (Принцип єдиної відповідальності)
    internal class Student
    {
        public int StudentNumberInGroup { get; private set; }
        public string FullName { get; private set; }
        public string RecordBookNumber { get; private set; }
        public string PhoneNumber { get; private set; }
        public string GroupName { get; set; }

        public StudentRecord Record { get; } = new StudentRecord(); // Делегація обов'язків; клас Student не відповідає за зберігання та обробку оцінок, а делегує це класу StudentRecord.

        public Student(int number, string fullName, string recordBook, string phone, string groupName)
        {
            StudentNumberInGroup = number;
            FullName = fullName;
            RecordBookNumber = recordBook;
            PhoneNumber = phone;
            GroupName = groupName;
        }

        public void AddGrade(string subject, int grade) => Record.AddGrade(subject, grade);
        public double AverageGrade => Record.AverageGrade;
        public string TopSubject => Record.TopSubject;
        public string LowestSubject => Record.LowestSubject;


        public override string ToString() =>"Group: " + GroupName + ", Group Number: " + StudentNumberInGroup + ", Full Name: " + FullName + ", Record Book Number: " + RecordBookNumber + ", Phone Number: " + PhoneNumber;
        public string StudRecord => $"Highest Grade: {Record.TopSubject}, Lowest Grade: {Record.LowestSubject}, Average Grade: {Record.AverageGrade}";
    }
}
