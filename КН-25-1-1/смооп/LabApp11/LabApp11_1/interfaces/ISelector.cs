using System;
using System.Collections.Generic;
using System.Text;
using LabApp11_1.university.student;

namespace LabApp11_1.interfaces
{
    internal interface ISelector
    {
        Student Select(Student[] students);
    }
}
