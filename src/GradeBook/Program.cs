using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Mike");
            book.GradeAdded += ActionWhenGradeAdded;

            Console.Clear();
            ReadConsoleAndAddGrades(book);
            book.WriteStatsToConsole();
            ExitOnBlankLine();            
        }

        private static void ExitOnBlankLine()
        {
            Console.WriteLine("Press any key to exit.");
            string line;
            while((line = Console.ReadLine()) != ""){};
        }

        private static void ReadConsoleAndAddGrades(IBook book)
        {
            Console.WriteLine("Please enter a numerical value between 0 and 100 and press enter to store. Press enter again when done.");
            
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

        static void ActionWhenGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }

        static void Delegates()
        {
            Console.WriteLine("Now please provide a log message.");
            DelegateDemo logger = new DelegateDemo();
            string message = Console.ReadLine();
            logger.DoAllDelegateActions(message);
        }
    }
}
