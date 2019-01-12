﻿using System;
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
        private const int ScaleFactor = 5;

        private readonly Color LiveCellColor = Color.White;
        private readonly Color DeadCellColor = Color.Black;

        private readonly IGenerationStrategy gameStrategy;

        private ulong generationsCount;
        private bool stopGame;
        private HashSet<Cell> currentGeneration;
        private Bitmap gameStateBitmap;

        public GameOfLife()
        {
            InitializeComponent();
            this.gameStateBitmap = new Bitmap(this.gamePictureBox.Width, this.gamePictureBox.Height);
            this.gameStrategy = new ImmediateEvaluationForAllCellsWithAliveNeighborsGenerationStrategy();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            return this.IsCellOutOfBounds(
                Convert.ToInt32(cell.RowCoordinate),
                Convert.ToInt32(cell.ColumnCoordinate));
        }

        private bool IsCellOutOfBounds(int row, int column)
        {
            return row >= (double)this.gameStateBitmap.Height ||
                column >= (double)this.gameStateBitmap.Width;
        }

        private void ShadeCell(Cell cell, Color color)
        {
            if (this.IsCellOutOfBounds(cell))
            {
                return;
            }

            var scaledRow = Convert.ToInt32(cell.RowCoordinate * ScaleFactor);
            var scaledCol = Convert.ToInt32(cell.ColumnCoordinate * ScaleFactor);

            foreach (var rowOffset in Enumerable.Range(0, ScaleFactor))
            {
                foreach (var colOffset in Enumerable.Range(0, ScaleFactor))
                {
                    if (!this.IsCellOutOfBounds(scaledRow + rowOffset, scaledCol + colOffset))
                    {
                        this.gameStateBitmap.SetPixel(scaledCol + colOffset, scaledRow + rowOffset, color);
                    }
                }
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

        private void stopGameButton_Click(object sender, EventArgs e)
        {
            this.stopGame = true;
        }
    }
}
