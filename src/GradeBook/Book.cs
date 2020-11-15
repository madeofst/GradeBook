using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name;
        private Statistics stats;

        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                stats = getExtremesAndAverage();
            }
            else
            {
                Console.WriteLine($"Sorry, but {grade} is not a valid grade.");
            }
        }

        public Statistics getExtremesAndAverage()
        {
            Statistics result = new Statistics();
            
            double total = 0;
            for(byte i = 0; i<grades.Count; i++)
            {
                if(grades[i] < result.minGrade) result.minGrade = grades[i];
                if(grades[i] > result.maxGrade) result.maxGrade = grades[i];
                total += grades[i];
            }
            result.avgGrade = total/grades.Count;
            
            switch(result.avgGrade)
            {
                case var d when d >= 90.0:
                    result.avgLetterGrade = 'A';
                    break;
                case var d when d >= 80.0:
                    result.avgLetterGrade = 'B';
                    break;
                case var d when d >= 70.0:
                    result.avgLetterGrade = 'C';
                    break;
                case var d when d >= 60.0:
                    result.avgLetterGrade = 'D';
                    break;
                default:
                    result.avgLetterGrade = 'F';
                    break;
            }
            return result;
        }
    
        public void WriteStatsToConsole()
        {
            if(stats==null)
            {
                System.Console.WriteLine($"Student {Name}'s gradebook does not contain any data.");
            }
            else
            {
                System.Console.WriteLine($"Student {Name}'s minimum grade is {stats.minGrade:N1}");
                System.Console.WriteLine($"Student {Name}'s maximum grade is {stats.maxGrade:N1}");
                System.Console.WriteLine($"Student {Name}'s average grade is {stats.avgGrade:N1}");
                System.Console.WriteLine($"Student {Name}'s average letter grade is {stats.avgLetterGrade:N1}");
            }
        }
    }
}