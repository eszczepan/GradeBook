using System;
using Xunit;

namespace GradeBook.Tests
{
  public class TypeTests
  {
    [Fact]
    public void StringBehaveLikeValueTypes()
    {
      string name = "Szczepan";
      var upperName = MakeUpperCase(name);
      MakeUpperCase(name);

      Assert.Equal(name, "Szczepan");
      Assert.Equal(upperName, "SZCZEPAN");
    }

    private string MakeUpperCase(string param)
    {
      return param.ToUpper();
    }

    [Fact]
    public void ValueTypesAlsoPassByValue()
    {
      var x = GetInt();
      SetInt(ref x);
      var y = x;
      y = 5;

      Assert.Equal(7, x);
      Assert.Equal(5, y);
    }

    private void SetInt(ref int z)
    {
      z = 7;
    }

    private int GetInt()
    {
      return 3;
    }

    [Fact]
    public void CSharpCanPassByReference()
    {
      var book1 = GetBook("Book 1");
      GetBookSetName(ref book1, "New Name");

      Assert.Equal("New Name", book1.Name);
    }

    private void GetBookSetName(ref Book book, string name)
    {
      book = new Book(name);
    }

    [Fact]
    public void CSharpIsPassByValue()
    {
      var book1 = GetBook("Book 1");
      GetBookSetName(book1, "New Name");

      Assert.Equal("Book 1", book1.Name);
    }

    private void GetBookSetName(Book book, string name)
    {
      book = new Book(name);
    }


    [Fact]
    public void CanSetNameFromReference()
    {
      var book1 = GetBook("Book 1");
      var book2 = book1;
      SetName(book2, "New Name");

      Assert.Equal("New Name", book1.Name);
      Assert.Same(book1, book2);
      Assert.True(Object.ReferenceEquals(book1, book2));
    }

    private void SetName(Book book, string name)
    {
      book.Name = name;
    }

    [Fact]
    public void GetBookReturnsDiffrentObjects()
    {
      var book1 = GetBook("Book 1");
      var book2 = GetBook("Book 2");

      Assert.Equal("Book 1", book1.Name);
      Assert.Equal("Book 2", book2.Name);
      Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVarsReferenceSameObject()
    {
      var book1 = GetBook("Book 1");
      var book2 = book1;

      Assert.Same(book1, book2);
      Assert.True(Object.ReferenceEquals(book1, book2));
    }

    Book GetBook(string name)
    {
      return new Book(name);
    }
  }
}
