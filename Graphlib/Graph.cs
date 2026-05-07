using System.Collections.Generic;

namespace Graphlib
{
    public class Graph
    {
        //Список смежности
        public Dictionary<string, List<string>> AdjacencyList = new Dictionary<string, List<string>>();

        public int EdgeCount = 0; 

        //Добавляет вершину в граф
        public void AddVertex(string v)
        {
            if (!AdjacencyList.ContainsKey(v))
                AdjacencyList[v] = new List<string>();
        }

        //Добавляет неориентированное ребро между вершинами u и v
        public void AddEdge(string u, string v)
        {
            AddVertex(u); 
            AddVertex(v);
            if (!AdjacencyList[u].Contains(v))
            {
                AdjacencyList[u].Add(v); 
                AdjacencyList[v].Add(u);  
                EdgeCount++;
            }
        }
        //Возвращает список всех вершин графа
        public List<string> GetVertices()
        {
            return new List<string>(AdjacencyList.Keys);
        }
        public int GetVertexCount()
        {
            return AdjacencyList.Count;
        }
    }
}