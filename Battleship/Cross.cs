using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Figures {
    public class Cross : Figure {
        public Cross() : base() { }

        public Cross(Color backgroundColor = default, Color borderColor = default, Point position = default, Size size = default)
            : base(backgroundColor, borderColor, position, size) {

        }

        public override void Draw(PaintEventArgs e) {
            Point point1 = new Point(Position.X, Position.Y);
            Point point2 = new Point(Position.X + Size.Width, Position.Y + Size.Height);
            Point point3 = new Point(Position.X + Size.Width, Position.Y);
            Point point4 = new Point(Position.X, Position.Y + Size.Height);
            using (Pen pen = new Pen(BorderColor)) {
                e.Graphics.DrawLine(pen, point1, point2);
                e.Graphics.DrawLine(pen, point3, point4);
            }
        }
    }
}
