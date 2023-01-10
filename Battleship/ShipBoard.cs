using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleshipGame {
    public class ShipBoard : Board {
        public ShipBoard() : base() {

        }

        public ShipBoard(int width, int height) : base(width, height) {

        }

        public List<Ship> Ships { get; set; }
        public List<Point> ShipLocations { get; set; }

        public void PlaceShips(List<Ship> ships) {
            Ships = ships;
            Clear();

            ShipLocations = new List<Point>();

            Random random = new Random(Guid.NewGuid().GetHashCode());
            foreach (Ship ship in ships) {
                bool isOpen = true;
                ship.Cells = new List<Cell>();
                while (isOpen) {
                    var startColumn = random.Next(Size.Width);
                    var startRow = random.Next(Size.Height);
                    int endRow = startRow;
                    int endColumn = startColumn;
                    var orientation = random.Next(Size.Width) % 2;

                    if (orientation == 0) {
                        endRow += ship.Length - 1;
                        endColumn += ship.Width - 1;
                    } else {
                        endRow += ship.Width - 1;
                        endColumn += ship.Length - 1;
                    }

                    if (endRow >= Size.Height || endColumn >= Size.Width) {
                        isOpen = true;
                        continue;
                    }

                    var affectedCells = Range(startRow - 1, startColumn - 1, endRow + 1, endColumn + 1);
                    var shipCells = Range(affectedCells, startRow, startColumn, endRow, endColumn);

                    if (affectedCells.Any(cell => cell.State == Cell.States.Taken)) {
                        isOpen = true;
                        continue;
                    }

                    foreach (var cell in shipCells) {
                        cell.State = Cell.States.Taken;
                        ShipLocations.Add(cell.Location);
                        ship.Cells.Add(new Cell() { Location = cell.Location });
                    }
                    isOpen = false;
                }
            }
        }

        public bool Hit(Point point) {
            bool result = false;
            foreach (var ship in Ships.FindAll(ship => ship.IsAlive)) {
                Cell hitCell = ship.Cells.Find(cell => cell.Location == point);
                if (hitCell == default) {
                    continue;
                }
                if (hitCell.State == Cell.States.Taken) {
                    return false;
                }
                hitCell.State = Cell.States.Taken;
                ship.Health -= 1;
                result = true;
            }
            return result;
        }
    }
}
