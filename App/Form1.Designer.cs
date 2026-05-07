namespace App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoad = new Button();
            btnBFS = new Button();
            btnDFS = new Button();
            btnReach = new Button();
            btnComp = new Button();
            lblStart = new Label();
            txtStart = new TextBox();
            lblEnd = new Label();
            txtEnd = new TextBox();
            txtOutput = new TextBox();
            btnDijkstra = new Button();
            btnArticulation = new Button();
            btnMST = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.Khaki;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Location = new Point(196, 67);
            btnLoad.Margin = new Padding(4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(254, 33);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Загрузить граф";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnBFS
            // 
            btnBFS.BackColor = Color.Khaki;
            btnBFS.FlatStyle = FlatStyle.Flat;
            btnBFS.Location = new Point(1149, 26);
            btnBFS.Margin = new Padding(4);
            btnBFS.Name = "btnBFS";
            btnBFS.Size = new Size(118, 33);
            btnBFS.TabIndex = 1;
            btnBFS.Text = "BFS";
            btnBFS.UseVisualStyleBackColor = false;
            btnBFS.Click += btnBFS_Click;
            // 
            // btnDFS
            // 
            btnDFS.BackColor = Color.Khaki;
            btnDFS.FlatStyle = FlatStyle.Flat;
            btnDFS.Location = new Point(1149, 107);
            btnDFS.Margin = new Padding(4);
            btnDFS.Name = "btnDFS";
            btnDFS.Size = new Size(118, 33);
            btnDFS.TabIndex = 2;
            btnDFS.Text = "DFS";
            btnDFS.UseVisualStyleBackColor = false;
            btnDFS.Click += btnDFS_Click;
            // 
            // btnReach
            // 
            btnReach.BackColor = Color.Khaki;
            btnReach.FlatStyle = FlatStyle.Flat;
            btnReach.Location = new Point(849, 80);
            btnReach.Margin = new Padding(4);
            btnReach.Name = "btnReach";
            btnReach.Size = new Size(254, 33);
            btnReach.TabIndex = 3;
            btnReach.Text = "Проверить достижимость";
            btnReach.UseVisualStyleBackColor = false;
            btnReach.Click += btnReach_Click;
            // 
            // btnComp
            // 
            btnComp.BackColor = Color.Khaki;
            btnComp.FlatStyle = FlatStyle.Flat;
            btnComp.Location = new Point(849, 31);
            btnComp.Margin = new Padding(4);
            btnComp.Name = "btnComp";
            btnComp.Size = new Size(254, 33);
            btnComp.TabIndex = 4;
            btnComp.Text = "Компоненты связности";
            btnComp.UseVisualStyleBackColor = false;
            btnComp.Click += btnComp_Click;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblStart.Location = new Point(483, 41);
            lblStart.Margin = new Padding(4, 0, 4, 0);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(108, 23);
            lblStart.TabIndex = 5;
            lblStart.Text = "Вершина A:";
            // 
            // txtStart
            // 
            txtStart.BackColor = Color.Khaki;
            txtStart.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtStart.Location = new Point(643, 41);
            txtStart.Margin = new Padding(4);
            txtStart.Name = "txtStart";
            txtStart.Size = new Size(155, 30);
            txtStart.TabIndex = 6;
            txtStart.Text = "LeCun_1989";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblEnd.Location = new Point(484, 88);
            lblEnd.Margin = new Padding(4, 0, 4, 0);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(107, 23);
            lblEnd.TabIndex = 7;
            lblEnd.Text = "Вершина B:";
            // 
            // txtEnd
            // 
            txtEnd.BackColor = Color.Khaki;
            txtEnd.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtEnd.Location = new Point(644, 88);
            txtEnd.Margin = new Padding(4);
            txtEnd.Name = "txtEnd";
            txtEnd.Size = new Size(155, 30);
            txtEnd.TabIndex = 8;
            txtEnd.Text = "Llama_2023";
            // 
            // txtOutput
            // 
            txtOutput.BackColor = SystemColors.ActiveCaption;
            txtOutput.BorderStyle = BorderStyle.FixedSingle;
            txtOutput.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            txtOutput.Location = new Point(15, 230);
            txtOutput.Margin = new Padding(4);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Both;
            txtOutput.Size = new Size(1270, 438);
            txtOutput.TabIndex = 9;
            // 
            // btnDijkstra
            // 
            btnDijkstra.BackColor = Color.Khaki;
            btnDijkstra.FlatStyle = FlatStyle.Flat;
            btnDijkstra.Location = new Point(1149, 67);
            btnDijkstra.Margin = new Padding(4);
            btnDijkstra.Name = "btnDijkstra";
            btnDijkstra.Size = new Size(118, 33);
            btnDijkstra.TabIndex = 10;
            btnDijkstra.Text = "Дейкстра";
            btnDijkstra.UseVisualStyleBackColor = false;
            btnDijkstra.Click += btnDijkstra_Click;
            // 
            // btnArticulation
            // 
            btnArticulation.BackColor = Color.Khaki;
            btnArticulation.FlatStyle = FlatStyle.Flat;
            btnArticulation.Location = new Point(849, 133);
            btnArticulation.Margin = new Padding(4);
            btnArticulation.Name = "btnArticulation";
            btnArticulation.Size = new Size(254, 33);
            btnArticulation.TabIndex = 11;
            btnArticulation.Text = "Точки сочленения";
            btnArticulation.UseVisualStyleBackColor = false;
            btnArticulation.Click += btnArticulation_Click;
            // 
            // btnMST
            // 
            btnMST.BackColor = Color.Khaki;
            btnMST.FlatStyle = FlatStyle.Flat;
            btnMST.Location = new Point(1149, 148);
            btnMST.Margin = new Padding(4);
            btnMST.Name = "btnMST";
            btnMST.Size = new Size(118, 33);
            btnMST.TabIndex = 12;
            btnMST.Text = "МОД";
            btnMST.UseVisualStyleBackColor = false;
            btnMST.Click += btnMST_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Khaki;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Location = new Point(1, 4);
            btnExit.Margin = new Padding(4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(118, 33);
            btnExit.TabIndex = 13;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Aqua;
            ClientSize = new Size(1298, 700);
            Controls.Add(btnExit);
            Controls.Add(btnMST);
            Controls.Add(btnArticulation);
            Controls.Add(btnDijkstra);
            Controls.Add(txtOutput);
            Controls.Add(txtEnd);
            Controls.Add(lblEnd);
            Controls.Add(txtStart);
            Controls.Add(lblStart);
            Controls.Add(btnComp);
            Controls.Add(btnReach);
            Controls.Add(btnDFS);
            Controls.Add(btnBFS);
            Controls.Add(btnLoad);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Анализ графа";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoad;
        private Button btnBFS;
        private Button btnDFS;
        private Button btnReach;
        private Button btnComp;
        private Label lblStart;
        private TextBox txtStart;
        private Label lblEnd;
        private TextBox txtEnd;
        private TextBox txtOutput;
        private Button btnDijkstra;
        private Button btnArticulation;
        private Button btnMST;
        private Button btnExit;
    }
}
