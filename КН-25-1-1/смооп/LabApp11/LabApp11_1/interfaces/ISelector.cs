using System;
using System.Collections.Generic;
using System.Text;
using LabApp11_1.university.student;

namespace LabApp11_1.interfaces
{
    // Принцип 4 SOLID: Interface Segregation Principle (Принцип розділення інтерфейсів)
    internal interface ISelector
    {
        Student Select(Student[] students); // Інтерфейс повинен бути розділений на більш конкретні інтерфейси, щоб клієнти не були змушені залежати від методів, які вони не використовують.
    }
}
