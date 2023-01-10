using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BattleshipGame {
    public class Ship {
        public Ship() {
            Size = new Point(1, 1);
            IsAlive = true;
            Cells = new List<Cell>();
        }

        private Point size;
        private Point Size {
            get => size;
            set {
                size = value;
                SetHealth();
            }
        }
        public int Width {
            get => size.X;
            set {
                size.X = value > 0 ? value : 1;
                SetHealth();
            }
        }
        public int Length {
            get => size.Y;
            set {
                size.Y = value > 0 ? value : 1;
                SetHealth();
            }
        }
        public bool IsAlive { get; set; }
        public List<Cell> Cells { get; set; }
        public List<Point> DrawingLocations { get; set; }
        private int health;
        public int Health {
            get => health;
            set {
                health = value;
                if (health <= 0) {
                    IsAlive = false;
                }
            }
        }

        private void SetHealth() {
            health = size.X * size.Y;
        }
    }
}
