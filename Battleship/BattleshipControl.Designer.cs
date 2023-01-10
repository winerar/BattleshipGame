namespace BattleshipGame {
    partial class BattleshipControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gameBoard = new Traffic_Light.DoubleBufferedPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.labelArrow = new System.Windows.Forms.Label();
            this.panelEndGame = new System.Windows.Forms.Panel();
            this.textBoxEndGame = new System.Windows.Forms.TextBox();
            this.textBoxShipsLeft = new System.Windows.Forms.TextBox();
            this.gameBoard.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelEndGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameBoard
            // 
            this.gameBoard.Controls.Add(this.panelEndGame);
            this.gameBoard.Controls.Add(this.panel1);
            this.gameBoard.Location = new System.Drawing.Point(0, 0);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(601, 201);
            this.gameBoard.TabIndex = 0;
            this.gameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.gameBoard_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxShipsLeft);
            this.panel1.Controls.Add(this.labelArrow);
            this.panel1.Controls.Add(this.buttonRestart);
            this.panel1.Location = new System.Drawing.Point(201, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(199, 201);
            this.panel1.TabIndex = 1;
            // 
            // buttonRestart
            // 
            this.buttonRestart.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestart.Location = new System.Drawing.Point(23, 153);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(153, 25);
            this.buttonRestart.TabIndex = 0;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // labelArrow
            // 
            this.labelArrow.AutoSize = true;
            this.labelArrow.Font = new System.Drawing.Font("JetBrains Mono", 20F);
            this.labelArrow.Location = new System.Drawing.Point(67, 70);
            this.labelArrow.Name = "labelArrow";
            this.labelArrow.Size = new System.Drawing.Size(63, 36);
            this.labelArrow.TabIndex = 2;
            this.labelArrow.Text = "-->";
            this.labelArrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelEndGame
            // 
            this.panelEndGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEndGame.Controls.Add(this.textBoxEndGame);
            this.panelEndGame.Location = new System.Drawing.Point(150, 47);
            this.panelEndGame.Name = "panelEndGame";
            this.panelEndGame.Padding = new System.Windows.Forms.Padding(15);
            this.panelEndGame.Size = new System.Drawing.Size(300, 100);
            this.panelEndGame.TabIndex = 2;
            // 
            // textBoxEndGame
            // 
            this.textBoxEndGame.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEndGame.Font = new System.Drawing.Font("JetBrains Mono SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEndGame.Location = new System.Drawing.Point(18, 32);
            this.textBoxEndGame.Name = "textBoxEndGame";
            this.textBoxEndGame.ReadOnly = true;
            this.textBoxEndGame.Size = new System.Drawing.Size(264, 36);
            this.textBoxEndGame.TabIndex = 0;
            this.textBoxEndGame.Text = "You win!";
            this.textBoxEndGame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxShipsLeft
            // 
            this.textBoxShipsLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxShipsLeft.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxShipsLeft.Font = new System.Drawing.Font("JetBrains Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxShipsLeft.Location = new System.Drawing.Point(23, 24);
            this.textBoxShipsLeft.Name = "textBoxShipsLeft";
            this.textBoxShipsLeft.ReadOnly = true;
            this.textBoxShipsLeft.Size = new System.Drawing.Size(153, 18);
            this.textBoxShipsLeft.TabIndex = 3;
            this.textBoxShipsLeft.Text = "Ships left: 0";
            this.textBoxShipsLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BattleshipControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gameBoard);
            this.Name = "BattleshipControl";
            this.Size = new System.Drawing.Size(601, 201);
            this.gameBoard.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelEndGame.ResumeLayout(false);
            this.panelEndGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Traffic_Light.DoubleBufferedPanel gameBoard;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelArrow;
        private System.Windows.Forms.Panel panelEndGame;
        private System.Windows.Forms.TextBox textBoxEndGame;
        private System.Windows.Forms.TextBox textBoxShipsLeft;
    }
}
