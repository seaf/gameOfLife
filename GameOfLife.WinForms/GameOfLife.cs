using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameOfLife.Core.Engine;
using GameOfLife.Core.Engine.Strategy;
using System.IO;
using GameOfLife.Core.Input;

namespace GameOfLife.WinForms
{
    public partial class GameOfLife : Form
    {
        private const byte DefaultCellScale = 2;
        private const ushort DefaultGenerationDelayMs = 50;
        private const string GenerationsCountTextTemplate = "Generation: ";
        private const string RelativePathFromBinToPatterns = @"..\..\..\GameOfLife.Core\Patterns";

        private static readonly Color LiveCellColor = Color.GhostWhite;
        private static readonly Color DeadCellColor = Color.MidnightBlue;

        private readonly IGenerationStrategy gameStrategy;
        private readonly ICellParser cellParser;

        private byte scaleFactor;
        private ushort generationDelayMs;
        private ulong generationsCount;
        private bool gameIsRunning;
        private HashSet<Cell> currentGeneration;
        private Bitmap gameStateBitmap;

        public GameOfLife()
        {
            InitializeComponent();

            this.scaleFactor = DefaultCellScale;
            this.cellScaleTextBox.Text = DefaultCellScale.ToString();

            this.generationDelayMs = DefaultGenerationDelayMs;
            this.generationDelayTextBox.Text = DefaultGenerationDelayMs.ToString();

            this.gameStrategy = new ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy();
            this.cellParser = new TupleFormatCellParser();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetGameImage();
        }

        private void ResetGameImage()
        {
            this.gameStateBitmap = new Bitmap(this.gamePictureBox.Width, this.gamePictureBox.Height);
            this.gamePictureBox.Image = this.gameStateBitmap;
        }

        private async void runGameButton_Click(object sender, EventArgs e)
        {
            if (gameIsRunning)
            {
                return;
            }
            else
            {
                gameIsRunning = true;
            }

            while (gameIsRunning)
            {
                var newGeneration = this.gameStrategy.AdvanceGeneration(this.currentGeneration);
                this.UpdateGameState(this.currentGeneration, newGeneration);

                await Task.Delay(this.generationDelayMs);
            }
        }

        private void UpdateGameState(
            HashSet<Cell> currentGeneration,
            HashSet<Cell> newGeneration)
        {
            if (currentGeneration != null)
            {
                foreach (var dyingCell in currentGeneration.Except(newGeneration))
                {
                    this.ShadeCell(dyingCell, DeadCellColor);
                }
            }

            foreach (var cell in newGeneration)
            {
                this.ShadeCell(cell, LiveCellColor);
            }

            this.currentGeneration = newGeneration;
            this.generationCountLabel.Text = GenerationsCountTextTemplate + (++this.generationsCount);
            this.gamePictureBox.Image = this.gameStateBitmap;
        }

        private void ShadeCell(Cell cell, Color color)
        {
            if (this.IsCellOutOfBounds(cell))
            {
                return;
            }

            var scaledRow = Convert.ToInt32(cell.RowCoordinate * scaleFactor);
            var scaledCol = Convert.ToInt32(cell.ColumnCoordinate * scaleFactor);

            foreach (var rowOffset in Enumerable.Range(0, scaleFactor))
            {
                foreach (var colOffset in Enumerable.Range(0, scaleFactor))
                {
                    if (!this.IsCellOutOfBounds(scaledRow + rowOffset, scaledCol + colOffset))
                    {
                        this.gameStateBitmap.SetPixel(scaledCol + colOffset, scaledRow + rowOffset, color);
                    }
                }
            }
        }

        private bool IsCellOutOfBounds(Cell cell)
        {
            return this.IsCellOutOfBounds(
                Convert.ToInt32(cell.RowCoordinate),
                Convert.ToInt32(cell.ColumnCoordinate));
        }

        private bool IsCellOutOfBounds(int row, int column)
        {
            return row >= (double)this.gameStateBitmap.Height ||
                column >= (double)this.gameStateBitmap.Width;
        }

        private void stopGameButton_Click(object sender, EventArgs e)
        {
            this.gameIsRunning = false;
        }

        private async void loadPatternButton_Click(object sender, EventArgs e)
        {
            ResetGameImage();

            var patternDirectory = Path.GetFullPath(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    RelativePathFromBinToPatterns));

            openPatternFileDialog.InitialDirectory = patternDirectory;
            if (openPatternFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var file = openPatternFileDialog.FileName;

            var fileInputSource = new FileGameInputSource(file, this.cellParser);

            this.UpdateGameState(
                null,
                await fileInputSource.GetInitialGameState());
        }

        private void cellScaleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (byte.TryParse(this.cellScaleTextBox.Text, out byte scale))
            {
                this.scaleFactor = scale;
                ResetGameImage();
            }
        }

        private void generationDelayTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ushort.TryParse(this.generationDelayTextBox.Text, out ushort genDelay))
            {
                this.generationDelayMs = genDelay;
            }
        }
    }
}
