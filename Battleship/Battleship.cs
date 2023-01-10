using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace BattleshipGame {
    public class Battleship {
        public Battleship(Control control) {
            this.control = control;
            Start();
        }

        private Control control;
        public Player Player { get; set; }
        public AI Bot { get; set; }
        private int botInterval;
        public int BotInterval {
            get => botInterval;
            set {
                botInterval = value > 0 ? value : 1;
            }
        }
        private Player activePlayer;
        public Player ActivePlayer {
            get => activePlayer;
            set {
                activePlayer = value;
            }
        }
        public bool GameOver {
            get => Player.Health == 0 || Bot.Health == 0;
        }
        private ViewInfo viewInfo;
        private Painter painter;
        public List<Cell> PlayerShipBoardField {
            get => Player.Board.ShipBoard.Field;
        }
        public List<Cell> PlayerBoardField {
            get => Player.Board.Field;
        }
        public List<Cell> PlayerHitBoardField {
            get => Player.Board.HitBoard.Field;
        }
        public List<Cell> BotShipBoardField {
            get => Player.EnemyBoard.ShipBoard.Field;
        }
        public List<Cell> BotBoardField {
            get => Player.EnemyBoard.Field;
        }
        public List<Cell> BotHitBoardField {
            get => Player.EnemyBoard.HitBoard.Field;
        }
        public List<Ship> PlayerShips {
            get => Player.Ships;
        }
        public List<Ship> BotShips {
            get => Bot.Ships;
        }
        private System.Timers.Timer timer;
        public Color ShipBackColor {
            get => viewInfo.ShipBackColor;
            set => viewInfo.ShipBackColor = value;
        }
        public Color ShipBorderColor {
            get => viewInfo.ShipBorderColor;
            set => viewInfo.ShipBorderColor = value;
        }
        public Color CellBackColor {
            get => viewInfo.CellBackColor;
            set => viewInfo.CellBackColor = value;
        }
        public Color CellBorderColor {
            get => viewInfo.CellBorderColor;
            set => viewInfo.CellBorderColor = value;
        }
        public Color HitColor {
            get => viewInfo.HitColor;
            set => viewInfo.HitColor = value;
        }
        public Color PastColor {
            get => viewInfo.PastColor;
            set => viewInfo.PastColor = value;
        }
        public Color WaitColor {
            get => viewInfo.WaitColor;
            set => viewInfo.WaitColor = value;
        }

        public void BotMove() {
            timer = new System.Timers.Timer(BotInterval);
            timer.Elapsed += HitPlayer;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void HitPlayer(object sender, ElapsedEventArgs e) {
            if (GameOver) {
                timer.Stop();
                timer.Dispose();
            } else if (!Bot.HitPlayer()) {
                timer.Stop();
                timer.Dispose();
                activePlayer = Player;
            }
            viewInfo.SetHitLocations();
            control.Invalidate();
        }

        public void Hit(Point point) {
            if (GameOver) {
                Update();
                return;
            }
            if (Player.EnemyBoard.HitBoard.PointIsHit(point)) {
                return;
            }
            if (!Player.HitEnemy(point)) {
                ActivePlayer = ActivePlayer == Player ? Bot : Player;
                BotMove();
            }
        }

        public void Start() {
            if (viewInfo != null) {
                viewInfo.Detach(control);
            }
            viewInfo = new ViewInfo();
            painter = new Painter();
            viewInfo.Painter = painter;

            viewInfo.Attach(control);

            Player = new Player();
            Player.ShowShips = true;
            Bot = new AI();
            Bot.ShowShips = false;
            ActivePlayer = Player;
            Player.Enemy = Bot;
            Bot.Enemy = Player;
            BotInterval = 1000;

            viewInfo.Battleship = this;

            painter.ViewInfo = viewInfo;

            control.Invalidate();
        }

        public void Restart() {
            Player = new Player();
            Player.ShowShips = true;
            Bot = new AI();
            Bot.ShowShips = false;
            ActivePlayer = Player;
            Player.Enemy = Bot;
            Bot.Enemy = Player;
            viewInfo.Update();
            control.Invalidate();
        }

        public void Update() {
            if (GameOver) {
                Bot.ShowShips = true;
            }
        }
    }
}
