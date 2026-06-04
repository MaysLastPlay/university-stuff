using System;
using System.Collections.Generic;
using System.Text;
using LabApp11_1.interfaces;
using LabApp11_1.university.student;

namespace LabApp11_1.university.group
{
    //  Принцип 2 SOLID: Open/Closed Principle (Принцип відкритості/закритості)
    // Принцип 5 SOLID: Dependency Inversion Principle (Принцип інверсії залежностей)
    internal class Group(int k)
    {
        private Student[] _students = new Student[k];
        private readonly ISelector? bestStudent;

        public Student this[int index]
        {
            get { return _students[index]; }
            set { _students[index] = value; }
        }

        // Метод закритий для зміни, але відкритий для розширення.
        // Клас залежить від абстракції (інтерфейсу ISelector), а не від конкретної реалізації.
        public Student? GetStudent(ISelector selector) => selector?.Select(_students);

        public Student? MostSuccessfulStudent => GetStudent(bestStudent);
    }
}
