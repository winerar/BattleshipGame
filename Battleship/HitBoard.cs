using System;
using System.Drawing;
using System.Linq;

namespace BattleshipGame {
    public class HitBoard : Board {
        public HitBoard() : base() {

        }

        public HitBoard(int width, int height) : base(width, height) {

        }

        public bool Hit(Point point) {
            Cell cell = GetCell(point);
            if (cell.State != Cell.States.Free) {
                return false;
            }
            cell.State = Cell.States.Taken;
            return true;
        }

        public Cell GetCell(Point point) {
            return field.Find(cell => cell.Location.X == point.X
                && cell.Location.Y == point.Y);
        }

        public bool PointIsHit(Point point) {
            if (GetCell(point).State == Cell.States.Free) {
                return false;
            }
            return true;
        }
    }
}
