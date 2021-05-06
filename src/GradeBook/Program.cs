using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var book = new Book("Szczepan");
      book.AddGrade(3.0);
      book.AddGrade(4.0);
      book.ShowStats();
    }
  }
}
