using System;
using System.Collections.Generic;

namespace Graphlib
{
    public static class GraphAlgorithms
    {
        //BFS
        public static List<string> BFS(Graph graph, string start)
        {
            List<string> result = new List<string>();

            if (!graph.ContainsVertex(start))
                return result;

            Queue<string> queue = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                result.Add(current);

                foreach (Edge edge in graph.AdjacencyList[current])
                {
                    if (!visited.Contains(edge.Target))
                    {
                        visited.Add(edge.Target);
                        queue.Enqueue(edge.Target);
                    }
                }
            }
            return result;
        }

        //DFS (Рекурсия)
        public static List<string> DFS(Graph graph, string start)
        {
            List<string> result = new List<string>();
            HashSet<string> visited = new HashSet<string>();

            if (!graph.ContainsVertex(start))
                return result;

            DFS_Recursive(graph, start, visited, result);
            return result;
        }

        private static void DFS_Recursive(Graph graph, string vertex, HashSet<string> visited, List<string> result)
        {
            visited.Add(vertex);
            result.Add(vertex);

            foreach (Edge edge in graph.AdjacencyList[vertex])
            {
                if (!visited.Contains(edge.Target))
                {
                    DFS_Recursive(graph, edge.Target, visited, result);
                }
            }
        }

        //Достижимость
        public static bool IsReachable(Graph graph, string start, string end)
        {
            List<string> path = BFS(graph, start);

            foreach (string s in path)
            {
                if (s == end) return true;
            }
            return false;
        }

        //Компоненты связности
        public static List<List<string>> FindConnectedComponents(Graph graph)
        {
            List<List<string>> components = new List<List<string>>();
            HashSet<string> visitedGlobal = new HashSet<string>();

            foreach (string vertex in graph.GetVertices())
            {
                if (!visitedGlobal.Contains(vertex))
                {
                    List<string> component = BFS(graph, vertex);

                    foreach (string v in component)
                    {
                        visitedGlobal.Add(v);
                    }

                    components.Add(component);
                }
            }
            return components;
        }

        //Дейкстра(Расстояния)
        public static Dictionary<string, int> Dijkstra(Graph graph, string start)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            HashSet<string> visited = new HashSet<string>();

            //Инициализация бесконечностью
            foreach (string v in graph.GetVertices())
            {
                distances[v] = int.MaxValue;
            }
            distances[start] = 0;

            for (int i = 0; i < graph.GetVertexCount(); i++)
            {
                //Поиск минимума
                string u = null;
                int minDist = int.MaxValue;

                foreach (string v in graph.GetVertices())
                {
                    if (!visited.Contains(v) && distances[v] < minDist)
                    {
                        minDist = distances[v];
                        u = v;
                    }
                }

                if (u == null) break;
                visited.Add(u);

                //Обновление соседей
                foreach (Edge edge in graph.AdjacencyList[u])
                {
                    if (!visited.Contains(edge.Target))
                    {
                        int newDist = distances[u] + edge.Weight;
                        if (newDist < distances[edge.Target])
                        {
                            distances[edge.Target] = newDist;
                        }
                    }
                }
            }
            return distances;
        }

        //Путь Дейкстры
        public static List<string> GetDijkstraPath(Graph graph, string start, string end)
        {
            Dictionary<string, int> distances = new Dictionary<string, int>();
            Dictionary<string, string> previous = new Dictionary<string, string>();
            HashSet<string> visited = new HashSet<string>();

            foreach (string v in graph.GetVertices())
            {
                distances[v] = int.MaxValue;
                previous[v] = null;
            }
            distances[start] = 0;

            for (int i = 0; i < graph.GetVertexCount(); i++)
            {
                string u = null;
                int minDist = int.MaxValue;

                foreach (string v in graph.GetVertices())
                {
                    if (!visited.Contains(v) && distances[v] < minDist)
                    {
                        minDist = distances[v];
                        u = v;
                    }
                }

                if (u == null) break;
                visited.Add(u);

                foreach (Edge edge in graph.AdjacencyList[u])
                {
                    if (!visited.Contains(edge.Target))
                    {
                        int newDist = distances[u] + edge.Weight;
                        if (newDist < distances[edge.Target])
                        {
                            distances[edge.Target] = newDist;
                            previous[edge.Target] = u;
                        }
                    }
                }
            }

            //Восстановление пути
            List<string> path = new List<string>();
            string current = end;

            if (previous[current] == null && current != start)
                return new List<string>();//Пути нет

            while (current != null)
            {
                path.Add(current);
                current = previous[current];
            }

            path.Reverse();
            return path;
        }

        //Точки сочленения
        public static List<string> FindArticulationPoints(Graph graph)
        {
            HashSet<string> points = new HashSet<string>();
            HashSet<string> visited = new HashSet<string>();
            Dictionary<string, int> disc = new Dictionary<string, int>();
            Dictionary<string, int> low = new Dictionary<string, int>();
            Dictionary<string, string> parent = new Dictionary<string, string>();

            int time = 0;

            foreach (string v in graph.GetVertices())
            {
                if (!visited.Contains(v))
                {
                    APUtil(v, visited, disc, low, parent, points, ref time, graph);
                }
            }

            return new List<string>(points);
        }

        private static void APUtil(string u, HashSet<string> visited, Dictionary<string, int> disc,
                                   Dictionary<string, int> low, Dictionary<string, string> parent,
                                   HashSet<string> ap, ref int time, Graph graph)
        {
            int children = 0;
            visited.Add(u);
            disc[u] = low[u] = ++time;

            foreach (Edge edge in graph.AdjacencyList[u])
            {
                string v = edge.Target;

                if (!visited.Contains(v))
                {
                    children++;
                    parent[v] = u; 
                    APUtil(v, visited, disc, low, parent, ap, ref time, graph);

                    low[u] = Math.Min(low[u], low[v]);

                    // Проверка условий точки сочленения
                    if (!parent.ContainsKey(u) && children > 1)
                        ap.Add(u);

                    if (parent.ContainsKey(u) && low[v] >= disc[u])
                        ap.Add(u);
                }
                else
                {              
                    if (parent.ContainsKey(u) && parent[u] == v)
                        continue;

                    low[u] = Math.Min(low[u], disc[v]);
                }
            }
        }

        //МОД (Прим)
        public static List<Edge> FindMST_Prim(Graph graph, string start)
        {
            List<Edge> mstEdges = new List<Edge>();
            HashSet<string> visited = new HashSet<string>();

            //Очередь с приоритетом (список кортежей)
            List<Tuple<int, string, string>> priorityQueue = new List<Tuple<int, string, string>>();

            if (!graph.ContainsVertex(start)) return mstEdges;

            visited.Add(start);

            foreach (Edge edge in graph.AdjacencyList[start])
            {
                priorityQueue.Add(new Tuple<int, string, string>(edge.Weight, start, edge.Target));
            }

            while (priorityQueue.Count > 0 && visited.Count < graph.GetVertexCount())
            {
                //Поиск минимума вручную
                Tuple<int, string, string> minEdge = priorityQueue[0];
                int minIndex = 0;

                for (int i = 1; i < priorityQueue.Count; i++)
                {
                    if (priorityQueue[i].Item1 < minEdge.Item1)
                    {
                        minEdge = priorityQueue[i];
                        minIndex = i;
                    }
                }

                priorityQueue.RemoveAt(minIndex);

                string from = minEdge.Item2;
                string to = minEdge.Item3;
                int weight = minEdge.Item1;

                if (visited.Contains(to)) continue;

                visited.Add(to);
                mstEdges.Add(new Edge(from, weight));

                foreach (Edge edge in graph.AdjacencyList[to])
                {
                    if (!visited.Contains(edge.Target))
                    {
                        priorityQueue.Add(new Tuple<int, string, string>(edge.Weight, to, edge.Target));
                    }
                }
            }

            return mstEdges;
        }
    }
}