using System;
using Xunit;

namespace GradeBook.Tests
{
  public class BookTests
  {
    [Fact]
    public void BookCanAddLetterGrades()
    {
      var book = new Book("");
      book.AddGrade('B');
      book.AddGrade('A');
      book.AddGrade('C');

      var result = book.GetStats();

      Assert.Equal(4.0, result.Average, 1);
      Assert.Equal(3.0, result.Low, 1);
      Assert.Equal(5.0, result.High, 1);
      Assert.Equal('B', result.Letter);
    }

    [Fact]
    public void BooksCalculatesGrades()
    {
      // arrange
      var book = new Book("");
      book.AddGrade(4.5);
      book.AddGrade(2.0);
      book.AddGrade(5.0);

      // act
      var result = book.GetStats();

      // assert
      Assert.Equal(3.8, result.Average, 1);
      Assert.Equal(2.0, result.Low, 1);
      Assert.Equal(5.0, result.High, 1);
      Assert.Equal('C', result.Letter);
    }
  }
}
