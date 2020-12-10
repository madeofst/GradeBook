using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public double minGrade;
        public double avgGrade;
        public double maxGrade;
        public char avgLetterGrade;

        public Statistics()
        {
            minGrade = double.MaxValue;
            avgGrade = 0;
            maxGrade = double.MinValue;
            avgLetterGrade = '-';
        }

        public void updateStats(List<double> grades)
        {
            double total = 0;
            for(byte i = 0; i<grades.Count; i++)
            {
                if(grades[i] < minGrade) minGrade = grades[i];
                if(grades[i] > maxGrade) maxGrade = grades[i];
                total += grades[i];
            }
            avgGrade = total/grades.Count;
            
            switch(avgGrade)
            {
                case var d when d >= 90.0:
                    avgLetterGrade = 'A';
                    break;
                case var d when d >= 80.0:
                    avgLetterGrade = 'B';
                    break;
                case var d when d >= 70.0:
                    avgLetterGrade = 'C';
                    break;
                case var d when d >= 60.0:
                    avgLetterGrade = 'D';
                    break;
                default:
                    avgLetterGrade = 'F';
                    break;
            }
        }

    }
}