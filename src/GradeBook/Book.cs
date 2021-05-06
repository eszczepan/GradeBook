using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Book
  {
    public Book(string name)
    {
      grades = new List<double>();
      this.name = name;
    }
    public void AddGrade(double grade)
    {
      grades.Add(grade);
    }
    public void ShowStats()
    {
      var worstGrade = double.MaxValue;
      var bestGrade = double.MinValue;
      var sum = 0.0;
      foreach (var grade in grades)
      {
        worstGrade = Math.Min(grade, worstGrade);
        bestGrade = Math.Max(grade, bestGrade);
        sum += grade;
      }
      Console.WriteLine($"Hello {this.name}!");
      Console.WriteLine($"This is your worst grade: {worstGrade:N1}");
      Console.WriteLine($"Here's your best: {bestGrade:N1}");
      Console.WriteLine($"And your average grade is: {(sum / grades.Count):N2}");
    }
    private List<double> grades;
    private string name;
  }
}