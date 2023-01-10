using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleshipGame {
    public class AI : Player {
        public AI() : base() {
            Name = "Computer";
            previousHits = new List<Point>();
            emptyCells = new List<Cell>();
        }

        private List<Point> previousHits;
        private List<Cell> emptyCells;

        public bool HitPlayer() {
            Point point = Point.Empty;
            Random random = new Random();
            List<Point> possiblePoints = new List<Point>();
            if (previousHits.Count == 1) {
                int x = previousHits.First().X;
                int y = previousHits.First().Y;
                possiblePoints = new List<Point> {
                    new Point(x + 1, y),
                    new Point(x - 1, y),
                    new Point(x, y + 1),
                    new Point(x, y - 1),
                };
            } else if (previousHits.Count > 1) {
                previousHits.Sort((p1, p2) => (p1.X + p1.Y) - (p2.X + p2.Y));
                int x, y;
                if (previousHits.First().X == previousHits.Last().X) {
                    x = previousHits.First().X;
                    possiblePoints = new List<Point>() {
                        new Point(x, previousHits.First().Y - 1),
                        new Point(x, previousHits.Last().Y + 1),
                    };
                } else {
                    y = previousHits.First().Y;
                    possiblePoints = new List<Point>() {
                        new Point(previousHits.First().X - 1, y),
                        new Point(previousHits.Last().X + 1, y),
                    };
                }
            }
            possiblePoints = possiblePoints.OrderBy(index => random.Next()).ToList();
            foreach (var possiblePoint in possiblePoints) {
                if (possiblePoint.X < 0 ||
                    possiblePoint.Y < 0 ||
                    possiblePoint.X >= EnemyBoard.Size.Width ||
                    possiblePoint.Y >= EnemyBoard.Size.Height
                    || emptyCells.Any(cell => cell.Location.Equals(possiblePoint))) {
                    continue;
                }
                if (EnemyBoard.HitBoard.GetCell(possiblePoint).State == Cell.States.Free) {
                    point = possiblePoint;
                    break;
                }
            }
            if (point.IsEmpty) {
                List<Cell> freeCells = EnemyBoard.HitBoard.Field.FindAll(cell => cell.State == Cell.States.Free);
                if (freeCells.Count == 0) {
                    return false;
                }
                do {
                    point = freeCells[random.Next(freeCells.Count)].Location;
                } while (emptyCells.Any(cell => cell.Location.Equals(point)));
            }
            if (HitEnemy(point)) {
                if (Enemy.GetShip(point).IsAlive) {
                    previousHits.Add(point);
                } else {
                    emptyCells.AddRange(EnemyBoard.Range(
                        previousHits.First().X - 1,
                        previousHits.First().Y - 1,
                        previousHits.Last().X + 1,
                        previousHits.Last().Y + 1));
                    previousHits.Clear();
                }
                return true;
            }
            return false;
        }
    }
}
