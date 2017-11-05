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
          var work = g.BreadthFirstSearch();
          Console.WriteLine($"deltaP = {Delta.deltaP}");
          Console.WriteLine(work);
          Console.WriteLine();
          if (work)break;
          Delta.deltaP += 0.05;
          g = new Graph(10);
        }
        i++;
      }
      Console.WriteLine();
    }
  }
}