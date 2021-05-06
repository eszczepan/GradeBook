using System;
using System.Collections.Generic;

namespace GradeBook
{
  public class Book
  {
    public Book(string name)
    {
      grades = new List<double>();
      Name = name;
    }
    public void AddGrade(double grade)
    {
      grades.Add(grade);
    }
    public Stats GetStats()
    {
      var result = new Stats();
      result.Average = 0.0;
      result.Low = double.MaxValue;
      result.High = double.MinValue;

      foreach (var grade in grades)
      {
        result.Low = Math.Min(grade, result.Low);
        result.High = Math.Max(grade, result.High);
        result.Average += grade;
      }

      result.Average /= grades.Count;

      return result;
    }
    private List<double> grades;
    public string Name;
  }
}