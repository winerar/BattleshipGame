using Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace BattleshipGame {
    public class Painter {
        public Painter() {

        }

        public ViewInfo ViewInfo { get; set; }
        private PaintEventArgs e;

        public void Paint(object sender, PaintEventArgs e) {
            this.e = e;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            DrawCells(ViewInfo.PlayerCellLocations);
            DrawCells(ViewInfo.BotCellLocations);
            DrawShips(ViewInfo.PlayerShipLocations);
            if (ViewInfo.GameOver) {
                DrawShips(ViewInfo.BotShipLocations);
            }
            DrawPastCells();
            DrawKilledShips();
            DrawHitCells();
            DrawForeground();
        }

        private void DrawCells(List<Point> locations) {
            foreach (var location in locations) {
                var square = new Square(ViewInfo.CellBackColor, ViewInfo.CellBorderColor) {
                    Side = ViewInfo.CellSize,
                    Position = location,
                };
                square.Draw(e);
            }
        }

        private void DrawShips(List<Point> locations) {
            foreach (var location in locations) {
                var square = new Square(ViewInfo.ShipBackColor, ViewInfo.ShipBorderColor) {
                    Side = ViewInfo.CellSize,
                    Position = location,
                };
                square.Draw(e);
            }
        }

        private void DrawPastCells() {
            foreach (var location in ViewInfo.PastCellsLocations) {
                var circle = new Circle() {
                    Diameter = ViewInfo.CellSize / 2,
                    Position = new Point(location.X + ViewInfo.CellSize / 4, location.Y + ViewInfo.CellSize / 4),
                    BackgroundColor = ViewInfo.PastColor,
                };
                circle.Draw(e);
            }
        }

        private void DrawKilledShips() {
            foreach (var location in ViewInfo.KilledShipCellsLocations) {
                var square = new Square(ViewInfo.ShipBackColor, ViewInfo.HitColor) {
                    Side = ViewInfo.CellSize,
                    Position = location,
                };
                square.Draw(e);
            }
        }

        private void DrawHitCells() {
            foreach (var location in ViewInfo.HitShipCellsLocations) {
                var square = new Square(ViewInfo.ShipBackColor) {
                    Side = ViewInfo.CellSize,
                    Position = location,
                };
                square.Draw(e);
                var cross = new Cross() {
                    Size = new Size(ViewInfo.CellSize, ViewInfo.CellSize),
                    Position = location,
                    BorderColor = ViewInfo.HitColor,
                };
                cross.Draw(e);
            }
        }

        private void DrawForeground() {
            if (!ViewInfo.GameOver) {
                var foreground = new Square(ViewInfo.WaitColor) {
                    Side = ViewInfo.BotBounds.Width,
                    Position = ViewInfo.BotBounds.Location,
                };
                if (ViewInfo.BotMove) {
                    foreground.Side = ViewInfo.BotBounds.Width;
                    foreground.Position = ViewInfo.BotBounds.Location;
                } else {
                    foreground.Side = ViewInfo.PlayerBounds.Width;
                    foreground.Position = ViewInfo.PlayerBounds.Location;
                }
                foreground.Draw(e);
            }
        }
    }
}
