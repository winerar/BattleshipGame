namespace BattleshipGame {
    partial class Form1 {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.battleshipControl1 = new BattleshipGame.BattleshipControl();
            this.SuspendLayout();
            // 
            // battleshipControl1
            // 
            this.battleshipControl1.BotInterval = 1000;
            this.battleshipControl1.CellBackColor = System.Drawing.Color.White;
            this.battleshipControl1.CellBorderColor = System.Drawing.Color.LightGray;
            this.battleshipControl1.HitColor = System.Drawing.Color.DarkRed;
            this.battleshipControl1.Location = new System.Drawing.Point(13, 13);
            this.battleshipControl1.Name = "battleshipControl1";
            this.battleshipControl1.PastColor = System.Drawing.Color.DarkGray;
            this.battleshipControl1.ShipBackColor = System.Drawing.Color.Lavender;
            this.battleshipControl1.ShipBorderColor = System.Drawing.Color.Gray;
            this.battleshipControl1.Size = new System.Drawing.Size(601, 201);
            this.battleshipControl1.TabIndex = 0;
            this.battleshipControl1.WaitColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(862, 329);
            this.Controls.Add(this.battleshipControl1);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private BattleshipControl battleshipControl1;
    }
}

