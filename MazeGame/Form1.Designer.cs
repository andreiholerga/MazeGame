namespace MazeGame
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lostLabel = new Label();
            subtitleLabel = new Label();
            playButton = new Button();
            panel1 = new Panel();
            enemyGroupImage = new PictureBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            highscoreLabel = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            levelLabel = new Label();
            enemyImage2 = new PictureBox();
            nextLvlButton = new Button();
            enemyImage = new PictureBox();
            playerImage = new PictureBox();
            titleLabel = new Label();
            gameLoopTimer = new System.Windows.Forms.Timer(components);
            panel2 = new Panel();
            button2 = new Button();
            button1 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)enemyGroupImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemyImage2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemyImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerImage).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lostLabel
            // 
            lostLabel.AutoSize = true;
            lostLabel.BackColor = Color.Transparent;
            lostLabel.Font = new Font("Matura MT Script Capitals", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lostLabel.ForeColor = Color.White;
            lostLabel.Location = new Point(470, 224);
            lostLabel.Name = "lostLabel";
            lostLabel.Size = new Size(325, 85);
            lostLabel.TabIndex = 0;
            lostLabel.Text = "You lost!";
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.BackColor = Color.Transparent;
            subtitleLabel.Font = new Font("Javanese Text", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            subtitleLabel.ForeColor = Color.White;
            subtitleLabel.Location = new Point(694, 294);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(241, 62);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "by Andrei Holerga";
            // 
            // playButton
            // 
            playButton.BackColor = Color.White;
            playButton.FlatStyle = FlatStyle.Popup;
            playButton.Font = new Font("Matura MT Script Capitals", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            playButton.ForeColor = Color.FromArgb(29, 0, 86);
            playButton.Location = new Point(341, 407);
            playButton.Name = "playButton";
            playButton.Size = new Size(594, 70);
            playButton.TabIndex = 2;
            playButton.Text = "Play";
            playButton.UseVisualStyleBackColor = false;
            playButton.Click += playButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(enemyGroupImage);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(highscoreLabel);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(levelLabel);
            panel1.Controls.Add(enemyImage2);
            panel1.Controls.Add(nextLvlButton);
            panel1.Controls.Add(enemyImage);
            panel1.Controls.Add(playerImage);
            panel1.Location = new Point(1035, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(1273, 684);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // enemyGroupImage
            // 
            enemyGroupImage.Image = Properties.Resources.Untitled_design__4_;
            enemyGroupImage.Location = new Point(583, 449);
            enemyGroupImage.Name = "enemyGroupImage";
            enemyGroupImage.Size = new Size(50, 44);
            enemyGroupImage.SizeMode = PictureBoxSizeMode.StretchImage;
            enemyGroupImage.TabIndex = 21;
            enemyGroupImage.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Javanese Text", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(47, 459);
            label11.Name = "label11";
            label11.Size = new Size(119, 47);
            label11.TabIndex = 20;
            label11.Text = "Good luck!";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Javanese Text", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(47, 400);
            label10.Name = "label10";
            label10.Size = new Size(114, 47);
            label10.TabIndex = 19;
            label10.Text = "reach you.";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Javanese Text", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(47, 371);
            label9.Name = "label9";
            label9.Size = new Size(189, 47);
            label9.TabIndex = 18;
            label9.Text = "before the enemies";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Javanese Text", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(47, 342);
            label8.Name = "label8";
            label8.Size = new Size(148, 47);
            label8.TabIndex = 17;
            label8.Text = "Reach the exit";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Matura MT Script Capitals", 36F, FontStyle.Italic);
            label7.ForeColor = Color.White;
            label7.Location = new Point(21, 273);
            label7.Name = "label7";
            label7.Size = new Size(286, 64);
            label7.TabIndex = 16;
            label7.Text = "How to play";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Javanese Text", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(881, 576);
            label6.Name = "label6";
            label6.Size = new Size(81, 54);
            label6.TabIndex = 15;
            label6.Text = "EXIT";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // highscoreLabel
            // 
            highscoreLabel.AutoSize = true;
            highscoreLabel.BackColor = Color.Transparent;
            highscoreLabel.Font = new Font("Javanese Text", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            highscoreLabel.ForeColor = Color.White;
            highscoreLabel.Location = new Point(47, 148);
            highscoreLabel.Name = "highscoreLabel";
            highscoreLabel.Size = new Size(135, 47);
            highscoreLabel.TabIndex = 8;
            highscoreLabel.Text = "Highscore: 0";
            highscoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Javanese Text", 18F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(1036, 364);
            label5.Name = "label5";
            label5.Size = new Size(128, 54);
            label5.TabIndex = 14;
            label5.Text = "D - Right";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Javanese Text", 18F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(1036, 324);
            label4.Name = "label4";
            label4.Size = new Size(126, 54);
            label4.TabIndex = 13;
            label4.Text = "S - Down";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Javanese Text", 18F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(1036, 284);
            label3.Name = "label3";
            label3.Size = new Size(112, 54);
            label3.TabIndex = 12;
            label3.Text = "A - Left";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Javanese Text", 18F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1036, 244);
            label2.Name = "label2";
            label2.Size = new Size(105, 54);
            label2.TabIndex = 11;
            label2.Text = "W - Up";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Matura MT Script Capitals", 36F, FontStyle.Italic);
            label1.ForeColor = Color.White;
            label1.Location = new Point(1001, 169);
            label1.Name = "label1";
            label1.Size = new Size(216, 64);
            label1.TabIndex = 10;
            label1.Text = "Controls";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.BackColor = Color.Transparent;
            levelLabel.Font = new Font("Matura MT Script Capitals", 36F, FontStyle.Italic);
            levelLabel.ForeColor = Color.White;
            levelLabel.Location = new Point(21, 89);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new Size(161, 64);
            levelLabel.TabIndex = 9;
            levelLabel.Text = "Level";
            levelLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // enemyImage2
            // 
            enemyImage2.Image = Properties.Resources.Adobe_Express___file__1_;
            enemyImage2.Location = new Point(583, 324);
            enemyImage2.Name = "enemyImage2";
            enemyImage2.Size = new Size(50, 40);
            enemyImage2.SizeMode = PictureBoxSizeMode.StretchImage;
            enemyImage2.TabIndex = 9;
            enemyImage2.TabStop = false;
            // 
            // nextLvlButton
            // 
            nextLvlButton.BackColor = Color.White;
            nextLvlButton.FlatStyle = FlatStyle.Popup;
            nextLvlButton.Font = new Font("Matura MT Script Capitals", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nextLvlButton.ForeColor = Color.FromArgb(29, 0, 86);
            nextLvlButton.Location = new Point(1008, 587);
            nextLvlButton.Name = "nextLvlButton";
            nextLvlButton.Size = new Size(212, 54);
            nextLvlButton.TabIndex = 8;
            nextLvlButton.Text = "Next level";
            nextLvlButton.UseVisualStyleBackColor = false;
            nextLvlButton.Click += nextLvlButton_Click;
            // 
            // enemyImage
            // 
            enemyImage.Image = Properties.Resources.Adobe_Express___file__1_;
            enemyImage.Location = new Point(583, 391);
            enemyImage.Name = "enemyImage";
            enemyImage.Size = new Size(50, 40);
            enemyImage.SizeMode = PictureBoxSizeMode.StretchImage;
            enemyImage.TabIndex = 6;
            enemyImage.TabStop = false;
            // 
            // playerImage
            // 
            playerImage.Image = Properties.Resources.logo__1_;
            playerImage.Location = new Point(583, 239);
            playerImage.Name = "playerImage";
            playerImage.Size = new Size(50, 50);
            playerImage.SizeMode = PictureBoxSizeMode.StretchImage;
            playerImage.TabIndex = 5;
            playerImage.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Matura MT Script Capitals", 72F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(341, 167);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(594, 127);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "Maze Game";
            // 
            // gameLoopTimer
            // 
            gameLoopTimer.Interval = 33;
            gameLoopTimer.Tick += gameLoopTimer_Tick;
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(lostLabel);
            panel2.Location = new Point(945, 800);
            panel2.Name = "panel2";
            panel2.Size = new Size(1271, 683);
            panel2.TabIndex = 7;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Matura MT Script Capitals", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(29, 0, 86);
            button2.Location = new Point(624, 332);
            button2.Name = "button2";
            button2.Size = new Size(233, 51);
            button2.TabIndex = 8;
            button2.Text = "Main menu";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Matura MT Script Capitals", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(29, 0, 86);
            button1.Location = new Point(377, 332);
            button1.Name = "button1";
            button1.Size = new Size(230, 51);
            button1.TabIndex = 8;
            button1.Text = "Restart Level";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 0, 86);
            ClientSize = new Size(1854, 1116);
            Controls.Add(panel2);
            Controls.Add(titleLabel);
            Controls.Add(playButton);
            Controls.Add(subtitleLabel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Maze Game";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)enemyGroupImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemyImage2).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemyImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)playerImage).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lostLabel;
        private Label subtitleLabel;
        private Button playButton;
        private Panel panel1;
        private System.Windows.Forms.Timer gameLoopTimer;
        private PictureBox playerImage;
        private PictureBox enemyImage;
        private Label titleLabel;
        private Panel panel2;
        private Button button2;
        private Button button1;
        private Button nextLvlButton;
        private Label highscoreLabel;
        private PictureBox enemyImage2;
        private Label levelLabel;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label11;
        private Label label10;
        private Label label9;
        private PictureBox enemyGroupImage;
    }
}
