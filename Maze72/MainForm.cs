using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Maze72
{
    public partial class MainForm : Form
    {
        #region Cell Class
        /// <summary>
        /// Helper class that represents the cell of the grid
        /// </summary>
        private class Cell
        {
            public int row;     // the row number of the cell(row 0 is the top)
            public int col;     // the column number of the cell (Column 0 is the left)
            public Cell prev;   // Each state corresponds to a cell
                                // and each state has a predecessor which
                                // is stored in this variable

            public Cell(int row, int col)
            {
                this.row = row;
                this.col = col;
            }

        } // end nested class Cell 
        #endregion

        #region Constants Variable
        const int EMPTY = 0;      // empty cell
        const int OBST = 1;       // cell with obstacle
        const int ROBOT = 2;      // the position of the robot
        const int TARGET = 3;     // the position of the target
        const int FRONTIER = 4;   // cells that form the frontier (OPEN SET)
        const int CLOSED = 5;     // cells that form the CLOSED SET
        const int ROUTE = 6;      // cells that form the robot-to-target path

        const String MSG_DRAW_AND_SELECT =
            "Select the Shape then click 'Real-Time'";
        #endregion

        #region Main Variables
        int
            rows,        // the number of rows of the grid
            columns,     // the number of columns of the grid
            squareSize; // the cell size in pixels
                        // pointing the predecessor cell

        List<Cell> openSet = new List<Cell>(); // the OPEN SET
        List<Cell> closedSet = new List<Cell>(); // the CLOSED SET

        Cell robotStart;  // the initial position of the robot
        Cell targetPos;   // the position of the target

        int[,] grid;      // the grid
        Point[,] centers; // the centers of the cells
        bool realTime;    // Solution is displayed instantly
        bool found;       // flag that the goal was found
        bool searching;   // flag that the search is in progress
        bool endOfSearch; // flag that the search came to an end
        int expanded;     // the number of nodes that have been expanded 
        #endregion


        #region Constructor For MainForm
        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            square.Checked = true;
            dfs.Checked = true;
            message.Text = MSG_DRAW_AND_SELECT;
            InitializeGrid(false);
        } // end MainForm constructor

        #endregion

        #region Create New Grid
        /// <summary>
        /// Creates a new clean grid or a new maze
        /// </summary>
        /// <param name="makeMaze">Flag for maze creation</param>
        private void InitializeGrid(bool makeMaze)
        {
            rows = 31;
            columns = 31;

            grid = new int[rows, columns];
            centers = new Point[rows, columns];
            robotStart = new Cell(rows - 2, 1);
            targetPos = new Cell(1, columns - 2);
            squareSize = 16;

            // Calculate center points for each grid cell
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    int x = 11 + c * squareSize + squareSize / 2;
                    int y = 11 + r * squareSize + squareSize / 2;
                    centers[r, c] = new Point(x, y);
                }
            }

            FillGrid();

            if (makeMaze)
            {
                var maze = new Maze(rows / 2, columns / 2);
                string mazeStr = maze.maze_str;

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        string cell = mazeStr.Substring(r * columns + c, 1);
                        if (Regex.IsMatch(cell, "[+-|]"))
                            grid[r, c] = OBST;
                    }
                }
            }

            Invalidate(); // Trigger redraw
        }
        #endregion


        #region To Draw Squares
        /// <summary>
        /// Initializes the grid cells for a new or continued search.
        /// </summary>
        private void FillGrid()
        {
            if (searching || endOfSearch || realTime)
            {
                // Clear previous search results but keep obstacles and start/target positions
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        if (grid[r, c] == FRONTIER || grid[r, c] == CLOSED || grid[r, c] == ROUTE)
                            grid[r, c] = EMPTY;
                        else if (grid[r, c] == ROBOT)
                            robotStart = new Cell(r, c);
                        else if (grid[r, c] == TARGET)
                            targetPos = new Cell(r, c);
                    }
                }
            }
            else
            {
                // Fully reset the grid
                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < columns; c++)
                        grid[r, c] = EMPTY;

                robotStart = new Cell(rows - 2, 1);
                targetPos = new Cell(1, columns - 2);
            }

            // Reset state
            expanded = 0;
            found = false;
            searching = realTime;
            endOfSearch = false;

            // Initialize OPEN and CLOSED sets
            openSet.Clear();
            openSet.Add(robotStart);
            closedSet.Clear();

            if (!realTime)
            {
                grid[targetPos.row, targetPos.col] = TARGET;
                grid[robotStart.row, robotStart.col] = ROBOT;
                message.Text = MSG_DRAW_AND_SELECT;
            }
        }
        #endregion


        #region Logic of Program
        /// <summary>
        /// Enables radio buttons and checkboxes
        /// </summary>
        private void EnableRadiosAndChecks()
        {
            dfs.Enabled = true;
            bfs.Enabled = true;
        } // end EnableRadiosAndChecks

        /// <summary>
        /// Disables radio buttons and checkboxes
        /// </summary>
        private void DisableRadiosAndChecks()
        {
            dfs.Enabled = false;
            bfs.Enabled = false;
        } // end DisableRadiosAndChecks


        /// <summary>
        /// When the user clicks the "Maze" button
        /// </summary>
        private void MazeButton_Click(object sender, EventArgs e)
        {
            realTime = false;
            RealTimeButton.Enabled = true;
            RealTimeButton.ForeColor = Color.Black;
            EnableRadiosAndChecks();
            InitializeGrid(true);
        }// end MazeButton_Click

        /// <summary>
        /// When the user clicks the "Clear" button
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            realTime = false;
            RealTimeButton.Enabled = true;
            RealTimeButton.ForeColor = Color.Black;
            EnableRadiosAndChecks();
            FillGrid();
            Invalidate();
        } // end ClearButton_Click

        /// <summary>
        /// When the user clicks the "Real-Time" button
        /// </summary>
        private void RealTimeButton_Click(object sender, EventArgs e)
        {
            if (realTime)
                return;
            realTime = true;
            searching = true;
            RealTimeButton.ForeColor = Color.Red;
            DisableRadiosAndChecks();
            RealTime_action();
        } // end RealTimeButton_Click

        /// <summary>
        /// Action performed during real-time search
        /// </summary>
        private void RealTime_action()
        {
            do
                CheckTermination();
            while (!endOfSearch);
        } // end RealTime_action


        /// <summary>
        /// Checks if we have reached the end of search
        /// </summary>
        private void CheckTermination()
        {
            ExpandNode();
            if (found)
            {
                endOfSearch = true;
                PlotRoute();
                Invalidate();
            }
        } // end CheckTermination 
        #endregion


        #region Core Logic For  DFS & BFS 
        /// <summary>
        /// Expands a node and creates its successors
        /// </summary>
        /// 
        private void ExpandNode()
        {
            // 1. Get current node and move to CLOSED SET
            Cell current = openSet[0];
            openSet.RemoveAt(0);
            closedSet.Insert(0, current);
            grid[current.row, current.col] = CLOSED;

            // 2. Check if target reached
            if (current.row == targetPos.row && current.col == targetPos.col)
            {
                targetPos.prev = current.prev;
                closedSet.Add(targetPos);
                found = true;
                return;
            }

            expanded++;

            // 3. Create successors
            List<Cell> successors = CreateSuccesors(current, false);

            // 4. For each successor
            foreach (Cell cell in successors)
            {
                // Skip if already visited
                if (IsInList(openSet, cell) != -1 || IsInList(closedSet, cell) != -1)
                    continue;

                // Add to open set: DFS → front, BFS → back
                if (dfs.Checked)
                    openSet.Insert(0, cell);
                else if (bfs.Checked)
                    openSet.Add(cell);

                grid[cell.row, cell.col] = FRONTIER;
            }
        }

        #endregion

        #region DFS and BFS Utilities
        /// <summary>
        /// Creates three, four, six or eight successors of a cell
        /// </summary>
        /// <param name="current">The cell for which we ask successors</param>
        /// <param name="makeConnected">
        /// Flag that indicates that we are interested only on the coordinates 
        /// of cells and not on the label 'dist' (concerns only Dijkstra's)</param>
        /// <returns>The successors of the cell as a list</returns>
        private List<Cell> CreateSuccesors(Cell current, bool makeConnected)
        {
            int r = current.row;
            int c = current.col;
            List<Cell> successors = new List<Cell>();

            // Directions: Up, Right, Down, Left
            int[] dr = { -1, 0, 1, 0 };
            int[] dc = { 0, 1, 0, -1 };

            for (int i = 0; i < 4; i++)
            {
                int newR = r + dr[i];
                int newC = c + dc[i];

                // Check bounds
                if (newR < 0 || newR >= rows || newC < 0 || newC >= columns)
                    continue;

                // Skip if obstacle
                if (grid[newR, newC] == OBST)
                    continue;

                // Skip if already in open/closed (only for DFS/BFS)
                if ((dfs.Checked || bfs.Checked) &&
                    (IsInList(openSet, new Cell(newR, newC)) != -1 ||
                     IsInList(closedSet, new Cell(newR, newC)) != -1))
                    continue;

                Cell cell = new Cell(newR, newC);
                cell.prev = current;
                successors.Add(cell);
            }

            successors.Reverse();
            return successors;
        }

        /// <summary>
        /// Returns the index of the cell 'current' in the list 'list'
        /// </summary>
        /// <param name="list">The list in which we seek</param>
        /// <param name="current">The cell we are looking for</param>
        /// <returns>The index of the cell in the list. If the cell is not found returns -1</returns>
        private int IsInList(List<Cell> list, Cell current)
        {
            int index = -1;
            for (int i = 0; i < list.Count; i++)
            {
                Cell listItem = (Cell)list[i];
                if (current.row == listItem.row && current.col == listItem.col)
                {
                    index = i;
                    break;
                }
            }
            return index;
        } // end IsInList()

        #endregion


        #region To Calc Path From Start to Target
        /// <summary>
        /// Calculates the path from the target to the initial position of the robot, 
                /// counts the corresponding steps and measures the distance travelled.
        /// </summary>
        private void PlotRoute()
        {
            int steps = 0;
            double distance = 0;

            // Start from the target cell
            Cell cur = closedSet[IsInList(closedSet, targetPos)];
            grid[cur.row, cur.col] = TARGET;

            // Trace back the path using prev pointers
            while (!(cur.row == robotStart.row && cur.col == robotStart.col))
            {
                steps++;

                Cell prev = cur.prev;
                double dx = centers[cur.row, cur.col].X - centers[prev.row, prev.col].X;
                double dy = centers[cur.row, cur.col].Y - centers[prev.row, prev.col].Y;
                distance += Math.Sqrt(dx * dx + dy * dy);

                cur = prev;
                grid[cur.row, cur.col] = ROUTE;
            }

            // Mark the starting position of the robot
            grid[robotStart.row, robotStart.col] = ROBOT;

            string msg = string.Format("Nodes expanded: {0}, Steps: {1}, Distance: {2:N1}",
                      expanded, steps, distance);
            message.Text = msg;

        } // end PlotRoute() 
        #endregion

        #region Repaint The Grid

        /// <summary>
        /// Repaints the grid
        /// </summary>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush;
            brush = new SolidBrush(Color.DarkGray);
            // Fills the background color.
            if (square.Checked)
                g.FillRectangle(brush, new Rectangle(10, 10, columns * squareSize + 1, rows * squareSize + 1));
            brush.Dispose();
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                {
                    if (grid[r, c] == EMPTY)
                        brush = new SolidBrush(Color.White);
                    else if (grid[r, c] == ROBOT)
                        brush = new SolidBrush(Color.Red);
                    else if (grid[r, c] == TARGET)
                        brush = new SolidBrush(Color.Green);
                    else if (grid[r, c] == OBST)
                        brush = new SolidBrush(Color.Black);
                    else if (grid[r, c] == FRONTIER)
                        brush = new SolidBrush(Color.Blue);
                    else if (grid[r, c] == CLOSED)
                        brush = new SolidBrush(Color.Cyan);
                    else if (grid[r, c] == ROUTE)
                        brush = new SolidBrush(Color.Yellow);
                    if (square.Checked)
                        g.FillPolygon(brush, CalcSquare(r, c));
                    brush.Dispose();
                }

        } // end MainForm_Paint 
        #endregion


        #region To Calculate Square Length
        /// <summary>
        /// Calculates the coordinates of the vertices of the square representing a cell
        /// </summary>
        /// <param name="r">The row of the cell</param>
        /// <param name="c">The row of the cell</param>
        /// <returns>The coordinates of the vertices as an array of points</returns>
        private Point[] CalcSquare(int r, int c)
        {
            Point[] polygon = {
                new Point((int)(11 +     c*squareSize + 0), (int)(11 +     r*squareSize + 0)),
                new Point((int)(11 + (c+1)*squareSize - 1), (int)(11 +     r*squareSize + 0)),
                new Point((int)(11 + (c+1)*squareSize - 1), (int)(11 + (r+1)*squareSize - 1)),
                new Point((int)(11 +     c*squareSize + 0), (int)(11 + (r+1)*squareSize - 1))
            };
            return polygon;
        } // end CalcSquare 
        #endregion


    } // end class MainForm


    #region Extensions

    /// <summary>
    /// The following code creates a random, perfect (without cycles) maze
    /// 
    /// From http://rosettacode.org/wiki/Maze_generation
    /// </summary>
    public static class Extensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            var e = source.ToArray();
            for (var i = e.Length - 1; i >= 0; i--)
            {
                var swapIndex = rng.Next(i + 1);
                yield return e[swapIndex];
                e[swapIndex] = e[i];
            }
        }

        public static CellState OppositeWall(this CellState orig)
        {
            return (CellState)(((int)orig >> 2) | ((int)orig << 2)) & CellState.Initial;
        }

        public static bool HasFlag(this CellState cs, CellState flag)
        {
            return ((int)cs & (int)flag) != 0;
        }
    }

    [Flags]
    public enum CellState
    {
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8,
        Visited = 128,
        Initial = Top | Right | Bottom | Left,
    }

    public struct RemoveWallAction
    {
        public Point Neighbour;
        public CellState Wall;
    }

    public class Maze
    {
        private readonly CellState[,] _cells;
        private readonly int _width;
        private readonly int _height;
        private readonly Random _rng;
        public String maze_str = "";

        public Maze(int width, int height)
        {
            _width = width;
            _height = height;
            _cells = new CellState[width, height];
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    _cells[x, y] = CellState.Initial;
            _rng = new Random();
            VisitCell(_rng.Next(width), _rng.Next(height));
            make_string();
        }

        public CellState this[int x, int y]
        {
            get { return _cells[x, y]; }
            set { _cells[x, y] = value; }
        }

        public IEnumerable<RemoveWallAction> GetNeighbours(Point p)
        {
            if (p.X > 0) yield return new RemoveWallAction { Neighbour = new Point(p.X - 1, p.Y), Wall = CellState.Left };
            if (p.Y > 0) yield return new RemoveWallAction { Neighbour = new Point(p.X, p.Y - 1), Wall = CellState.Top };
            if (p.X < _width - 1) yield return new RemoveWallAction { Neighbour = new Point(p.X + 1, p.Y), Wall = CellState.Right };
            if (p.Y < _height - 1) yield return new RemoveWallAction { Neighbour = new Point(p.X, p.Y + 1), Wall = CellState.Bottom };
        }

        public void VisitCell(int x, int y)
        {
            this[x, y] |= CellState.Visited;
            foreach (var p in GetNeighbours(new Point(x, y)).Shuffle(_rng).Where(z => !(this[z.Neighbour.X, z.Neighbour.Y].HasFlag(CellState.Visited))))
            {
                this[x, y] -= p.Wall;
                this[p.Neighbour.X, p.Neighbour.Y] -= p.Wall.OppositeWall();
                VisitCell(p.Neighbour.X, p.Neighbour.Y);
            }
        }

        public void make_string()
        {
            var firstLine = string.Empty;
            for (var y = 0; y < _height; y++)
            {
                var sbTop = new StringBuilder();
                var sbMid = new StringBuilder();
                for (var x = 0; x < _width; x++)
                {
                    sbTop.Append(this[x, y].HasFlag(CellState.Top) ? "+-" : "+ ");
                    sbMid.Append(this[x, y].HasFlag(CellState.Left) ? "| " : "  ");
                }
                if (firstLine == string.Empty)
                    firstLine = sbTop.ToString();
                maze_str = maze_str + sbTop + "+";
                maze_str = maze_str + sbMid + "|";
            }
            maze_str = maze_str + firstLine + "+";
        }
    }

} // end namespace Maze72

#endregion
