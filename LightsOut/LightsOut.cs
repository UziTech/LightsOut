using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LightsOut
{
    public partial class LightsOut : Form
    {
        #region Global Variables
        Options optionsDialog = new Options();
        int _buttonSize = 20;
        int _moves = 0;
        int[,] _movesA;
        int[,] _movesB;
        int[,] _CmovesA;
        int[,] _CmovesB = new int[0,2];
        Pen _penThick = new Pen(Color.Black, 3);
        Rectangle _board = new Rectangle(0, 0, 0, 0);
        Rectangle[,] _boardArray = new Rectangle[0, 0];
        int _selectedRow = -1;
        int _selectedCol = -1;
        bool[,] _grid = null;
        bool _play = false;
        Random _rand = new Random((int)System.DateTime.Now.Ticks);
        #endregion
        public LightsOut()
        {
            InitializeComponent();
            InitializeBoardArray();
            CreateGrid();
        }
        private void LightsOut_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
        }
        private void LightsOut_MouseDown(object sender, MouseEventArgs e)
        {
            TranslateToRect(new Point(e.X, e.Y), out _selectedRow, out _selectedCol);
            if (_play && _selectedCol > -1)
            {
                ChangeMoves(_selectedRow, _selectedCol);
                ChangeLights(_selectedRow, _selectedCol);
                _moves++;
                _CmovesA = new int[_moves, 2];
                for (int i = 0; i < _CmovesB.Length / 2; i++)
                {
                    _CmovesA[i, 0] = _CmovesB[i, 0];
                    _CmovesA[i, 1] = _CmovesB[i, 1];
                }
                _CmovesA[_moves - 1, 0] = _selectedRow;
                _CmovesA[_moves - 1, 1] = _selectedCol;
                _CmovesB = new int[_moves, 2];
                for (int i = 0; i < _CmovesB.Length / 2; i++)
                {
                    _CmovesB[i, 0] = _CmovesA[i, 0];
                    _CmovesB[i, 1] = _CmovesA[i, 1];
                }
                movesToolStripMenuItem.Text = "Moves: " + _moves.ToString();
                if (CheckDone())
                {
                    System.Windows.Forms.MessageBox.Show("Congratulations!!! You won in " + _moves.ToString() + " moves!!");
                    _play = false;
                }
            }
        }
        private void ChangeMoves(int row, int col)
        {
            bool k = true;
            for (int i = 0; i < _movesA.Length / 2; i++)
            {
                if (row == _movesA[i, 0] && col == _movesA[i, 1])
                {
                    _movesA = new int[_movesB.Length / 2 - 1, 2];
                    int var = 0;
                    for (int j = 0; j < _movesB.Length / 2; j++)
                    {
                        if (j == i)
                        {
                            var = 1;
                        }
                        else
                        {
                            _movesA[j - var, 0] = _movesB[j, 0];
                            _movesA[j - var, 1] = _movesB[j, 1];
                        }
                    }
                    _movesB = new int[_movesA.Length / 2, 2];
                    for (int j = 0; j < _movesA.Length / 2; j++)
                    {
                        _movesB[j, 0] = _movesA[j, 0];
                        _movesB[j, 1] = _movesA[j, 1];
                    }
                    k = false;
                    break;
                }
            }
            if (k)
            {
                _movesA = new int[_movesB.Length / 2 + 1, 2];
                for (int i = 0; i < _movesB.Length / 2; i++)
                {
                    _movesA[i, 0] = _movesB[i, 0];
                    _movesA[i, 1] = _movesB[i, 1];
                }
                _movesA[_movesB.Length / 2, 0] = row;
                _movesA[_movesB.Length / 2, 1] = col;
                _movesB = new int[_movesA.Length / 2, 2];
                for (int i = 0; i < _movesA.Length / 2; i++)
                {
                    _movesB[i, 0] = _movesA[i, 0];
                    _movesB[i, 1] = _movesA[i, 1];
                }
            }
            _movesA = sortArray(_movesA);
            _movesB = sortArray(_movesB);
        }
        private void ChangeLights(int row, int col)
        {
            if (row != 0)
            {
                _grid[row - 1, col] = !_grid[row - 1, col];
                Invalidate(_boardArray[row - 1, col]);
            }
            if (col != 0)
            {
                _grid[row, col - 1] = !_grid[row, col - 1];
                Invalidate(_boardArray[row, col - 1]);
            }
            _grid[row, col] = !_grid[row, col];
            Invalidate(_boardArray[row, col]);
            if (col != optionsDialog._cols - 1)
            {
                _grid[row, col + 1] = !_grid[row, col + 1];
                Invalidate(_boardArray[row, col + 1]);
            }
            if (row != optionsDialog._rows - 1)
            {
                _grid[row + 1, col] = !_grid[row + 1, col];
                Invalidate(_boardArray[row + 1, col]);
            }
        }
        private void InitializeBoardArray()
        {
            _board = new Rectangle(7, 7 + menuStrip1.Height, optionsDialog._cols * _buttonSize, optionsDialog._rows * _buttonSize);
            _boardArray = new Rectangle[optionsDialog._rows, optionsDialog._cols];
            int spacingX = _board.Width / optionsDialog._cols;
            int spacingY = _board.Height / optionsDialog._rows;
            for (int col = 0; col < optionsDialog._cols; col++)
            {
                for (int row = 0; row < optionsDialog._rows; row++)
                {
                    _boardArray[row, col] = new Rectangle(_board.Left + col * spacingX, _board.Top + row * spacingY, spacingX, spacingY);
                }
            }
        }
        private void TranslateToRect(Point p, out int selectedRow, out int selectedCol)
        {
            for (int col = 0; col < optionsDialog._cols; col++)
            {
                for (int row = 0; row < optionsDialog._rows; row++)
                {
                    if (_boardArray[row, col].Contains(p))
                    {
                        selectedRow = row;
                        selectedCol = col;
                        return;
                    }
                }
            }
            selectedRow = -1;
            selectedCol = -1;
            return;
        }
        private void DrawGrid(Graphics g)
        {
            this.Height = 50 + menuStrip1.Height + optionsDialog._rows * _buttonSize;
            this.Width = 31 + optionsDialog._cols * _buttonSize;
            _board = new Rectangle(7, 7 + menuStrip1.Height, optionsDialog._cols * _buttonSize, optionsDialog._rows * _buttonSize);
            g.DrawRectangle(_penThick, _board);
            for (int i = 0; i < optionsDialog._rows; i++)
            {
                for (int j = 0; j < optionsDialog._cols; j++)
                {
                    if (_grid[i, j])
                    {
                        g.FillRectangle(Brushes.Yellow, _boardArray[i, j]);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Black, _boardArray[i, j]);
                    }
                }
            }
            int spacingX = _board.Width / optionsDialog._cols;
            int spacingY = _board.Height / optionsDialog._rows;
            for (int i = 0; i < ((optionsDialog._cols > optionsDialog._rows) ? optionsDialog._cols : optionsDialog._rows); i++)
            {
                if (i < optionsDialog._rows)
                {
                    g.DrawLine(Pens.Black, _board.Left, _board.Top + spacingY * i, _board.Right, _board.Top + spacingY * i);
                }
                if (i < optionsDialog._cols)
                {
                    g.DrawLine(Pens.Black, _board.Left + spacingX * i, _board.Top, _board.Left + spacingX * i, _board.Bottom);
                }
            }
            for (int row = 0; row < optionsDialog._rows; row++)
            {
                for (int col = 0; col < optionsDialog._cols; col++)
                {
                    g.FillRectangle(Brushes.Black, _boardArray[row, col].Right - 1, _boardArray[row, col].Bottom - 1, 3, 3);
                }
            }
            for (int row = 0; row < optionsDialog._rows; row++)
            {
                for (int col = 0; col < optionsDialog._cols; col++)
                {
                    g.FillRectangle(Brushes.Black, _boardArray[row, col].Left - 1, _boardArray[row, col].Top - 1, 3, 3);
                }
            }
        }
        private void CreateGrid()
        {
            _grid = new bool[optionsDialog._rows, optionsDialog._cols];
            ResetGrid();
            int clicks = (optionsDialog._easy) ? optionsDialog._rows * optionsDialog._cols / 10 : (optionsDialog._medium) ? optionsDialog._rows * optionsDialog._cols / 5 : optionsDialog._rows * optionsDialog._cols / 2;
            _CmovesA = new int[0, 2];
            _CmovesB = new int[0, 2];
            _movesA = new int[clicks, 2];
            _movesB = new int[clicks, 2];
            for (int i = 0; i < clicks; i++)
            {
                _movesA[i, 0] = -1;
                _movesA[i, 1] = -1;
                _movesB[i, 0] = -1;
                _movesB[i, 1] = -1;
            }
            for (int i = 0; i < clicks; i++)
            {
                int row = _rand.Next(optionsDialog._rows);
                int col = _rand.Next(optionsDialog._cols);
                for (int j = 0; j < clicks; j++)
                {
                    while (row == _movesA[j, 0] && col == _movesA[j, 1])
                    {
                        row = _rand.Next(optionsDialog._rows);
                        col = _rand.Next(optionsDialog._cols);
                        j = 0;
                    }
                }
                _movesA[i, 0] = row;
                _movesB[i, 0] = row;
                _movesA[i, 1] = col;
                _movesB[i, 1] = col;
                ChangeLights(row, col);
            }
            _movesA = sortArray(_movesA);
            _movesB = sortArray(_movesB);
            _play = true;
        }
        private void ResetGrid()
        {
            _moves = 0;
            for (int i = 0; i < optionsDialog._rows; i++)
                for (int j = 0; j < optionsDialog._cols; j++)
                {
                    _grid[i, j] = false;
                }
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGrid();
            Invalidate();
            movesToolStripMenuItem.Text = "Moves: " + _moves.ToString();
        }
        private bool CheckDone()
        {
            for (int row = 0; row < optionsDialog._rows; row++)
            {
                for (int col = 0; col < optionsDialog._cols; col++)
                {
                    if (_grid[row, col])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            optionsDialog.ShowDialog();
            InitializeBoardArray();
            CreateGrid();
            Invalidate();
        }
        private void LightsOut_Resize(object sender, EventArgs e)
        {
            this.Height = 50 + menuStrip1.Height + optionsDialog._rows * _buttonSize;
            this.Width = 31 + optionsDialog._cols * _buttonSize;
        }
        private void hintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckDone() && _play)
            {
                int row = _movesA[_movesA.Length / 2 - 1, 0];
                int col = _movesA[_movesA.Length / 2 - 1, 1];
                _movesA = new int[_movesB.Length / 2 - 1, 2];
                for (int i = 0; i < _movesA.Length / 2; i++)
                {
                    _movesA[i, 0] = _movesB[i, 0];
                    _movesA[i, 1] = _movesB[i, 1];
                }
                _movesB = new int[_movesA.Length / 2, 2];
                for (int i = 0; i < _movesA.Length / 2; i++)
                {
                    _movesB[i, 0] = _movesA[i, 0];
                    _movesB[i, 1] = _movesA[i, 1];
                }
                ChangeLights(row, col);
                _moves++;
                _CmovesA = new int[_moves, 2];
                for (int i = 0; i < _CmovesB.Length / 2; i++)
                {
                    _CmovesA[i, 0] = _CmovesB[i, 0];
                    _CmovesA[i, 1] = _CmovesB[i, 1];
                }
                _CmovesA[_moves - 1, 0] = row;
                _CmovesA[_moves - 1, 1] = col;
                _CmovesB = new int[_moves, 2];
                for (int i = 0; i < _CmovesB.Length / 2; i++)
                {
                    _CmovesB[i, 0] = _CmovesA[i, 0];
                    _CmovesB[i, 1] = _CmovesA[i, 1];
                }
                movesToolStripMenuItem.Text = "Moves: " + _moves.ToString();
            }
            if (CheckDone())
            {
                System.Windows.Forms.MessageBox.Show("Congratulations!!! You won in " + _moves.ToString() + " moves!!");
                _play = false;
            }
        }
        private int[,] sortArray(int[,] A)
        {
            for (int i = 0; i < A.Length / 2; i++)
            {
                for (int j = i; j < A.Length / 2; j++)
                {
                    if (A[j, 0] < A[i, 0] || (A[j, 0] == A[i, 0] && A[j, 1] < A[i, 1]))
                    {
                        int temp = A[i, 0];
                        A[i, 0] = A[j, 0];
                        A[j, 0] = temp;
                        temp = A[i, 1];
                        A[i, 1] = A[j, 1];
                        A[j, 1] = temp;
                    }
                }
            }
            return A;
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_moves > 0)
            {
                _play = true;
                _moves--;
                ChangeMoves(_CmovesA[_moves, 0], _CmovesA[_moves, 1]);
                ChangeLights(_CmovesA[_moves, 0], _CmovesA[_moves, 1]);
                _CmovesA = new int[_moves, 2];
                for (int i = 0; i < _CmovesA.Length / 2; i++)
                {
                    _CmovesA[i, 0] = _CmovesB[i, 0];
                    _CmovesA[i, 1] = _CmovesB[i, 1];
                }
                _CmovesB = new int[_moves, 2];
                for (int i = 0; i < _CmovesB.Length / 2; i++)
                {
                    _CmovesB[i, 0] = _CmovesA[i, 0];
                    _CmovesB[i, 1] = _CmovesA[i, 1];
                }
                movesToolStripMenuItem.Text = "Moves: " + _moves.ToString();
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }
    }
}
