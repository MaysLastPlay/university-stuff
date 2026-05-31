using System;
using System.Collections.Generic;
using System.Text;
using LabApp11_1.interfaces;
using LabApp11_1.university.student;

namespace LabApp11_1.university.group
{
    internal class Group
    {
        private Student[] _students;

        public Group(int k)
        {
            _students = new Student[k];
        }

        public Student this[int index]
        {
            get { return _students[index]; }
            set { _students[index] = value; }
        }

        public Student? GetStudent(ISelector selector) => selector?.Select(_students);

        public Student? MostSuccessfulStudent
        {
            get
            {
                return GetStudent(new BestStudent());
            }
        }
    }
}
