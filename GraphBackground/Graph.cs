using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphBackground
{
  public class Graph
  {
    public int[,] IncidenceMatrix { get; set; }

    //public double deltaP = 0.05;

    public List<Vertex> Vertices;

    public int VerticesCount;
    private static readonly Random Rng = new Random();

    public Graph(int[,] incidenceMatrix)
    {
      IncidenceMatrix = incidenceMatrix;
      VerticesCount = incidenceMatrix.GetLength(0);
      Vertices = new List<Vertex>();
      GenerateGraph();
    }
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
          if (Rng.NextDouble() < StatisticsAndParams.DeltaP)
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

    public bool BreadthFirstSearch(int startVertex = 0, int[,] treeIncidenceMatrix = null)
    {
      var verticesQueue = new Queue<Vertex>();
      if (treeIncidenceMatrix == null) treeIncidenceMatrix = new int[VerticesCount,VerticesCount];
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
          treeIncidenceMatrix[current.Index, current.ConnectedVertices.ElementAt(i).Index] = 1;
          treeIncidenceMatrix[current.ConnectedVertices.ElementAt(i).Index, current.Index] = 1;
        }
      }

      return Vertices.Count(x => x.Visited == false) == 0;
    }

    public void Colorize()
    {
     var sorted =  Vertices.OrderBy(x => x.ConnectedVertices.Count).ToList();
      int color = 1;
      while (sorted.Count >0)
      {
        foreach (var vertex in sorted)
        {
          vertex.Color = color;
        }
        color++;
        foreach (var vertex in sorted)
        {
          foreach (var v in vertex.ConnectedVertices)
          {
            if (v.Color == vertex.Color) v.Color = color;
          }
        }
        sorted.RemoveAt(0);
      }
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
}