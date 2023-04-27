using System.Drawing;
using System.Drawing.Drawing2D;

namespace SimplePainterApplication
{
    public enum RulerOrientation
    {
        Horizontal,
        Vertical
    }

    public class Ruler
    {
        private int _position;
        private int _size;
        private readonly Color _color;
        private readonly RulerOrientation _orientation;

        public Ruler(RulerOrientation orientation, int position, int size, Color color)
        {
            _orientation = orientation;
            _position = position;
            _size = size;
            _color = color;
        }

        public void Draw(Graphics g)
        {
            using var pen = new Pen(_color);
            using var brush = new SolidBrush(_color);

            if (_orientation == RulerOrientation.Horizontal)
            {
                g.DrawLine(pen, 0, _position, _size, _position);

                for (int i = 0; i < _size; i += 10)
                {
                    g.DrawLine(pen, i, _position - 5, i, _position + 5);

                    if (i % 50 == 0)
                    {
                        g.DrawString(i.ToString(), SystemFonts.DefaultFont, brush, i + 2, _position + 10);
                    }
                }
            }
            else
            {
                g.DrawLine(pen, _position, 0, _position, _size);

                for (int i = 0; i < _size; i += 10)
                {
                    g.DrawLine(pen, _position - 5, i, _position + 5, i);

                    if (i % 50 == 0)
                    {
                        g.DrawString(i.ToString(), SystemFonts.DefaultFont, brush, _position + 10, i - 6);
                    }
                }
            }
        }

        public int Position
        {
            get => _position;
            set => _position = value;
        }

        public int Size
        {
            get => _size;
            set => _size = value;
        }

        public RulerOrientation Orientation => _orientation;
    }

    public class Guideline
    {
        public int Position { get; set; }
        public bool Horizontal { get; set; }
        public Pen Pen { get; set; }
        public bool Visible { get; set; } = true; // Add this line

        public void Draw(Graphics g)
        {
            if (!Visible) return; // Add this line

            if (Horizontal)
            {
                g.DrawLine(Pen, 0, Position, g.VisibleClipBounds.Width, Position);
            }
            else
            {
                g.DrawLine(Pen, Position, 0, Position, g.VisibleClipBounds.Height);
            }
        }
    }

}
