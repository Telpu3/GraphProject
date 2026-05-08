using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Graphlib;
using System.Diagnostics; 

namespace App
{
    public partial class Form1 : Form
    {
        private Graph graph = new Graph();

        public Form1()
        {
            InitializeComponent();
        }

        //Загрузка графа
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы графа|*.txt;*.csv";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                graph = new Graph();
                string[] lines = File.ReadAllLines(ofd.FileName);
                int edgesCount = 0;

                foreach (string line in lines)
                {
                    string cleanLine = line.Trim();
                    if (string.IsNullOrEmpty(cleanLine) || cleanLine.StartsWith("#")) continue;

                    string[] parts = cleanLine.Split(new char[] { ',', ';', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 2)
                    {
                        string u = parts[0].Trim();
                        string v = parts[1].Trim();
                        int weight = 1;
                        if (parts.Length >= 3) int.TryParse(parts[2].Trim(), out weight);

                        graph.AddEdge(u, v, weight);
                        edgesCount++;
                    }
                }

                txtOutput.Text = "Граф успешно загружен.\n" +
                                 $" Вершин:{graph.GetVertexCount()}\n" +
                                 $"  Рёбер:{edgesCount}";
            }
            catch (Exception ex)
            {
                txtOutput.Text = $"Ошибка чтения файла:\n{ex.Message}";
            }
        }

        //BFS
        private void btnBFS_Click(object sender, EventArgs e)
        {
            if (graph.GetVertexCount() == 0)
            {
                txtOutput.Text = "Сначала загрузите граф!";
                return;
            }

            string start = txtStart.Text.Trim();
            if (!graph.ContainsVertex(start))
            {
                txtOutput.Text = $"Вершина '{start}' не найдена в графе!";
                return;
            }
            try
            {
                Stopwatch sw = Stopwatch.StartNew(); 
                List<string> result = GraphAlgorithms.BFS(graph, start);
                sw.Stop(); 

                // Формируем строку с переносами каждые 6 элементов
                string pathString = "";
                for (int i = 0; i < result.Count; i++)
                {
                    pathString += result[i];
                    if (i < result.Count - 1) pathString += " -> ";

                    // Перенос строки каждые 6 вершин
                    if ((i + 1) % 6 == 0 && i < result.Count - 1)
                    {
                        pathString += "\n";
                    }
                }

                txtOutput.Text = $"Обход в ширину (BFS) от '{start}':\n\n{pathString}\n\n" +
                                 $"   (Время выполнения: {sw.ElapsedMilliseconds} мс)";
            }
            catch (Exception)
            {
                txtOutput.Text = $"Вершина '{start}' не найдена.";
            }
        }

        //DFS
        private void btnDFS_Click(object sender, EventArgs e)
        {
            if (graph.GetVertexCount() == 0)
            {
                txtOutput.Text = "Сначала загрузите граф!";
                return;
            }

            string start = txtStart.Text.Trim();
            if (!graph.ContainsVertex(start))
            {
                txtOutput.Text = $" Вершина '{start}' не найдена в графе!";
                return;
            }
            try
            {
                Stopwatch sw = Stopwatch.StartNew(); 
                List<string> result = GraphAlgorithms.DFS(graph, start);
                sw.Stop(); 

                string pathString = "";
                for (int i = 0; i < result.Count; i++)
                {
                    pathString += result[i];
                    if (i < result.Count - 1) pathString += " -> ";

                    if ((i + 1) % 6 == 0 && i < result.Count - 1)
                    {
                        pathString += "\n";
                    }
                }

                txtOutput.Text = $"Обход в глубину (DFS) от '{start}':\n\n{pathString}\n\n" +
                                 $"   (Время выполнения: {sw.ElapsedMilliseconds} мс)";
            }
            catch (Exception)
            {
                txtOutput.Text = $"Вершина '{start}' не найдена.";
            }
        }

        //Достижимость
        private void btnReach_Click(object sender, EventArgs e)
        {
            if (graph.GetVertexCount() == 0)
            {
                txtOutput.Text = "Сначала загрузите граф!";
                return;
            }

            string start = txtStart.Text.Trim();
            if (!graph.ContainsVertex(start))
            {
                txtOutput.Text = $" Вершина '{start}' не найдена в графе!";
                return;
            }
            string end = txtEnd.Text.Trim();
            if (!graph.ContainsVertex(end))
            {
                txtOutput.Text = $" Вершина '{end}' не найдена в графе!";
                return;
            }

            bool isReachable = GraphAlgorithms.IsReachable(graph, start, end);

            txtOutput.Text = $"Проверка достижимости:\n" +
                             $"Из '{start}' в '{end}'.\n\n" +
                             $"Ответ: {(isReachable ? "ДА" : "НЕТ")}";
        }

        //Компоненты связности
        private void btnComp_Click(object sender, EventArgs e)
        {
            if (graph.GetVertexCount() == 0)
            {
                txtOutput.Text = "Сначала загрузите граф!";
                return;
            }

            Stopwatch sw = Stopwatch.StartNew(); 
            List<List<string>> components = GraphAlgorithms.FindConnectedComponents(graph);
            sw.Stop(); 

            string outputText = "Компоненты связности:\n\n";

            for (int i = 0; i < components.Count; i++)
            {
                outputText += $"---Компонента №{i + 1} ({components[i].Count} вершин): \n";
                outputText += "[" + string.Join(", ", components[i]) + "]\n\n";
            }

            txtOutput.Text = outputText + $"   (Время выполнения: {sw.ElapsedMilliseconds} мс)";
            ;
        }

        //Точки сочленения 
        private void btnArticulation_Click(object sender, EventArgs e)
        {
            if (graph.GetVertexCount() == 0)
            {
                txtOutput.Text = "Сначала загрузите граф!";
                return;
            }

            Stopwatch sw = Stopwatch.StartNew(); 
            List<string> points = GraphAlgorithms.FindArticulationPoints(graph);
            sw.Stop(); 

            if (points.Count == 0)
            {
                txtOutput.Text = "В данном графе нет точек сочленения.\nГраф является двусвязным.\n\n" +
                                 $"   (Время выполнения: {sw.ElapsedMilliseconds} мс)";
            }
            else
            {
                string txt = $"Точки сочленения ({points.Count} шт.):\n\n";
                foreach (var p in points)
                {
                    txt += $"  - {p}\n";
                }
                txtOutput.Text = txt + $"   (Время выполнения: {sw.ElapsedMilliseconds} мс)";
              
            }
        }
        //Дейкстра
        private void btnDijkstra_Click(object sender, EventArgs e)
        {
            if (graph.GetVertexCount() == 0)
            {
                txtOutput.Text = "Сначала загрузите граф!";
                return;
            }

            string start = txtStart.Text.Trim();
            if (!graph.ContainsVertex(start))
            {
                txtOutput.Text = $" Вершина '{start}' не найдена в графе!";
                return;
            }
            string end = txtEnd.Text.Trim();
            if (!graph.ContainsVertex(end))
            {
                txtOutput.Text = $" Вершина '{end}' не найдена в графе!";
                return;
            }
            try
            {
                Stopwatch sw = Stopwatch.StartNew(); 
                var distances = GraphAlgorithms.Dijkstra(graph, start);
                var path = GraphAlgorithms.GetDijkstraPath(graph, start, end);
                sw.Stop(); 

                string txt = $"Кратчайшие расстояния от вершины [{start}]:\n\n";
                foreach (var d in distances)
                {
                    string status = d.Value == int.MaxValue ? "Недостижимо  " : d.Value.ToString();
                    txt += $"|{d.Key}:{status} \n";
                }

                txt += "\n---------------------------------------------------------------------------------------------------------------\n";

                if (path.Count > 0 && distances.ContainsKey(end) && distances[end] != int.MaxValue)
                {
                    txt += "\n";
                    txt += $"\nМаршрут до [{end}]:\n";
                    txt += $"{string.Join(" -> ", path)}\n";
                    txt += $"\nСтоимость пути: {distances[end]}";
                }
                else
                {
                    txt += $"\nПути до [{end}] не существует.";
                }

                txtOutput.Text = txt + $"\n\n   (Время выполнения: {sw.ElapsedMilliseconds} мс)";
            }
            catch (Exception ex)
            {
                txtOutput.Text = $"Ошибка: {ex.Message}";
            }
        }
        //МОД
        private void btnMST_Click(object sender, EventArgs e)
        {
            if (graph.GetVertexCount() == 0)
            {
                txtOutput.Text = "Сначала загрузите граф!";
                return;
            }

            string start = txtStart.Text.Trim();
            if (!graph.ContainsVertex(start))
            {
                start = graph.GetVertices()[0];
            }

            Stopwatch sw = Stopwatch.StartNew(); 
            List<Edge> mst = GraphAlgorithms.FindMST_Prim(graph, start);
            sw.Stop(); 

            int totalWeight = 0;
            string txt = $"Минимальное остовное дерево (старт: {start}):\n\n";

            foreach (var edge in mst)
            {
                txt += $"| Ребро в вершину {edge.Target}, вес:{edge.Weight}\n";
                totalWeight += edge.Weight;
            }

            txt += $"\n   (Общий вес МОД:{totalWeight})";
            txtOutput.Text = txt + $"\n\n    (Время выполнения: {sw.ElapsedMilliseconds} мс)";
        }
        //Выход
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}