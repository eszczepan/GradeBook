using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var book = new Book("Szczepan");

      while (true)
      {
        Console.WriteLine("Enter a grade or 'q' to quit.");
        var input = Console.ReadLine();
        if (input == "q")
        {
          break;
        }
        try
        {
          var grade = double.Parse(input);
          book.AddGrade(grade);
        }
        catch (ArgumentException ex)
        {
          Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
          Console.WriteLine(ex.Message);
        }
        finally
        {
          Console.WriteLine("**");
        }
      }

      var stats = book.GetStats();
      Console.WriteLine($"Hello {book.Name}!");
      Console.WriteLine($"This is your worst grade: {stats.Low:N1}");
      Console.WriteLine($"Here's your best: {stats.High:N1}");
      Console.WriteLine($"And your average grade is: {stats.Average:N2}");
      Console.WriteLine($"The average letter grade is: {stats.Letter:N2}");
    }
  }
}
