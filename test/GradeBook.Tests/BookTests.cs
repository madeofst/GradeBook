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

            //act
            Statistics result = testBook.getExtremesAndAverage();

            //assert
            Assert.Equal(46.5, result.minGrade,1);  
            Assert.Equal(89.4, result.maxGrade,1);
            Assert.Equal(71.1, result.avgGrade,1);
        }
    }
}
