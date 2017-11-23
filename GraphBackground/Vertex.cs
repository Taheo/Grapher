using System.Collections.Generic;

namespace GraphBackground
{
  public class Vertex
  {
    public int Index;
    public int Color = -1;
    public bool Visited = false;
    public int Degree => ConnectedVertices.Count;

    public List<Vertex> ConnectedVertices;

    public Vertex()
    {
      ConnectedVertices = new List<Vertex>();
    }
  }
}