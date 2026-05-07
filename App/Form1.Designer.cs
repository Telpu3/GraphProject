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
            btnLoad.Location = new Point(823, 33);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(203, 29);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Загрузить граф";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnBFS
            // 
            btnBFS.Location = new Point(869, 213);
            btnBFS.Name = "btnBFS";
            btnBFS.Size = new Size(94, 29);
            btnBFS.TabIndex = 1;
            btnBFS.Text = "BFS";
            btnBFS.UseVisualStyleBackColor = true;
            btnBFS.Click += btnBFS_Click;
            // 
            // btnDFS
            // 
            btnDFS.Location = new Point(869, 290);
            btnDFS.Name = "btnDFS";
            btnDFS.Size = new Size(94, 29);
            btnDFS.TabIndex = 2;
            btnDFS.Text = "DFS";
            btnDFS.UseVisualStyleBackColor = true;
            btnDFS.Click += btnDFS_Click;
            // 
            // btnReach
            // 
            btnReach.Location = new Point(823, 122);
            btnReach.Name = "btnReach";
            btnReach.Size = new Size(203, 29);
            btnReach.TabIndex = 3;
            btnReach.Text = "Проверить достижимость";
            btnReach.UseVisualStyleBackColor = true;
            btnReach.Click += btnReach_Click;
            // 
            // btnComp
            // 
            btnComp.Location = new Point(823, 79);
            btnComp.Name = "btnComp";
            btnComp.Size = new Size(203, 29);
            btnComp.TabIndex = 4;
            btnComp.Text = "Компоненты связности";
            btnComp.UseVisualStyleBackColor = true;
            btnComp.Click += btnComp_Click;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new Point(12, 57);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(90, 20);
            lblStart.TabIndex = 5;
            lblStart.Text = "Вершина A:";
            // 
            // txtStart
            // 
            txtStart.Location = new Point(140, 57);
            txtStart.Name = "txtStart";
            txtStart.Size = new Size(125, 27);
            txtStart.TabIndex = 6;
            txtStart.Text = "LeCun_1989";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new Point(13, 98);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(89, 20);
            lblEnd.TabIndex = 7;
            lblEnd.Text = "Вершина B:";
            // 
            // txtEnd
            // 
            txtEnd.Location = new Point(141, 98);
            txtEnd.Name = "txtEnd";
            txtEnd.Size = new Size(125, 27);
            txtEnd.TabIndex = 8;
            txtEnd.Text = "Llama_2023";
            // 
            // txtOutput
            // 
            txtOutput.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtOutput.Location = new Point(12, 181);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Both;
            txtOutput.Size = new Size(722, 401);
            txtOutput.TabIndex = 9;
            // 
            // btnDijkstra
            // 
            btnDijkstra.Location = new Point(869, 255);
            btnDijkstra.Name = "btnDijkstra";
            btnDijkstra.Size = new Size(94, 29);
            btnDijkstra.TabIndex = 10;
            btnDijkstra.Text = "Дейкстра";
            btnDijkstra.UseVisualStyleBackColor = true;
            btnDijkstra.Click += btnDijkstra_Click;
            // 
            // btnArticulation
            // 
            btnArticulation.Location = new Point(823, 168);
            btnArticulation.Name = "btnArticulation";
            btnArticulation.Size = new Size(203, 29);
            btnArticulation.TabIndex = 11;
            btnArticulation.Text = "Точки сочленения";
            btnArticulation.UseVisualStyleBackColor = true;
            btnArticulation.Click += btnArticulation_Click;
            // 
            // btnMST
            // 
            btnMST.Location = new Point(869, 337);
            btnMST.Name = "btnMST";
            btnMST.Size = new Size(94, 29);
            btnMST.TabIndex = 12;
            btnMST.Text = "МОД";
            btnMST.UseVisualStyleBackColor = true;
            btnMST.Click += btnMST_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(932, 568);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 13;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 609);
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
            Name = "Form1";
            Text = "Form1";
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
