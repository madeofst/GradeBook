using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            if(ValidGrade(grade))
            {
                using(StreamWriter writer = File.AppendText($"{Name}.txt"))
                {
                    writer.WriteLine(grade);
                }       
                AfterGradeAdded();
            }
            else
            {
                Console.WriteLine($"Sorry, but {grade} is not a valid grade.");
            }
        }

        public override List<double> Grades()
        {
            string[] dataLines = File.ReadAllLines($"{Name}.txt");
            List<double> grades = new List<double>{};
            for (int i = 0; i<dataLines.GetLength(0); i++)
            {
                grades.Add(Convert.ToDouble(dataLines[i]));
            }
            return grades;
        }
    }
}