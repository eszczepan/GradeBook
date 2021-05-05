using System;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var x = 34.2;
      var y = 65.5;

      var result = x + y;

      if (args.Length > 0 && x > 30)
      {
        Console.WriteLine($"Hello {args[0]}!");
        Console.WriteLine(result);
      }
      else
      {
        Console.WriteLine("Something went wrong :(");
      }
    }
  }
}
