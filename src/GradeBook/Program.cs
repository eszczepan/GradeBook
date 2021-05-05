using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var grades = new List<double>() { 4.0, 3.0, 5.0, 2.0, 4.5, 3.5, 5.0, 2.0, 2.0, 3.5, 4.5 };
      double worstGrade = 6;
      double bestGrade = 0;
      double sum = 0.0;

      if (grades.Count > 0 && args.Length > 0)
      {
        foreach (var grade in grades)
        {
          if (grade < worstGrade)
          {
            worstGrade = grade;
          }

          if (grade > bestGrade)
          {
            bestGrade = grade;
          }

          sum += grade;
        }
        Console.WriteLine($"Hello {args[0]}!");
        Console.WriteLine($"This is your worst grade: {worstGrade}");
        Console.WriteLine($"Here's your best: {bestGrade}");
        Console.WriteLine($"And your average grade is: {(sum / grades.Count):N2}");
      }
      else if (args.Length == 0)
      {
        Console.WriteLine("Type your name in.");
      }
      else
      {
        Console.WriteLine("You have 0 grades yet.");
      }
    }
  }
}
