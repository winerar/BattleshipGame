using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleshipGame {
    public class Player {
        public Player() {
            Board = new GameBoard();
            Health = Board.ShipBoard.ShipLocations.Count;
            ShowShips = true;
        }

        public string Name { get; set; }
        public GameBoard Board { get; set; }
        public Player Enemy { get; set; }
        public GameBoard EnemyBoard {
            get => Enemy.Board;
        }
        public int Health { get; set; }
        public bool ShowShips { get; set; }
        public List<Ship> Ships {
            get => Board.Ships;
        }
        public int ShipsLeft {
            get => Ships.Count(ship => ship.IsAlive);
        }

        public bool HitEnemy(Point point) {
            if (EnemyBoard.Hit(point)) {
                Enemy.Health -= 1;
                return true;
            }
            return false;
        }

        public Ship GetShip(Point point) {
            foreach (var ship in Ships) {
                if (ship.Cells.Any(cell => cell.Location == point)) {
                    return ship;
                }
            }
            return default;
        }
    }
}
