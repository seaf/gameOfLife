using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameOfLife.Core;
using GameOfLife.Core.Engine;
using GameOfLife.Core.Engine.Strategy;

namespace GameOfLife.WinForms
{
    public partial class GameOfLife : Form
    {
        private const string GenerationsCountTextTemplate = "Generations: ";

        private readonly Color LiveCellColor = Color.White;
        private readonly Color DeadCellColor = Color.Black;

        private readonly Bitmap gameStateBitmap;
        private readonly IGenerationStrategy gameStrategy;

        private ulong generationsCount;
        private bool stopGame;
        private HashSet<Cell> currentGeneration;

        public GameOfLife()
        {
            InitializeComponent();
            this.gameStateBitmap = new Bitmap(this.gamePictureBox.Width, this.gamePictureBox.Height);
            this.gameStrategy = new ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.UpdateGameState(
                null,
                InitialGameStates.GosperGliderGun);
        }

        private async void runGameButton_Click(object sender, EventArgs e)
        {
            // TODO: ultimately, read input from text box here

            if (stopGame)
            {
                stopGame = false;
            }

            while (!stopGame)
            {
                var newGeneration = this.gameStrategy.AdvanceGeneration(this.currentGeneration);
                this.UpdateGameState(this.currentGeneration, newGeneration);

                // TODO: Make this modifiable
                await Task.Delay(50);
            }
        }

        private bool IsCellOutOfBounds(Cell cell)
        {
            return cell.RowCoordinate >= (double)this.gameStateBitmap.Height ||
                cell.ColumnCoordinate >= (double)this.gameStateBitmap.Width;
        }

        // TODO: Consider adding a scaling factor here so each cell is draw over more than 1 pixel.
        // e.g scale factor = 2 means multiply row and column each by 2 to find starting point and then color
        // a scale factor * scale factor box of pixels to represent the cell.
        private void KillCell(Cell dyingCell)
        {
            this.gameStateBitmap.SetPixel(
                Convert.ToInt32(dyingCell.ColumnCoordinate),
                Convert.ToInt32(dyingCell.RowCoordinate),
                DeadCellColor);
        }

        private void ReviveCell(Cell cell)
        {
            this.gameStateBitmap.SetPixel(
                Convert.ToInt32(cell.ColumnCoordinate),
                Convert.ToInt32(cell.RowCoordinate),
                LiveCellColor);
        }

        private void UpdateGameState(
            HashSet<Cell> currentGeneration,
            HashSet<Cell> newGeneration)
        {
            if (currentGeneration != null)
            {
                foreach (var dyingCell in currentGeneration.Except(newGeneration))
                {
                    if (!this.IsCellOutOfBounds(dyingCell))
                    {
                        this.KillCell(dyingCell);
                    }
                }
            }

            foreach (var cell in newGeneration)
            {
                if (!this.IsCellOutOfBounds(cell))
                {
                    this.ReviveCell(cell);
                }
            }

            // TODO: write new generation to the text box (even those beyond bitmap dimensions)

            this.currentGeneration = newGeneration;
            this.generationCountLabel.Text = GenerationsCountTextTemplate + (++this.generationsCount);
            this.gamePictureBox.Image = this.gameStateBitmap;
        }

        private void stopGameButton_Click(object sender, EventArgs e)
        {
            this.stopGame = true;
        }
    }
}
