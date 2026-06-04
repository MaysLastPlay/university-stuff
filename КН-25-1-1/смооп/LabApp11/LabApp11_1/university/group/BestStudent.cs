using System;
using System.Collections.Generic;
using System.Text;
using LabApp11_1.university.student;
using LabApp11_1.interfaces;

namespace LabApp11_1.university.group
{
    // Принцип 3 SOLID: Liskov Substitution Principle (Принцип підстановки Барбари Лісков)
    internal class BestStudent : ISelector
    {
        public Student Select(Student[] _students) // Об'єкт, який реалізує інтерфейс ISelector, повинен бути замінним на будь-який інший об'єкт, який реалізує цей інтерфейс, без порушення коректності програми.
        {
                Student? bestStudent = null;

                for (int i = 0; i < _students.Length; i++)
                {
                    if (_students[i] != null)
                    {
                        if (bestStudent == null || _students[i].AverageGrade > bestStudent.AverageGrade)
                        {
                            bestStudent = _students[i];
                        }
                    }
                }
                return bestStudent;
        }
    }
}
