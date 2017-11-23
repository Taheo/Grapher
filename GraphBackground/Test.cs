using System;
using System.Text;
using System.Threading.Tasks;

namespace GraphBackground
{
  class Test
  {
    static void Main(string[] args)
    {
      int i = 0;
      int n = 10;
      
        var g = new Graph(n);
        while (true)
        {
          g.ShowIncidenceMatrix();
          StatisticsAndParams.Attemps++;
          var work = g.BreadthFirstSearch();
          Console.WriteLine($"deltaP = {StatisticsAndParams.DeltaP}");
          Console.WriteLine(work);
          Console.WriteLine();
          if (work)break;
          StatisticsAndParams.IncreaseDeltaP();
          g = new Graph(n);
        }
      g.Colorize();
      foreach (var v in g.Vertices)
      {
        Console.Write($"{v.Index}({v.Degree}){v.Color}: ");
        foreach (var vv in v.ConnectedVertices)
        {
          Console.Write($"{vv.Index} ");
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }
  }
}