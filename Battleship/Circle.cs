using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Figures {
    public class Circle : Figure {
        public Circle() : base() { }

        public Circle(Color backgroundColor = default, Color borderColor = default, Point position = default, Size size = default)
            : base(backgroundColor, borderColor, position, size) {

        }

        public int Diameter {
            get => Size.Width;
            set => Size = new Size(value, value);
        }

        public override void Draw(PaintEventArgs e) {
            using (SolidBrush brush = new SolidBrush(BackgroundColor)) {
                e.Graphics.FillEllipse(brush, new Rectangle(Position, Size));
            }
            using (Pen pen = new Pen(BorderColor)) {
                e.Graphics.DrawEllipse(pen, new Rectangle(Position, Size));
            }
        }
    }
}
