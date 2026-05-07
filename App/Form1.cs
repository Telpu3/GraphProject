using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Graphlib;

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
                                 $"Вершин: {graph.GetVertexCount()}\n" +
                                 $"Рёбер: {edgesCount}";
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

            try
            {
                List<string> result = GraphAlgorithms.BFS(graph, start);

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

                txtOutput.Text = $"Обход в ширину (BFS) от '{start}':\n\n{pathString}";
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

            try
            {
                List<string> result = GraphAlgorithms.DFS(graph, start);

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

                txtOutput.Text = $"Обход в глубину (DFS) от '{start}':\n\n{pathString}";
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
            string end = txtEnd.Text.Trim();

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

            List<List<string>> components = GraphAlgorithms.FindConnectedComponents(graph);

            string outputText = "Компоненты связности:\n\n";

            for (int i = 0; i < components.Count; i++)
            {
                outputText += $"Компонента №{i + 1} ({components[i].Count} вершин):\n";
                outputText += "[" + string.Join(", ", components[i]) + "]\n\n";
            }

            txtOutput.Text = outputText;
        }

        //Точки сочленения 
        private void btnArticulation_Click(object sender, EventArgs e)
        {
            if (graph.GetVertexCount() == 0)
            {
                txtOutput.Text = "Сначала загрузите граф!";
                return;
            }

            List<string> points = GraphAlgorithms.FindArticulationPoints(graph);

            if (points.Count == 0)
            {
                txtOutput.Text = "В данном графе нет точек сочленения.\nГраф является двусвязным.";
            }
            else
            {
                string txt = $"Точки сочленения ({points.Count} шт.):\n\n";
                foreach (var p in points)
                {
                    txt += $"  - {p}\n";
                }
                txtOutput.Text = txt;
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
            string end = txtEnd.Text.Trim();

            try
            {
                var distances = GraphAlgorithms.Dijkstra(graph, start);
                var path = GraphAlgorithms.GetDijkstraPath(graph, start, end);

                string txt = $"Кратчайшие расстояния от вершины [{start}]:\n\n";
                foreach (var d in distances)
                {
                    string status = d.Value == int.MaxValue ? "Недостижимо" : d.Value.ToString();
                    txt += $"{d.Key}: {status}\n";
                }

                txt += "\n--------------------------------------------------\n";

                if (path.Count > 0 && distances.ContainsKey(end) && distances[end] != int.MaxValue)
                {
                    txt += $"\nМаршрут до [{end}]:\n";
                    txt += $"{string.Join(" -> ", path)}\n";
                    txt += $"\nСтоимость пути: {distances[end]}";
                }
                else
                {
                    txt += $"\nПути до [{end}] не существует.";
                }

                txtOutput.Text = txt;
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

            List<Edge> mst = GraphAlgorithms.FindMST_Prim(graph, start);

            int totalWeight = 0;
            string txt = $"Минимальное остовное дерево (старт: {start}):\n\n";

            foreach (var edge in mst)
            {
                txt += $"Ребро в вершину {edge.Target}, вес: {edge.Weight}\n";
                totalWeight += edge.Weight;
            }

            txt += $"\nОбщий вес МОД: {totalWeight}";
            txtOutput.Text = txt;
        }
        //Выход
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}