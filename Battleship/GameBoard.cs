using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleshipGame {
    public class GameBoard : Board {
        public GameBoard() : base() {
            // size = new Size(10, 10);
            CreateBoards();
            CreateShips();
            CellSize = 20;
        }

        private int cellSize;
        public int CellSize {
            get => cellSize;
            set {
                cellSize = value;
            }
        }
        private ShipBoard shipBoard;
        public ShipBoard ShipBoard {
            get => shipBoard;
        }
        private HitBoard hitBoard;
        public HitBoard HitBoard {
            get => hitBoard;
        }
        public List<Ship> Ships { get; set; }

        private void CreateBoards() {
            shipBoard = new ShipBoard(Size.Width, Size.Height);
            hitBoard = new HitBoard(Size.Width, Size.Height);
        }

        public bool Hit(Point point) {
            Cell cell = HitBoard.GetCell(point);
            if (cell.State == Cell.States.Free) {
                cell.State = Cell.States.Taken;
            }
            if (!shipBoard.Hit(point)) {
                return false;
            }
            return true;
        }

        public bool PointIsHit(Point point) {
            return hitBoard.PointIsHit(point);
        }

        private void CreateShips() {
            Ships = new List<Ship>();
            int carrierSize = 5;
            int battleShipSize = 4;
            int destroyerSize = 3;
            int patrolBoatSize = 2;
            for (int i = 0; i < 1; i++) {
                Ships.Add(new Ship() {
                    Length = carrierSize
                });
            }
            for (int i = 0; i < 2; i++) {
                Ships.Add(new Ship() {
                    Length = battleShipSize
                });
            }
            for (int i = 0; i < 3; i++) {
                Ships.Add(new Ship() {
                    Length = destroyerSize
                });
            }
            for (int i = 0; i < 4; i++) {
                Ships.Add(new Ship() {
                    Length = patrolBoatSize
                });
            }

            shipBoard.PlaceShips(Ships);
        }
    }
}
