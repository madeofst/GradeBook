using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //arrange
            Book testBook = new Book("Test Book");
            testBook.AddGrade(77.5);
            testBook.AddGrade(46.5);
            testBook.AddGrade(89.4);
            testBook.AddGrade('A');
            testBook.AddGrade('D');

            //act
            Statistics result = testBook.getExtremesAndAverage();

            //assert
            Assert.Equal(46.5, result.minGrade,1);  
            Assert.Equal(90.0, result.maxGrade,1);
            Assert.Equal(72.7, result.avgGrade,1);
            Assert.Equal('C',result.avgLetterGrade);
        }
    }
}
