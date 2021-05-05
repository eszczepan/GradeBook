using System;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var grades = new double[] { 4, 3, 5, 2, 2.5, 3.5, 5, 2, 2, 3.5, 4.5 };
      double worstGrade = 6;
      double bestGrade = 0;
      double sum = 0;
      System.Console.WriteLine();

      if (grades.Length > 0 && args.Length > 0)
      {
        for (int i = 0; i < grades.Length; i++)
        {
          var currGrade = grades[i];

          if (currGrade < worstGrade)
          {
            worstGrade = currGrade;
          }

          if (currGrade > bestGrade)
          {
            bestGrade = currGrade;
          }

          sum += currGrade;
        }
        Console.WriteLine($"Hello {args[0]}!");
        Console.WriteLine($"This is your worst grade: {worstGrade}");
        Console.WriteLine($"Here's your best: {bestGrade}");
        Console.WriteLine($"And your average grade: {sum / grades.Length}");
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
