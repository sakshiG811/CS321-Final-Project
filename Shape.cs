using System.Drawing.Drawing2D;

namespace SimplePainterApplication;

public enum ShapeType
{
    Ellipse,
    Rectangle,
    Square,
    Circle,
    Line,
    Freeform,
}

public class Shape
{
    public Color StrokeColor;
    public float StrokeThickness;
    public float X;
    public float Y;
    public float Width;
    public float Height;
    public Color FillColor;
    public bool Filled;
    public ShapeType Type;


    public List<Point> Points { get; set; }
    public bool Selected { get; set; }
    public Color SelectedFillColor { get; set; }


    public void Draw(Graphics g)
    {
        using var pen = new Pen(StrokeColor, StrokeThickness);
        using var brush = new SolidBrush(FillColor);

        if (Selected)
        {
            pen.Color = Color.Red;
            brush.Color = SelectedFillColor;
        }

        switch (Type)
        {
            case ShapeType.Ellipse:
                if (Filled)
                {
                    g.FillEllipse(brush, X, Y, Width, Height);
                }

                g.DrawEllipse(pen, X, Y, Width, Height);
                break;

            case ShapeType.Rectangle:
                if (Filled)
                {
                    g.FillRectangle(brush, X, Y, Width, Height);
                }

                g.DrawRectangle(pen, X, Y, Width, Height);
                break;

            case ShapeType.Square:
                float side = Math.Min(Width, Height);
                if (Filled)
                {
                    g.FillRectangle(brush, X, Y, side, side);
                }
                g.DrawRectangle(pen, X, Y, side, side);
                break;

            case ShapeType.Line:
                g.DrawLine(pen, X, Y, X + Width, Y + Height);
                break;

            case ShapeType.Freeform:
                if (Points != null && Points.Count > 1)
                {
                    g.DrawLines(pen, Points.ToArray());
                }
                break;

            case ShapeType.Circle:
                float diameter = Math.Min(Width, Height);
                if (Filled)
                {
                    g.FillEllipse(brush, X, Y, diameter, diameter);
                }
                g.DrawEllipse(pen, X, Y, diameter, diameter);
                break;
        }
    }

    public virtual bool ContainsPoint(PointF point)
    {
        bool containsPoint = false;

        switch (Type)
        {
            case ShapeType.Ellipse:
                RectangleF ellipseRect = new RectangleF(X, Y, Width, Height);
                var ellipsePath = new GraphicsPath();
                ellipsePath.AddEllipse(ellipseRect);
                containsPoint = new Region(ellipsePath).IsVisible(point);
                break;

            case ShapeType.Rectangle:
                RectangleF rectangleRect = new RectangleF(X, Y, Width, Height);
                containsPoint = rectangleRect.Contains(point);
                break;

            case ShapeType.Square:
                RectangleF squareRect = new RectangleF(X, Y, Math.Min(Width, Height), Math.Min(Width, Height));
                containsPoint = squareRect.Contains(point);
                break;

            case ShapeType.Line:
                // Use a "hit box" around the line
                RectangleF lineRect = new RectangleF(X, Y - StrokeThickness, Width, 2 * StrokeThickness);
                containsPoint = lineRect.Contains(point);
                break;

            case ShapeType.Freeform:
                if (Points != null && Points.Count > 0)
                {
                    var pointArray = Points.Select(p => new PointF(p.X, p.Y)).ToArray();
                    var freeformPath = new GraphicsPath();
                    freeformPath.AddLines(pointArray);
                    containsPoint = new Region(freeformPath).IsVisible(point);
                }
                break;

            case ShapeType.Circle:
                RectangleF circleRect = new RectangleF(X, Y, Math.Min(Width, Height), Math.Min(Width, Height));
                var circlePath = new GraphicsPath();
                circlePath.AddEllipse(circleRect);
                containsPoint = new Region(circlePath).IsVisible(point);
                break;
        }

        return containsPoint;
    }

}