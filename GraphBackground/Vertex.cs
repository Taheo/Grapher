using System.Collections.Generic;

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
}