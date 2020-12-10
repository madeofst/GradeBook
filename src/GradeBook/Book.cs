using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook
    {
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
        void AddGrade(double grade);
        void AddGrade(char letter);
        List<double> Grades();
    }

    public abstract class Book : IBook
    {
        public string Name { get; set; }
        private Statistics stats;

        public Book(string name)
        {
            Name = name;
            stats = new Statistics();
        }

        public event GradeAddedDelegate GradeAdded;
        public abstract List<double> Grades();

        public abstract void AddGrade(double grade);
        public void AddGrade(char letter)
        {
            if(char.IsLetter(letter))
            {
                double grade;
                switch(letter)
                {
                    case 'A':
                        grade = 90;
                        break;
                    case 'B':
                        grade = 80;
                        break;
                    case 'C':
                        grade = 70;
                        break;
                    case 'D':
                        grade = 60;
                        break;
                    case 'E':
                        grade = 50;
                        break;
                    default:
                        grade = 40;
                        break;
                }
                AddGrade(grade);
            }
            else
            {
                Console.WriteLine($"Sorry, but {letter} is not a valid grade.");
            }
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

        public bool ValidGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AfterGradeAdded()
        {
            if (GradeAdded != null)
            {
                GradeAdded(this,new EventArgs());
            }
            stats.updateStats(Grades());
        }
    }
}