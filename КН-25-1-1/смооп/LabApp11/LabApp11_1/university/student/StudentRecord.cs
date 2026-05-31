using System;
using System.Collections.Generic;
using System.Text;

namespace LabApp11_1.university.student
{
    internal class StudentRecord
    {
        private string[] subjects = new string[7];
        private int[] grades = new int[7];
        private int count = 0;

        public void AddGrade(string subject, int grade)
        {
            if (count < 7)
            {
                subjects[count] = subject;
                grades[count] = grade;
                count++;
            }
            else
            {
                Console.WriteLine("Повинно бути тільки 7 дисциплін");
            }
        }
        public double AverageGrade
        {
            get
            {
                if (count == 0) return 0;

                double sum = 0;
                for (int i = 0; i < count; i++)
                {
                    sum += grades[i];
                }
                return sum / count;
            }
        }

        public string TopSubject
        {
            get
            {
                if (count == 0) return "Немає дисциплін";

                int maxIndex = 0;
                for (int i = 1; i < count; i++)
                {
                    if (grades[i] > grades[maxIndex])
                    {
                        maxIndex = i;
                    }
                }
                return subjects[maxIndex];
            }
        }
        public string LowestSubject
        {
            get
            {
                if (count == 0) return "Немає дисциплін";

                int minIndex = 0;
                for (int i = 1; i < count; i++)
                {
                    if (grades[i] < grades[minIndex])
                    {
                        minIndex = i;
                    }
                }
                return subjects[minIndex];
            }
        }
    }
}
