using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
  public delegate void GradeAddedDelegate(object sender, EventArgs args);

  public class NamedObject
  {
    public NamedObject(string name)
    {
      Name = name;
    }
    public string Name
    {
      get;
      set;
    }
  }

  public interface IBook
  {
    void AddGrade(double grade);
    Stats GetStats();
    string Name { get; }
    event GradeAddedDelegate GradeAdded;
  }

  public abstract class Book : NamedObject, IBook
  {
    protected Book(string name) : base(name)
    {
    }

    public abstract event GradeAddedDelegate GradeAdded;
    public abstract void AddGrade(double grade);
    public abstract Stats GetStats();
  }

  public class DiskBook : Book
  {
    public DiskBook(string name) : base(name)
    {
    }

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(double grade)
    {
      using (var writer = File.AppendText($"{Name}.txt"))
      {
        writer.WriteLine(grade);
        if (GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
    }

    public override Stats GetStats()
    {
      throw new NotImplementedException();
    }
  }

  public class InMemoryBook : Book
  {
    public InMemoryBook(string name) : base(name)
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
    public override void AddGrade(double grade)
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

    public override event GradeAddedDelegate GradeAdded;

    public override Stats GetStats()
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

    public const string CATEGORY = "Science";
  }
}