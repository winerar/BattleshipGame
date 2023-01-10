using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleshipGame {
    public class Board {

        public Board() : this(10, 10) { }

        public Board(int width, int height) {
            size = new Size(width, height);
            CreateField();
        }

        private Size size;
        public Size Size {
            get => size;
        }
        public List<Cell> field;
        public List<Cell> Field { get => field; }

        private void CreateField() {
            field = new List<Cell>();
            for (int i = 0; i < Size.Width; i++) {
                for (int j = 0; j < Size.Height; j++) {
                    field.Add(new Cell() {
                        Location = new Point(i, j),
                    });
                }
            }
        }

        public void Clear() {
            CreateField();
        }
        public List<Cell> Range(int startRow,
                                    int startColumn,
                                    int endRow,
                                    int endColumn) {
            return Range(field, startRow, startColumn, endRow, endColumn);
        }
        public List<Cell> Range(List<Cell> cells, int startRow,
                                    int startColumn,
                                    int endRow,
                                    int endColumn) {
            return cells.Where(cell => cell.Location.X >= startRow
                                     && cell.Location.Y >= startColumn
                                     && cell.Location.X <= endRow
                                     && cell.Location.Y <= endColumn).ToList();
        }
    }
}
