using System.Collections.Generic;

namespace Graphlib
{
    public static class GraphAlgorithms
    {
        public static List<string> BFS(Graph graph, string start)
        {
            List<string> result = new List<string>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return result;

            //Очередь: хранит вершины, которые нужно обработать
            Queue<string> queue = new Queue<string>();

            //Множество: хранит уже посещенные вершины, чтобы не ходить по кругу
            HashSet<string> visited = new HashSet<string>();

            //Начинаем со стартовой вершины
            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                //Берем первую вершину из очереди
                string current = queue.Dequeue();
                result.Add(current); 

                //Смотрим всех соседей текущей вершины
                foreach (string neighbor in graph.AdjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor); 
                        queue.Enqueue(neighbor); //Добавляем в конец очереди
                    }
                }
            }
            return result;
        }
        //DFS через рекурсию 
        public static List<string> DFS(Graph graph, string start)
        {
            List<string> result = new List<string>();
            HashSet<string> visited = new HashSet<string>();
            DFS_Recursive(graph, start, visited, result);

            return result;
        }
        private static void DFS_Recursive(Graph graph, string vertex, HashSet<string> visited, List<string> result)
        {
            visited.Add(vertex);      
            result.Add(vertex);       

            //Идем по всем соседям
            foreach (string neighbor in graph.AdjacencyList[vertex])
            {
                //Если сосед еще не был посещен, идем в него
                if (!visited.Contains(neighbor))
                {
                    DFS_Recursive(graph, neighbor, visited, result);
                }
            }
        }

        //Проверка достижимости вершины end из start
        public static bool IsReachable(Graph graph, string start, string end)
        {
            List<string> reachableVertices = BFS(graph, start);
            return reachableVertices.Contains(end);
        }

        public static List<List<string>> FindConnectedComponents(Graph graph)
        {
            List<List<string>> components = new List<List<string>>();
            HashSet<string> visitedGlobal = new HashSet<string>(); // Чтобы запоминать, кого уже обработали

            foreach (string vertex in graph.GetVertices())
            {
                // Если вершина еще не входила ни в одну компоненту
                if (!visitedGlobal.Contains(vertex))
                {
                    // Запускаем BFS от этой вершины. 
                    List<string> component = BFS(graph, vertex);

                    foreach (string v in component)
                    {
                        visitedGlobal.Add(v);
                    }
                    // Сохраняем эту группу как отдельную компоненту
                    components.Add(component);
                }
            }
            return components;
        }
    }
}