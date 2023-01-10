using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficLight;

namespace BattleshipGame {
    public partial class BattleshipControl : UserControl {
        public BattleshipControl() {
            InitializeComponent();
            battleship = new Battleship(gameBoard);
            panelEndGame.Hide();
        }
        
        private Battleship battleship;

        private void buttonRestart_Click(object sender, EventArgs e) {
            battleship.Restart();
            panelEndGame.Hide();
        }

        private void gameBoard_Paint(object sender, PaintEventArgs e) {
            if (battleship.ActivePlayer == battleship.Player) {
                labelArrow.Text = "-->";
                textBoxShipsLeft.Text = $"Ships left: {battleship.Bot.ShipsLeft}";
            } else {
                labelArrow.Text = "<--";
            }
            if (battleship.GameOver) {
                if (battleship.Player.Health == 0) {
                    textBoxEndGame.Text = "You lose...";
                } else {
                    textBoxEndGame.Text = "You win!";
                }
                panelEndGame.Show();
            }
        }

        public Color ShipBackColor {
            get => battleship.ShipBackColor;
            set => battleship.ShipBackColor = value;
        }
        public Color ShipBorderColor {
            get => battleship.ShipBorderColor;
            set => battleship.ShipBorderColor = value;
        }
        public Color CellBackColor {
            get => battleship.CellBackColor;
            set => battleship.CellBackColor = value;
        }
        public Color CellBorderColor {
            get => battleship.CellBorderColor;
            set => battleship.CellBorderColor = value;
        }
        public Color HitColor {
            get => battleship.HitColor;
            set => battleship.HitColor = value;
        }
        public Color PastColor {
            get => battleship.PastColor;
            set => battleship.PastColor = value;
        }
        public Color WaitColor {
            get => battleship.WaitColor;
            set => battleship.WaitColor = value;
        }
        public int BotInterval {
            get => battleship.BotInterval;
            set => battleship.BotInterval = value;
        }
    }
}
