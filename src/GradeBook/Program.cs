using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Mike");

            Console.Clear();
            Console.WriteLine("Please enter a numerical value between 0 and 100 and press enter to store. Press enter again when done.");
            
            ReadConsoleAndAddGrade(book);
            book.WriteStatsToConsole();

            Console.WriteLine("Now please provide a log message.");
            DelegateDemo logger = new DelegateDemo();
            string message = Console.ReadLine();
            logger.DoAllDelegateActions(message);
            
            ExitOnBlankLine();
        }

        private static void ExitOnBlankLine()
        {
            Console.WriteLine("Press any key to exit.");
            string line;
            while((line = Console.ReadLine()) != ""){};
        }

        private static void ReadConsoleAndAddGrade(Book book)
        {
            string line;
            while((line = Console.ReadLine()) != ""){
                if(double.TryParse(line, out double grade))
                {
                    book.AddGrade(grade);
                }
                else if(char.TryParse(line,out char letter))
                {
                    book.AddGrade(letter);
                }
                else{
                    Console.WriteLine($"Sorry, {line} is not a valid grade value.");
                }
            }
        }

    }
}
