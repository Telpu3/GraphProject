using System.Collections.Generic;

namespace Graphlib
{
    public class Edge
    {
        public string Target;
        public int Weight;

        public Edge(string target, int weight)
        {
            this.Target = target;
            this.Weight = weight;
        }
    }

    public class Graph
    {
        //Словарь смежности: Вершина -> Список ребер
        public Dictionary<string, List<Edge>> AdjacencyList = new Dictionary<string, List<Edge>>();
        public int EdgeCount = 0;

        public void AddVertex(string v)
        {
            if (!AdjacencyList.ContainsKey(v))
            {
                AdjacencyList[v] = new List<Edge>();
            }
        }

        public void AddEdge(string u, string v, int weight = 1)
        {
            AddVertex(u);
            AddVertex(v);

            //Проверка на дубликаты
            bool exists = false;
            foreach (var e in AdjacencyList[u])
            {
                if (e.Target == v)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                AdjacencyList[u].Add(new Edge(v, weight));
                AdjacencyList[v].Add(new Edge(u, weight));//Неориентированный граф
                EdgeCount++;
            }
        }

        public List<string> GetVertices()
        {
            return new List<string>(AdjacencyList.Keys);
        }

        public bool ContainsVertex(string v)
        {
            return AdjacencyList.ContainsKey(v);
        }

        public int GetVertexCount()
        {
            return AdjacencyList.Count;
        }
    }
}