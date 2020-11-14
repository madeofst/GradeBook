using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            MakeUpperCase(name);
            Assert.Equal("Scott",name);
        }

        private void MakeUpperCase(string parameterString)
        {
            parameterString.ToUpper();
        }

        [Fact]
        public void Test1()
        {
            int x = GetInt();
            SetInt(ref x);
            Assert.Equal(42,x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()

        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            Book book1 = new Book("Book 1");
            GetBookSetName(ref book1,"New Name");
            Assert.Equal("New Name",book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            Book book1 = new Book("Book 1");
            GetBookSetName(book1,"New Name");
            Assert.Equal("Book 1",book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            Book book1 = new Book("Book 1");
            SetName(book1,"New Name");
            Assert.Equal("New Name",book1.Name);
        }

        private void SetName(Book book, string newName)
        {
            book.Name = newName;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange
            Book book1 = GetBook("Book 1");
            Book book2 = GetBook("Book 2");
            //act
            

            //assert
            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameOjbect()
        {
            //arrange
            Book book1 = GetBook("Book 1");
            Book book2 = book1;
            
            //act
            
            
            //assert
            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
