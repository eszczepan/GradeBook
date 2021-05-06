using System;
using System.Collections.Generic;

namespace GradeBook
{
  public delegate void GradeAddedDelegate(object sender, EventArgs args);

  public class Book
  {
    public Book(string name)
    {
      grades = new List<double>();
      Name = name;
    }

    public void AddGrade(char letter)
    {
      switch (letter)
      {
        case 'A':
          AddGrade(5.0);
          break;
        case 'B':
          AddGrade(4.0);
          break;
        case 'C':
          AddGrade(3.0);
          break;
        default:
          AddGrade(2.0);
          break;
      }

    }
    public void AddGrade(double grade)
    {
      if (grade >= 2.0 && grade <= 5.0)
      {
        grades.Add(grade);
        if (GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
    }

    public event GradeAddedDelegate GradeAdded;

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

      switch (result.Average)
      {
        case var d when d >= 5.0:
          result.Letter = 'A';
          break;
        case var d when d >= 4.0:
          result.Letter = 'B';
          break;
        case var d when d >= 3.0:
          result.Letter = 'C';
          break;
        default:
          result.Letter = 'F';
          break;
      }

      return result;
    }
    private List<double> grades;

    public string Name
    {
      get;
      set;
    }

    public const string CATEGORY = "Science";
  }
}