namespace GradeBook
{
    public class Statistics
    {
        public double minGrade;
        public double avgGrade;
        public double maxGrade;
        

        public Statistics()
        {
            minGrade = double.MaxValue;
            avgGrade = 0;
            maxGrade = double.MinValue;
        }

    }
}