using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleTesting.student
{
    using System;

    public class Group
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

        public Student MostSuccessfulStudent
        {
            get
            {
                Student bestStudent = null;

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
}
