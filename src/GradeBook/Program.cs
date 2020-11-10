using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Mike");
            book.AddGrade(21.3);
            book.AddGrade(24.65);
            book.AddGrade(28);
            book.WriteStatsToConsole();
        }
    }
}
