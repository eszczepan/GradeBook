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
      var stats = book.GetStats();
      Console.WriteLine($"Hello {book.Name}!");
      Console.WriteLine($"This is your worst grade: {stats.Low:N1}");
      Console.WriteLine($"Here's your best: {stats.High:N1}");
      Console.WriteLine($"And your average grade is: {stats.Average:N2}");
    }
  }
}
