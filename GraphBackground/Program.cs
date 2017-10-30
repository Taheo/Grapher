using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphBackground
{
  public class Vertex
  {
    public int Index;
    public int Color;
    public bool Visited = false;
    public List<Vertex> ConnectedVertices;

    public Vertex()
    {
      ConnectedVertices = new List<Vertex>();
    }
  }

  public static class Delta
  {
    public static double deltaP = 0.05;
  }

  public class Graph
  {
    public int[,] IncidenceMatrix { get; set; }

    //public double deltaP = 0.05;

    public List<Vertex> Vertices;

    public int VerticesCount;
    private static readonly Random Rng = new Random();

    public Graph(int verticesCount)
    {
      VerticesCount = verticesCount;
      IncidenceMatrix = new int[verticesCount, verticesCount];
      Vertices = new List<Vertex>();
      GenerateGraph();
    }

    public void GenerateIncidenceMatrix()
    {
      for (var i = 0; i < VerticesCount; i++)
      {
        for (var j = i; j < VerticesCount; j++)
        {
          if (i == j) continue;
          if (Rng.NextDouble() < Delta.deltaP)
          {
            IncidenceMatrix[i, j] = 1;
            IncidenceMatrix[j, i] = 1;
          }
        }
      }
    }

    public void GenerateGraph()
    {
      GenerateIncidenceMatrix();
      for (int i = 0; i < VerticesCount; i++)
      {
        Vertices.Add(new Vertex() {Index = i});
      }
      for (var i = 0; i < VerticesCount; i++)
      {
        for (var j = 0; j < VerticesCount; j++)
        {
          if (i == j) continue;
          if (IncidenceMatrix[i, j] == 1)
          {
            Vertices.ElementAt(i).ConnectedVertices.Add(Vertices.ElementAt(j));
          }
        }
      }
    }

    public bool BreadthFirstSearch(int startVertex = 0)
    {
      var verticesQueue = new Queue<Vertex>();

      verticesQueue.Enqueue(Vertices.ElementAt(startVertex));
      Vertices.ElementAt(startVertex).Visited = true;
      while (verticesQueue.Count !=0)
      {
        var current = verticesQueue.Dequeue();
        for (int i = 0; i < current.ConnectedVertices.Count; i++)
        {
          if (current.ConnectedVertices.ElementAt(i).Visited) continue;
          verticesQueue.Enqueue(current.ConnectedVertices.ElementAt(i));
          current.ConnectedVertices.ElementAt(i).Visited = true;
        }
      }

      return Vertices.Count(x => x.Visited == false) == 0;
    }

    public void ShowIncidenceMatrix()
    {
      for (int i = 0; i < IncidenceMatrix.GetLength(0); i++)
      {
        for (int j = 0; j < IncidenceMatrix.GetLength(1); j++)
        {
          Console.Write($"{IncidenceMatrix[i, j]} ");
        }
        Console.WriteLine();
      }
    }
  }

  class Program
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