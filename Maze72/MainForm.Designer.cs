namespace Maze72
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MazeButton = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ClearButton = new System.Windows.Forms.Button();
            this.RealTimeButton = new System.Windows.Forms.Button();
            this.dfs = new System.Windows.Forms.RadioButton();
            this.bfs = new System.Windows.Forms.RadioButton();
            this.square = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.robotLbl = new System.Windows.Forms.Label();
            this.targetLbl = new System.Windows.Forms.Label();
            this.frontierLbl = new System.Windows.Forms.Label();
            this.closedLbl = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MazeButton
            // 
            this.MazeButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.MazeButton.Location = new System.Drawing.Point(607, 185);
            this.MazeButton.Margin = new System.Windows.Forms.Padding(4);
            this.MazeButton.Name = "MazeButton";
            this.MazeButton.Size = new System.Drawing.Size(196, 34);
            this.MazeButton.TabIndex = 6;
            this.MazeButton.Text = "Maze";
            this.ToolTip.SetToolTip(this.MazeButton, "Creates a random maze");
            this.MazeButton.UseVisualStyleBackColor = true;
            this.MazeButton.Click += new System.EventHandler(this.MazeButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.ClearButton.Location = new System.Drawing.Point(607, 222);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(196, 34);
            this.ClearButton.TabIndex = 7;
            this.ClearButton.Text = "Clear";
            this.ToolTip.SetToolTip(this.ClearButton, "First click: clears search, Second click: clears obstacles");
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // RealTimeButton
            // 
            this.RealTimeButton.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.RealTimeButton.Location = new System.Drawing.Point(607, 258);
            this.RealTimeButton.Margin = new System.Windows.Forms.Padding(4);
            this.RealTimeButton.Name = "RealTimeButton";
            this.RealTimeButton.Size = new System.Drawing.Size(196, 34);
            this.RealTimeButton.TabIndex = 8;
            this.RealTimeButton.Text = "Real-Time";
            this.ToolTip.SetToolTip(this.RealTimeButton, "Position of obstacles, robot and target can be changed when search is underway");
            this.RealTimeButton.UseVisualStyleBackColor = true;
            this.RealTimeButton.Click += new System.EventHandler(this.RealTimeButton_Click);
            // 
            // dfs
            // 
            this.dfs.AutoSize = true;
            this.dfs.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.dfs.Location = new System.Drawing.Point(19, 30);
            this.dfs.Margin = new System.Windows.Forms.Padding(4);
            this.dfs.Name = "dfs";
            this.dfs.Size = new System.Drawing.Size(63, 23);
            this.dfs.TabIndex = 0;
            this.dfs.TabStop = true;
            this.dfs.Text = "DFS";
            this.ToolTip.SetToolTip(this.dfs, "Depth First Search algorithm");
            this.dfs.UseVisualStyleBackColor = true;
            // 
            // bfs
            // 
            this.bfs.AutoSize = true;
            this.bfs.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.bfs.Location = new System.Drawing.Point(103, 30);
            this.bfs.Margin = new System.Windows.Forms.Padding(4);
            this.bfs.Name = "bfs";
            this.bfs.Size = new System.Drawing.Size(63, 23);
            this.bfs.TabIndex = 1;
            this.bfs.TabStop = true;
            this.bfs.Text = "BFS";
            this.ToolTip.SetToolTip(this.bfs, "Breadth First Search algorithm");
            this.bfs.UseVisualStyleBackColor = true;
            // 
            // square
            // 
            this.square.AutoSize = true;
            this.square.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.square.Location = new System.Drawing.Point(45, 25);
            this.square.Margin = new System.Windows.Forms.Padding(4);
            this.square.Name = "square";
            this.square.Size = new System.Drawing.Size(86, 23);
            this.square.TabIndex = 0;
            this.square.TabStop = true;
            this.square.Text = "Square";
            this.ToolTip.SetToolTip(this.square, "Depth First Search algorithm");
            this.square.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bfs);
            this.groupBox1.Controls.Add(this.dfs);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.groupBox1.Location = new System.Drawing.Point(607, 425);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(196, 66);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorithms";
            // 
            // robotLbl
            // 
            this.robotLbl.AutoSize = true;
            this.robotLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.robotLbl.ForeColor = System.Drawing.Color.Red;
            this.robotLbl.Location = new System.Drawing.Point(616, 585);
            this.robotLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.robotLbl.MinimumSize = new System.Drawing.Size(93, 20);
            this.robotLbl.Name = "robotLbl";
            this.robotLbl.Size = new System.Drawing.Size(93, 24);
            this.robotLbl.TabIndex = 15;
            this.robotLbl.Text = "Robot";
            this.robotLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // targetLbl
            // 
            this.targetLbl.AutoSize = true;
            this.targetLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.targetLbl.ForeColor = System.Drawing.Color.Green;
            this.targetLbl.Location = new System.Drawing.Point(709, 585);
            this.targetLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.targetLbl.MinimumSize = new System.Drawing.Size(93, 20);
            this.targetLbl.Name = "targetLbl";
            this.targetLbl.Size = new System.Drawing.Size(93, 25);
            this.targetLbl.TabIndex = 16;
            this.targetLbl.Text = "Target";
            this.targetLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frontierLbl
            // 
            this.frontierLbl.AutoSize = true;
            this.frontierLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.frontierLbl.ForeColor = System.Drawing.Color.Blue;
            this.frontierLbl.Location = new System.Drawing.Point(616, 609);
            this.frontierLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.frontierLbl.MinimumSize = new System.Drawing.Size(93, 20);
            this.frontierLbl.Name = "frontierLbl";
            this.frontierLbl.Size = new System.Drawing.Size(93, 25);
            this.frontierLbl.TabIndex = 17;
            this.frontierLbl.Text = "Frontier";
            this.frontierLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closedLbl
            // 
            this.closedLbl.AutoSize = true;
            this.closedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.closedLbl.ForeColor = System.Drawing.Color.Cyan;
            this.closedLbl.Location = new System.Drawing.Point(709, 609);
            this.closedLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.closedLbl.MinimumSize = new System.Drawing.Size(93, 20);
            this.closedLbl.Name = "closedLbl";
            this.closedLbl.Size = new System.Drawing.Size(105, 25);
            this.closedLbl.TabIndex = 18;
            this.closedLbl.Text = "Closed set";
            this.closedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.message.ForeColor = System.Drawing.Color.Blue;
            this.message.Location = new System.Drawing.Point(9, 634);
            this.message.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.message.MinimumSize = new System.Drawing.Size(583, 20);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(583, 25);
            this.message.TabIndex = 20;
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 500;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.square);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.groupBox2.Location = new System.Drawing.Point(607, 55);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(196, 75);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shape of Cell";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 673);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.message);
            this.Controls.Add(this.closedLbl);
            this.Controls.Add(this.frontierLbl);
            this.Controls.Add(this.targetLbl);
            this.Controls.Add(this.robotLbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RealTimeButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.MazeButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maze Escape";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button MazeButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button RealTimeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton dfs;
        private System.Windows.Forms.RadioButton bfs;
        private System.Windows.Forms.Label robotLbl;
        private System.Windows.Forms.Label targetLbl;
        private System.Windows.Forms.Label frontierLbl;
        private System.Windows.Forms.Label closedLbl;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton square;
    }
}

