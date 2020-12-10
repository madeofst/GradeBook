using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
        }

        private List<double> grades;

        public override void AddGrade(double grade)
        {
            if(ValidGrade(grade))
            {
                grades.Add(grade);
                AfterGradeAdded();
            }
            else
            {
                Console.WriteLine($"Sorry, but {grade} is not a valid grade.");
            }
        }

        public override List<double> Grades()
        {
            return grades;
        }
    }
}