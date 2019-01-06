﻿namespace GameOfLife.WinForms
{
    partial class GameOfLife
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
            this.gamePictureBox = new System.Windows.Forms.PictureBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.inputBoxLabel = new System.Windows.Forms.Label();
            this.runGameButton = new System.Windows.Forms.Button();
            this.stopGameButton = new System.Windows.Forms.Button();
            this.generationCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePictureBox
            // 
            this.gamePictureBox.BackColor = System.Drawing.Color.Black;
            this.gamePictureBox.Location = new System.Drawing.Point(12, 6);
            this.gamePictureBox.Name = "gamePictureBox";
            this.gamePictureBox.Size = new System.Drawing.Size(776, 553);
            this.gamePictureBox.TabIndex = 0;
            this.gamePictureBox.TabStop = false;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(12, 590);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(776, 68);
            this.inputTextBox.TabIndex = 1;
            // 
            // inputBoxLabel
            // 
            this.inputBoxLabel.AutoSize = true;
            this.inputBoxLabel.Location = new System.Drawing.Point(12, 566);
            this.inputBoxLabel.Name = "inputBoxLabel";
            this.inputBoxLabel.Size = new System.Drawing.Size(118, 13);
            this.inputBoxLabel.TabIndex = 2;
            this.inputBoxLabel.Text = "Enter Initial Living Cells:";
            // 
            // runGameButton
            // 
            this.runGameButton.Location = new System.Drawing.Point(12, 677);
            this.runGameButton.Name = "runGameButton";
            this.runGameButton.Size = new System.Drawing.Size(75, 23);
            this.runGameButton.TabIndex = 3;
            this.runGameButton.Text = "Run Game";
            this.runGameButton.UseVisualStyleBackColor = true;
            this.runGameButton.Click += new System.EventHandler(this.runGameButton_Click);
            // 
            // stopGameButton
            // 
            this.stopGameButton.Location = new System.Drawing.Point(93, 677);
            this.stopGameButton.Name = "stopGameButton";
            this.stopGameButton.Size = new System.Drawing.Size(75, 23);
            this.stopGameButton.TabIndex = 4;
            this.stopGameButton.Text = "Stop Game";
            this.stopGameButton.UseVisualStyleBackColor = true;
            this.stopGameButton.Click += new System.EventHandler(this.stopGameButton_Click);
            // 
            // generationCountLabel
            // 
            this.generationCountLabel.AutoSize = true;
            this.generationCountLabel.Location = new System.Drawing.Point(174, 682);
            this.generationCountLabel.Name = "generationCountLabel";
            this.generationCountLabel.Size = new System.Drawing.Size(62, 13);
            this.generationCountLabel.TabIndex = 5;
            this.generationCountLabel.Text = "Generation:";
            // 
            // GameOfLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 715);
            this.Controls.Add(this.generationCountLabel);
            this.Controls.Add(this.stopGameButton);
            this.Controls.Add(this.runGameButton);
            this.Controls.Add(this.inputBoxLabel);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.gamePictureBox);
            this.Name = "GameOfLife";
            this.Text = "Game Of Life";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gamePictureBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Label inputBoxLabel;
        private System.Windows.Forms.Button runGameButton;
        private System.Windows.Forms.Button stopGameButton;
        private System.Windows.Forms.Label generationCountLabel;
    }
}

