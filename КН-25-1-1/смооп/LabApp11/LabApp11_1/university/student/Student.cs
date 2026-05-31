using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using LabApp11_1.university.student;

namespace LabApp11_1.university.student
{
    internal class Student
    {
        public int StudentNumberInGroup { get; private set; }
        public string FullName { get; private set; }
        public string RecordBookNumber { get; private set; }
        public string PhoneNumber { get; private set; }

        public StudentRecord Record { get; } = new StudentRecord();

        public Student(int number, string fullName, string recordBook, string phone)
        {
            StudentNumberInGroup = number;
            FullName = fullName;
            RecordBookNumber = recordBook;
            PhoneNumber = phone;
        }

        public void AddGrade(string subject, int grade) => Record.AddGrade(subject, grade);
        public double AverageGrade => Record.AverageGrade;
        public string TopSubject => Record.TopSubject;
        public string LowestSubject => Record.LowestSubject;


        public override string ToString()
        {
            return "Group Number: " + StudentNumberInGroup + ", Full Name: " + FullName + ", Record Book Number: " + RecordBookNumber + ", Phone Number: " + PhoneNumber;
        }
    }
}
