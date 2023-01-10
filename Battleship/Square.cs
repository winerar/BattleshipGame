using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Figures {
    public class Square : Figure {
        public Square() : base() { }

        public Square(Color backgroundColor = default, Color borderColor = default, Point position = default, Size size = default)
            : base(backgroundColor, borderColor, position, size) {

        }

        public int Side {
            get => Size.Width;
            set => Size = new Size(value, value);
        }

        public override void Draw(PaintEventArgs e) {
            using (SolidBrush brush = new SolidBrush(BackgroundColor)) {
                e.Graphics.FillRectangle(brush, new Rectangle(Position, Size));
            }
            using (Pen pen = new Pen(BorderColor)) {
                e.Graphics.DrawRectangle(pen, new Rectangle(Position, Size));
            }
        }
    }
}
