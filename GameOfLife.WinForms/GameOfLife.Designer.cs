namespace GameOfLife.WinForms
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
            this.runGameButton = new System.Windows.Forms.Button();
            this.stopGameButton = new System.Windows.Forms.Button();
            this.generationCountLabel = new System.Windows.Forms.Label();
            this.loadPatternButton = new System.Windows.Forms.Button();
            this.openPatternFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cellScaleTextBox = new System.Windows.Forms.TextBox();
            this.cellScaleLabel = new System.Windows.Forms.Label();
            this.generationDelayLabel = new System.Windows.Forms.Label();
            this.generationDelayTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gamePictureBox
            // 
            this.gamePictureBox.BackColor = System.Drawing.Color.Black;
            this.gamePictureBox.Location = new System.Drawing.Point(2, 12);
            this.gamePictureBox.Name = "gamePictureBox";
            this.gamePictureBox.Size = new System.Drawing.Size(1379, 1034);
            this.gamePictureBox.TabIndex = 0;
            this.gamePictureBox.TabStop = false;
            // 
            // runGameButton
            // 
            this.runGameButton.Location = new System.Drawing.Point(1216, 1080);
            this.runGameButton.Name = "runGameButton";
            this.runGameButton.Size = new System.Drawing.Size(75, 23);
            this.runGameButton.TabIndex = 3;
            this.runGameButton.Text = "Run Game";
            this.runGameButton.UseVisualStyleBackColor = true;
            this.runGameButton.Click += new System.EventHandler(this.runGameButton_Click);
            // 
            // stopGameButton
            // 
            this.stopGameButton.Location = new System.Drawing.Point(1297, 1080);
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
            this.generationCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generationCountLabel.Location = new System.Drawing.Point(-1, 1058);
            this.generationCountLabel.Name = "generationCountLabel";
            this.generationCountLabel.Size = new System.Drawing.Size(85, 18);
            this.generationCountLabel.TabIndex = 5;
            this.generationCountLabel.Text = "Generation:";
            // 
            // loadPatternButton
            // 
            this.loadPatternButton.Location = new System.Drawing.Point(1130, 1080);
            this.loadPatternButton.Name = "loadPatternButton";
            this.loadPatternButton.Size = new System.Drawing.Size(80, 23);
            this.loadPatternButton.TabIndex = 6;
            this.loadPatternButton.Text = "Load Pattern";
            this.loadPatternButton.UseVisualStyleBackColor = true;
            this.loadPatternButton.Click += new System.EventHandler(this.loadPatternButton_Click);
            // 
            // openPatternFileDialog
            // 
            this.openPatternFileDialog.Title = "Select Pattern File";
            // 
            // cellScaleTextBox
            // 
            this.cellScaleTextBox.Location = new System.Drawing.Point(1042, 1082);
            this.cellScaleTextBox.MaxLength = 1;
            this.cellScaleTextBox.Name = "cellScaleTextBox";
            this.cellScaleTextBox.Size = new System.Drawing.Size(42, 20);
            this.cellScaleTextBox.TabIndex = 7;
            this.cellScaleTextBox.Text = "2";
            this.cellScaleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cellScaleTextBox.TextChanged += new System.EventHandler(this.cellScaleTextBox_TextChanged);
            // 
            // cellScaleLabel
            // 
            this.cellScaleLabel.AutoSize = true;
            this.cellScaleLabel.Location = new System.Drawing.Point(979, 1085);
            this.cellScaleLabel.Name = "cellScaleLabel";
            this.cellScaleLabel.Size = new System.Drawing.Size(57, 13);
            this.cellScaleLabel.TabIndex = 8;
            this.cellScaleLabel.Text = "Cell Scale:";
            // 
            // generationDelayLabel
            // 
            this.generationDelayLabel.AutoSize = true;
            this.generationDelayLabel.Location = new System.Drawing.Point(797, 1085);
            this.generationDelayLabel.Name = "generationDelayLabel";
            this.generationDelayLabel.Size = new System.Drawing.Size(114, 13);
            this.generationDelayLabel.TabIndex = 9;
            this.generationDelayLabel.Text = "Generation Delay (ms):";
            // 
            // generationDelayTextBox
            // 
            this.generationDelayTextBox.Location = new System.Drawing.Point(917, 1082);
            this.generationDelayTextBox.MaxLength = 4;
            this.generationDelayTextBox.Name = "generationDelayTextBox";
            this.generationDelayTextBox.Size = new System.Drawing.Size(42, 20);
            this.generationDelayTextBox.TabIndex = 10;
            this.generationDelayTextBox.Text = "2";
            this.generationDelayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.generationDelayTextBox.TextChanged += new System.EventHandler(this.generationDelayTextBox_TextChanged);
            // 
            // GameOfLife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 1111);
            this.Controls.Add(this.generationDelayTextBox);
            this.Controls.Add(this.generationDelayLabel);
            this.Controls.Add(this.cellScaleLabel);
            this.Controls.Add(this.cellScaleTextBox);
            this.Controls.Add(this.loadPatternButton);
            this.Controls.Add(this.generationCountLabel);
            this.Controls.Add(this.stopGameButton);
            this.Controls.Add(this.runGameButton);
            this.Controls.Add(this.gamePictureBox);
            this.Name = "GameOfLife";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Of Life";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gamePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gamePictureBox;
        private System.Windows.Forms.Button runGameButton;
        private System.Windows.Forms.Button stopGameButton;
        private System.Windows.Forms.Label generationCountLabel;
        private System.Windows.Forms.Button loadPatternButton;
        private System.Windows.Forms.OpenFileDialog openPatternFileDialog;
        private System.Windows.Forms.TextBox cellScaleTextBox;
        private System.Windows.Forms.Label cellScaleLabel;
        private System.Windows.Forms.Label generationDelayLabel;
        private System.Windows.Forms.TextBox generationDelayTextBox;
    }
}

