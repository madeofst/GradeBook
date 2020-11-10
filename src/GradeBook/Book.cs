using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        private string name;
        private Statistics stats;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
            stats = getExtremesAndAverage();
        }

        public Statistics getExtremesAndAverage()
        {
            Statistics result = new Statistics();
            
            double total = 0;
            foreach (double g in grades)
            {
                if(g < result.minGrade){
                    result.minGrade = g;
                }
                if(g > result.maxGrade){
                    result.maxGrade = g;
                }
                total += g;
            }
            result.avgGrade = total/grades.Count;
            return result;
        }
    
        public void WriteStatsToConsole()
        {
            System.Console.WriteLine($"Student {name}'s minimum grade is {stats.minGrade:N1}");
            System.Console.WriteLine($"Student {name}'s maximum grade is {stats.maxGrade:N1}");
            System.Console.WriteLine($"Student {name}'s average grade is {stats.avgGrade:N1}");
        }
    }
}