using System;
using System.Collections.Generic;

namespace GradeBook
{
  public class Stats
  {
    public double Average
    {
      get
      {
        return Sum / Count;
      }
    }
    public char Letter
    {
      get
      {

        switch (Average)
        {
          case var d when d >= 5.0:
            return 'A';
          case var d when d >= 4.0:
            return 'B';
          case var d when d >= 3.0:
            return 'C';
          default:
            return 'F';
        }
      }
    }
    public double Low;
    public double High;
    public double Sum;
    public int Count;

    public void Add(double number)
    {
      Sum += number;
      Count += 1;
      Low = Math.Min(number, Low);
      High = Math.Max(number, High);
    }

    public Stats()
    {
      Low = double.MaxValue;
      High = double.MinValue;
      Sum = 0.0;
      Count = 0;
    }
  }
}