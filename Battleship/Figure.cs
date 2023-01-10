using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Figures {
    public class Figure {
        public Figure() : this(default) { }

        public Figure(Color backgroundColor = default, Color borderColor = default, Point position = default, Size size = default) {
            Position = position == default ? Point.Empty : position;
            BackgroundColor = backgroundColor == default ? Color.Empty : backgroundColor;
            BorderColor = borderColor == default ? Color.Empty : borderColor;
            Size = size == default ? Size.Empty : size;
        }

        public Size Size { get; set; }
        private protected Point position;
        public virtual Point Position {
            get => position;
            set => position = value;
        }
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }

        public virtual void Draw(PaintEventArgs e) {

        }
    }
}
