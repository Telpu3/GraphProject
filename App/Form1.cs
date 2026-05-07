using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using Graphlib; // Обязательно подключить библиотеку

namespace App
{
    public partial class Form1 : Form
    {
        //Глобальный объект графа
        private Graph graph = new Graph();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы графа|*.txt;*.csv";
            ofd.Title = "Выберите файл с описанием графа";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                //Очищаем старый граф
                graph = new Graph();

                string[] lines = File.ReadAllLines(ofd.FileName);
                int edgesCount = 0;

                foreach (string line in lines)
                {
                    string cleanLine = line.Trim();
                    //Пропускаем пустые строки и комментарии
                    if (string.IsNullOrEmpty(cleanLine) || cleanLine.StartsWith("#")) continue;

                    //Разделяем по запятой, точке с запятой, дефису или пробелу
                    string[] parts = cleanLine.Split(new char[] { ',', ';', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 2)
                    {
                        string u = parts[0].Trim();
                        string v = parts[1].Trim();

                        graph.AddEdge(u, v);
                        edgesCount++;
                    }
                }

                txtOutput.Text = $"Граф успешно загружен!\n" +
                                 $"Вершин: {graph.GetVertexCount()}\n" +
                                 $"Рёбер: {edgesCount}";
            }
            catch (Exception ex)
            {
                txtOutput.Text = $" Ошибка чтения файла:\n{ex.Message}";
            }
        }

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

                txtOutput.Text = $" BFS от вершины '{start}':\n\n" +
                                 string.Join(" → ", result);
            }
            catch (Exception)
            {
                txtOutput.Text = $"Вершина '{start}' не найдена в графе.";
            }
        }

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
                // Вызов алгоритма из библиотеки
                List<string> result = GraphAlgorithms.DFS(graph, start);

                txtOutput.Text = $"DFS от вершины '{start}':\n\n" +
                                 string.Join(" → ", result);
            }
            catch (Exception)
            {
                txtOutput.Text = $"Вершина '{start}' не найдена в графе.";
            }
        }

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

            txtOutput.Text = $"Достижима ли '{end}' из '{start}'?\n\n" +
                             $"Ответ: {(isReachable ? "ДА" : "НЕТ")}";
        }

        private void btnComp_Click(object sender, EventArgs e)
        {
            if (graph.GetVertexCount() == 0)
            {
                txtOutput.Text = "️Сначала загрузите граф!";
                return;
            }

            // Вызов алгоритма из библиотеки
            List<List<string>> components = GraphAlgorithms.FindConnectedComponents(graph);

            string outputText = "Компоненты связности:\n\n";

            for (int i = 0; i < components.Count; i++)
            {
                outputText += $"Компонента {i + 1}: [{string.Join(", ", components[i])}]\n";
            }

            txtOutput.Text = outputText;
        }
    }
}