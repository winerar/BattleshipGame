using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BattleshipGame {
    public class ViewInfo {

        public ViewInfo() {
            Size = new Size(10, 10);
            CellSize = 20;
            CellBorderColor = Color.LightGray;
            CellBackColor = Color.White;
            ShipBackColor = Color.Lavender;
            ShipBorderColor = Color.Gray;
            HitColor = Color.DarkRed;
            PastColor = Color.DarkGray;
            WaitColor = Color.FromArgb(64, Color.LightGray);
        }

        private Battleship battleship;
        public Battleship Battleship {
            get => battleship;
            set {
                battleship = value;
                SetLocations();
            }
        }
        private enum CellStates { Empty, Ship, EmptyHit, ShipHit, ShipKilled }

        public Painter Painter { get; set; }
        public Color ShipBackColor { get; set; }
        public Color ShipBorderColor { get; set; }
        public Color CellBorderColor { get; set; }
        public Color CellBackColor { get; set; }
        public Color HitColor { get; set; }
        public Color PastColor { get; set; }
        public Color WaitColor { get; set; }
        public int HorizontalMargin {
            get => CellSize * 10;
        }
        public int CellSize { get; set; }
        public Size Size { get; set; }
        public Size DrawingSize { get; set; }
        public List<Point> PlayerCellLocations { get; set; }
        public List<Point> PlayerShipLocations { get; set; }
        public List<Point> PlayerHitLocations { get; set; }
        public List<Point> PlayerPastLocations { get; set; }
        public List<Point> BotCellLocations { get; set; }
        public List<Point> BotShipLocations { get; set; }
        public List<Point> HitShipCellsLocations { get; set; }
        public List<Point> KilledShipCellsLocations { get; set; }
        public List<Point> PastCellsLocations { get; set; }
        public List<Ship> PlayerShips {
            get => battleship.PlayerShips;
        }
        public List<Ship> BotShips {
            get => battleship.BotShips;
        }
        public Rectangle PlayerBounds { get; set; }
        public Rectangle BotBounds { get; set; }
        public bool BotMove {
            get => battleship.ActivePlayer == battleship.Bot;
        }
        public bool GameOver {
            get => battleship.GameOver;
        }

        public void Attach(Control control) {
            control.Paint += Painter.Paint;
            control.MouseClick += MouseClick;
        }

        public void Detach(Control control) {
            control.Paint -= Painter.Paint;
            control.MouseClick -= MouseClick;
        }

        public void Update() {
            SetLocations();
        }

        public List<Point> GetCellLocations(List<Cell> cells, Point startPoint) {
            List<Point> cellLocations = new List<Point>();
            foreach (var cell in cells) {
                cellLocations.Add(new Point(startPoint.X + cell.Location.X * CellSize, startPoint.Y + cell.Location.Y * CellSize));
            }
            return cellLocations;
        }

        public void MouseClick(object sender, MouseEventArgs e) {
            if (battleship.ActivePlayer == battleship.Player) {
                if (BotBounds.Contains(e.Location)) {
                    Battleship.Hit(GetPoint(e.Location));
                }
                SetHitLocations();
                Battleship.Update();

                (sender as Control).Invalidate();
            }
        }

        public Point GetPoint(Point location) {
            int x = (location.X - HorizontalMargin - DrawingSize.Width) / CellSize;
            int y = location.Y / CellSize;
            return new Point(x, y);
        }

        private void SetLocations() {
            Point playerLocation = new Point(0, 0);
            DrawingSize = new Size(CellSize * Size.Width, CellSize * Size.Height);
            PlayerBounds = new Rectangle(playerLocation, DrawingSize);
            PlayerCellLocations = GetCellLocations(Battleship.PlayerBoardField, PlayerBounds.Location);
            PlayerShipLocations = GetCellLocations(Battleship.PlayerShipBoardField.FindAll(cell => cell.State == Cell.States.Taken), PlayerBounds.Location);
            foreach (var ship in PlayerShips) {
                ship.DrawingLocations = GetCellLocations(ship.Cells, PlayerBounds.Location);
            }

            Point botLocation = new Point(DrawingSize.Width + HorizontalMargin, 0);
            BotBounds = new Rectangle(botLocation, DrawingSize);
            BotCellLocations = GetCellLocations(Battleship.BotBoardField, BotBounds.Location);
            BotShipLocations = GetCellLocations(Battleship.BotShipBoardField.FindAll(cell => cell.State == Cell.States.Taken), BotBounds.Location);

            SetHitLocations();
        }

        public void SetHitLocations() {
            PlayerHitLocations = GetCellLocations(Battleship.PlayerHitBoardField.FindAll(cell => cell.State == Cell.States.Taken), PlayerBounds.Location);
            PlayerPastLocations = PlayerHitLocations.FindAll(location => !PlayerShipLocations.Contains(location));
            PlayerHitLocations = PlayerHitLocations.FindAll(location => PlayerShipLocations.Contains(location));

            HitShipCellsLocations = new List<Point>();
            KilledShipCellsLocations = new List<Point>();
            SetHitShipLocations(PlayerShips, PlayerBounds);
            SetHitShipLocations(BotShips, BotBounds);


            PastCellsLocations = new List<Point>();
            SetPastCellLocations(battleship.PlayerHitBoardField, PlayerBounds);
            SetPastCellLocations(battleship.BotHitBoardField, BotBounds);
        }

        private void SetHitShipLocations(List<Ship> ships, Rectangle bounds) {
            foreach (var ship in ships) {
                foreach (var cell in ship.Cells) {
                    if (cell.State == Cell.States.Taken) {
                        Point drawingLocation = new Point(bounds.Location.X + cell.Location.X * CellSize, bounds.Location.Y + cell.Location.Y * CellSize);
                        HitShipCellsLocations.Add(drawingLocation);
                        if (!ship.IsAlive) {
                            KilledShipCellsLocations.Add(drawingLocation);
                        }
                    }
                }
            }
        }

        private void SetPastCellLocations(List<Cell> cells, Rectangle bounds) {
            foreach (var cell in cells) {
                if (cell.State == Cell.States.Taken) {
                    PastCellsLocations.Add(new Point(bounds.Location.X + cell.Location.X * CellSize, bounds.Location.Y + cell.Location.Y * CellSize));
                }
            }
        }
    }
}
