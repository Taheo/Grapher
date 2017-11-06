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
      while (i<10)
      {
        
        var g = new Graph(10);
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
          g = new Graph(10);
        }
        i++;
      }
      Console.WriteLine();
    }
  }
}