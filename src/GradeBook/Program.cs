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
            string line;
            while((line = Console.ReadLine()) != ""){
                if(double.TryParse(line, out double grade)){
                    book.AddGrade(grade);
                }
                else{
                    Console.WriteLine($"Sorry, {line} is not a valid grade value.");
                }
            }
            
            book.WriteStatsToConsole();
            Console.WriteLine("Press any key to exit.");
            while((line = Console.ReadLine()) != ""){
            }
        }
    }
}
