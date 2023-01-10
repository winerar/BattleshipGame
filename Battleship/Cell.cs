using System;
using System.Drawing;
using System.Linq;

namespace BattleshipGame {
    public class Cell {
        public Cell() {
            State = States.Free;
        }

        public enum States { Free, Taken }
        public Point Location { get; set; }
        public States State { get; set; }
    }
}
