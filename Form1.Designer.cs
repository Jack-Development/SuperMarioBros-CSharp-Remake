namespace SuperMarioBros
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tmrGame = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.spriteClock = new System.Windows.Forms.Timer(this.components);
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.scoreDisplay = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.TimeCounter = new System.Windows.Forms.Label();
            this.WorldTitle = new System.Windows.Forms.Label();
            this.LevelName = new System.Windows.Forms.Label();
            this.CoinCount = new System.Windows.Forms.Label();
            this.posXDebug = new System.Windows.Forms.Label();
            this.posYDebug = new System.Windows.Forms.Label();
            this.offsetDebug = new System.Windows.Forms.Label();
            this.GoombaSpeed = new System.Windows.Forms.Label();
            this.Menu1 = new System.Windows.Forms.Label();
            this.Menu2 = new System.Windows.Forms.Label();
            this.MenuTop = new System.Windows.Forms.Label();
            this.MenuSelector = new System.Windows.Forms.PictureBox();
            this.LivesCountText = new System.Windows.Forms.Label();
            this.MarioLife = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MenuSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // spriteClock
            // 
            this.spriteClock.Enabled = true;
            this.spriteClock.Interval = 300;
            this.spriteClock.Tick += new System.EventHandler(this.spriteClock_Tick_1);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.ForeColor = System.Drawing.Color.White;
            this.ScoreLabel.Location = new System.Drawing.Point(12, 9);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(48, 20);
            this.ScoreLabel.TabIndex = 0;
            this.ScoreLabel.Text = "Mario";
            // 
            // scoreDisplay
            // 
            this.scoreDisplay.AutoSize = true;
            this.scoreDisplay.BackColor = System.Drawing.Color.Transparent;
            this.scoreDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreDisplay.ForeColor = System.Drawing.Color.White;
            this.scoreDisplay.Location = new System.Drawing.Point(12, 29);
            this.scoreDisplay.Name = "scoreDisplay";
            this.scoreDisplay.Size = new System.Drawing.Size(63, 20);
            this.scoreDisplay.TabIndex = 1;
            this.scoreDisplay.Text = "000000";
            // 
            // TimeLabel
            // 
            this.TimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.ForeColor = System.Drawing.Color.White;
            this.TimeLabel.Location = new System.Drawing.Point(710, 9);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(43, 20);
            this.TimeLabel.TabIndex = 2;
            this.TimeLabel.Text = "Time";
            // 
            // TimeCounter
            // 
            this.TimeCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeCounter.AutoSize = true;
            this.TimeCounter.BackColor = System.Drawing.Color.Transparent;
            this.TimeCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeCounter.ForeColor = System.Drawing.Color.White;
            this.TimeCounter.Location = new System.Drawing.Point(727, 29);
            this.TimeCounter.Name = "TimeCounter";
            this.TimeCounter.Size = new System.Drawing.Size(36, 20);
            this.TimeCounter.TabIndex = 3;
            this.TimeCounter.Text = "000";
            // 
            // WorldTitle
            // 
            this.WorldTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WorldTitle.AutoSize = true;
            this.WorldTitle.BackColor = System.Drawing.Color.Transparent;
            this.WorldTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorldTitle.ForeColor = System.Drawing.Color.White;
            this.WorldTitle.Location = new System.Drawing.Point(466, 9);
            this.WorldTitle.Name = "WorldTitle";
            this.WorldTitle.Size = new System.Drawing.Size(50, 20);
            this.WorldTitle.TabIndex = 4;
            this.WorldTitle.Text = "World";
            // 
            // LevelName
            // 
            this.LevelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LevelName.AutoSize = true;
            this.LevelName.BackColor = System.Drawing.Color.Transparent;
            this.LevelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelName.ForeColor = System.Drawing.Color.White;
            this.LevelName.Location = new System.Drawing.Point(475, 29);
            this.LevelName.Name = "LevelName";
            this.LevelName.Size = new System.Drawing.Size(32, 20);
            this.LevelName.TabIndex = 5;
            this.LevelName.Text = "1-1";
            this.LevelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CoinCount
            // 
            this.CoinCount.AutoSize = true;
            this.CoinCount.BackColor = System.Drawing.Color.Transparent;
            this.CoinCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoinCount.ForeColor = System.Drawing.Color.White;
            this.CoinCount.Location = new System.Drawing.Point(233, 29);
            this.CoinCount.Name = "CoinCount";
            this.CoinCount.Size = new System.Drawing.Size(34, 20);
            this.CoinCount.TabIndex = 7;
            this.CoinCount.Text = "x00";
            this.CoinCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // posXDebug
            // 
            this.posXDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.posXDebug.AutoSize = true;
            this.posXDebug.BackColor = System.Drawing.Color.Transparent;
            this.posXDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posXDebug.ForeColor = System.Drawing.Color.White;
            this.posXDebug.Location = new System.Drawing.Point(693, 392);
            this.posXDebug.Name = "posXDebug";
            this.posXDebug.Size = new System.Drawing.Size(50, 20);
            this.posXDebug.TabIndex = 8;
            this.posXDebug.Text = "posX:";
            this.posXDebug.Visible = false;
            // 
            // posYDebug
            // 
            this.posYDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.posYDebug.AutoSize = true;
            this.posYDebug.BackColor = System.Drawing.Color.Transparent;
            this.posYDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posYDebug.ForeColor = System.Drawing.Color.White;
            this.posYDebug.Location = new System.Drawing.Point(693, 412);
            this.posYDebug.Name = "posYDebug";
            this.posYDebug.Size = new System.Drawing.Size(50, 20);
            this.posYDebug.TabIndex = 9;
            this.posYDebug.Text = "posY:";
            this.posYDebug.Visible = false;
            // 
            // offsetDebug
            // 
            this.offsetDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.offsetDebug.AutoSize = true;
            this.offsetDebug.BackColor = System.Drawing.Color.Transparent;
            this.offsetDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offsetDebug.ForeColor = System.Drawing.Color.White;
            this.offsetDebug.Location = new System.Drawing.Point(693, 372);
            this.offsetDebug.Name = "offsetDebug";
            this.offsetDebug.Size = new System.Drawing.Size(57, 20);
            this.offsetDebug.TabIndex = 10;
            this.offsetDebug.Text = "Offset:";
            this.offsetDebug.Visible = false;
            // 
            // GoombaSpeed
            // 
            this.GoombaSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GoombaSpeed.AutoSize = true;
            this.GoombaSpeed.BackColor = System.Drawing.Color.Transparent;
            this.GoombaSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoombaSpeed.ForeColor = System.Drawing.Color.White;
            this.GoombaSpeed.Location = new System.Drawing.Point(12, 60);
            this.GoombaSpeed.Name = "GoombaSpeed";
            this.GoombaSpeed.Size = new System.Drawing.Size(118, 20);
            this.GoombaSpeed.TabIndex = 11;
            this.GoombaSpeed.Text = "GoombaSpeed";
            this.GoombaSpeed.Visible = false;
            // 
            // Menu1
            // 
            this.Menu1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu1.AutoSize = true;
            this.Menu1.BackColor = System.Drawing.Color.Transparent;
            this.Menu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu1.ForeColor = System.Drawing.Color.White;
            this.Menu1.Location = new System.Drawing.Point(313, 277);
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(113, 20);
            this.Menu1.TabIndex = 12;
            this.Menu1.Text = "1 Player Game";
            // 
            // Menu2
            // 
            this.Menu2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu2.AutoSize = true;
            this.Menu2.BackColor = System.Drawing.Color.Transparent;
            this.Menu2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Menu2.ForeColor = System.Drawing.Color.White;
            this.Menu2.Location = new System.Drawing.Point(313, 310);
            this.Menu2.Name = "Menu2";
            this.Menu2.Size = new System.Drawing.Size(113, 20);
            this.Menu2.TabIndex = 13;
            this.Menu2.Text = "2 Player Game";
            // 
            // MenuTop
            // 
            this.MenuTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuTop.AutoSize = true;
            this.MenuTop.BackColor = System.Drawing.Color.Transparent;
            this.MenuTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuTop.ForeColor = System.Drawing.Color.White;
            this.MenuTop.Location = new System.Drawing.Point(313, 365);
            this.MenuTop.Name = "MenuTop";
            this.MenuTop.Size = new System.Drawing.Size(98, 20);
            this.MenuTop.TabIndex = 14;
            this.MenuTop.Text = "TOP - 00000";
            // 
            // MenuSelector
            // 
            this.MenuSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(148)))), ((int)(((byte)(252)))));
            this.MenuSelector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuSelector.Image = global::SuperMarioBros.Properties.Resources.MenuSelect;
            this.MenuSelector.InitialImage = global::SuperMarioBros.Properties.Resources.MenuSelect;
            this.MenuSelector.Location = new System.Drawing.Point(253, 277);
            this.MenuSelector.Name = "MenuSelector";
            this.MenuSelector.Size = new System.Drawing.Size(16, 16);
            this.MenuSelector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MenuSelector.TabIndex = 16;
            this.MenuSelector.TabStop = false;
            this.MenuSelector.Click += new System.EventHandler(this.MenuSelector_Click);
            // 
            // LivesCountText
            // 
            this.LivesCountText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LivesCountText.AutoSize = true;
            this.LivesCountText.BackColor = System.Drawing.Color.Transparent;
            this.LivesCountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LivesCountText.ForeColor = System.Drawing.Color.White;
            this.LivesCountText.Location = new System.Drawing.Point(345, 235);
            this.LivesCountText.Name = "LivesCountText";
            this.LivesCountText.Size = new System.Drawing.Size(38, 20);
            this.LivesCountText.TabIndex = 17;
            this.LivesCountText.Text = "x 00";
            // 
            // MarioLife
            // 
            this.MarioLife.AutoSize = true;
            this.MarioLife.BackColor = System.Drawing.Color.Transparent;
            this.MarioLife.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MarioLife.ForeColor = System.Drawing.Color.White;
            this.MarioLife.Location = new System.Drawing.Point(345, 190);
            this.MarioLife.Name = "MarioLife";
            this.MarioLife.Size = new System.Drawing.Size(48, 20);
            this.MarioLife.TabIndex = 18;
            this.MarioLife.Text = "Mario";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MarioLife);
            this.Controls.Add(this.LivesCountText);
            this.Controls.Add(this.MenuSelector);
            this.Controls.Add(this.MenuTop);
            this.Controls.Add(this.Menu2);
            this.Controls.Add(this.Menu1);
            this.Controls.Add(this.GoombaSpeed);
            this.Controls.Add(this.offsetDebug);
            this.Controls.Add(this.posYDebug);
            this.Controls.Add(this.posXDebug);
            this.Controls.Add(this.CoinCount);
            this.Controls.Add(this.LevelName);
            this.Controls.Add(this.WorldTitle);
            this.Controls.Add(this.TimeCounter);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.scoreDisplay);
            this.Controls.Add(this.ScoreLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Super Mario Bros.";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.MenuSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrGame;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer spriteClock;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label scoreDisplay;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label TimeCounter;
        private System.Windows.Forms.Label WorldTitle;
        private System.Windows.Forms.Label LevelName;
        private System.Windows.Forms.Label CoinCount;
        private System.Windows.Forms.Label posXDebug;
        private System.Windows.Forms.Label posYDebug;
        private System.Windows.Forms.Label offsetDebug;
        private System.Windows.Forms.Label GoombaSpeed;
        private System.Windows.Forms.Label Menu1;
        private System.Windows.Forms.Label Menu2;
        private System.Windows.Forms.Label MenuTop;
        private System.Windows.Forms.PictureBox MenuSelector;
        private System.Windows.Forms.Label LivesCountText;
        private System.Windows.Forms.Label MarioLife;
    }
}

